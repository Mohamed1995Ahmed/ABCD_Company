using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

public class HandelAnyExceptionAttribute : Attribute, IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        string errorMsg = "An unexpected error occurred.";

        if (context.Exception is DbUpdateException dbEx &&
            dbEx.InnerException?.Message.Contains("REFERENCE constraint") == true)
        {
            errorMsg = "You cannot delete a department that still has employees assigned.";
        }

        var viewResult = new ViewResult
        {
            ViewName = "Error"
        };

        viewResult.ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(
            new Microsoft.AspNetCore.Mvc.ModelBinding.EmptyModelMetadataProvider(),
            context.ModelState)
            {
                { "ExceptionMessage", errorMsg }
            };

        context.Result = viewResult;
        context.ExceptionHandled = true;
    }
}