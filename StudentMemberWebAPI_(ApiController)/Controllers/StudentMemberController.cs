using StudentMemberWebAPI__ApiController_.Models;
using StudentMemberWebAPI__ApiController_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace StudentMemberWebAPI__ApiController_.Controllers
{
    public class StudentMemberController : ApiController
    {
        public List<StudentMember> Get()
        {// Get Method
            return StudentMemberRepositories.Get();
        }
        public StudentMember Get(int Id)
        {// Get Method
            return StudentMemberRepositories.Get(Id);
        }
        public StudentMember Put([FromBody] StudentMember studentMember)
        {// Put Method
            if (!StudentMemberRepositories.IsExist(studentMember.Id))
            {
                throw new HttpResponseException(Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest,"Unable to find Student Member with given Id."));
            }
            StudentMemberRepositories.Update(studentMember);
            return studentMember;
        }
        public StudentMember Post([FromBody] StudentMember studentMember)
        {// Post Method
            if (!StudentMemberRepositories.IsExist(studentMember.FullName))
            {
                throw new HttpResponseException(Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, "Another studen member with the same Fullname is already exist."));
            }
            
            return StudentMemberRepositories.Add(studentMember.FullName, studentMember.Age, studentMember.Section, studentMember.ClassNumber);
        }
        public HttpResponseMessage Delete(int Id)
        {// Delete Method
            if (!StudentMemberRepositories.IsExist(Id))
            {
                throw new HttpResponseException(Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, "Unable to find Student Member with given Id."));
            }
            StudentMemberRepositories.Remove(Id);
            return Request.CreateErrorResponse(HttpStatusCode.OK, "successful"); 
        }
    }
}