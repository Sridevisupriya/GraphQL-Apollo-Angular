using StudentGraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGraphQL.Interfaces
{
    public interface IStudentService
    {
        public IEnumerable<Student> GetAllStudents();
        public IEnumerable<Student> GetStudentsByCourse(string course);
        public Student GetStudentsByEmail(string email);
        public Student AddStudent(Student student);
        public Student UpdateStudentDetails(string email, Student student);
        public void DeleteStudent(string id);
        Notice AddNotice(Notice noticeData);
        IEnumerable<Notice> GetAllNotices();
    }
}
