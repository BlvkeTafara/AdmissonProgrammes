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
    public class ApplicationsRepository:IApplicationsRepository 
    {
        private readonly AdmissionProgrammesDbContext _context;
        private readonly IMapper _mapper;
        public ApplicationsRepository(AdmissionProgrammesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(ApplicationsDto dto)
        {
            var entity = _mapper.Map<Applications>(dto);
            _context.Applications.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<ApplicationsDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<Applications>>(dto);
            _context.Applications.AddRange(entities);
        }

        public IEnumerable<ApplicationsDto> GetAll()
        {
            var entities = _context.Applications.ToList();
            var Dtos = _mapper.Map<IEnumerable<ApplicationsDto>>(entities);
            return Dtos;
        }

        public ApplicationsDto GetById(int id)
        {
            var entity = _context.Applications.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<ApplicationsDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var applicationsdel = _context.Applications.Where(application => application.Id == id).FirstOrDefault();

            _context.Applications.Remove(applicationsdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<ApplicationsDto> entities)
        {
            var entitties = _context.Applications.ToList();
            var Dtos = _mapper.Map<IEnumerable<ApplicationsDto>>(entities);
        }

        public void Update(ApplicationsDto dto)
        {
            var applicationsupt = _context.Applications.Where(application => application.Id == dto.Id).FirstOrDefault();

            if (applicationsupt != null)
            {
                applicationsupt.AppNumber = dto.AppNumber;
                applicationsupt.ApprovalStatus = dto.ApprovalStatus;
                applicationsupt.ApplicantUserId = dto.ApplicantUserId;
                applicationsupt.DateUpdated = dto.DateUpdated;
                applicationsupt.DateCreated = dto.DateCreated;
                applicationsupt.ApplicantTypeId = dto.ApplicantTypeId;
                applicationsupt.PaymentStatus = dto.PaymentStatus;
                applicationsupt.AdmissionSessionId = dto.AdmissionSessionId;
                applicationsupt.Uuid = dto.Uuid;
                applicationsupt.CampusId = dto.CampusId;
                applicationsupt.ProgrammeTypeId = dto.ProgrammeTypeId;
            }
            _context.SaveChanges();
        }
    }
}
