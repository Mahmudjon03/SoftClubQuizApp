
using Domain.DTOs.GroupDto;
using Domain.GetFilter;
using Domain.Wapper;

namespace Infrastructure.Servises.GroupServises
{
    public interface IGroupServise
    {
        Task<PoginationResponse<List<GetGroupDto>>> GetGroup(GetFilter filter);
        Task<Response<GetGroupDto>> GetById(int id);
        Task<Response<GetGroupDto>> Delete(int id);
        Task<Response<GetGroupDto>>  Update(AddGroupDto group);
        Task<Response<GetGroupDto>> AddGroup(AddGroupDto group);

    }

}
