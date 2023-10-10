
using AutoMapper;
using Domain.DTOs.CourseDto;
using Domain.Wapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Servises.CourseServises
{
    public class CourseServise:ICourseServise
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CourseServise(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        
            
        

        public Task<Response<GetCourseDto>> AddCourse(AddCourseDto user)
        {
            throw new NotImplementedException();
        }

        public Task<Response<GetCourseDto>> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<GetCourseDto>>> GetCourse()
        {
            throw new NotImplementedException();
        }

        public Task<Response<GetCourseDto>> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<GetCourseDto>> UpdateUser(AddCourseDto user)
        {
            throw new NotImplementedException();
        }
    }
}
