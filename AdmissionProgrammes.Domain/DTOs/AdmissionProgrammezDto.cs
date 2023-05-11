using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionProgrammes.Domain.DTOs
{
    public class AdmissionProgrammezDto
    {
        public int Id { get; set; }
        public string EntryRequirements { get; set; }
        public string CareerProspects { get; set; }
        public int ProgrammeId { get; set; }
        public int AdmissionTemplateId { get; set; }
    }
}
