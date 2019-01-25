using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GestionNotes_DAO.Models
{
    public class GestionNotesContext : DbContext
    {
 
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Examen> Examens { get; set; }
        public DbSet <Evaluation> Evaluations { get; set; }

        public GestionNotesContext() : base("CS_GestionNotes")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
