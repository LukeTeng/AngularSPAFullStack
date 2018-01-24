using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AngularSPA.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(4)]
        public string CountryCode { get; set; }
        [Required]
        public string CountryName { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
