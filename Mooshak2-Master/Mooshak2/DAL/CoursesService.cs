using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Mooshak2.Models;
using Mooshak2.Models.Entities;
using Mooshak2.Models.ViewModels;

namespace Mooshak2.DAL
{
    public class CoursesService
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        
        public IEnumerable<Course> GetAllCourses()
        {
            IEnumerable<Course> courses = (from c in _dbContext.Courses
                orderby c.Title ascending
                select c).ToList();
            return courses;
        }

        public Course GetCourseByName(string title)
        {
            return _dbContext.Courses.Find(title);
        }

        public Course GetCourseById(int id)
        {
            var cor = (from item in _dbContext.Courses
                where item.CourseID == id
                select item).SingleOrDefault();
            return cor;
        }

        public List<Course> GetCoursesForTeacher(ApplicationUser user)
        {
            var cor = (from e in _dbContext.Courses
                join em in _dbContext.Teachments on e.CourseID equals em.CourseID
                where em.UserID.Id == user.Id
                select e).ToList();
            return cor;
        }

        public List<Course> GetCoursesForStudent(ApplicationUser user)
        {
            var cor = (from e in _dbContext.Courses
                join em in _dbContext.Enrollments on e.CourseID equals em.CourseID
                where em.UserID.Id == user.Id
                select e).ToList();
            return cor;
        }

        public List<StudentViewModel> GetStudentsInCourse(int courseId)
        {
            var cor = (from enrollments in _dbContext.Enrollments

                join course in _dbContext.Courses
                    on enrollments.CourseID equals course.CourseID

                join users in _dbContext.Users
                    on enrollments.UserID.Id equals users.Id

                where enrollments.CourseID == courseId

                select new StudentViewModel {ID = enrollments, Title = course, Name = users}).ToList();
            return cor;
        }

        public List<TeacherViewModel> GetTeachersInCourse(int courseId)
        {
            var asi = (from teachment in _dbContext.Teachments
                join course in _dbContext.Courses
                    on teachment.CourseID equals course.CourseID
                join users in _dbContext.Users
                    on teachment.UserID.Id equals users.Id

                where teachment.CourseID == courseId
                select new TeacherViewModel {ID = teachment, Title = course, Name = users}).ToList();
            return asi;
        }



        public Course AddNewCourse(Course model)
        {
            var newCourse = _dbContext.Courses.Add(model);
            _dbContext.SaveChanges();

            return newCourse;
        }

        public void UpdateCourse(Course model)
        {
            var course = GetCourseById(model.CourseID);

            course.Title = model.Title;
            course.Details = model.Details;
            _dbContext.SaveChanges();
        }

        public void RemoveCourse(int id)
        {

            var cor = (from c in _dbContext.Courses
                where c.CourseID == id
                select c).FirstOrDefault();
            _dbContext.Courses.Remove(cor);
            _dbContext.SaveChanges();
        }
    }
}