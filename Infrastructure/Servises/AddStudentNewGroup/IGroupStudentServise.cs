
using Domain.DTOs.GroupDto;
using Domain;

namespace Infrastructure.Servises.AddStudentNewGroup
{
    public interface IGroupStudentServise
    {
        Task<Response<GetGroupDto>> AddStudentToGroup(AddStudentToGroupDto student);
        Task<Response<GetGroupDto>> AddMentorToGroup(AddStudentToGroupDto userGroup);
        Task<Response<GetGroupDto>> DeleteStudent(AddStudentToGroupDto model);
        Task<Response<GetGroupDto>> DeleteMentor(AddStudentToGroupDto model);
        Task<Response<GetGroupDto>> TransferStudentToNewGroup(TransferStudentNewGroup model);


    }
}
