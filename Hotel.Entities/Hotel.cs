using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Entities
{
    public class Hotel
    {
        //id alanı primary key ve identity
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(40)]
        [Required]
        public string Name { get; set; }
        [StringLength(40)]
        [Required]
        public string City { get; set; }
    }
}
