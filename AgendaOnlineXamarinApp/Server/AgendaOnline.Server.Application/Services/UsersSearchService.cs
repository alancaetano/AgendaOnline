using System.Linq;
using AgendaOnline.Server.Application.DataTransferObjects.Messages;
using AgendaOnline.Server.Application.DataTransferObjects.Requests;
using AgendaOnline.Server.Application.Seedwork;
using AgendaOnline.Server.Application.Sessions;
using AgendaOnline.Server.Domain.Entities;
using AgendaOnline.Server.Domain.Seedwork;
using AgendaOnline.Server.Domain.Seedwork.Specifications;

namespace AgendaOnline.Server.Application.Services
{
    public class UsersSearchService : AppService
    {
        public UsersSearchService(IUnitOfWorkFactory unitOfWorkFactory) 
            : base(unitOfWorkFactory)
        {
        }

        public UsersSearchResponse SearchUser(ISession session, UsersSearchRequest request)
        {
            var response = request.CreateResponse<UsersSearchResponse>();

            using (var uow = UnitOfWorkFactory.Create())
            {
                var users = uow.UsersRepository.AllMatching(UserSpecification.NameLike(request.QueryString), 20);
                var userDtos = users.ProjectedAsCollection<UserDto>();
                
                response.Result = userDtos.ToArray();
            }
            return response;
        }

        public GetUserDetailsResponse GetUserDetails(ISession session, GetUserDetailsRequest request)
        {
            var response = request.CreateResponse<GetUserDetailsResponse>();
            using (var uow = UnitOfWorkFactory.Create())
            {
                Specification<User> spec = null;
                if (request.UserId != 0)
                {
                    spec = UserSpecification.Id(request.UserId);
                }
                else if (!string.IsNullOrEmpty(request.Name))
                {
                    spec = UserSpecification.Name(request.Name);
                }
                else
                {
                    return response; //invalid request
                }
                
                var user = uow.UsersRepository.FirstMatching(spec);
                if (user != null)
                {
                    response.User = user.ProjectedAs<UserDto>();
                    response.IsFriend = session.User.Friends.Any(p => p.Id == user.Id);
                    
                    uow.Attach(session.User);
                }
            }
            return response;
        }
    }
}
