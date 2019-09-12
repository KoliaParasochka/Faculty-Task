using ProjectDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faculty.Storages
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStorage
    {
        int GetCountOfStudentsOnCourse(Course course);
        string GetEmail(string userId);
        void AddTeacherToList(RegisterAccount model);
        void AddCourse(Course course);
        void ChangeCourse(CreateCourse course);
        void AddMark(Mark mark);
        void DelMark(int courseId, int studentId);
        void AddCourseToStudent(string Name, dynamic userId);
        void AddStudent(Student student);
        void BlockUnblockStudent(string name, bool act);
        void RemoveRestoreCourse(string Name, bool act);
        void AddTeacher(int id);
        void DelTeacher(int id);
        Mark GetMark(int courseId, int studentId);
        Student GetStudent(string email);
        Teacher GetTeacher(string email);
        List<Student> GetStudents();
        List<TeacherList> GetTeacherList();
        List<Teacher> GetTeachers();
        List<Course> GetCoursesAndStudents();
        List<Course> GetCoursesAndTeachers();
    }
}
