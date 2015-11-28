using System.Linq;
using AgendaOnline.Server.Application.Contracts;
using AgendaOnline.Server.Application.DataTransferObjects.Enums;
using AgendaOnline.Server.Application.DataTransferObjects.Messages;
using AgendaOnline.Server.Application.DataTransferObjects.Requests;
using AgendaOnline.Server.Application.Seedwork;
using AgendaOnline.Server.Application.Sessions;
using AgendaOnline.Server.Domain.Entities;
using AgendaOnline.Server.Domain.Seedwork;

namespace AgendaOnline.Server.Application.Services
{
    public class AuthenticationService : AppService
    {
        private readonly ISettings _settings;

        public AuthenticationService(
            ISettings settings,
            IUnitOfWorkFactory unitOfWorkFactory)
            : base(unitOfWorkFactory)
        {
            _settings = settings;
        }

        public AuthenticationResponse Authenticate(ISession session, AuthenticationRequest request)
        {
            var response = request.CreateResponse<AuthenticationResponse>();
            
            response.Result = AuthenticationResponseType.Success;

            using (var uow = UnitOfWorkFactory.Create())
            {
                var user = uow.UsersRepository.FirstMatching(UserSpecification.NameAndPassword(request.Name, request.Password));
                if (user == null)
                {
                    response.Result = AuthenticationResponseType.InvalidNameOrPassword;
                    return response;
                }
                else
                {
                    if (user.IsBanned)
                    {
                    }
                    else if (user.Huid != request.Huid)
                    {
                        user.ChangeHuid(request.Huid);
                    }
                }
                
                uow.Commit();
                
                if (response.Result == AuthenticationResponseType.Success)
                {
                    Enumerable.Count(user.Friends);
                    session.SetUser(user);
                    response.User = user.ProjectedAs<UserDto>();
                }
            }
            return response;
        }
    }
}
