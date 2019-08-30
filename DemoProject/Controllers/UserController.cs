using DemoProject.DAL;
using DemoProject.DataContexts;
using DemoProject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class UserController : Controller
    {
        private EntityContext db = new EntityContext();
        // GET: User
        public ActionResult Register()
        {
            //var CountryList = db.CountryDB.ToList();
            //var StateList = db.StateDB.ToList();
            //var CityList = db.CityDB.ToList();
            //var auto = AutoMapper.Mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(CountryList);

            return View();
        }
    }
}