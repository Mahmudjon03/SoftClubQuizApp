using Domain;
using Domain.GetFilter;


namespace Infrastructure.Servises.MentorServise
{
    public interface IMentorServise
    {
        Task<PoginationResponse<List<GetUserDto>>> GetMentor(GetFilter filter);
        Task<Response<GetUserDto>> AddMentor(int id);
        Task<Response<GetUserDto>>  DeleteMentor(int id);
    }
}
