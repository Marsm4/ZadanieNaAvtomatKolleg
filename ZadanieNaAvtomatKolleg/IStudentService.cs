using System.Collections.Generic;

namespace ZadanieNaAvtomatKolleg.Interfaces
{
    public interface IStudentService
    {
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int studentId);
        Student GetStudentById(int studentId);
        IEnumerable<Student> GetAllStudents();
    }
}
