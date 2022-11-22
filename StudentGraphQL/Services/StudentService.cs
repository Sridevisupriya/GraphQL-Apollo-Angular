using StudentGraphQL.Interfaces;
using StudentGraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGraphQL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _studentRepo;
        public StudentService(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public Notice AddNotice(Notice noticeData)
        {
            return _studentRepo.AddNotice(noticeData);
        }

        public IEnumerable<Notice> GetAllNotices()
        {
            return _studentRepo.GetAllNotices();
        }

        Student IStudentService.AddStudent(Student student)
        {
            return _studentRepo.AddStudent(student);
        }

        void IStudentService.DeleteStudent(string id)
        {
            _studentRepo.DeleteStudent(id);
        }

        IEnumerable<Student> IStudentService.GetAllStudents()
        {
            return _studentRepo.GetAllStudents();
        }

        IEnumerable<Student> IStudentService.GetStudentsByCourse(string course)
        {
            return _studentRepo.GetStudentsByCourse(course);
        }

        Student IStudentService.GetStudentsByEmail(string email)
        {
            return _studentRepo.GetStudentsByEmail(email);
        }

        Student IStudentService.UpdateStudentDetails(string email, Student student)
        {
            return _studentRepo.UpdateStudentDetails(email, student);
        }
    }
}
