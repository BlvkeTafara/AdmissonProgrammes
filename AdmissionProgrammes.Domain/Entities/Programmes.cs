﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionProgrammes.Domain.Entities
{
    public class Programmes
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int ProgrammeTypeId { get; set; }
    }
}
