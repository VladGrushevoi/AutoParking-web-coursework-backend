using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("api")]
    public class RegistrationController : ControllerBase
    {
        private RegistrationService regeistrationService;

        public RegistrationController(RegistrationService service)
        {
            this.regeistrationService = service;
        }


        [HttpPost("registration")]
        public ActionResult RegistrationUser([FromBody] Registration registration)
        {
            var user = regeistrationService.RegistrationUser(registration);
            if(user != null)
            {
                return Created("Created new user", user);
            }
            return NotFound();
        }

        [HttpGet("auth")]
        public ActionResult<User> AuthUser([FromBody] Authorization auth)
        {
            var user = regeistrationService.AuthUser(auth);
            if(user != null)
            {
                return Ok(user);
            }
            return NoContent();
        }

        [HttpGet("init")]
        public ActionResult<User> InitUser()
        {
            return Created("Created", regeistrationService.InitClient());
        }
        
    }   
}