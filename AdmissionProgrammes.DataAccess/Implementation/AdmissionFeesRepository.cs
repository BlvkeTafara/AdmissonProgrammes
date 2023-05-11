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
    public class AdmissionFeesRepository:IAdmissionFeesRepository 
    {
        private readonly AdmissionProgrammesDbContext _context;
        private readonly IMapper _mapper;
        public AdmissionFeesRepository(AdmissionProgrammesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(AdmissionFeesDto dto)
        {
            var entity = _mapper.Map<AdmissionFees>(dto);
            _context.AdmissionFees.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<AdmissionFeesDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<AdmissionFees>>(dto);
            _context.AdmissionFees.AddRange(entities);
            
        }

        public IEnumerable<AdmissionFeesDto> GetAll()
        {
            var entities = _context.AdmissionFees.ToList();
            var Dtos = _mapper.Map<IEnumerable<AdmissionFeesDto>>(entities);
            return Dtos;
            
        }

        public AdmissionFeesDto GetById(int id)
        {
            var entity = _context.AdmissionFees.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<AdmissionFeesDto>(entity);
            return dto;
            
        }

        public void Remove(int id)
        {
            var admissionFeesdel = _context.AdmissionFees.Where(admissionFee => admissionFee.Id == id).FirstOrDefault();

            _context.AdmissionFees.Remove(admissionFeesdel);
            _context.SaveChanges();
            
        }

        public void RemoveRange(IEnumerable<AdmissionFeesDto> entities)
        {
            var entitties = _context.AdmissionFees.ToList();
            var Dtos = _mapper.Map<IEnumerable<AdmissionFeesDto>>(entities);
            
        }

        public void Update(AdmissionFeesDto dto)
        {
            var admissionFeesupt = _context.AdmissionFees.Where(admissionFee => admissionFee.Id == dto.Id).FirstOrDefault();

            if (admissionFeesupt != null)
            {
                admissionFeesupt.ApplicantTypeId = dto.ApplicantTypeId;
                admissionFeesupt.ProgrammeTypeId = dto.ProgrammeTypeId;
                admissionFeesupt.CurrencyId = dto.CurrencyId;
                admissionFeesupt.Amount = dto.Amount;

            }
            _context.SaveChanges();
        }
    }
}
