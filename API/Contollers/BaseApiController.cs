using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{               
    //derived from ControllerBase class, Base class for MVC controller (Model, View, Controller); In an API contoller we don't return a view but an HTTP response
    [ApiController]
    [Route("api/[controller]")] // api/users, Angular client will hit this controller and endpoints
    public class BaseApiController : ControllerBase
    {

    }
}