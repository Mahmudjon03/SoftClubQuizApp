using Domain;

namespace Infrastructure.Servises.AnswerServices;

public interface IAnswerService
{
    Task<Response<string>> AddAnswer(AddAnswerDTO addAnswerDTO);
    Task<Response<string>> UpdateAnswer(UpdateUnswerDTO updateUnswerDTO);
    Task<Response<string>> DleteAnswer(int id);
}
