using ProjectDatabase.EF;
using ProjectDatabase.Interfaces;
using ProjectDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using ProjectDatabase.Entities;

namespace ProjectDatabase.Repositories
{
    public class TeacherRepository : IRepository<Teacher>
    {
        ApplicationDbContext db;

        public TeacherRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<Teacher> GetAll()
        {
            return db.Teachers.ToList();
        }

        public void Create(Teacher item)
        {
            db.Teachers.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            if (teacher != null)
                db.Teachers.Remove(teacher);
            db.SaveChanges();
        }

        public IEnumerable<Teacher> Find<C>(System.Linq.Expressions.Expression<Func<Teacher, ICollection<C>>> path, Func<Teacher, bool> predicate)
        {
            return db.Teachers.Include(path).Where(predicate).ToList();
        }

        public Teacher Get(int id)
        {
            return db.Teachers.Find(id);
        }

        public IEnumerable<Teacher> GetAll<C>(System.Linq.Expressions.Expression<Func<Teacher, ICollection<C>>> path)
        {
            return db.Teachers.Include(path);
        }

        public void Update(Teacher item)
        {
             db.Entry(item).State = EntityState.Modified;
             db.SaveChanges();
        }
    }
}
