using AdmissionProgrammes.Domain.DTOs;
using AdmissionProgrammes.Domain.Entities;
using AdmissionProgrammes.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionProgrammes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantTypesController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public ApplicantTypesController(IUnitOfWorkRepository unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var applicanttypesFromRepo = _unitOfWork.ApplicantTypes.GetAll();
            return Ok(applicanttypesFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var applicanttypesFromRepo = _unitOfWork.ApplicantTypes.GetById(id);
            return Ok(applicanttypesFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(ApplicantTypesDto data)
        {
            _unitOfWork.ApplicantTypes.Add(data);
            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(ApplicantTypesDto data)
        {
            _unitOfWork.ApplicantTypes.Update(data);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.ApplicantTypes.Remove(id);
            return Ok();
        }

    }
}
