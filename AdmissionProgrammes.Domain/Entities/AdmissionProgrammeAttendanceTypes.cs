using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionProgrammes.Domain.Entities
{
    public class AdmissionProgrammeAttendanceTypes
    {
        public int Id { get; set; }
        public int AdmissionProgrammeId { get; set; }
        public int AttendenceTypeId { get; set; }
    }
}
