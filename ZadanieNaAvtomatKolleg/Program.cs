using System;
using Unity;
using ZadanieNaAvtomatKolleg.Core;
using ZadanieNaAvtomatKolleg.Services;
using ZadanieNaAvtomatKolleg.Interfaces;
using System.Data.Entity.Core.Metadata.Edm;

namespace ZadanieNaAvtomatKolleg
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            // Регистрируем сервисы
            container.RegisterType<IStudentService, StudentService>();

            // Регистрируем ядро
            container.RegisterType<CoreApplication>();

            var coreApp = container.Resolve<CoreApplication>();

            // Пример работы с ядром
            var newStudent = new Student { Familia_St = "Иванов", Names_St = "Иван", Othestvo_St = "Иванович" };
            coreApp.AddStudent(newStudent);

            Console.WriteLine("Студент добавлен!");
        }
    }
}
