using System;
using System.Collections.Generic;
using System.Linq;
using ZadanieNaAvtomatKolleg.Interfaces;

namespace ZadanieNaAvtomatKolleg.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            _context.Student.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            var existingStudent = _context.Student.Find(student.ID_Studenta);
            if (existingStudent != null)
            {
                existingStudent.Familia_St = student.Familia_St;
                existingStudent.Names_St = student.Names_St;
                existingStudent.Othestvo_St = student.Othestvo_St;
                existingStudent.Data_Rojdenia = student.Data_Rojdenia;
                existingStudent.Gorod_Rojdenia = student.Gorod_Rojdenia;
                existingStudent.LoginStudent = student.LoginStudent;
                existingStudent.PasswordStudent = student.PasswordStudent;
                _context.SaveChanges();
            }
        }

        public void DeleteStudent(int studentId)
        {
            var student = _context.Student.Find(studentId);
            if (student != null)
            {
                _context.Student.Remove(student);
                _context.SaveChanges();
            }
        }

        public Student GetStudentById(int studentId)
        {
            return _context.Student.Find(studentId);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Student.ToList();
        }
    }
}
