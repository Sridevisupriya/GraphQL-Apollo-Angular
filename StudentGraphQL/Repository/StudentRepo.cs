using StudentGraphQL.Interfaces;
using StudentGraphQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace StudentGraphQL.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentRepo(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;

        }

        Notice IStudentRepo.AddNotice(Notice noticeData)
        {
            noticeData.date = DateTime.Now;
            _studentDbContext.Notices.Add(noticeData);
            _studentDbContext.SaveChanges();
            return noticeData;
        }

        Student IStudentRepo.AddStudent(Student student)
        {
            var studentExists = _studentDbContext.Students.FirstOrDefault(x => x.Email == student.Email);
            if (studentExists == null)
            {
                student.YearOfJoining = DateTime.Now.Year;
                _studentDbContext.Add(student);
                _studentDbContext.SaveChanges();
                return student;
            }
            else
            {
                return null;
            }
        }

        void IStudentRepo.DeleteStudent(string id)
        {
            var student = _studentDbContext.Students.FirstOrDefault(x => x.Email == id);
            _studentDbContext.Remove(student);
            _studentDbContext.SaveChanges();
        }

        IEnumerable<Notice> IStudentRepo.GetAllNotices()
        {
            var notices = _studentDbContext.Notices.ToList();
            notices.Reverse();
            return notices;
        }

        IEnumerable<Student> IStudentRepo.GetAllStudents()
        {
            var students = _studentDbContext.Students.ToList();
            return students;
        }

        IEnumerable<Student> IStudentRepo.GetStudentsByCourse(string course)
        {
            var students = _studentDbContext.Students.Where(x => x.Course == course).ToList();
            return students;
        }

        Student IStudentRepo.GetStudentsByEmail(string email)
        {
            var student = _studentDbContext.Students.FirstOrDefault(x => x.Email == email);
            return student;
        }

        Student IStudentRepo.UpdateStudentDetails(string email, Student student)
        {
            var candidate = _studentDbContext.Students.FirstOrDefault(x => x.Email == email);
            if (candidate == null)
            {
                return null;
            }
            else
            {
                candidate.Name = student.Name;
                candidate.Mobile = student.Mobile;
                candidate.Address = student.Address;
                candidate.Course = student.Course;
                candidate.Email = student.Email;
                candidate.Gender = student.Gender;
                candidate.Dateofbirth = student.Dateofbirth;
                _studentDbContext.Update(candidate);
                _studentDbContext.SaveChanges();
                var updatedStudent = _studentDbContext.Students.FirstOrDefault(x => x.Email == email);
                return updatedStudent;
            }
        }

    }
}
