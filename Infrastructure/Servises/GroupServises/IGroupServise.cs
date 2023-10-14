using Domain;
using Domain.DTOs.GroupDto;
using Domain.GetFilter;

namespace Infrastructure.Servises.GroupServises
{
    public interface IGroupServise
    {
        Task<PoginationResponse<List<GetGroupDto>>> GetGroup(GetFilter filter);
        Task<Response<GetGroupDto>> GetById(int id);
        Task<Response<GetGroupDto>> Delete(int id);
        Task<Response<GetGroupDto>>  Update(AddGroupDto group);
        Task<Response<GetGroupDto>> AddGroup(AddGroupDto group);
      
        Task<PoginationResponse<List<GetGroupDto>>> GetMentor(GetFilter filter);
        Task<PoginationResponse<List<GetGroupDto>>> GetStudent(GetFilter filter);


    }

}
