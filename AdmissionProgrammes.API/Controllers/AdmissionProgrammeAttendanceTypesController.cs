using AdmissionProgrammes.Domain.DTOs;
using AdmissionProgrammes.Domain.Entities;
using AdmissionProgrammes.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionProgrammes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionProgrammeAttendanceTypesController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public AdmissionProgrammeAttendanceTypesController(IUnitOfWorkRepository unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var admissionprogrammeattendancetypesFromRepo = _unitOfWork.AdmissionProgrammeAttendanceTypes.GetAll();
            return Ok(admissionprogrammeattendancetypesFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var admissionprogrammeattendancetypesFromRepo = _unitOfWork.AdmissionProgrammeAttendanceTypes.GetById(id);
            return Ok(admissionprogrammeattendancetypesFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(AdmissionProgrammeAttendanceTypesDto data)
        {
            _unitOfWork.AdmissionProgrammeAttendanceTypes.Add(data);
            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(AdmissionProgrammeAttendanceTypesDto data)
        {
            _unitOfWork.AdmissionProgrammeAttendanceTypes.Update(data);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.AdmissionProgrammeAttendanceTypes.Remove(id);
            return Ok();
        }
    }
}
