

using Domain.DTOs.UserDto;
using Domain.Enums;
using Domain.GetFilter;
using Domain.Wapper;
using Infrastructure.Data;

namespace Infrastructure.Servises.MentorServise
{
    public class MentorServise:IMentorServise
    {
        private readonly DataContext _context;

        public MentorServise(DataContext context)
        {
            _context = context;
        }

        public async Task<Response<GetUserDto>> AddMentor(int id)
        {

            throw new NotImplementedException();

        }

        public Task<Response<GetUserDto>> DeleteMentor(int id)
        {
            throw new NotImplementedException();

        }

        public Task<PoginationResponse<GetUserDto>> GetMentor(GetFilter filter)
        {
            throw new NotImplementedException();
        }
    }

}
