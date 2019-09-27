
namespace Generic.Controllers
{
    using Generic.Storage.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System;

    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        private readonly IUnitOfWork UnitOfWork;

        public GenericController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpGet]
        [Route("{name}")]
        public ActionResult SayHi(string name)
        {
            return Ok(UnitOfWork.SayHi(name));
        }
        
    }
}