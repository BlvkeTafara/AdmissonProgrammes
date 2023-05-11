using AdmissionProgrammes.Domain.DTOs;
using AdmissionProgrammes.Domain.Entities;
using AdmissionProgrammes.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionProgrammes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammesTypesController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public ProgrammesTypesController(IUnitOfWorkRepository unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var programmetypesFromRepo = _unitOfWork.ProgrammeTypes.GetAll();
            return Ok(programmetypesFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var programmetypesFromRepo = _unitOfWork.ProgrammeTypes.GetById(id);
            return Ok(programmetypesFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(ProgrammeTypesDto data)
        {
            _unitOfWork.ProgrammeTypes.Add(data);
            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(ProgrammeTypesDto data)
        {
            _unitOfWork.ProgrammeTypes.Update(data);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.ProgrammeTypes.Remove(id);
            return Ok();
        }

    }
}
