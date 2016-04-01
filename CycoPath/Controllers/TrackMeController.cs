using System.Dynamic;
using System.Web.Mvc;

namespace CycoPath.Controllers
{
    public class TrackMeController : Controller
    {
        public ActionResult Index(string hiddenTab3)
        {
             if (String.IsNullOrEmpty(hiddenTab3) == false)
            {
                //hidden 3 = lat,long of selected carpark
                HttpContext.Session["selectedCarpark"] = hiddenTab3;

            }
            dynamic ParksPathsModel = new ExpandoObject();
            if (Session["ParksPathsModel"] != null)
            {
                ParksPathsModel = Session["ParksPathsModel"];
            }
            else {
                ParksPathsModel = null;
            }
            return View();
        }

    }
}