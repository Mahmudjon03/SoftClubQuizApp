using Domain;


namespace Infrastructure.Servises.TestServices;

public interface ITestService
{
    Task<Response<List<GetTestDTO>>> GetTests();
    Task<Response<GetTestDTO>> GetTest(int id);
    Task<Response<string>> AddTest(AddTestDTO addTestDTO);
    Task<Response<string>> UpdateTest(UpdateTestDTO updateTestDTO);
    Task<Response<string>> DeleteTest(int id);
}
