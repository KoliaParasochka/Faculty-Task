using ProjectDatabase.EF;
using ProjectDatabase.Entities;
using ProjectDatabase.Interfaces;
using ProjectDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase.Repositories
{
    public class TeacherListRepository : IRepository<TeacherList>
    {
        ApplicationDbContext db;

        public TeacherListRepository(ApplicationDbContext context)
        {
            db = context;
        }

        public void Create(TeacherList item)
        {
            db.TeacherLists.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            TeacherList teacherList = db.TeacherLists.Find(id);
            if (teacherList != null)
                db.TeacherLists.Remove(teacherList);
            db.SaveChanges();
        }

        public IEnumerable<TeacherList> Find<C>(System.Linq.Expressions.Expression<Func<TeacherList, ICollection<C>>> path, Func<TeacherList, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public TeacherList Get(int id)
        {
            return db.TeacherLists.Find(id);
        }

        public IEnumerable<TeacherList> GetAll()
        {
            return db.TeacherLists.ToList();
        }

        public IEnumerable<TeacherList> GetAll<C>(System.Linq.Expressions.Expression<Func<TeacherList, ICollection<C>>> path)
        {
            throw new NotImplementedException();
        }

        public void Update(TeacherList item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
