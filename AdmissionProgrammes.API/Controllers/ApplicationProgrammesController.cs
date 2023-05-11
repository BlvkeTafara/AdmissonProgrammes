using AdmissionProgrammes.Domain.DTOs;
using AdmissionProgrammes.Domain.Entities;
using AdmissionProgrammes.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionProgrammes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationProgrammesController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public ApplicationProgrammesController(IUnitOfWorkRepository unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var applicationprogrammesFromRepo = _unitOfWork.ApplicationProgrammes.GetAll();
            return Ok(applicationprogrammesFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var applicationprogrammesFromRepo = _unitOfWork.ApplicationProgrammes.GetById(id);
            return Ok(applicationprogrammesFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(ApplicationProgrammesDto data)
        {
            _unitOfWork.ApplicationProgrammes.Add(data);
            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(ApplicationProgrammesDto data)
        {
            _unitOfWork.ApplicationProgrammes.Update(data);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.ApplicationProgrammes.Remove(id);
            return Ok();
        }

    }
}
