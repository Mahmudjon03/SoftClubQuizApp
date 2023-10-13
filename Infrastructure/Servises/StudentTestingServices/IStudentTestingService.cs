using Domain;
using Domain.Wapper;

namespace Infrastructure.Servises.StudentTestingServices;

public interface IStudentTestingService
{
    Task<Response<AddStudentTestDto>> AddStudentTest(AddStudentTestDto model);
}
