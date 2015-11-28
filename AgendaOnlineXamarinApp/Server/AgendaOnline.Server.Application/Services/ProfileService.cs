using System;
using System.Collections.Generic;
using AgendaOnline.Server.Application.Contracts;
using AgendaOnline.Server.Application.DataTransferObjects.Requests;
using AgendaOnline.Server.Application.Seedwork;
using AgendaOnline.Server.Application.Services.Helpers;
using AgendaOnline.Server.Application.Sessions;
using AgendaOnline.Server.Domain.Seedwork;

namespace AgendaOnline.Server.Application.Services
{
    public class ProfileService : AppService
    {
        private readonly IFileStorage _fileStorage;
        private readonly ISessionManager _sessionManager;
        private readonly ProfileChangesNotificator _profileChangesNotificator;

        public ProfileService(
            IUnitOfWorkFactory unitOfWorkFactory,
            IFileStorage fileStorage,
            ISessionManager sessionManager,
            ProfileChangesNotificator profileChangesNotificator) 
            : base(unitOfWorkFactory)
        {
            _fileStorage = fileStorage;
            _sessionManager = sessionManager;
            _profileChangesNotificator = profileChangesNotificator;
        }

        public ChangePhotoResponse ChangePhoto(ISession session, ChangePhotoRequest request)
        {
            var response = request.CreateResponse<ChangePhotoResponse>();
            response.Success = true;
            int photoId = request.BuiltinPhotoId;
            if (!request.PhotoData.IsNullOrEmpty() && request.PhotoData.Length > 10)
            {
                try
                {
                    photoId = _fileStorage.AppendFile(request.PhotoData);
                }
                catch (Exception exc)
                {
                    photoId = 0;
                    response.Success = false;
                }
            }
            response.PhotoId = photoId;

            if (response.Success)
            {
                using (var uow = UnitOfWorkFactory.Create())
                {
                    uow.Attach(session.User);
                    session.User.ChangePhoto(photoId);

                    uow.Commit();
                }
                _profileChangesNotificator.NotifyEverybodyInChatAboutProfileChanges(session.User.Id, new Dictionary<string, object> { { "PhotoId", photoId } });
            }

            return response;
        }
    }
}
