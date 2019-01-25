using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNotes_DAO.Models
{
    public class Evaluation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Identifiant { get; set; }
        public long IdExamen { get; set; }
        public long IdEleve { get; set; }
        [Required]
        public float Note { get; set; }

        [ForeignKey("IdExamen")]
        public Examen Examen { get; set; }
        [ForeignKey("IdEleve")]
        public Eleve Eleve { get; set; }

        public Evaluation()
        {
            this.Identifiant = -1;
            this.Note = -1;
        }

        public Evaluation(Eleve aEleve, Examen aExamen, float aNote) : this()
        {
            this.IdEleve = aEleve.Identifiant;
            this.Eleve = aEleve;
            this.IdExamen = aExamen.Identifiant;
            this.Examen = aExamen;
            this.Note = aNote;
        }
    }

}
