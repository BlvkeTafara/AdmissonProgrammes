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
    public class ProgrammesRepository:IProgrammesRepository 
    {
        private readonly AdmissionProgrammesDbContext _context;
        private readonly IMapper _mapper;
        public ProgrammesRepository(AdmissionProgrammesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(ProgrammesDto dto)
        {
            var entity = _mapper.Map<Programmes>(dto);
            _context.Programmes.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<ProgrammesDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<Programmes>>(dto);
            _context.Programmes.RemoveRange(entities);
        }

        public IEnumerable<ProgrammesDto> GetAll()
        {
            var entities = _context.Programmes.ToList();
            var Dtos = _mapper.Map<IEnumerable<ProgrammesDto>>(entities);
            return Dtos;
        }

        public ProgrammesDto GetById(int id)
        {
            var entity = _context.Programmes.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<ProgrammesDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var programmesdel = _context.Programmes.Where(programme => programme.Id == id).FirstOrDefault();

            _context.Programmes.Remove(programmesdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<ProgrammesDto> entities)
        {
            var entitties = _context.Programmes.ToList();
            var Dtos = _mapper.Map<IEnumerable<ProgrammesDto>>(entities);
        }

        public void Update(ProgrammesDto dto)
        {
            var programmesupt = _context.Programmes.Where(programme => programme.Id == dto.Id).FirstOrDefault();

            if (programmesupt != null)
            {
                programmesupt.Description = dto.Description;
                programmesupt.Code = dto.Code;
                programmesupt.ProgrammeTypeId = dto.ProgrammeTypeId;
            }
            _context.SaveChanges();
        }
    }
}
