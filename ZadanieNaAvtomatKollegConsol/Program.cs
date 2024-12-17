using System;
using System.Linq;
using Unity;
using ZadanieNaAvtomatKolleg.Core;
using ZadanieNaAvtomatKolleg.Interfaces;
using ZadanieNaAvtomatKolleg.Services;

namespace ZadanieNaAvtomatKolleg.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();

            // Регистрируем сервисы
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IPrepodovatelService, PrepodovatelService>();
            container.RegisterType<IZavOtdeleniaService, ZavOtdeleniaService>();
            container.RegisterType<IRaspisanieService, RaspisanieService>();
            container.RegisterType<IEkzamensService, EkzamensService>();
            container.RegisterType<INagruzkaService, NagruzkaService>();
            // Регистрируем ядро
            container.RegisterType<CoreApplication>();

            var coreApp = container.Resolve<CoreApplication>();

            Console.WriteLine("Добро пожаловать в систему колледжа!");
            Console.WriteLine("Выберите роль для входа:");
            Console.WriteLine("1. Студент");
            Console.WriteLine("2. Преподаватель");
            Console.WriteLine("3. Заведующий отделением");

            int roleChoice = int.Parse(Console.ReadLine());

            switch (roleChoice)
            {
                case 1:
                    StudentMenu(coreApp);
                    break;
                case 2:
                    PrepodovatelMenu(coreApp);
                    break;
                case 3:
                    ZavOtdeleniaMenu(coreApp);
                    break;
                default:
                    Console.WriteLine("Неверный выбор роли.");
                    break;
            }
        }

        static void StudentMenu(CoreApplication coreApp)
        {
            Console.WriteLine("Введите логин студента:");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль студента:");
            string password = Console.ReadLine();

            var student = coreApp.GetAllStudents().FirstOrDefault(s => s.LoginStudent == login && s.PasswordStudent == password);

            if (student == null)
            {
                Console.WriteLine("Неверный логин или пароль.");
                return;
            }

            Console.WriteLine($"Добро пожаловать, {student.Familia_St} {student.Names_St}!");
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Просмотреть расписание");
            Console.WriteLine("2. Просмотреть экзамены");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var raspisanie = coreApp.GetAllRaspisanie().Where(r => r.ID_Gruppa == student.ID_Gruppa);
                    foreach (var item in raspisanie)
                    {
                        Console.WriteLine($"Пара: {item.Nomer_para}, День: {item.ID_Day_Nedelia}, Кабинет: {item.Nomer_kabineta}");
                    }
                    break;
                case 2:
                    var ekzamens = coreApp.GetAllEkzamens().Where(e => e.ID_Studenta == student.ID_Studenta);
                    foreach (var item in ekzamens)
                    {
                        Console.WriteLine($"Экзамен: {item.ID_Ekzamena}, Оценка: {item.Ocenka}");
                    }
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        static void PrepodovatelMenu(CoreApplication coreApp)
        {
            Console.WriteLine("Введите логин преподавателя:");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль преподавателя:");
            string password = Console.ReadLine();

            var prepodovatel = coreApp.GetAllPrepodovatel().FirstOrDefault(p => p.Login_Prepod == login && p.Password_Prepod == password);

            if (prepodovatel == null)
            {
                Console.WriteLine("Неверный логин или пароль.");
                return;
            }

            Console.WriteLine($"Добро пожаловать, {prepodovatel.ID_Prepodovatela}!");
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Просмотреть расписание");
            Console.WriteLine("2. Просмотреть экзамены");
            Console.WriteLine("3. Изменить оценку");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var raspisanie = coreApp.GetAllRaspisanie();
                    foreach (var item in raspisanie)
                    {
                        Console.WriteLine($"Пара: {item.Nomer_para}, День: {item.ID_Day_Nedelia}, Кабинет: {item.Nomer_kabineta}");
                    }
                    break;
                case 2:
                    var ekzamens = coreApp.GetAllEkzamens().Where(e => e.ID_Prepodovatela == prepodovatel.ID_Prepodovatela);
                    foreach (var item in ekzamens)
                    {
                        Console.WriteLine($"Экзамен: {item.ID_Ekzamena}, Оценка: {item.Ocenka}");
                    }
                    break;
                case 3:
                    Console.WriteLine("Введите ID экзамена для изменения оценки:");
                    int ekzamenId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите новую оценку:");
                    int newOcenka = int.Parse(Console.ReadLine());

                    var ekzamen = coreApp.GetEkzamenById(ekzamenId);
                    if (ekzamen != null)
                    {
                        ekzamen.Ocenka = newOcenka;
                        coreApp.UpdateEkzamen(ekzamen);
                        Console.WriteLine("Оценка успешно изменена.");
                    }
                    else
                    {
                        Console.WriteLine("Экзамен не найден.");
                    }
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        static void ZavOtdeleniaMenu(CoreApplication coreApp)
        {
            Console.WriteLine("Введите логин заведующего отделением:");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль заведующего отделением:");
            string password = Console.ReadLine();

            var zavOtdelenia = coreApp.GetAllZavOtdelenia().FirstOrDefault(z => z.Login_zaved == login && z.Passwors_zaved == password);

            if (zavOtdelenia == null)
            {
                Console.WriteLine("Неверный логин или пароль.");
                return;
            }

            Console.WriteLine($"Добро пожаловать, {zavOtdelenia.ID_zav_Otdelenia}!");
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Просмотреть расписание");
            Console.WriteLine("2. Просмотреть экзамены");
            Console.WriteLine("3. Изменить оценку");
            Console.WriteLine("4. Добавить новый экзамен");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var raspisanie = coreApp.GetAllRaspisanie();
                    foreach (var item in raspisanie)
                    {
                        Console.WriteLine($"Пара: {item.Nomer_para}, День: {item.ID_Day_Nedelia}, Кабинет: {item.Nomer_kabineta}");
                    }
                    break;
                case 2:
                    var ekzamens = coreApp.GetAllEkzamens();
                    foreach (var item in ekzamens)
                    {
                        Console.WriteLine($"Экзамен: {item.ID_Ekzamena}, Оценка: {item.Ocenka}");
                    }
                    break;
                case 3:
                    Console.WriteLine("Введите ID экзамена для изменения оценки:");
                    int ekzamenId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите новую оценку:");
                    int newOcenka = int.Parse(Console.ReadLine());

                    var ekzamen = coreApp.GetEkzamenById(ekzamenId);
                    if (ekzamen != null)
                    {
                        ekzamen.Ocenka = newOcenka;
                        coreApp.UpdateEkzamen(ekzamen);
                        Console.WriteLine("Оценка успешно изменена.");
                    }
                    else
                    {
                        Console.WriteLine("Экзамен не найден.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Введите ID учебного плана:");
                    int idUchebnogoPlana = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите ID преподавателя:");
                    int idPrepodovatela = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите ID студента:");
                    int idStudenta = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите дату проведения экзамена (гггг-мм-дд):");
                    DateTime dataProvedenia = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Введите номер кабинета:");
                    int nomerKabineta = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите оценку:");
                    int ocenka = int.Parse(Console.ReadLine());

                    var newEkzamen = new Ekzamens
                    {
                        ID_Uhebnogo_Plana = idUchebnogoPlana,
                        ID_Prepodovatela = idPrepodovatela,
                        ID_Studenta = idStudenta,
                        Data_Provedenia = dataProvedenia,
                        Nomer_Kabineta = nomerKabineta,
                        Ocenka = ocenka
                    };

                    coreApp.AddEkzamen(newEkzamen);
                    Console.WriteLine("Экзамен успешно добавлен.");
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }
}