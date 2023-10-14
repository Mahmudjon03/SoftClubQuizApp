using AutoMapper;
using Domain;
using Domain.DTOs.TestDTOs;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Servises.TestServices;

public class TestService : ITestService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;

    public TestService(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }

    public async Task<Response<string>> AddTest(AddTestDTO addTestDTO)
    {
        var mapped = _mapper.Map<Test>(addTestDTO);
        await _dataContext.Tests.AddAsync(mapped);
        await _dataContext.SaveChangesAsync();
        return new Response<string>("Test added!");
    }

    public async Task<Response<string>> DeleteTest(int id)
    {
        var test = await _dataContext.Tests.FindAsync(id);
        if (test == null) return new Response<string>("Data not found!");

        _dataContext.Tests.Remove(test);
        await _dataContext.SaveChangesAsync();

        return new Response<string>("Test deleted!");
    }

    public async Task<Response<GetTestDTO>> GetTest(int id)
    {
        var test = await _dataContext.Tests.FindAsync(id);
        // if (test == null) return new  Response<GetTestDTO>("Data not found!");
        var mapped = new GetTestDTO()
        {
            Id = test.Id,
            Name = test.Name,
            Questions = await _dataContext.Questions.Where(q=> q.TestId == test.Id).Select(q=> new GetQuestionDTO()
            {
                Id = q.Id,
                Title = q.Title
            }).ToListAsync()
        };
        return new Response<GetTestDTO>(mapped);
    }

    public async Task<Response<List<GetTestDTO>>> GetTests()
    {
        var tests = await _dataContext.Tests.Select(t=>new GetTestDTO()
        {
            Id = t.Id,
            Name = t.Name,
            Questions = t.Questions.Where(q=> q.TestId == t.Id).Select(q=> new GetQuestionDTO()
            {
                Id = q.Id,
                Title = q.Title
            }).ToList()
        }).ToListAsync();

        return new Response<List<GetTestDTO>>(tests);
    }

    public async Task<Response<string>> UpdateTest(UpdateTestDTO updateTestDTO)
    {
        var test = await _dataContext.Tests.FindAsync(updateTestDTO.Id);
        if (test == null) return new Response<string>("Data not found!");
        var mapped = _mapper.Map<Test>(test);
        _dataContext.Tests.Update(mapped);
        _dataContext.SaveChanges();
        return new Response<string>("Test updated!");
    }

}
