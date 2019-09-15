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

            //// ������� ��� ����
            //var role1 = new IdentityRole { Name = "admin" };
            //var role2 = new IdentityRole { Name = "user" };

            //// ��������� ���� � ��
            //roleManager.Create(role1);
            //roleManager.Create(role2);

            //// ������� �������������
            //var admin = new ApplicationUser { Email = "kolian@mail.ru", UserName = "kolian@mail.ru" };
            //string password = "Zakashmar_99";
            //var result = userManager.Create(admin, password);

            //// ���� �������� ������������ ������ �������
            //if (result.Succeeded)
            //{
            //    // ��������� ��� ������������ ����
            //    userManager.AddToRole(admin.Id, role1.Name);
            //    userManager.AddToRole(admin.Id, role2.Name);
            //}

            var teachers = new List<Teacher>()
            {
                new Teacher{ Name = "��������", Surname = "����������", Email = "gena2@gmail.com" },
                new Teacher{ Name = "������", Surname = "�����������", Email = "serhii2@gmail.com" },
                new Teacher{ Name = "���������", Surname = "������", Email = "sasha2@gmail.com" },
                new Teacher{ Name = "�������", Surname = "�����", Email = "alexey2@gmail.com" }
            };

            teachers.ForEach(s => context.Teachers.Add(s));
            context.SaveChanges();

            var courses = new List<Course>()
            {
                new Course { IsRemoved = false, TeacherId = 1, Name = "���������������� �� java", StartDate = new DateTime(2019, 9, 10), FinishDate = new DateTime(2019, 12, 10), Text = "Java � ������ �������������� ��������-��������������� ���� ����������������, ������������� ��������� Sun Microsystems (� ����������� ������������ ��������� Oracle). � ��������� ����� ������ ����������� OpenSource � ���������������� �� �������� GPL. � OpenJDK ������ ����� ������� ��������, ����� ��� � Oracle, RedHat, IBM, Google, JetBrains. ��� �� �� ������ OpenJDK ��� �������� ������������� ���� ������ JDK. ��� ���������� �������� Oracle � ������� ����� OpenJDK � OracleJDK ����������� ����������� �� ����������� ��������, ��������� ������� � Swing � ��������� ���������, �� ������� �������� GPL �� ����������������. ���������� Java ������ ������������� � ����������� ����-���, ������� ��� ����� �������� �� ����� ������������ ����������� � ������� ����������� Java-������. ���� ������������ ������� � 23 ��� 1995 ����. �� 2019 ��� Java � ���� �� ����� ���������� ������ ����������������." },
                new Course { IsRemoved = false, TeacherId = 2, Name = "���������������� �� C++",  StartDate = new DateTime(2019, 10, 1), FinishDate = new DateTime(2020, 2, 10), Text = "C++ (�������� ��-����-����) � �������������, ���������� �������������� ���� ���������������� ������ ����������. ������������ ����� ��������� ����������������, ��� ����������� ����������������, �������� - ��������������� ����������������,  ���������� ����������������.���� ����� ������� ����������� ����������, ������� �������� � ���� ��������������� ���������� � ���������, ���� - �����, ���������� ���������, ��������� ��������������� � ������ �����������.C++ �������� �������� ��� ���������������, ��� � �������������� ������.� ��������� � ��� ���������������� � ������ C, � ���������� �������� ������� ��������� �������� - ���������������� � ����������� ����������������. C++ ������ ������������ ��� ���������� ������������ �����������, ������� ����� �� ����� ���������� ������ ����������������.������� ��� ���������� �������� �������� ������������ ������,  ������������� ���������� ��������, ��������� ���������,  ���������� ��� ������������ ������,  ���������������������� ��������, � ����� ���.���������� ��������� ���������� ����� C++,  ��� ����������, ��� � ������������ � ��� ��������� ��������.��������, �� ��������� x86 ��� GCC, Visual C++, Intel C++ Compiler, Embarcadero(Borland) C++ Builder � ������.C++ ������ �������� ������� �� ������ ����� ����������������, � ������ ������� �� Java � C#. ��������� C++ ����������� �� ����� C.����� �� ��������� ���������� ���� ���������� ������������� � C.��� �� �����, C++ �� �������� � ������� ������ ������������� C; ��������� ��������, ������� ����� ��������� ������� ��������������� ��� ������������� C, ��� � ������������� C++, �������� ������, �� �� �������� ��� ��������� ��������� �� C." },
                new Course { IsRemoved = false, TeacherId = 3, Name = "Back end �� php",  StartDate = new DateTime(2020, 1, 14), FinishDate = new DateTime(2020, 6, 10), Text = "PHP (Hypertext Preprocessor � �PHP: ������������ �����������; ������������� Personal Home Page Tools � ������������ ��� �������� ������������ ���-��������) � ���������� ���� ������ ����������, ���������� ����������� ��� ���������� ���-����������. � ��������� ����� �������������� ����������� ������������ �������-����������� � �������� ����� �� ������� ����� ������, ������������� ��� �������� ������������ ���-������. ���� � ��� ������������� (Zend Engine) ��������������� ������� ����������� � ������ ������� � �������� �����. ������ ���������������� ��� ����������� ���������, ������������� � GNU GPL." },
                new Course { IsRemoved = false, TeacherId = 4, Name = "�������� .Net",  StartDate = new DateTime(2019, 3, 13), FinishDate = new DateTime(2019, 12, 25), Text = ".NET Framework � ����������� ���������, ���������� ��������� Microsoft � 2002 ����. ������� ��������� �������� ������������ ����� ���������� Common Language Runtime (CLR), ������� �������� ��� ������ ������ ����������������. �������������� ����������� CLR �������� � ����� ������ ����������������, ������������ ��� �����.���������, ��� ��������� .NET Framework ������� ������� �������� Microsoft �� ��������� � ���� ������� ������� ������������ ��������� Java �������� Sun Microsystems (���� ����������� Oracle).���� .NET �������� ������������� ����������� ���������� Microsoft � ���������� ���������� �� ������ ��� ������������� ��������� ��������� Microsoft Windows, ���������� ����������� ������� (������ ����� ��� Mono � Portable.NET), ����������� ��������� ��������� .NET �� ��������� ������ ������������ ��������. � ��������� ����� .NET Framework �������� �������� � ���� .NET Core, ���������� �������������� ������������������ ���������� � ������������." },
                new Course { IsRemoved = false, TeacherId = 1, Name = "Android java",  StartDate = new DateTime(2019, 2, 10), FinishDate = new DateTime(2019, 5, 10), Text = "Android  � ������������ ������� ��� ����������, ���������, ����������� ����, �������� ��������������, �������� �����, ������-���������, ������� ���������, ���������, ��������, ����������, ����� Google Glass, ����������� � ������ ��������� (� 2015 ���� ��������� ��������� ������������� ��������������� ������ � ������� �������). �������� �� ���� Linux � ����������� ���������� ����������� ������ Java �� Google. ���������� ��������������� ��������� Android, Inc., ������� ����� ������ Google. ������������ Google ������������ �������� ������� Open Handset Alliance (OHA), ������� ������ ���������� ���������� � ���������� ��������� ���������. Android ��������� ��������� Java-����������, ����������� ����������� ����� ������������� Google ����������. Android Native Development Kit ��������� ����������� ���������� � ���������� ����������, ���������� �� �� � ������ ������. � 86 % ����������, ��������� �� ������ �������� 2014 ����, ���� ����������� ������������ ������� Android. �� ����������� ��� ������������� � ��� 2017 ���� Google ��������, ��� �� ��� ������� Android ���� ������������ ����� 2 ���� Android-���������." },
                new Course { IsRemoved = false, TeacherId = 2, Name = "���������������� Ruby",  StartDate = new DateTime(2019, 1, 1), FinishDate = new DateTime(2019, 5, 10), Text = "Ruby  � ������������, ������������, ���������������� ��������������� ���� ����������������. ���� �������� ����������� �� ������������ ������� ����������� ���������������, ������� ������������ ����������, ��������� ������ � ������� ������� �������������. �� ������������ ���������� �� ������ � ������ Perl � Eiffel, �� ��������-���������������� ������� � � Smalltalk. ����� ��������� ����� ����� ����� �� Python, Lisp, Dylan � ���.������������������ ���������� �������������� ����� �������� ��������� ���������." },
                new Course { IsRemoved = false, TeacherId = 3, Name = "���������������� Python",  StartDate = new DateTime(2018, 5, 14), FinishDate = new DateTime(2019, 6, 10), Text = "Python � ��������������� ���� ���������������� ������ ����������, ��������������� �� ��������� ������������������ ������������ � ���������� ����. ��������� ���� Python ��������������. � �� �� ����� ����������� ���������� �������� ������� ����� �������� �������.Python ������������ �����������, ��������-���������������, ��������������, ������������ � ��������-��������������� ����������������. �������� ������������� ����� � ������������ ���������, �������������� ���������� �������, ������ ������������, �������� ��������� ����������, ��������� ������������� ����������, ��������������� ��������� ������. �������������� ��������� �������� �� ������, �������, � ���� �������, ����� ������������ � ������." },
                new Course { IsRemoved = false, TeacherId = 4, Name = "���������������� JavaScript",  StartDate = new DateTime(2019, 6, 13), FinishDate = new DateTime(2019, 10, 25), Text = "JavaScript  � ������������������� ���� ����������������. ������������ ��������-���������������, ������������ � �������������� �����. �������� ����������� ����� ECMAScript (�������� ECMA-262).JavaScript ������ ������������ ��� ������������ ���� ��� ������������ ������� � �������� ����������. �������� ������� ���������� ������� � ��������� ��� ���� ��������� ��� �������� ��������������� ���-���������.�������� ������������� �����: ������������ ���������, ������ ���������, �������������� ���������� �������, ����������� ����������������, ������� ��� ������� ������� ������." }
            };

            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var students = new List<Student>()
            {
                new Student{ IsBlocked = false, Name = "�����", Surname = "���������", Email = "somemail@mail.ru", Courses = new List<Course>{ courses[0], courses[1], courses[2], courses[3], courses[4], courses[5], courses[6], courses[7] } },
                new Student{ IsBlocked = false, Name = "���������", Surname = "���������", Email = "myemail1@mail.ru", Courses = new List<Course>{ courses[0], courses[1], courses[3], courses[4], courses[5] }  },
                new Student{ IsBlocked = false, Name = "�������", Surname = "��������", Email = "somemail28@mail.ru", Courses = new List<Course>{ courses[2], courses[1], courses[2], courses[3], courses[4], courses[5], courses[6] }  },
                new Student{ IsBlocked = false, Name = "��������", Surname = "�����", Email = "somemail3@mail.ru", Courses = new List<Course>{ courses[3], courses[1], courses[3], courses[4] }  },
                new Student{ IsBlocked = false, Name = "�����", Surname = "�������", Email = "somemail4@mail.ru", Courses = new List<Course>{ courses[1], courses[3], courses[4] }  },
                new Student{ IsBlocked = false, Name = "��������", Surname = "������", Email = "somemail5@mail.ru", Courses = new List<Course>{ courses[0], courses[3], courses[7], courses[4] }  },
                new Student{ IsBlocked = false, Name = "����", Surname = "�������", Email = "myemail2@mail.ru", Courses = new List<Course>{ courses[0], courses[2], courses[3], courses[4], courses[5], courses[6] }  },
                new Student{ IsBlocked = false, Name = "�����", Surname = "�����", Email = "somemail7@mail.ru", Courses = new List<Course>{ courses[0], courses[2], courses[6], courses[7] }  },
                new Student{ IsBlocked = false, Name = "������", Surname = "�������", Email = "myemail3@mail.ru", Courses = new List<Course>{ courses[2], courses[1], courses[6], courses[7] }  },
                new Student{ IsBlocked = false, Name = "�������", Surname = "������������", Email = "somemail9@mail.ru", Courses = new List<Course>{ courses[0], courses[3] }  },
                new Student{ IsBlocked = false, Name = "�����", Surname = "������", Email = "somemail10@mail.ru", Courses = new List<Course>{ courses[0], courses[6], courses[7] }  },
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

        }

    }
}
