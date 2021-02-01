using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoginApplication.Models;
using LoginApplication.VM;

namespace LoginApplication.Controllers
{
    [RoutePrefix("Api/login")]
    public class LoginController : ApiController
    {
        ProjectEntities db = new ProjectEntities();
        [Route("InsertEmployee")]
       [HttpPost]
       public object InsertCustomer(Register rg)
        {
            try
            {
                UserLogin ul = new UserLogin();
                if(ul.Id==0) 
                {
                    ul.Name = rg.Name;
                    ul.City = rg.City;
                    ul.Email = rg.Email;
                    ul.Password = rg.Password;
                    db.UserLogins.Add(ul);
                    db.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Record Successlly saved"
                    };
                }
                else
                {
                    var obj = db.UserLogins.Where(x => x.Id == ul.Id).ToList().FirstOrDefault();
                    if (obj.Id > 0)
                    {
                        obj.Name = ul.Name;
                        obj.Email = ul.Email;
                        obj.City = ul.City;
                        db.SaveChanges();
                        return new Response
                        {
                            Status = "Success",
                            Message = "Record Successlly saved"
                        };
                    }
                }
            }
            catch (Exception)
            {
                return new Response
                {
                    Status = "AlreadyExists",
                    Message = "Invalid Data."
                };
            }
            return new Response { 
             Status = "Error", Message = "Invalid Data." };
        }

        [Route("Login")]
        [HttpPost]
        public Response Login(Login login)
        {
            var log = db.UserLogins.Where(x => x.Email.Equals(login.Email) &&
            x.Password.Equals(login.Password)).FirstOrDefault();
            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Invalid User" };
            }
            else
            
                return new Response { Status = "Success", Message = "Login SuccessFull" };
            
        }
        [Route("FetchUsers")]
        [HttpGet]
        public object CustomerDetails()
        {
            var a = db.UserLogins.ToList();
            return a;
        }

        [Route("DeleteCustomer")]
        [HttpDelete]
        public HttpResponseMessage Deletecustomer(int Id)
        {
            UserLogin l = db.UserLogins.Find(Id);
            Console.WriteLine(l);
             if(l != null)
            {
                db.UserLogins.Remove(l);
                db.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);

            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        
       
           

            
        }
}