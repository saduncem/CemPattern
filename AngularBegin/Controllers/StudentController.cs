using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularBegin.Models;
using System.Web.Http.Description;
using System.Data.Entity;

namespace AngularBegin.Controllers
{
    public class StudentController : ApiController
    {
        KutuphaneDBEntities  dbContext = null;
        // Constructor 
        public StudentController()
        {
            // create instance of an object
            dbContext = new KutuphaneDBEntities();
        }
        [ResponseType(typeof(tblStudent))]
        [HttpPost]
        public HttpResponseMessage SaveStudent(tblStudent astudent)
        {
            int result = 0;
            try
            {
                dbContext.tblStudent.Add(astudent);
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

       
        [HttpGet]
        public List<tblStudent> GetStudents()
        {
            List<tblStudent> students = null;
            try
            {
                students = dbContext.tblStudent.ToList();

            }
            catch (Exception e)
            {
                students = null;
            }

            return students;
        }

        
        [HttpGet]
        public tblStudent GetStudentByID(int studentID)
        {
            tblStudent astudent = null;
            try
            {
                astudent = dbContext.tblStudent.Where(x => x.StudentID == studentID).SingleOrDefault();
            }
            catch (Exception e)
            {
                astudent = null;
            }

            return astudent;
        }

      
        [HttpDelete]
        public HttpResponseMessage DeleteStudent(int id)
        {
            int result = 0;
            try
            {
                var student = dbContext.tblStudent.Where(x => x.StudentID == id).FirstOrDefault();
                dbContext.tblStudent.Attach(student);
                dbContext.tblStudent.Remove(student);
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {

                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut]
        public HttpResponseMessage UpdateStudent(tblStudent astudent)
        {
            int result = 0;
            try
            {
                dbContext.tblStudent.Attach(astudent);
                dbContext.Entry(astudent).State = EntityState.Modified;
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
