using AdmissionProgrammes.Domain.DTOs;
using AdmissionProgrammes.Domain.Entities;
using AdmissionProgrammes.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionProgrammes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionFeesController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public AdmissionFeesController(IUnitOfWorkRepository unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var admissionfeesFromRepo = _unitOfWork.AdmissionFees.GetAll ();
            return Ok(admissionfeesFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var admissionfeesFromRepo = _unitOfWork.AdmissionFees.GetById (id);
            return Ok(admissionfeesFromRepo);
        }
        [HttpPost ("Create")]
        public ActionResult Post(AdmissionFeesDto data)
        {
            _unitOfWork.AdmissionFees.Add(data);
                return Ok();
        }
        [HttpPut ("Update")]
        public ActionResult Put(AdmissionFeesDto data)
        {
            _unitOfWork.AdmissionFees.Update(data);
            return Ok();
        }
        [HttpDelete ("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.AdmissionFees.Remove(id);
            return Ok();    
        }

    }
}
