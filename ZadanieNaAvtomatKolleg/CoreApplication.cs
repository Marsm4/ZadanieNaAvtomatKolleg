using System;
using System.Collections.Generic;
using ZadanieNaAvtomatKolleg.Interfaces;
using ZadanieNaAvtomatKolleg.Services;

namespace ZadanieNaAvtomatKolleg.Core
{
    public class CoreApplication
    {
        private readonly IStudentService _studentService;

        public CoreApplication(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void AddStudent(Student student)
        {
            _studentService.AddStudent(student);
        }

        public void UpdateStudent(Student student)
        {
            _studentService.UpdateStudent(student);
        }

        public void DeleteStudent(int studentId)
        {
            _studentService.DeleteStudent(studentId);
        }

        public Student GetStudent(int studentId)
        {
            return _studentService.GetStudentById(studentId);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentService.GetAllStudents();
        }
    }
}
