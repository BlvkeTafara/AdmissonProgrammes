using AdmissionProgrammes.Domain.DTOs;
using AdmissionProgrammes.Domain.Entities;
using AdmissionProgrammes.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionProgrammes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammesController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        public ProgrammesController(IUnitOfWorkRepository unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var programmesFromRepo = _unitOfWork.Programmes.GetAll();
            return Ok(programmesFromRepo);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var programmesFromRepo = _unitOfWork.Programmes.GetById(id);
            return Ok(programmesFromRepo);
        }
        [HttpPost("Create")]
        public ActionResult Post(ProgrammesDto data)
        {
            _unitOfWork.Programmes.Add(data);
            return Ok();
        }
        [HttpPut("Update")]
        public ActionResult Put(ProgrammesDto data)
        {
            _unitOfWork.Programmes.Update(data);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _unitOfWork.Programmes.Remove(id);
            return Ok();
        }

    }
}
