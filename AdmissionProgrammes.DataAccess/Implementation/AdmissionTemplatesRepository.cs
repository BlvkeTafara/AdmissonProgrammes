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
    public class AdmissionTemplatesRepository:IAdmissionTemplatesRepository 
    {
        private readonly AdmissionProgrammesDbContext _context;
        private readonly IMapper _mapper;
        public AdmissionTemplatesRepository(AdmissionProgrammesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(AdmissionTemplatesDto dto)
        {
            var entity = _mapper.Map<AdmissionTemplates>(dto);
            _context.AdmissionTemplates.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<AdmissionTemplatesDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<AdmissionTemplates>>(dto);
            _context.AdmissionTemplates.AddRange(entities);
        }

        public IEnumerable<AdmissionTemplatesDto> GetAll()
        {
            var entities = _context.AdmissionTemplates.ToList();
            var Dtos = _mapper.Map<IEnumerable<AdmissionTemplatesDto>>(entities);
            return Dtos;
        }

        public AdmissionTemplatesDto GetById(int id)
        {
            var entity = _context.AdmissionTemplates.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<AdmissionTemplatesDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var admissionTemplatesdel = _context.AdmissionTemplates.Where(admissionTemplate => admissionTemplate.Id == id).FirstOrDefault();

            _context.AdmissionTemplates.Remove(admissionTemplatesdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<AdmissionTemplatesDto> entities)
        {
            var enttities = _context.AdmissionTemplates.ToList();
            var Dtos = _mapper.Map<IEnumerable<AdmissionTemplatesDto>>(entities);
        }

        public void Update(AdmissionTemplatesDto  dto)
        {
            var admissionTemplatesupt = _context.AdmissionTemplates.Where(admissionTemplate => admissionTemplate.Id == dto.Id).FirstOrDefault();

            if (admissionTemplatesupt != null)
            {
                admissionTemplatesupt.ProgrammeTypeId = dto.ProgrammeTypeId;
                admissionTemplatesupt.Name = dto.Name;
                admissionTemplatesupt.Status = dto.Status;
            }
            _context.SaveChanges();
        }
    }
}
