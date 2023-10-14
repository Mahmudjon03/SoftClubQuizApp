using AutoMapper;
using Domain;
using Domain.GetFilter;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Web;

namespace Infrastructure.Servises.CourseServises;

public class CourseServise : ICourseServise
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IFileService _file;

    public CourseServise(DataContext context, IMapper mapper, IFileService file)
    {
        _context = context;
        _mapper = mapper;
        _file = file;
    }

    public async Task<Response<GetCourseDto>> AddCourse(AddCourseDto model)
    {
        string fileName = string.Empty;
        if (model.CourseFoto != null) fileName = await _file.AddFileAsync("Images", model.CourseFoto);
        var course = new Course()
        {
            Id = model.Id,
            Name = model.Name,
            CourseFoto = fileName
        };
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();
        var mapped = _mapper.Map<GetCourseDto>(course);
        return new Response<GetCourseDto>(mapped);
    }

    public async Task<Response<GetCourseDto>> DeleteCourse(int id)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course == null) return new Response<GetCourseDto>(HttpStatusCode.NotFound, "Course Not Found");

        if (course.CourseFoto != null) { await _file.DeleteFileAsync("Images", course.CourseFoto); }

        _context.Courses.Remove(course);

        await _context.SaveChangesAsync();

        return new Response<GetCourseDto>(HttpStatusCode.OK, "Successfuly Delete Course");

    }

    public async Task<PoginationResponse<List<GetCourseDto>>> GetCourse(GetFilter filter)
    {
        var course = _context.Courses.AsQueryable();

        if (filter.Name != null) course = course.Where(c => c.Name.Contains(filter.Name));

        var filtersPage = new GetFilter(filter.PageNumber, filter.PageSize);

        var totalRecords = await course.CountAsync();

        var paged = course.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize);

        var resCourse = await paged.Select(c => new GetCourseDto()
        {
            Id = c.Id,
            Name = c.Name,
            CourseFoto = c.CourseFoto,
            Group= _mapper.Map<List<GetGroupDto>>(c.Group).ToList(),
        }).ToListAsync();
        return new PoginationResponse<List<GetCourseDto>>(resCourse, filter.PageNumber, filter.PageSize, totalRecords);

    }

    public async Task<Response<GetCourseDto>> GetCourseById(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null) return new Response<GetCourseDto>(HttpStatusCode.NotFound, "Course Not Found");
        var resCourse = new GetCourseDto()
        {
            Id = course.Id,
            Name = course.Name,
            CourseFoto = course.CourseFoto,
        };
        return new Response<GetCourseDto>(resCourse);

    }

    public async Task<Response<GetCourseDto>> UpdateCourse(AddCourseDto model)
    {
        var course = await _context.Courses.FindAsync(model.Id);
        if (course == null) return new Response<GetCourseDto>(HttpStatusCode.NotFound, "Data not found!");
        if (model.CourseFoto != null)
        {
            if (course.CourseFoto != "") await _file.DeleteFileAsync("Images", course.CourseFoto);
            course.CourseFoto = await _file.AddFileAsync("images", model.CourseFoto);
        }
        course.Id = model.Id;
        course.Name = model.Name;
        await _context.SaveChangesAsync();
        var mapped = _mapper.Map<GetCourseDto>(course);
        return new Response<GetCourseDto>(mapped);
    }
}

