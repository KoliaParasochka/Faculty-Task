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
        public void Create(Course item)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Courses.Add(item);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Course course = db.Courses.Find(id);
                if (course != null)
                    db.Courses.Remove(course);
                db.SaveChanges();
            }
        }

        public Course Get(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                List<Course> courses = db.Courses.Include(p => p.Teacher).ToList();
                return courses.Where(p => p.CourseId == id).First();
            }
        }

        public IEnumerable<Course> GetAll<C>(Expression<Func<Course, ICollection<C>>> path)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Courses.Include(path).ToList();
            }
        }

        public void Update(Course item)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public IEnumerable<Course> Find<C>(Expression<Func<Course, ICollection<C>>> path, Func<Course, bool> predicate)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Courses.Include(path).Where(predicate).ToList();
            }
        }
    }
}
