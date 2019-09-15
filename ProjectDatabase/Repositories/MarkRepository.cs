using ProjectDatabase.EF;
using ProjectDatabase.Entities;
using ProjectDatabase.Interfaces;
using ProjectDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase.Repositories
{
    public class MarkRepository : IRepository<Mark>
    {
        ApplicationDbContext db;

        public MarkRepository()
        {
            db = new ApplicationDbContext("DefaultConnection");
        }

        public MarkRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public IEnumerable<Mark> GetAll()
        {
            return db.Marks.ToList();
        }

        public void Create(Mark item)
        {
            db.Marks.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Mark mark = db.Marks.Find(id);
            if (mark != null)
                db.Marks.Remove(mark);
            db.SaveChanges();
           
        }

        public IEnumerable<Mark> Find<C>(System.Linq.Expressions.Expression<Func<Mark, ICollection<C>>> path, Func<Mark, bool> predicate)
        {
            return db.Marks.Where(predicate).ToList();
        }

        public IEnumerable<Mark> Find(Func<Mark, bool> predicate)
        {
            return db.Marks.Where(predicate).ToList();
        }

        public Mark Get(int id)
        {
            return db.Marks.Find(id);
        }

        public IEnumerable<Mark> GetAll<C>(System.Linq.Expressions.Expression<Func<Mark, ICollection<C>>> path)
        {
            return db.Marks.Include(path).ToList();
        }

        public void Update(Mark item)
        {
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
