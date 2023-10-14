using AutoMapper;
using Domain;
using Infrastructure.Data;

namespace Infrastructure.Servises.AnswerServices;

public class AnswerService : IAnswerService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public AnswerService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<Response<string>> AddAnswer(AddAnswerDTO addAnswerDTO)
    {
        var mapped = _mapper.Map<Answer>(addAnswerDTO);
        await _dataContext.Answers.AddAsync(mapped);
        _dataContext.SaveChanges();

        return new Response<string>("Answer added!");
    }

    public async Task<Response<string>> DeleteAnswer(int id)
    {
        var answer = await _dataContext.Answers.FindAsync(id);
        if (answer == null) return new Response<string>("Data not found!");
        _dataContext.Answers.Remove(answer);
        _dataContext.SaveChanges();

        return new Response<string>("Answer delted!");
    }

    public async Task<Response<string>> UpdateAnswer(UpdateUnswerDTO updateUnswerDTO)
    {
        var answer = await _dataContext.Answers.FindAsync(updateUnswerDTO.Id);
        if (answer == null) return new Response<string>("Data not found!");
        var mapped = _mapper.Map<Answer>(answer);
        _dataContext.Answers.Remove(mapped);
        _dataContext.SaveChanges();
        return new Response<string>("Answer delted!");
    }

}
