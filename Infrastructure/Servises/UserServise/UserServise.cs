using AutoMapper;
using Domain.DTOs.UserDto;
using Domain.Entities;
using Domain.GetFilter;
using Domain.Wapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Servises.UserServise;

public class UserServise : IUserServise
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserServise(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<GetUserDto>> AddUser(AddUserDto user)
    {
        var mapUser = _mapper.Map<User>(user);
        await _context.Users.AddAsync(mapUser);
        await _context.SaveChangesAsync();
        var response = _mapper.Map<GetUserDto>(user);

        return new Response<GetUserDto>(response);

    }

  

    public async Task<Response<GetUserDto>> DeleteUser(int id)
    {
        var Delete =await _context.Users.FindAsync(id);
        if (Delete != null) return new Response<GetUserDto>("User Not Found");
    var resUser= _mapper.Map<GetUserDto>(Delete);
         _context.Users.Remove(Delete);
         await _context.SaveChangesAsync();
        return new Response<GetUserDto>(resUser);
    }

    public async Task<PoginationResponse<List<GetUserDto>>> GetUser(GetFilter filter)
    {
        var users = _context.Users.AsQueryable();

        if (filter.Name != null) users = users.Where(c => c.FirstName.Contains(filter.Name));

        var filtersPage = new GetFilter(filter.PageNumber, filter.PageSize);

        var totalRecords = await users.CountAsync();

        var pogRes = users.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize);

        var resUser = _mapper.Map<List<GetUserDto>>(pogRes);
       
        return new PoginationResponse<List<GetUserDto>>(resUser, filter.PageNumber, filter.PageSize, totalRecords);

    }

    public async Task<Response<GetUserDto>> GetUserById(int id)
    {
        var users = await _context.Users.FindAsync(id);
        if (users != null) return new Response<GetUserDto>("User Not Found");
        var resUser=_mapper.Map<GetUserDto>(users);
        return new Response<GetUserDto>(resUser);

    }

    public async Task<Response<GetUserDto>> UpdateUser(AddUserDto user)
    {
        var _user = await _context.Users.FindAsync(user.Id);
        if (_user != null) return new Response<GetUserDto>("User Not Found");
        _user = _mapper.Map<User>(user);
        var resUser=_mapper.Map<GetUserDto>(user);
        return new Response<GetUserDto>(resUser);   
    }


}
