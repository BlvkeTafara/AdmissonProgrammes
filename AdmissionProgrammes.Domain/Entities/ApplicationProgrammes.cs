using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionProgrammes.Domain.Entities
{
    public class ApplicationProgrammes
    {
        public int Id { get; set; }
        public int AdmissionSessionId { get; set; }
            
        public string ApplicationId { get; set; }
        public int ProgrammeId { get; set; }
        public int AttendenceTypeId { get; set;}
        public string Status { get; set;}
        public DateTime DateCreated { get; set;}
        public DateTime DateUpdated { get; set;}
    }
}
