using System.Dynamic;
using System.Web.Mvc;

namespace CycoPath.Controllers
{
    public class TrackMeController : Controller
    {
        public ActionResult Index()
        {
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