using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TestApp.Core.Application;

namespace TestApp.MVC.Filters
{
    public class ValidationFilter :  ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ErrorView error = new ErrorView();
                error.Status = 400;

                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(x=>x.Errors);

                modelErrors.ToList().ForEach(x =>
                {
                    error.Errors.Add(x.ErrorMessage);
                });

                
                context.Result = new ViewResult{};
                
            }
            
        }
        
    }
}
