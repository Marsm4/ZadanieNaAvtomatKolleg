using System.Collections.Generic;
using ZadanieNaAvtomatKolleg.Interfaces;

namespace ZadanieNaAvtomatKolleg.Core
{
    public class CoreApplication
    {
        private readonly IStudentService _studentService;
        private readonly IPrepodovatelService _prepodovatelService;
        private readonly IZavOtdeleniaService _zavOtdeleniaService;
        private readonly RaspisanieService _raspisanieService;
        private readonly EkzamensService _ekzamensService;
        private readonly INagruzkaService _nagruzkaService; // Добавлено поле для INagruzkaService

        // Единый конструктор для всех зависимостей
        public CoreApplication(
            IStudentService studentService,
            IPrepodovatelService prepodovatelService,
            IZavOtdeleniaService zavOtdeleniaService,
            RaspisanieService raspisanieService,
            EkzamensService ekzamensService,
            INagruzkaService nagruzkaService) // Добавлен INagruzkaService
        {
            _studentService = studentService;
            _prepodovatelService = prepodovatelService;
            _zavOtdeleniaService = zavOtdeleniaService;
            _raspisanieService = raspisanieService;
            _ekzamensService = ekzamensService;
            _nagruzkaService = nagruzkaService; // Инициализация INagruzkaService
        }

        // Методы для работы с экзаменами
        public IEnumerable<Ekzamens> GetAllEkzamens()
        {
            return _ekzamensService.GetAll();
        }

        public Ekzamens GetEkzamenById(int id)
        {
            return _ekzamensService.GetById(id);
        }

        public void AddEkzamen(Ekzamens ekzamens)
        {
            _ekzamensService.Add(ekzamens);
        }

        public void UpdateEkzamen(Ekzamens ekzamens)
        {
            _ekzamensService.Update(ekzamens);
        }

        public void DeleteEkzamen(int id)
        {
            _ekzamensService.Delete(id);
        }

        // Методы для работы со студентами
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

        // Методы для работы с расписанием
        public IEnumerable<Raspisanie> GetAllRaspisanie()
        {
            return _raspisanieService.GetAll();
        }

        // Методы для работы с преподавателями
        public IEnumerable<Prepodovatel> GetAllPrepodovatel()
        {
            return _prepodovatelService.GetAll();
        }

        // Методы для работы с заведующими отделениями
        public IEnumerable<Zav_Otdelenia> GetAllZavOtdelenia()
        {
            return _zavOtdeleniaService.GetAll();
        }

        public Zav_Otdelenia GetZavOtdeleniaById(int id)
        {
            return _zavOtdeleniaService.GetById(id);
        }

        public void AddZavOtdelenia(Zav_Otdelenia zavOtdelenia)
        {
            _zavOtdeleniaService.Add(zavOtdelenia);
        }

        public void UpdateZavOtdelenia(Zav_Otdelenia zavOtdelenia)
        {
            _zavOtdeleniaService.Update(zavOtdelenia);
        }

        public void DeleteZavOtdelenia(int id)
        {
            _zavOtdeleniaService.Delete(id);
        }

        // Метод для работы с нагрузкой
        public IEnumerable<Nagruzka> GetAllNagruzka()
        {
            return _nagruzkaService.GetAll(); // Используется инициализированный сервис
        }
    }
}