using Domain;


namespace Infrastructure.Servises.StudentTestingServices;

public interface IStudentTestingService
{
    Task<Response<AddStudentTestDto>> AddStudentTest(AddStudentTestDto model);
    Task<Response<GetExamTestsForUserDto>> GetExamTestsForStudent(int studentId);
}
