using AdmissionProgrammes.Domain.DTOs;
using AdmissionProgrammes.Domain.Entities;
using AdmissionProgrammes.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionProgrammes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionProgrammezController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public AdmissionProgrammezController(IUnitOfWorkRepository unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var admissionprogrammezFromRepo = _unitOfWork.AdmissionProgrammez.GetAll();
            return Ok(admissionprogrammezFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var admissionprogrammezFromRepo = _unitOfWork.AdmissionProgrammez.GetById(id);
            return Ok(admissionprogrammezFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(AdmissionProgrammezDto data)
        {
            _unitOfWork.AdmissionProgrammez.Add(data);
            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(AdmissionProgrammezDto data)
        {
            _unitOfWork.AdmissionProgrammez.Update(data);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.AdmissionProgrammez.Remove(id);
            return Ok();
        }

    }
}
