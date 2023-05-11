using AdmissionProgrammes.DataAccess.Context;
using AdmissionProgrammes.Domain.DTOs;
using AdmissionProgrammes.Domain.Entities;
using AdmissionProgrammes.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionProgrammes.DataAccess.Implementation
{
    public class ApplicationProgrammesRepository:IApplicationProgrammesRepository 
    {
        private readonly AdmissionProgrammesDbContext _context;
        private readonly IMapper _mapper;
        public ApplicationProgrammesRepository(AdmissionProgrammesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(ApplicationProgrammesDto dto)
        {
            var entity = _mapper.Map<ApplicationProgrammes>(dto);
            _context.ApplicationProgrammes.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<ApplicationProgrammesDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<ApplicationProgrammes>>(dto);
            _context.ApplicationProgrammes.AddRange(entities);
        }

        public IEnumerable<ApplicationProgrammesDto> GetAll()
        {
            var entities = _context.ApplicationProgrammes.ToList();
            var Dtos = _mapper.Map<IEnumerable<ApplicationProgrammesDto>>(entities);
            return Dtos;
        }

        public ApplicationProgrammesDto GetById(int id)
        {
            var entity = _context.ApplicationProgrammes.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<ApplicationProgrammesDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var applicationProgrammesdel = _context.ApplicationProgrammes.Where(applicationProgramme => applicationProgramme.Id == id).FirstOrDefault();

            _context.ApplicationProgrammes.Remove(applicationProgrammesdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<ApplicationProgrammesDto> entities)
        {
            var entitties = _context.ApplicationProgrammes.ToList();
            var Dtos = _mapper.Map<IEnumerable<ApplicationProgrammesDto>>(entities);
        }

        public void Update(ApplicationProgrammesDto dto)
        {
            var applicationProgrammesupt = _context.ApplicationProgrammes.Where(applicationProgramme => applicationProgramme.Id == dto.Id).FirstOrDefault();

            if (applicationProgrammesupt != null)
            {
                applicationProgrammesupt.ApplicationId = dto.ApplicationId;
                applicationProgrammesupt.AdmissionSessionId = dto.AdmissionSessionId;
                applicationProgrammesupt.ProgrammeId = dto.ProgrammeId;
                applicationProgrammesupt.Status = dto.Status;
                applicationProgrammesupt.DateCreated = dto.DateCreated;
                applicationProgrammesupt.DateUpdated = dto.DateUpdated;
                applicationProgrammesupt.Status = dto.Status;
            }
            _context.SaveChanges();
        }
    }
}
