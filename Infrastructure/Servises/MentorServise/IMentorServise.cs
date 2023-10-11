using Domain.DTOs.UserDto;
using Domain.GetFilter;
using Domain.Wapper;

namespace Infrastructure.Servises.MentorServise
{
    public interface IMentorServise
    {
        Task<PoginationResponse<GetUserDto>> GetMentor(GetFilter filter);
        Task<Response<GetUserDto>> AddMentor(int id);
        Task<Response<GetUserDto>>  DeleteMentor(int id);
    }
}
