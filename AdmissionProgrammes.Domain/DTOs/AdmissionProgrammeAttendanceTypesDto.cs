using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionProgrammes.Domain.DTOs
{
    public class AdmissionProgrammeAttendanceTypesDto
    {
        public int Id { get; set; }
        public int AdmissionProgrammeId { get; set; }
        public int AttendenceTypeId { get; set; }
    }
}

