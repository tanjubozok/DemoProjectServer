using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace DemoProjectServer.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[EnableQuery]
public class oDataController : ControllerBase
{
    public static IEdmModel GetEdmModel()
    {
        ODataConventionModelBuilder builder = new();
        builder.EnableLowerCamelCase();

        //builder.EntitySet<DemoProjectServer.WebAPI.Models.Product>("Products");

        return builder.GetEdmModel();
    }
}
