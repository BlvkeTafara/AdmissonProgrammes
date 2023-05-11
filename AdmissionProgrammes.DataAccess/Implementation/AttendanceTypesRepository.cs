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
    public class AttendanceTypesRepository:IAttendanceTypesRepository 
    {
        private readonly AdmissionProgrammesDbContext _context;
        private readonly IMapper _mapper;
        public AttendanceTypesRepository(AdmissionProgrammesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(AttendanceTypesDto dto)
        {
            var entity = _mapper.Map<AttendanceTypes>(dto);
            _context.AttendanceTypes.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<AttendanceTypesDto> dto)
        {
            var entities = _mapper.Map<IEnumerable<AttendanceTypes>>(dto);
            _context.AttendanceTypes.AddRange(entities);
        }

        public IEnumerable<AttendanceTypesDto> GetAll()
        {
            var entities = _context.AttendanceTypes.ToList();
            var Dtos = _mapper.Map<IEnumerable<AttendanceTypesDto>>(entities);
            return Dtos;
        }

        public AttendanceTypesDto GetById(int id)
        {
            var entity = _context.AttendanceTypes.Where(x => x.Id == id).FirstOrDefault();

            var dto = _mapper.Map<AttendanceTypesDto>(entity);
            return dto;
        }

        public void Remove(int id)
        {
            var attendanceTypesdel = _context.AttendanceTypes.Where(attendanceType => attendanceType.Id == id).FirstOrDefault();

            _context.AttendanceTypes.Remove(attendanceTypesdel);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<AttendanceTypesDto> entities)
        {
            var entitties = _context.AttendanceTypes.ToList();
            var Dtos = _mapper.Map<IEnumerable<AttendanceTypesDto>>(entities);
        }

        public void Update(AttendanceTypesDto dto)
        {
            var attendanceTypesupt = _context.AttendanceTypes.Where(attendanceType => attendanceType.Id == dto.Id).FirstOrDefault();

            if (attendanceTypesupt != null)
            {
                attendanceTypesupt.Name = dto.Name;
            }
            _context.SaveChanges();
        }
    }
}
