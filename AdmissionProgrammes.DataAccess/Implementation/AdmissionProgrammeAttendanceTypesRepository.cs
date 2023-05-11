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
    public class AdmissionProgrammeAttendanceTypesRepository:IAdmissionProgrammeAttendanceTypesRepository 
    {
        private readonly AdmissionProgrammesDbContext _context;
        private readonly IMapper _mapper;
        public AdmissionProgrammeAttendanceTypesRepository(AdmissionProgrammesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(AdmissionProgrammeAttendanceTypesDto dto)
        {
            var entity = _mapper.Map<AdmissionProgrammeAttendanceTypes>(dto);
            _context.AdmissionProgrammeAttendanceTypes.Add(entity);
            _context.SaveChanges();
            
        }

        public void AddRange(IEnumerable<AdmissionProgrammeAttendanceTypesDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<AdmissionProgrammeAttendanceTypes>>(dto);
            _context.AdmissionProgrammeAttendanceTypes.AddRange(entities);
            
        }

        public IEnumerable<AdmissionProgrammeAttendanceTypesDto> GetAll()
        {
            var entities = _context.AdmissionProgrammeAttendanceTypes.ToList();
            var Dtos = _mapper.Map<IEnumerable<AdmissionProgrammeAttendanceTypesDto>>(entities);
            return Dtos;
            
        }

        public AdmissionProgrammeAttendanceTypesDto GetById(int id)
        {
            
            var entity = _context.AdmissionProgrammeAttendanceTypes.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<AdmissionProgrammeAttendanceTypesDto>(entity);
            return dto;
           
        }

        public void Remove(int id)
        {
            var admissionProgrammeAttendanceTypesdel = _context.AdmissionProgrammeAttendanceTypes.Where(admissionProgrammeAttendanceType => admissionProgrammeAttendanceType.Id == id).FirstOrDefault();

            _context.AdmissionProgrammeAttendanceTypes.Remove(admissionProgrammeAttendanceTypesdel);
            _context.SaveChanges();
            
        }

        public void RemoveRange(IEnumerable<AdmissionProgrammeAttendanceTypesDto> entities)
        {
            var entitties = _context.AdmissionProgrammeAttendanceTypes.ToList();
            var Dtos = _mapper.Map<IEnumerable<AdmissionProgrammeAttendanceTypesDto>>(entities);
            
        }

        public void Update(AdmissionProgrammeAttendanceTypesDto dto)
        {
            var admissionProgrammeAttendanceTypesupt = _context.AdmissionProgrammeAttendanceTypes.Where(admissionProgrammeAttendanceType => admissionProgrammeAttendanceType.Id == dto.Id).FirstOrDefault();

            if (admissionProgrammeAttendanceTypesupt != null)
            {
                admissionProgrammeAttendanceTypesupt.AdmissionProgrammeId = dto.AdmissionProgrammeId;
                admissionProgrammeAttendanceTypesupt.AttendenceTypeId = dto.AttendenceTypeId;
            }
            _context.SaveChanges();
        }
    }
}
    