using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Artillery.Data.Models
{
    public class Shell
    {
        public Shell()
        {
            this.Guns = new HashSet<Gun>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Range(2.0, 1_680.0)]
        public double ShellWeight { get; set; }

        [Required]
        [MaxLength(30)]
        public string Caliber { get; set; }

        public ICollection<Gun> Guns { get; set; }
    }
}
