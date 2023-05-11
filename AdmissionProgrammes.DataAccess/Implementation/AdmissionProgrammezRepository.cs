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
    public class AdmissionProgrammezRepository:IAdmissionProgrammezRepository 
    {
        private readonly AdmissionProgrammesDbContext _context;
        private readonly IMapper _mapper;
        public AdmissionProgrammezRepository(AdmissionProgrammesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(AdmissionProgrammezDto dto)
        {
            var entity = _mapper.Map<AdmissionProgrammez>(dto);
            _context.AdmissionProgrammezs.Add(entity);
            _context.SaveChanges();
            
        }

        public void AddRange(IEnumerable<AdmissionProgrammezDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<AdmissionProgrammez>>(dto);
            _context.AdmissionProgrammezs.AddRange(entities);
            
        }

        public IEnumerable<AdmissionProgrammezDto> GetAll()
        {
            var entities = _context.AdmissionProgrammezs.ToList();
            var Dtos = _mapper.Map<IEnumerable<AdmissionProgrammezDto>>(entities);
            return Dtos;
           
        }

        public AdmissionProgrammezDto GetById(int id)
        {
            var entity = _context.AdmissionProgrammezs.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<AdmissionProgrammezDto>(entity);
            return dto;
            
        }

        public void Remove(int id)
        {
            var admissionProgrammezdel = _context.AdmissionProgrammezs.Where(admissionProgrammez => admissionProgrammez.Id == id).FirstOrDefault();

            _context.AdmissionProgrammezs.Remove(admissionProgrammezdel);
            _context.SaveChanges();
            
        }

        public void RemoveRange(IEnumerable<AdmissionProgrammezDto> dto)
        {
            var entitties = _context.AdmissionProgrammezs.ToList();
            var Dtos = _mapper.Map<IEnumerable<AdmissionProgrammezDto>>(dto);
           
        }

        public void Update(AdmissionProgrammezDto dto)
        {
            var admissionProgrammezupt = _context.AdmissionProgrammezs.Where(admissionProgrammez => admissionProgrammez.Id == dto.Id).FirstOrDefault();

            if (admissionProgrammezupt != null)
            {
                admissionProgrammezupt.EntryRequirements = dto.EntryRequirements;
                admissionProgrammezupt.CareerProspects = dto.CareerProspects;
                admissionProgrammezupt.ProgrammeId = dto.ProgrammeId;
                admissionProgrammezupt.AdmissionTemplateId = dto.AdmissionTemplateId;
            }
            _context.SaveChanges();
        }
    }
}
