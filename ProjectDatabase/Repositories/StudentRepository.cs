using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using ProjectDatabase.EF;
using ProjectDatabase.Interfaces;
using ProjectDatabase.Models;
using System.Linq.Expressions;

namespace ProjectDatabase.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        public void Create(Student item)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Students.Add(item);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                Student student = db.Students.Find(id);
                if (student != null)
                    db.Students.Remove(student);
                db.SaveChanges();
            }
        }

        public IEnumerable<Student> Find<C>(System.Linq.Expressions.Expression<Func<Student, ICollection<C>>> path, 
            Func<Student, bool> predicate)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Students.Include(path).Where(predicate).ToList();
            }
        }

        public Student Get(int id)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                
                return db.Students.Find(id);
            }
        }

        public IEnumerable<Student> GetAll<C>(Expression<Func<Student, ICollection<C>>> path)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Students.Include(path).ToList();
            }
        }

        public void Update(Student item)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
