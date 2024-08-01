using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIService.Models
{
    public class PhoneNumber
    {
        [Key]
        [Column("phone_number_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("phone"), MaxLength(200)]
        public string Phone { get; set; }
        [Column("type"), MaxLength(200)]
        public string? Type { get; set; } = null;
        public User User { get; set; }
    }
}
