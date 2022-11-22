using StudentGraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentGraphQL.Interfaces
{
    public interface IStudentRepo
    {
        IEnumerable<Student> GetAllStudents();
        IEnumerable<Notice> GetAllNotices();
        IEnumerable<Student> GetStudentsByCourse(string course);
        Student GetStudentsByEmail(string email);
        Student AddStudent(Student student);
        Notice AddNotice(Notice noticeData);
        Student UpdateStudentDetails(string email, Student student);
        void DeleteStudent(string id);
    }
}
