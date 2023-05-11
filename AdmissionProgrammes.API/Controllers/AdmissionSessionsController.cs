using AdmissionProgrammes.Domain.DTOs;
using AdmissionProgrammes.Domain.Entities;
using AdmissionProgrammes.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionProgrammes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionSessionsController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public AdmissionSessionsController(IUnitOfWorkRepository unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var admissionfeesFromRepo = _unitOfWork.AdmissionFees.GetAll();
            return Ok(admissionfeesFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var admissionsessionsFromRepo = _unitOfWork.AdmissionSessions.GetById(id);
            return Ok(admissionsessionsFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(AdmissionSessionsDto data)
        {
            _unitOfWork.AdmissionSessions.Add(data);
            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(AdmissionSessionsDto data)
        {
            _unitOfWork.AdmissionSessions.Update(data);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.AdmissionSessions.Remove(id);
            return Ok();
        }

    }
}
