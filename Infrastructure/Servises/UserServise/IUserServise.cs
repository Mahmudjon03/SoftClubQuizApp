using Domain;
using Domain.GetFilter;

namespace Infrastructure.Servises.UserServise
{
    public interface IUserServise
    {
        Task<PoginationResponse<List<GetUserDto>>> GetUser(GetFilter filter);
        Task<Response<GetUserDto>> AddUser(AddUserDto user);
        Task<Response<GetUserDto>> UpdateUser(AddUserDto user);
        Task<Response<GetUserDto>> DeleteUser(int id);
        Task<Response<GetUserDto>> GetUserById(int id);
      
    }
}
