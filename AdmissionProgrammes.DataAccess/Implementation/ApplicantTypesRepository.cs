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
    public class ApplicantTypesRepository:IApplicantTypesRepository 
    {
        private readonly AdmissionProgrammesDbContext _context;
        private readonly IMapper _mapper;
        public ApplicantTypesRepository(AdmissionProgrammesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(ApplicantTypesDto dto)
        {
            var entity = _mapper.Map<ApplicantTypes>(dto);
            _context.ApplicantTypes.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<ApplicantTypesDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<ApplicantTypes>>(dto);
            _context.ApplicantTypes.AddRange(entities);
        }

        public IEnumerable<ApplicantTypesDto> GetAll()
        {
            var entities = _context.ApplicantTypes.ToList();
            var Dtos = _mapper.Map<IEnumerable<ApplicantTypesDto>>(entities);
            return Dtos;
        }

        public ApplicantTypesDto GetById(int id)
        {
            var entity = _context.ApplicantTypes.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<ApplicantTypesDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var applicantTypesdel = _context.ApplicantTypes.Where(applicantType => applicantType.Id == id).FirstOrDefault();

            _context.ApplicantTypes.Remove(applicantTypesdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<ApplicantTypesDto> entities)
        {
            var entitties = _context.ApplicantTypes.ToList();
            var Dtos = _mapper.Map<IEnumerable<ApplicantTypesDto>>(entities);
        }

        public void Update(ApplicantTypesDto dto)
        {
            var applicantTypesupt = _context.ApplicantTypes.Where(applicantType => applicantType.Id == dto.Id).FirstOrDefault();

            if (applicantTypesupt != null)
            {
                applicantTypesupt.Name = dto.Name;
            }
            _context.SaveChanges();
        }
    }
}
