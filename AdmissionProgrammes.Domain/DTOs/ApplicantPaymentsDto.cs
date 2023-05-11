using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionProgrammes.Domain.DTOs
{
    public class ApplicantPaymentsDto
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string ApplicantUserId { get; set; }
        public int CurrencyId { get; set; }
        public string Pollurl { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
