using AdmissionProgrammes.DataAccess.Context;
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
    public class UnitOfWork:IUnitOfWorkRepository 
    {
        private readonly AdmissionProgrammesDbContext _context;
        private readonly IMapper _mapper;
        public UnitOfWork(AdmissionProgrammesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            AdmissionFees = new AdmissionFeesRepository (_context, _mapper);
            AdmissionProgrammeAttendanceTypes = new AdmissionProgrammeAttendanceTypesRepository (_context, _mapper);
            AdmissionProgrammez = new AdmissionProgrammezRepository (_context, _mapper);
            AdmissionSessions = new AdmissionSessionsRepository (_context, _mapper);
            AdmissionTemplates = new AdmissionTemplatesRepository (_context, _mapper);
            ApplicantPayments = new ApplicantPaymentsRepository (_context, _mapper);
            ApplicantTypes = new ApplicantTypesRepository (_context, _mapper);
            ApplicationProgrammes = new ApplicationProgrammesRepository (_context, _mapper);
            Applications = new ApplicationsRepository (_context, _mapper);
            AttendanceTypes = new AttendanceTypesRepository (_context, _mapper);
            Programmes = new ProgrammesRepository (_context, _mapper);
            ProgrammeTypes = new ProgrammeTypesRepository (_context, _mapper);

        }
        public IAdmissionFeesRepository AdmissionFees { get; private set;}
        public IAdmissionProgrammeAttendanceTypesRepository AdmissionProgrammeAttendanceTypes { get; private set;}
        public IAdmissionProgrammezRepository AdmissionProgrammez { get; private set;}
        public IAdmissionSessionsRepository AdmissionSessions { get; private set;}
        public IAdmissionTemplatesRepository AdmissionTemplates { get; private set;}
        public IApplicantPaymentsRepository ApplicantPayments { get; private set;}
        public IApplicantTypesRepository ApplicantTypes { get; private set;}
        public IApplicationProgrammesRepository ApplicationProgrammes { get; private set; }
        public IApplicationsRepository Applications { get; private set;}
        public IAttendanceTypesRepository AttendanceTypes { get; private set;}
        public IProgrammesRepository Programmes { get; private set; }
        public IProgrammeTypesRepository ProgrammeTypes { get; private set; }

        

        

        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
