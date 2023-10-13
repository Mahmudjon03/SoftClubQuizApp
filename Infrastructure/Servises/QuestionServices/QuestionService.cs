using System.Net;
using AutoMapper;
using Domain;
using Domain.DTOs.AnswerDTOs;
using Domain.DTOs.QuestionDTOs;
using Domain.Wapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Servises.QuestionServices;

public class QuestionService : IQuestionService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public QuestionService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<Response<string>> AddQuestion(AddQuestionDTO addQuestionDTO)
    {
        var mapped = _mapper.Map<Question>(addQuestionDTO);
        await _dataContext.Questions.AddAsync(mapped);
        await _dataContext.SaveChangesAsync();
        return new Response<string>("Question added!");
    }

    public async Task<Response<string>> DleteQuestion(int id)
    {
        var question = await _dataContext.Questions.FindAsync(id);
        if (question == null) return new Response<string>("Data not found!");
        _dataContext.Questions.Remove(question);
        await _dataContext.SaveChangesAsync();
        return new Response<string>("Question deleted!");
    }

    public async Task<Response<GetQuestionDTO>> GetQuestion(int id)
    {
        var question = await _dataContext.Questions.FindAsync(id);
        if (question == null) return new Response<GetQuestionDTO>(HttpStatusCode.NotFound, "Data not found!");
        var mapped = new GetQuestionDTO()
        {
            Id = question.Id,
            Title = question.Title,
            Answers = question.Answers.Select(a=> new GetAnswerDTO()
            {
                Id = a.Id,
                Name = a.Name,
                Status = a.IsCorrect,
                QuestionId = a.QuestionId
            }).ToList()
        };
        return new Response<GetQuestionDTO>(mapped);
    }

    public async Task<Response<List<GetQuestionDTO>>> GetQuestions()
    {
        var questions = await _dataContext.Questions.Select(q=> new GetQuestionDTO()
        {
            Id = q.Id,
            Title = q.Title,
            Answers = q.Answers.Select(a=> new GetAnswerDTO()
            {
                Id = a.Id,
                Name = a.Name,
                Status = a.IsCorrect,
                QuestionId = a.QuestionId
            }).ToList()
        }).ToListAsync();

        return new Response<List<GetQuestionDTO>>(questions);
    }

    public async Task<Response<string>> UpdateQuestion(UpdateQuestionDTO updateQuestionDTO)
    {
        var question = await _dataContext.Questions.FindAsync(updateQuestionDTO.Id);
        if (question == null) return new Response<string>("Data not found!");
        var mapped = _mapper.Map<Question>(question);
        _dataContext.Questions.Update(mapped);
        await _dataContext.SaveChangesAsync();
        
        return new Response<string>("Question updated!");
    }

}
