using AdmissionProgrammes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionProgrammes.DataAccess.Context
{
    public class AdmissionProgrammesDbContext: DbContext
    {
        public AdmissionProgrammesDbContext(DbContextOptions<AdmissionProgrammesDbContext> options) : base(options) { }
        public DbSet<AdmissionFees> AdmissionFees { get; set; }
        public DbSet<AdmissionProgrammeAttendanceTypes> AdmissionProgrammeAttendanceTypes { get; set; }
        public DbSet<AdmissionProgrammez> AdmissionProgrammezs { get; set; }
        public DbSet<AdmissionSessions> AdmissionSessions { get; set; } 
        public DbSet<AdmissionTemplates > AdmissionTemplates { get; set; }
        public DbSet<ApplicantPayments> ApplicantPayments { get; set; }
        public DbSet<ApplicantTypes> ApplicantTypes { get; set; }
        public DbSet<ApplicationProgrammes > ApplicationProgrammes { get; set; }
        public DbSet<Applications > Applications { get; set; }
        public DbSet<AttendanceTypes> AttendanceTypes { get; set; }
        public DbSet<Programmes> Programmes { get; set; }
        public DbSet<ProgrammeTypes > ProgrammeTypes { get; set; }
       
    }
}
