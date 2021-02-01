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
    [RoutePrefix("Api/RoomBooking")]
    public class RoomBookingController : ApiController
    {
        ProjectEntities3 db = new ProjectEntities3();
        [Route("fetchcustomerbooking")]
        [HttpGet]
        public object booking()
        {
            var a = db.RoomBookings.ToList();
            return a;
        }




        [Route("Roombookings")]
        [HttpPost]
         public object InsertCustomer(Roombookingclass rb)
        {
            try
            {
                RoomBooking ul = new RoomBooking();
                if(ul.Room_id==0) 
                {
                    ul.Name = rb.Name;
                    ul.Room_id = rb.Room_id;
                    ul.Email = rb.Email;
                    ul.StartDate = rb.StartDate;
                    ul.EndDate = rb.EndDate;

                    db.RoomBookings.Add(ul);
                    db.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Record Successlly saved"
                    };
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


        [Route("Delete")]
        [HttpDelete]
        public HttpResponseMessage deletecustomerbooking(string Email)
        {
            RoomBooking r = db.RoomBookings.Find(Email);
            Console.WriteLine(r);
            if(r != null)
            {
                db.RoomBookings.Remove(r);
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