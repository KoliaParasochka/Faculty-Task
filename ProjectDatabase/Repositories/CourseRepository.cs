using ProjectDatabase.EF;
using ProjectDatabase.Interfaces;
using ProjectDatabase.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace ProjectDatabase.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        ApplicationDbContext db;

        public CourseRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<Course> GetAll()
        {
            return db.Courses.Include(p => p.Teacher).ToList();
        }

        public void Create(Course item)
        {
            db.Courses.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
              Course course = db.Courses.Find(id);
                if (course != null)
                    db.Courses.Remove(course);
                db.SaveChanges();
            
        }

        public Course Get(int id)
        {
            List<Course> courses = db.Courses.Include(p => p.Teacher).ToList();
            return courses.Where(p => p.CourseId == id).First();
        }

        public IEnumerable<Course> GetAll<C>(Expression<Func<Course, ICollection<C>>> path)
        {
            return db.Courses.Include(path).ToList();            
        }

        public void Update(Course item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }

        public IEnumerable<Course> Find<C>(Expression<Func<Course, ICollection<C>>> path, Func<Course, bool> predicate)
        {
            return db.Courses.Include(path).Where(predicate).ToList();
        }
    }
}
