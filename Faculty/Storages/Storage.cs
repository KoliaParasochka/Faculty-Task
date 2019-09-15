using ProjectDatabase;
using ProjectDatabase.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Faculty.FileManage;
using ProjectDatabase.EF;
using ProjectDatabase.Entities;
//using ProjectDatabase.EF;

namespace Faculty.Storages
{
    /// <summary>
    /// This class created to works
    /// with database context
    /// </summary>
    public class Storage<T>
    {
        
        /// <summary>
        /// This method gets a count of students
        /// who studies on one course
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public int GetCountOfStudentsOnCourse(Course course)
        {
            int count = 0;
            count = course.Students.Count;
            return count;
        }
    }
}