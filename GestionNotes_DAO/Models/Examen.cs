using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNotes_DAO.Models
{
    public class Examen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Identifiant { get; set; }

        [Required]
        [MaxLength(20)]
        public string Libelle { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual ICollection<Evaluation> Evaluations { get; set; }

        public Examen()
        {
            this.Identifiant = -1;
            this.Libelle = string.Empty;
            this.Date = new DateTime(2000, 01, 01);
            this.Evaluations = new HashSet<Evaluation>();
        }

        public Examen(string aLibelle, DateTime aDate) : this()
        {
            this.Libelle = aLibelle;
            this.Date = aDate;
        }

    }
}
