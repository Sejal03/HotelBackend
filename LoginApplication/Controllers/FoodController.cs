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
    [RoutePrefix("Api/Food")]
    public class FoodController : ApiController
    {
        ProjectEntities4 db = new ProjectEntities4();

        [Route("foodmenu")]
        // GET api/<controller>
        public IEnumerable<FoodMenu> Get()
        {
            
            var list = db.FoodMenu.Where(m => m.available == true);
            return list;

        }
        [Route("foodbyid")]
        [HttpGet]
        public FoodMenu getbyid(int Food_Id)
        {
            return db.FoodMenu.Find(Food_Id);
        }

        [Route("foodmenuadmin")]
        [HttpGet]
        // GET api/<controller>
        public IEnumerable<FoodMenu> Getfood()
        {

           
            return db.FoodMenu.ToList();

        }

        [Route("insertfood")]
        [HttpPost]
        public object insertfood( FoodMenu fm)
        {

            db.FoodMenu.Add(fm);
            db.SaveChanges();
            return new Response
            {
                Status = "Success",
                Message = "Data Add"

            };
            
           
        }

        [Route("Add")]
      [HttpPost]
      public object addorupdatefood(Food fm)
        { 
            try
            {
                
                if (fm.Food_Id == 0)
                {
                    FoodMenu c = new FoodMenu();
                    c.Name = fm.Name;
                    c.Price = fm.Price;
                    c.available = fm.available;
                    db.FoodMenu.Add(c);
                    db.SaveChanges();

                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Add"
                    };
                }
                else
                {
                    var obj = db.FoodMenu.Where(x => x.Food_Id == fm.Food_Id).ToList().FirstOrDefault();
                    if(obj.Food_Id > 0)
                    {
                        obj.Name = fm.Name;
                        obj.Price = fm.Price;
                        obj.available = fm.available;
                        db.SaveChanges();
                       
                    }
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Add"
                    };
                }
            }
            catch
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Error"
                };
            }
           
        }
        [Route("Update")]
        [HttpPut]
        public object updatefood(int Food_Id, FoodMenu fm)
        {
            try
            {

                if ( Food_Id == fm.Food_Id)
                {
                    db.Entry(fm).State = System.Data.Entity.EntityState.Modified;

                    db.SaveChanges();
                    return new Response
                    {
                        Status = "Success",
                        Message = "Data Add"
                    };
                }
                else
                {
                    return new Response
                    {
                        Status = "Not Found",
                        Message = "Not Found"
                    };
                }
                

            }
            catch
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Error"
                };
            }

        }
    }
}