using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionNotes_DAO.Models
{
    public class Eleve
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Identifiant { get; set; }
        [Required]
        [MaxLength(20)]        
        public string Nom { get; set; }
        [Required]
        [StringLength(30)]
        public string Prenom { get; set; }
        
        public virtual ICollection<Evaluation> Evaluations { get; set; }

        public Eleve()
        {
            this.Identifiant = -1;
            this.Nom = string.Empty;
            this.Prenom = string.Empty;
            this.Evaluations = new HashSet<Evaluation>();
        }

        public Eleve(string aNom, string aPremon) : this()
        {
            this.Nom = aNom;
            this.Prenom = aPremon;
        }
    }
}
