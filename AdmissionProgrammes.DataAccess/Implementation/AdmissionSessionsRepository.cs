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
     public class AdmissionSessionsRepository:IAdmissionSessionsRepository
    {
        private readonly AdmissionProgrammesDbContext _context;
        private readonly IMapper _mapper;
        public AdmissionSessionsRepository(AdmissionProgrammesDbContext context, IMapper mapper)
        {
            _context= context;
            _mapper= mapper;
        }

        public void Add(AdmissionSessionsDto dto)
        {
            var entity = _mapper.Map<AdmissionSessions>(dto);
            _context.AdmissionSessions.Add(entity);
            _context.SaveChanges();
           
        }

        public void AddRange(IEnumerable<AdmissionSessionsDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<AdmissionSessions>>(dto);
            _context.AdmissionSessions.AddRange(entities);
            

        }

        public IEnumerable<AdmissionSessionsDto> GetAll()
        {
            var entities = _context.AdmissionSessions.ToList();
            var Dtos = _mapper.Map<IEnumerable<AdmissionSessionsDto>>(entities);
            return Dtos;
            
        }

        public AdmissionSessionsDto GetById(int id)
        {
            var entity = _context.AdmissionSessions.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<AdmissionSessionsDto>(entity);
            return dto;
            
        }

        public void Remove(int id)
        {
            var admissionSessionsdel = _context.AdmissionSessions.Where(admissionSession => admissionSession.Id == id).FirstOrDefault();

            _context.AdmissionSessions.Remove(admissionSessionsdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<AdmissionSessionsDto> entities)
        {
            var entitties = _context.AdmissionSessions.ToList();
            var Dtos = _mapper.Map<IEnumerable<AdmissionSessionsDto>>(entities);
            
        }

        public void Update(AdmissionSessionsDto dto)
        {
            var admissionSessionsupt = _context.AdmissionSessions.Where(admissionSession => admissionSession.Id == dto.Id).FirstOrDefault();

            if (admissionSessionsupt != null)
            {
                admissionSessionsupt.Year = dto.Year;
                admissionSessionsupt.StartDate = dto.StartDate;
                admissionSessionsupt.EndDate = dto.EndDate;
                admissionSessionsupt.IsPublished = dto.IsPublished;
                admissionSessionsupt.Name = dto.Name;
            }
            _context.SaveChanges();
        }
    }
}
