using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionProgrammes.Domain.Repositories
{
    public interface IUnitOfWorkRepository: IDisposable 
    {
        IAdmissionFeesRepository AdmissionFees { get; }
        IAdmissionProgrammeAttendanceTypesRepository AdmissionProgrammeAttendanceTypes { get; }
        IAdmissionProgrammezRepository AdmissionProgrammez { get; }
        IAdmissionSessionsRepository AdmissionSessions { get; }
        IAdmissionTemplatesRepository AdmissionTemplates { get; }
        IApplicantPaymentsRepository ApplicantPayments { get; }
        IApplicantTypesRepository ApplicantTypes { get; }
        IApplicationsRepository Applications { get; }
        IApplicationProgrammesRepository ApplicationProgrammes { get; }
        IAttendanceTypesRepository AttendanceTypes { get; } 
        IProgrammesRepository Programmes { get; }
        IProgrammeTypesRepository ProgrammeTypes { get; }

        int Save();

    }
}
