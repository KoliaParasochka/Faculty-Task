using ProjectDatabase.EF;
using ProjectDatabase.Interfaces;
using ProjectDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        ApplicationDbContext db;
        private MarkRepository markRepository;
        private StudentRepository studentRepository;
        private TeacherRepository teacherRepository;
        private TeacherListRepository teacherListRepository;
        private CourseRepository courseRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new ApplicationDbContext(connectionString);
        }

        public IRepository<Student> Students
        {
            get
            {
                if (studentRepository == null)
                    studentRepository = new StudentRepository(db);
                return studentRepository;
            }
        }

        public IRepository<Course> Courses
        {
            get
            {
                if (courseRepository == null)
                    courseRepository = new CourseRepository(db);
                return courseRepository;
            }
        }

        public IRepository<Teacher> Teachers
        {
            get
            {
                if (teacherRepository == null)
                    teacherRepository = new TeacherRepository(db);
                return teacherRepository;
            }
        }

        public IRepository<Mark> Marks
        {
            get
            {
                if (markRepository == null)
                    markRepository = new MarkRepository(db);
                return markRepository;
            }
        }

        public IRepository<TeacherList> TeacherLists
        {
            get
            {
                if (teacherListRepository == null)
                    teacherListRepository = new TeacherListRepository(db);
                return teacherListRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    using(ApplicationDbContext db = new ApplicationDbContext())
                    {
                        db.Dispose();
                    }
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
