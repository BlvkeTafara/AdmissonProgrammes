using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionProgrammes.Domain.Entities
{
    public class AdmissionFees
    {
        public int Id { get; set; }
        public int ApplicantTypeId { get; set; }
        public int ProgrammeTypeId { get; set; }
        public int CurrencyId { get; set; }
        public int Amount { get; set; }
    }
}
