using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIService.Models
{
    public class Address
    {
        [Key]
        [Column("address_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("street"), MaxLength(500)]
        public string? Street { get; set; } = null;
        [Column("city"), MaxLength(100)]
        public string? City { get; set; } = null;
        [Column("state"), MaxLength(100)]
        public string? State { get; set; } = null;
        [Column("postal_code"), MaxLength(200)]
        public string? Country { get; set; } = null;
        public User User { get; set; }
    }
}
