using MongoDB.Driver;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using WebApplication2.Models;
using MongoDB.Bson;
namespace WebApplication2.Controllers
{
   

    public class HomeController : Controller
    {
        public static bool IsLogged = false;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {           
            //ViewBag.Message = "Your Login page.";
            return View();
        }


        [HttpPost]

        public ActionResult Login(UserAdd usr, Login lgn)
        {
            var mail = lgn.Email;
            var parola = lgn.Parola;  
            if (ModelState.IsValid)
            {
                string constr = ConfigurationManager.AppSettings["connectionString"];
                var Client = new MongoClient(constr);
                var DB = Client.GetDatabase("Shop");
                var collection = DB.GetCollection<UserAdd>("Conturi");
                var filtru = Builders<UserAdd>.Filter.Eq("Email", mail);
                var filtru2 = Builders<UserAdd>.Filter.Eq("Parola", parola);

                if ((mail == "admin") && (parola == "123")) return RedirectToAction("Admin");
                else
                if ((collection.Find(filtru).FirstOrDefault() != null) && (collection.Find(filtru2).FirstOrDefault() != null))
                {
                    IsLogged = true;
                    return RedirectToAction("Welcome");                                   
                }

                else return RedirectToAction("Login");


            }
            return View();
        }

        public ActionResult Welcome()
        {
            ViewBag.message = IsLogged;

            return View();
        }
        public ActionResult Create()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Message = "Your administration page.";

            return View();
        }


        [HttpPost]
        public ActionResult Create(UserAdd usr)
        {
            if (ModelState.IsValid)
            {
                string constr = ConfigurationManager.AppSettings["connectionString"];
                var Client = new MongoClient(constr);
                var DB = Client.GetDatabase("Shop");
                var collection = DB.GetCollection<UserAdd>("Conturi");
                collection.InsertOneAsync(usr);
                return RedirectToAction("Login");

            }
            return View();
        }


    }
}