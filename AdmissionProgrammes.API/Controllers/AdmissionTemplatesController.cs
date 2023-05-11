using AdmissionProgrammes.Domain.DTOs;
using AdmissionProgrammes.Domain.Entities;
using AdmissionProgrammes.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionProgrammes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionTemplatesController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public AdmissionTemplatesController(IUnitOfWorkRepository unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var admissiontemplatesFromRepo = _unitOfWork.AdmissionTemplates.GetAll();
            return Ok(admissiontemplatesFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var admissiontemplatesFromRepo = _unitOfWork.AdmissionTemplates.GetById(id);
            return Ok(admissiontemplatesFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(AdmissionTemplatesDto data)
        {
            _unitOfWork.AdmissionTemplates.Add(data);
            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(AdmissionTemplatesDto data)
        {
            _unitOfWork.AdmissionTemplates.Update(data);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.AdmissionTemplates.Remove(id);
            return Ok();
        }

    }
}
