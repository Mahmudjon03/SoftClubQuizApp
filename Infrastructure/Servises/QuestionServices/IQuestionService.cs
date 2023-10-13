using Domain;

namespace Infrastructure.Servises.QuestionServices;

public interface IQuestionService
{
    Task<Response<List<GetQuestionDTO>>> GetQuestions();
    Task<Response<GetQuestionDTO>> GetQuestion(int id);
    Task<Response<string>> AddQuestion(AddQuestionDTO addQuestionDTO);
    Task<Response<string>> UpdateQuestion(UpdateQuestionDTO updateQuestionDTO);
    Task<Response<string>> DleteQuestion(int id);
}
