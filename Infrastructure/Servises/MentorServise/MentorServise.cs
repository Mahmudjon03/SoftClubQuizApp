using AutoMapper;
using Domain;
using Domain.GetFilter;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Servises.MentorServise
{
    public class MentorServise:IMentorServise
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MentorServise(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public async Task<Response<GetUserDto>> AddMentor(int id)
        {
            var mentor =await _context.Users.FindAsync(id);
           
            if (mentor == null) return new Response<GetUserDto>("User Not Found");
            
            mentor.UserType = UserType.Mentor;
          
            await  _context.SaveChangesAsync();
            
            return  new Response<GetUserDto>("Seccessfuly Add Mentor");
         }

       public async  Task<Response<GetUserDto>> DeleteMentor(int id)
        {
            var mentor = await _context.Users.FindAsync(id);

            if (mentor == null) return new Response<GetUserDto>("User Not Found");
           
            if (mentor.UserType != UserType.Mentor) return new Response<GetUserDto>("User Not Found");

            mentor.UserType = UserType.User;

            await _context.SaveChangesAsync();

            return new Response<GetUserDto>("Seccessfuly Delete Mentor");


        }
            

        

        public async Task<PoginationResponse<List<GetUserDto>>> GetMentor(GetFilter filter)
        {
            var  mentor= _context.Users.AsQueryable();

            var users = await mentor.Select(c => c).Where(c => c.UserType == UserType.Mentor).ToListAsync();


            if (filter.Name != null) users = users.Where(c => (c.FirstName).ToLower().Contains((filter.Name).ToLower())).ToList();

            var filtersPage = new GetFilter(filter.PageNumber, filter.PageSize);

            var totalRecords = users.Count();

            var pogRes = users.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize);


            var resUser = _mapper.Map<List<GetUserDto>>(pogRes);

           return new PoginationResponse<List<GetUserDto>>(resUser, filter.PageNumber, filter.PageSize, totalRecords);
        }

       
    }

}
