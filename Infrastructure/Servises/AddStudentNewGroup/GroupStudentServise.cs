using AutoMapper;
using Domain;
using Domain.DTOs.GroupDto;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Servises.AddStudentNewGroup
{
    public class GroupStudentServise : IGroupStudentServise
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GroupStudentServise(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
                mentor.Active = Status.Active;
                var AddMentor = _mapper.Map<UserGroup>(userGroup);

                await _context.UserGroups.AddAsync(AddMentor);

                await _context.SaveChangesAsync();

                return new Response<GetGroupDto>("Add Mentor to  Group");
            }

        }

        public async Task<Response<GetGroupDto>> AddStudentToGroup(AddStudentToGroupDto student)
        {
            var students = await _context.Users.FindAsync(student.UserId);

            if (students == null) return new Response<GetGroupDto>("User not found");

            students.UserType = UserType.Student;
            students.Active = Status.Active;    

            var addStudent = _mapper.Map<UserGroup>(student);

            await _context.UserGroups.AddAsync(addStudent);

            await _context.SaveChangesAsync();

            return new Response<GetGroupDto>($"Student Add to Group");
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
            var deleteuser = await _context.UserGroups.FirstOrDefaultAsync(ug => ug.UserId == model.UserId && ug.GroupId == model.GroupId);

            if (deleteuser == null) return new Response<GetGroupDto>("Student Not Found");

            _context.UserGroups.Remove(deleteuser); var students = await _context.Users.FindAsync(model.UserId);

            if (students == null) return new Response<GetGroupDto>("User not found");

            students.UserType = UserType.User;

            await _context.SaveChangesAsync();

            return new Response<GetGroupDto>("Saccessfuly Delete Student");
        }

        public async Task<Response<GetGroupDto>> TransferStudentToNewGroup(TransferStudentNewGroup student)
        {


            var userGroup = await _context.UserGroups.FirstOrDefaultAsync(ug => ug.UserId == student.UserId && ug.GroupId == student.oldGroupId);

            if (userGroup == null) return new Response<GetGroupDto>("Student Not Found");


                       _context.UserGroups.Remove(userGroup);

            var newStunetGroup = new UserGroup
            {
                UserId = student.UserId,
                GroupId = student.GroupId,
            };
            await _context.UserGroups.AddAsync(newStunetGroup);

            await _context.SaveChangesAsync();

            return new Response<GetGroupDto>($"Student Transfer to new Group");
        }
    }
}
