using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionProgrammes.Domain.Entities
{
    public class Applications
    {
        public int Id { get; set; }
        public string ApplicantUserId { get; set;}
        public string AppNumber { get; set;}
        public int ApplicantTypeId { get; set;}
        public int CampusId { get; set;}
        public int ProgrammeTypeId { get; set;}
        public string PaymentStatus { get; set;}
        public string ApprovalStatus { get; set;}
        public int AdmissionSessionId { get; set;}
        public string Uuid { get; set;}
            
        public DateTime DateCreated { get; set;}
        public DateTime DateUpdated { get; set;}
    }
}
