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
        public IRepository<Student> Students => throw new NotImplementedException();

        public IRepository<Course> Courses => throw new NotImplementedException();

        public IRepository<Teacher> Teachers => throw new NotImplementedException();

        public IRepository<Mark> Marks => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
