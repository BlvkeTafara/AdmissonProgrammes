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
    public class ProgrammeTypesRepository:IProgrammeTypesRepository 
    {
        private readonly AdmissionProgrammesDbContext _context;
        private readonly IMapper _mapper;
        public ProgrammeTypesRepository(AdmissionProgrammesDbContext context, IMapper  mapper)
        {
            _context = context; 
            _mapper = mapper;
        }

        public void Add(ProgrammeTypesDto dto)
        {
            var entity = _mapper.Map<ProgrammeTypes>(dto);
            _context.ProgrammeTypes.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<ProgrammeTypesDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<ProgrammeTypes>>(dto);
            _context.ProgrammeTypes.AddRange(entities);
        }

        public IEnumerable<ProgrammeTypesDto> GetAll()
        {
            var entities = _context.ProgrammeTypes.ToList();
            var Dtos = _mapper.Map<IEnumerable<ProgrammeTypesDto>>(entities);
            return Dtos;
        }

        public ProgrammeTypesDto GetById(int id)
        {
            var entity = _context.ProgrammeTypes.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<ProgrammeTypesDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var programmeTypesdel = _context.ProgrammeTypes.Where(programmeType => programmeType.Id == id).FirstOrDefault();

            _context.ProgrammeTypes.Remove(programmeTypesdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<ProgrammeTypesDto> entities)
        {
            var entitties = _context.ProgrammeTypes.ToList();
            var Dtos = _mapper.Map<IEnumerable<ProgrammeTypesDto>>(entities);
        }

        public void Update(ProgrammeTypesDto dto)
        {
            var programmeTypesupt = _context.ProgrammeTypes.Where(programmeType => programmeType.Id == dto.Id).FirstOrDefault();

            if (programmeTypesupt != null)
            {
                programmeTypesupt.Name = dto.Name;
            }
            _context.SaveChanges();
        }
    }
}
