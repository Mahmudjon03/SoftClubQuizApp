using AutoMapper;
using Domain;
using Domain.DTOs.GroupDto;
using Domain.GetFilter;
using Domain.Wapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure.Servises.GroupServises
{
    public class GroupServise : IGroupServise
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GroupServise(DataContext context,IMapper mapper)
        {
             _context = context;
              _mapper = mapper;
        }
        public async Task<Response<GetGroupDto>> AddGroup(AddGroupDto model)
        {
            // var group = _mapper.Map<Domain.Entities.Group>(model);

            var group = new Group()
            {
                Name = model.Name,
                CourseId= model.CourseId,
            };
            await  _context.Groups.AddAsync(group);
            
            await _context.SaveChangesAsync();

            return new Response<GetGroupDto>(HttpStatusCode.OK, "Group added!");
        }

        public async Task<Response<GetGroupDto>> Delete(int id)
        {
            var group =await _context.Groups.FindAsync(id);
           
            if (group == null) return new Response<GetGroupDto>(HttpStatusCode.NotFound, "Group Notfound");
            
            _context.Groups.Remove(group);  
            
            await _context.SaveChangesAsync();
            
            return new Response<GetGroupDto>(HttpStatusCode.Accepted, "Saccessfuly Delete Group");
        }

        public async Task<Response<GetGroupDto>> GetById(int id)
        {
            var group = await _context.Groups.Include(x => x.Course)
                .FirstOrDefaultAsync(x => x.Id == id);
            
            if (group == null) return new Response<GetGroupDto>(HttpStatusCode.NotFound ,"Group Not found");
            
            var resGroup= new GetGroupDto()
            {
                Id = id,
                Name = group.Name ,
                CourseName = group.Course.Name,
            };
            
            return new Response<GetGroupDto>(resGroup);
        }

        public async Task<PoginationResponse<List<GetGroupDto>>> GetGroup(GetFilter filter)
        {
           var group=_context.Groups.AsQueryable();
           
            if (filter.Name != null) group=group.Where(g=>g.Name.Contains(filter.Name));
            
            var filterPage = new GetFilter(filter.PageNumber,filter.PageSize);
            
            var totalRecords = await group.CountAsync();

            var pagGroup= group.Skip((filter.PageNumber-1)*filter.PageSize).Take(filter.PageSize);

            var resGroup =await pagGroup.Select(g => new GetGroupDto()
            {
                Id = g.Id,
                Name = g.Name,
                CourseName = g.Course.Name,
            }).ToListAsync();
            
            return new PoginationResponse<List<GetGroupDto>>(resGroup,filter.PageNumber,filter.PageSize,totalRecords);

        }

        public async Task<Response<GetGroupDto>> Update(AddGroupDto model)
        {
            var group = await _context.Groups.FindAsync(model.Id);
           
            if (group == null) return new Response<GetGroupDto>(HttpStatusCode.NotFound);

            group.Name = model.Name;

            await   _context.SaveChangesAsync();
           
            return new Response<GetGroupDto>(HttpStatusCode.Accepted,"Saccessfuly Update Group");
        }
    }
}
