namespace ProjectDatabase.Migrations
{
    using Faculty;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ProjectDatabase.EF;
    using ProjectDatabase.Entities;
    using ProjectDatabase.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectDatabase.EF.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProjectDatabase.EF.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //// создаем две роли
            //var role1 = new IdentityRole { Name = "admin" };
            //var role2 = new IdentityRole { Name = "user" };

            //// добавляем роли в бд
            //roleManager.Create(role1);
            //roleManager.Create(role2);

            //// создаем пользователей
            //var admin = new ApplicationUser { Email = "kolian@mail.ru", UserName = "kolian@mail.ru" };
            //string password = "Zakashmar_99";
            //var result = userManager.Create(admin, password);

            //// если создание пользователя прошло успешно
            //if (result.Succeeded)
            //{
            //    // добавляем для пользователя роль
            //    userManager.AddToRole(admin.Id, role1.Name);
            //    userManager.AddToRole(admin.Id, role2.Name);
            //}

            var teachers = new List<Teacher>()
            {
                new Teacher{ Name = "Геннадий", Surname = "Паровознюк", Email = "gena2@gmail.com" },
                new Teacher{ Name = "Сергей", Surname = "Николащенко", Email = "serhii2@gmail.com" },
                new Teacher{ Name = "Александр", Surname = "Коршун", Email = "sasha2@gmail.com" },
                new Teacher{ Name = "Алексей", Surname = "Кучма", Email = "alexey2@gmail.com" }
            };

            teachers.ForEach(s => context.Teachers.Add(s));
            context.SaveChanges();

