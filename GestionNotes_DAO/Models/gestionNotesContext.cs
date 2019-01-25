using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace GestionNotes_DAO.Models
{
    public class GestionNotesContext : DbContext
    {
        public GestionNotesContext()
        {
        }

        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Examen> Examens { get; set; }
        public DbSet <Evaluation> Evaluations { get; set; }
    }
}
