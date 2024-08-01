using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIService.DTO
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; } 
        public string? State { get; set; }
        public string? Country { get; set; }
        public UserDTO? UserDTO { get; set; }
    }
}
