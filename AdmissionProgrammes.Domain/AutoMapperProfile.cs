using AdmissionProgrammes.Domain.DTOs;
using AdmissionProgrammes.Domain.Entities;
using AdmissionProgrammes.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionProgrammes.Domain
{
    public class AutoMapperProfile: Profile 
    {
        public AutoMapperProfile()
        {
            CreateMap<AdmissionFeesDto , AdmissionFees>();
            CreateMap<AdmissionFees, AdmissionFeesDto>();

            CreateMap<AdmissionProgrammeAttendanceTypesDto  , AdmissionProgrammeAttendanceTypes>();
            CreateMap<AdmissionProgrammeAttendanceTypes , AdmissionProgrammeAttendanceTypesDto >();

            CreateMap<AdmissionProgrammezDto , AdmissionProgrammez>();
            CreateMap<AdmissionProgrammez, AdmissionProgrammezDto >();

            CreateMap<AdmissionSessionsDto  , AdmissionSessions>();
            CreateMap<AdmissionSessions , AdmissionSessionsDto >();

            CreateMap<AdmissionTemplatesDto  , AdmissionTemplates>();
            CreateMap<AdmissionTemplates , AdmissionTemplatesDto >();

            CreateMap<ApplicantPaymentsDto  , ApplicantPayments>();
            CreateMap<ApplicantPayments  , ApplicantPaymentsDto>();

            CreateMap<ApplicantTypesDto , ApplicantTypes>();
            CreateMap<ApplicantTypes , ApplicantTypesDto>();

            CreateMap<ApplicationProgrammesDto  , ApplicationProgrammes>();
            CreateMap<ApplicationProgrammes , ApplicationProgrammesDto >();

            CreateMap<ApplicationsDto , Applications>();
            CreateMap<Applications , ApplicationsDto >();

            CreateMap<AttendanceTypesDto, AttendanceTypes>();
            CreateMap<AttendanceTypes , AttendanceTypesDto >();

            CreateMap<ProgrammesDto , Programmes>();
            CreateMap<Programmes , ProgrammesDto >();

            CreateMap<ProgrammeTypesDto , ProgrammeTypes >();
            CreateMap<ProgrammeTypes, ProgrammeTypesDto>();
        }
    }
}