            var courses = new List<Course>()
            {
                new Course { IsRemoved = false, TeacherId = 1, Name = "Программирование на java", StartDate = new DateTime(2019, 9, 10), FinishDate = new DateTime(2019, 12, 10), Text = "Java — сильно типизированный объектно-ориентированный язык программирования, разработанный компанией Sun Microsystems (в последующем приобретённой компанией Oracle). В настоящее время проект принадлежит OpenSource и распространяется по лицензии GPL. В OpenJDK вносят вклад крупные компании, такие как — Oracle, RedHat, IBM, Google, JetBrains. Так же на основе OpenJDK эти компании разрабатывают свои сборки JDK. Как утверждает компания Oracle — отличия между OpenJDK и OracleJDK практически отсутствуют за исключением лицензии, отрисовки шрифтов в Swing и некоторых библиотек, на которые лицензия GPL не распространяется. Приложения Java обычно транслируются в специальный байт-код, поэтому они могут работать на любой компьютерной архитектуре с помощью виртуальной Java-машины. Дата официального выпуска — 23 мая 1995 года. На 2019 год Java — один из самых популярных языков программирования." },
                new Course { IsRemoved = false, TeacherId = 2, Name = "Программирование на C++",  StartDate = new DateTime(2019, 10, 1), FinishDate = new DateTime(2020, 2, 10), Text = "C++ (читается си-плюс-плюс) — компилируемый, статически типизированный язык программирования общего назначения. Поддерживает такие парадигмы программирования, как процедурное программирование, объектно - ориентированное программирование,  обобщённое программирование.Язык имеет богатую стандартную библиотеку, которая включает в себя распространённые контейнеры и алгоритмы, ввод - вывод, регулярные выражения, поддержку многопоточности и другие возможности.C++ сочетает свойства как высокоуровневых, так и низкоуровневых языков.В сравнении с его предшественником — языком C, — наибольшее внимание уделено поддержке объектно - ориентированного и обобщённого программирования. C++ широко используется для разработки программного обеспечения, являясь одним из самых популярных языков программирования.Область его применения включает создание операционных систем,  разнообразных прикладных программ, драйверов устройств,  приложений для встраиваемых систем,  высокопроизводительных серверов, а также игр.Существует множество реализаций языка C++,  как бесплатных, так и коммерческих и для различных платформ.Например, на платформе x86 это GCC, Visual C++, Intel C++ Compiler, Embarcadero(Borland) C++ Builder и другие.C++ оказал огромное влияние на другие языки программирования, в первую очередь на Java и C#. Синтаксис C++ унаследован от языка C.Одним из принципов разработки было сохранение совместимости с C.Тем не менее, C++ не является в строгом смысле надмножеством C; множество программ, которые могут одинаково успешно транслироваться как компиляторами C, так и компиляторами C++, довольно велико, но не включает все возможные программы на C." },
                new Course { IsRemoved = false, TeacherId = 3, Name = "Back end на php",  StartDate = new DateTime(2020, 1, 14), FinishDate = new DateTime(2020, 6, 10), Text = "PHP (Hypertext Preprocessor — «PHP: препроцессор гипертекста»; первоначально Personal Home Page Tools — «Инструменты для создания персональных веб-страниц») — скриптовый язык общего назначения, интенсивно применяемый для разработки веб-приложений. В настоящее время поддерживается подавляющим большинством хостинг-провайдеров и является одним из лидеров среди языков, применяющихся для создания динамических веб-сайтов. Язык и его интерпретатор (Zend Engine) разрабатываются группой энтузиастов в рамках проекта с открытым кодом. Проект распространяется под собственной лицензией, несовместимой с GNU GPL." },
                new Course { IsRemoved = false, TeacherId = 4, Name = "Обучение .Net",  StartDate = new DateTime(2019, 3, 13), FinishDate = new DateTime(2019, 12, 25), Text = ".NET Framework — программная платформа, выпущенная компанией Microsoft в 2002 году. Основой платформы является общеязыковая среда исполнения Common Language Runtime (CLR), которая подходит для разных языков программирования. Функциональные возможности CLR доступны в любых языках программирования, использующих эту среду.Считается, что платформа .NET Framework явилась ответом компании Microsoft на набравшую к тому времени большую популярность платформу Java компании Sun Microsystems (ныне принадлежит Oracle).Хотя .NET является патентованной технологией корпорации Microsoft и официально рассчитана на работу под операционными системами семейства Microsoft Windows, существуют независимые проекты (прежде всего это Mono и Portable.NET), позволяющие запускать программы .NET на некоторых других операционных системах. В настоящее время .NET Framework получает развитие в виде .NET Core, изначально предполагающей кроссплатформенную разработку и эксплуатацию." },
                new Course { IsRemoved = false, TeacherId = 1, Name = "Android java",  StartDate = new DateTime(2019, 2, 10), FinishDate = new DateTime(2019, 5, 10), Text = "Android  — операционная система для смартфонов, планшетов, электронных книг, цифровых проигрывателей, наручных часов, фитнес-браслетов, игровых приставок, ноутбуков, нетбуков, смартбуков, очков Google Glass, телевизоров и других устройств (в 2015 году появилась поддержка автомобильных развлекательных систем и бытовых роботов). Основана на ядре Linux и собственной реализации виртуальной машины Java от Google. Изначально разрабатывалась компанией Android, Inc., которую затем купила Google. Впоследствии Google инициировала создание альянса Open Handset Alliance (OHA), который сейчас занимается поддержкой и дальнейшим развитием платформы. Android позволяет создавать Java-приложения, управляющие устройством через разработанные Google библиотеки. Android Native Development Kit позволяет портировать библиотеки и компоненты приложений, написанные на Си и других языках. В 86 % смартфонов, проданных во втором квартале 2014 года, была установлена операционная система Android. На конференции для разработчиков в мае 2017 года Google объявила, что за всю историю Android было активировано более 2 млрд Android-устройств." },
                new Course { IsRemoved = false, TeacherId = 2, Name = "Программирование Ruby",  StartDate = new DateTime(2019, 1, 1), FinishDate = new DateTime(2019, 5, 10), Text = "Ruby  — динамический, рефлективный, интерпретируемый высокоуровневый язык программирования. Язык обладает независимой от операционной системы реализацией многопоточности, сильной динамической типизацией, сборщиком мусора и многими другими возможностями. По особенностям синтаксиса он близок к языкам Perl и Eiffel, по объектно-ориентированному подходу — к Smalltalk. Также некоторые черты языка взяты из Python, Lisp, Dylan и Клу.Кроссплатформенная реализация интерпретатора языка является полностью свободной." },
                new Course { IsRemoved = false, TeacherId = 3, Name = "Программирование Python",  StartDate = new DateTime(2018, 5, 14), FinishDate = new DateTime(2019, 6, 10), Text = "Python — высокоуровневый язык программирования общего назначения, ориентированный на повышение производительности разработчика и читаемости кода. Синтаксис ядра Python минималистичен. В то же время стандартная библиотека включает большой объём полезных функций.Python поддерживает структурное, объектно-ориентированное, функциональное, императивное и аспектно-ориентированное программирование. Основные архитектурные черты — динамическая типизация, автоматическое управление памятью, полная интроспекция, механизм обработки исключений, поддержка многопоточных вычислений, высокоуровневые структуры данных. Поддерживается разбиение программ на модули, которые, в свою очередь, могут объединяться в пакеты." },
                new Course { IsRemoved = false, TeacherId = 4, Name = "Программирование JavaScript",  StartDate = new DateTime(2019, 6, 13), FinishDate = new DateTime(2019, 10, 25), Text = "JavaScript  — мультипарадигменный язык программирования. Поддерживает объектно-ориентированный, императивный и функциональный стили. Является реализацией языка ECMAScript (стандарт ECMA-262).JavaScript обычно используется как встраиваемый язык для программного доступа к объектам приложений. Наиболее широкое применение находит в браузерах как язык сценариев для придания интерактивности веб-страницам.Основные архитектурные черты: динамическая типизация, слабая типизация, автоматическое управление памятью, прототипное программирование, функции как объекты первого класса." }
            };

            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var students = new List<Student>()
            {
                new Student{ IsBlocked = false, Name = "Данил", Surname = "Евтушенко", Email = "somemail@mail.ru", Courses = new List<Course>{ courses[0], courses[1], courses[2], courses[3], courses[4], courses[5], courses[6], courses[7] } },
                new Student{ IsBlocked = false, Name = "Владислав", Surname = "Коваленко", Email = "myemail1@mail.ru", Courses = new List<Course>{ courses[0], courses[1], courses[3], courses[4], courses[5] }  },
                new Student{ IsBlocked = false, Name = "Николай", Surname = "Панченко", Email = "somemail28@mail.ru", Courses = new List<Course>{ courses[2], courses[1], courses[2], courses[3], courses[4], courses[5], courses[6] }  },
                new Student{ IsBlocked = false, Name = "Анатолий", Surname = "Берко", Email = "somemail3@mail.ru", Courses = new List<Course>{ courses[3], courses[1], courses[3], courses[4] }  },
                new Student{ IsBlocked = false, Name = "Ольга", Surname = "Шаповал", Email = "somemail4@mail.ru", Courses = new List<Course>{ courses[1], courses[3], courses[4] }  },
                new Student{ IsBlocked = false, Name = "Виктория", Surname = "Плюйко", Email = "somemail5@mail.ru", Courses = new List<Course>{ courses[0], courses[3], courses[7], courses[4] }  },
                new Student{ IsBlocked = false, Name = "Анна", Surname = "Застава", Email = "myemail2@mail.ru", Courses = new List<Course>{ courses[0], courses[2], courses[3], courses[4], courses[5], courses[6] }  },
                new Student{ IsBlocked = false, Name = "Алена", Surname = "Ганжа", Email = "somemail7@mail.ru", Courses = new List<Course>{ courses[0], courses[2], courses[6], courses[7] }  },
                new Student{ IsBlocked = false, Name = "Степан", Surname = "Шеремет", Email = "myemail3@mail.ru", Courses = new List<Course>{ courses[2], courses[1], courses[6], courses[7] }  },
                new Student{ IsBlocked = false, Name = "Дмитрий", Surname = "Крижановский", Email = "somemail9@mail.ru", Courses = new List<Course>{ courses[0], courses[3] }  },
                new Student{ IsBlocked = false, Name = "Данил", Surname = "Волков", Email = "somemail10@mail.ru", Courses = new List<Course>{ courses[0], courses[6], courses[7] }  },
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

        }

    }
}
