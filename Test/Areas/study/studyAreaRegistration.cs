using System.Web.Mvc;

namespace Test.Areas.study
{
    public class studyAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "study";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "study_default",
                "study/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
