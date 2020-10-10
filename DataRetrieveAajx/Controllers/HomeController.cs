using DataRetrieveAajx.Entitiess;
using DataRetrieveAajx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace DataRetrieveAajx.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public JsonResult GetData()
        {
            using (var dbContext = new Entities())
            {
                List<UserDetail> userDetails = dbContext.UserDetails.ToList();
                List<CarDetail> carDetails = dbContext.CarDetails.ToList();
                List<UserDetailModel> userViewModels = new List<UserDetailModel>();
                foreach (var user in userDetails)
                {

                    var data = new UserDetailModel
                    {

                        UserId = user.UserId,
                        FullName = user.FullName,
                        UserEmail = user.UserEmail,
                        CivilIdNumber = user.CivilIdNumber,


                    };

                    var cardetails = string.Join(",", carDetails.Where(x => x.UserId == user.UserId).Select(y => y.CarLicense).ToList());

                    data.CarLicense = cardetails;


                    userViewModels.Add(data);

                }
                userViewModels = userViewModels.Where(x => x.CarLicense != "").ToList();
                return Json(new { data = userViewModels }, JsonRequestBehavior.AllowGet);





            }

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
    }
}