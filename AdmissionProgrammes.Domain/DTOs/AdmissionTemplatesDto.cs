using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionProgrammes.Domain.DTOs
{
    public class AdmissionTemplatesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammeTypeId { get; set; }
        public string Status { get; set; }
    }
}
