using AdmissionProgrammes.Domain.DTOs;
using AdmissionProgrammes.Domain.Entities;
using AdmissionProgrammes.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionProgrammes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public ApplicationsController(IUnitOfWorkRepository unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var applicationsFromRepo = _unitOfWork.Applications.GetAll();
            return Ok(applicationsFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var applicationsFromRepo = _unitOfWork.Applications.GetById(id);
            return Ok(applicationsFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(ApplicationsDto data)
        {
            _unitOfWork.Applications.Add(data);
            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(ApplicationsDto data)
        {
            _unitOfWork.Applications.Update(data);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.Applications.Remove(id);
            return Ok();
        }

    }
}
