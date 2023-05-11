using AdmissionProgrammes.Domain.DTOs;
using AdmissionProgrammes.Domain.Entities;
using AdmissionProgrammes.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionProgrammes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantPaymentsController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public ApplicantPaymentsController(IUnitOfWorkRepository unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var applicantpaymentsFromRepo = _unitOfWork.ApplicantPayments.GetAll();
            return Ok(applicantpaymentsFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var applicantpaymentsFromRepo = _unitOfWork.ApplicantPayments.GetById(id);
            return Ok(applicantpaymentsFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(ApplicantPaymentsDto data)
        {
            _unitOfWork.ApplicantPayments.Add(data);
            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(ApplicantPaymentsDto data)
        {
            _unitOfWork.ApplicantPayments.Update(data);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.ApplicantPayments.Remove(id);
            return Ok();
        }

    }
}
