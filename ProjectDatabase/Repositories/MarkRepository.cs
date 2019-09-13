using ProjectDatabase.EF;
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
        public void Create(Mark item)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Marks.Add(item);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Mark mark = db.Marks.Find(id);
                if (mark != null)
                    db.Marks.Remove(mark);
            }
        }

        public IEnumerable<Mark> Find<C>(System.Linq.Expressions.Expression<Func<Mark, ICollection<C>>> path, Func<Mark, bool> predicate)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Marks.Include(path).Where(predicate).ToList();
            }
        }

        public Mark Get(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Marks.Find(id);
            }
        }

        public IEnumerable<Mark> GetAll<C>(System.Linq.Expressions.Expression<Func<Mark, ICollection<C>>> path)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Marks.Include(path).ToList();
            }
        }

        public void Update(Mark item)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(item).State = EntityState.Modified;
            }
        }
    }
}
