using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIService.Models
{
    public class User
    {
        [Key]
        [Column("onwer_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, MaxLength(200), Column("email")]
        public string Email { get; set; }
        [MaxLength(200), Column("password")]
        public string Password { get; set; }
        [MaxLength(200), Column("full_name")]
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; }

        public static implicit operator User(int v)
        {
            throw new NotImplementedException();
        }
    }
}
