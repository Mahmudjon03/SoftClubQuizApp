﻿using AutoMapper;
using Domain;
using Domain.DTOs.GroupDto;
using Domain.GetFilter;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks.Dataflow;

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
        public async Task<Response<GetGroupDto>> AddMentorToGroup(AddStudentToGroupDto userGroup)

        {
            
            var mentor = await _context.Users.FindAsync(userGroup.UserId);

            if (mentor == null) return new Response<GetGroupDto>("Mentor Not found");

            if (mentor.UserType != UserType.Mentor)
            {
                return new Response<GetGroupDto>("Mentor Not found");
            }
            else
            {

                var AddMentor = _mapper.Map<UserGroup>(userGroup);

                await _context.UserGroups.AddAsync(AddMentor);

                await _context.SaveChangesAsync();

                return new Response<GetGroupDto>("Add Mentor to  Group");
            }

        }

        public async Task<Response<GetGroupDto>> AddStudentToGroup(AddStudentToGroupDto student)
        {
            var students =await _context.Users.FindAsync(student.UserId);
           
            if (students == null) return new Response<GetGroupDto>("User not found");

            students.UserType = UserType.Student;
            
            var addStudent = _mapper.Map<UserGroup>(student);
            
            await _context.UserGroups.AddAsync(addStudent);

            await _context.SaveChangesAsync();

            return new Response<GetGroupDto>($"Student Add to Group");
        }

        public async Task<Response<GetGroupDto>> Delete(int id)
        {
            var group =await _context.Groups.FindAsync(id);
           
            if (group == null) return new Response<GetGroupDto>(HttpStatusCode.NotFound, "Group Notfound");
            
            _context.Groups.Remove(group);  
            
            await _context.SaveChangesAsync();
            
            return new Response<GetGroupDto>(HttpStatusCode.Accepted, "Saccessfuly Delete Group");
        }

      

        public async Task<Response<GetGroupDto>> DeleteMentor(AddStudentToGroupDto model)
        {
            var deleteuser = await _context.UserGroups.FirstOrDefaultAsync(ug => ug.UserId == model.UserId && ug.GroupId == model.GroupId);

            if (deleteuser == null) return new Response<GetGroupDto>("Student Not Found");

            _context.UserGroups.Remove(deleteuser);

            await _context.SaveChangesAsync();

            return new Response<GetGroupDto>("Saccessfuly Delete Student");
        }




        public async Task<Response<GetGroupDto>> DeleteStudent(AddStudentToGroupDto model)
        {
            var deleteuser = await _context.UserGroups.FirstOrDefaultAsync(ug => ug.UserId == model.UserId && ug.GroupId==model.GroupId);

            if (deleteuser == null) return new Response<GetGroupDto>("Student Not Found");

            _context.UserGroups.Remove(deleteuser);

            await _context.SaveChangesAsync();

            return new Response<GetGroupDto>("Saccessfuly Delete Student");
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
                Students = _mapper.Map<List<GetUserDto>>(group.Users.Select(e => e.User)).Where(c=>c.Type=="Student").ToList(),
                Mentor =  _mapper.Map<List<GetUserDto>>(group.Users.Select(e => e.User)).Where(c => c.Type == "Mentor").ToList(),
                Test = group.Users.Select(x=>x.User).Where(x=>x.UserType==UserType.Mentor).SelectMany(x=>x.MentorTests).Select(x=>new GetTestDTO
                {
                    Id=x.Id,
                    Name=x.Name,
  }).ToList(),
                   



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
                Students=_mapper.Map<List<GetUserDto>>(g.Users.Select(e=>e.User).Where(u=>u.UserType==UserType.Student)).ToList(),
                }).ToListAsync();
            
            return new PoginationResponse<List<GetGroupDto>>(resGroup,filter.PageNumber,filter.PageSize,totalRecords);

         }

      public async  Task<PoginationResponse<List<GetGroupDto>>> GetMentor(GetFilter filter)
        {
            var group = _context.Groups.AsQueryable();

            if (filter.Name != null) group = group.Where(g => g.Name.Contains(filter.Name));

            var filterPage = new GetFilter(filter.PageNumber, filter.PageSize);

            var totalRecords = await group.CountAsync();

            var pagGroup = group.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize);


            var resGroup = await pagGroup.Select(g => new GetGroupDto()
            {
                Id = g.Id,
                Name = g.Name,
                CourseName = g.Course.Name,
                Students = _mapper.Map<List<GetUserDto>>(g.Users.Select(e => e.User).Where(s=>s.UserType==UserType.Mentor)).ToList(),
            }).ToListAsync();

            return new PoginationResponse<List<GetGroupDto>>(resGroup, filter.PageNumber, filter.PageSize, totalRecords);
        }

  public async Task<PoginationResponse<List<GetGroupDto>>> GetStudent(GetFilter filter)
        {
            var group = _context.Groups.AsQueryable();

            if (filter.Name != null) group = group.Where(g => g.Name.Contains(filter.Name));

            var filterPage = new GetFilter(filter.PageNumber, filter.PageSize);

            var totalRecords = await group.CountAsync();

            var pagGroup = group.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize);


            var resGroup = await pagGroup.Select(g => new GetGroupDto()
            {
                Id = g.Id,
                Name = g.Name,
                CourseName = g.Course.Name,
                Students = _mapper.Map<List<GetUserDto>>(g.Users.Select(e => e.User).Where(m=>m.UserType==UserType.Student)).ToList(),
            }).ToListAsync();

            return new PoginationResponse<List<GetGroupDto>>(resGroup, filter.PageNumber, filter.PageSize, totalRecords);
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
