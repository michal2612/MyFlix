using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.ComponentModel.DataAnnotations; 

namespace Webb.Controllers
{
    internal class TokenAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Request.Cookies["token"];
            if(String.IsNullOrEmpty(token))
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login" }));

        }
    }
}