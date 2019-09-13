using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using ProjectDatabase.EF;
using ProjectDatabase.Interfaces;
using ProjectDatabase.Models;
using System.Linq.Expressions;

namespace ProjectDatabase.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        ApplicationDbContext db;

        public StudentRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<Student> GetAll()
        {
            return db.Students.ToList();
        }

        public void Create(Student item)
        {
            db.Students.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Student student = db.Students.Find(id);
            if (student != null)
                db.Students.Remove(student);
            db.SaveChanges();
        }

        public IEnumerable<Student> Find<C>(System.Linq.Expressions.Expression<Func<Student, ICollection<C>>> path, 
            Func<Student, bool> predicate)
        {
            return db.Students.Include(path).Where(predicate).ToList();
        }

        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        public IEnumerable<Student> GetAll<C>(Expression<Func<Student, ICollection<C>>> path)
        {
            return db.Students.Include(path).ToList();
        }

        public void Update(Student item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
