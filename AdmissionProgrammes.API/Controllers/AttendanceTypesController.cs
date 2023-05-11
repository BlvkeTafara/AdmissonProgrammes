using AdmissionProgrammes.Domain.DTOs;
using AdmissionProgrammes.Domain.Entities;
using AdmissionProgrammes.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionProgrammes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceTypesController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public AttendanceTypesController(IUnitOfWorkRepository unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var attendancetypesFromRepo = _unitOfWork.AttendanceTypes.GetAll();
            return Ok(attendancetypesFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var attendancetypesFromRepo = _unitOfWork.AttendanceTypes.GetById(id);
            return Ok(attendancetypesFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(AttendanceTypesDto data)
        {
            _unitOfWork.AttendanceTypes.Add(data);
            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(AttendanceTypesDto data)
        {
            _unitOfWork.AttendanceTypes.Update(data);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.AttendanceTypes.Remove(id);
            return Ok();
        }

    }
}
