using ProjectDatabase.EF;
using ProjectDatabase.Interfaces;
using ProjectDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ProjectDatabase.Repositories
{
    public class TeacherRepository : IRepository<Teacher>
    {
        public void Create(Teacher item)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Teachers.Add(item);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Teacher teacher = db.Teachers.Find(id);
                if (teacher != null)
                    db.Teachers.Remove(teacher);
                db.SaveChanges();
            }
        }

        public IEnumerable<Teacher> Find<C>(System.Linq.Expressions.Expression<Func<Teacher, ICollection<C>>> path, Func<Teacher, bool> predicate)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Teachers.Include(path).Where(predicate).ToList();
            }
        }

        public Teacher Get(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Teachers.Find(id);
            }
        }

        public IEnumerable<Teacher> GetAll<C>(System.Linq.Expressions.Expression<Func<Teacher, ICollection<C>>> path)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Teachers.Include(path);
            }
        }

        public void Update(Teacher item)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
