using ProjectDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDatabase.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        IRepository<Student> Students { get; }
        IRepository<Course> Courses { get; }
        IRepository<Teacher> Teachers { get; }
        IRepository<Mark> Marks { get; }
        void Save();
    }
}
