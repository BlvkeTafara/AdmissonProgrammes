using AdmissionProgrammes.Domain.DTOs;
using AdmissionProgrammes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionProgrammes.Domain.Repositories
{
    public interface IProgrammesRepository:IGenericRepository<ProgrammesDto>
    {
    }
}
