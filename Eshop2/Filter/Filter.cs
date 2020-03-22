using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;


namespace Eshop2.Filter
{
    public class LogincheckAuthorizer : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
           if(HttpContext.Current.Session["username"] == null)
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(new
                {
                    controller = "Product",
                    action = "ProductList"
                }));
        }
    }
}