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
    public class ApplicantPaymentsRepository:IApplicantPaymentsRepository 
    {
        private readonly AdmissionProgrammesDbContext _context;
        private readonly IMapper _mapper;
        public ApplicantPaymentsRepository(AdmissionProgrammesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(ApplicantPaymentsDto dto)
        {
            var entity = _mapper.Map<ApplicantPayments>(dto);
            _context.ApplicantPayments.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<ApplicantPaymentsDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<ApplicantPayments>>(dto);
            _context.ApplicantPayments.AddRange(entities);
        }

        public IEnumerable<ApplicantPaymentsDto> GetAll()
        {
            var entities = _context.ApplicantPayments.ToList();
            var Dtos = _mapper.Map<IEnumerable<ApplicantPaymentsDto>>(entities);
            return Dtos;
         
        }

        public ApplicantPaymentsDto GetById(int id)
        {
            var entity = _context.ApplicantPayments.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<ApplicantPaymentsDto>(entity);
            return dto;
            
        }

        public void Remove(int id)
        {
            var applicantPaymentsdel = _context.ApplicantPayments.Where(applicantPayment => applicantPayment.Id == id).FirstOrDefault();

            _context.ApplicantPayments.Remove(applicantPaymentsdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<ApplicantPaymentsDto> entities)
        {
            var entitties = _context.ApplicantPayments.ToList();
            var Dtos = _mapper.Map<IEnumerable<ApplicantPaymentsDto>>(entities);
        }

        public void Update(ApplicantPaymentsDto dto)
        {
            var applicantPaymentsupt = _context.ApplicantPayments.Where(applicantPayment => applicantPayment.Id == dto.Id).FirstOrDefault();

            if (applicantPaymentsupt != null)
            {
                applicantPaymentsupt.Pollurl = dto.Pollurl;
                applicantPaymentsupt.Status = dto.Status;
                applicantPaymentsupt.ApplicantUserId = dto.ApplicantUserId;
                applicantPaymentsupt.UpdateDate = DateTime.Now;
                applicantPaymentsupt.CreateDate = DateTime.Now;
                applicantPaymentsupt.CurrencyId = dto.CurrencyId;
                applicantPaymentsupt.ApplicationId = dto.ApplicationId;
            }
            _context.SaveChanges();
        }
    }
}
