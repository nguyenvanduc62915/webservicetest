using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAPIService.Models;

namespace WebAPIService.DTO
{
    public class PhoneNumberDTO
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string? Type { get; set; }
        public UserDTO? UserDTO { get; set; }
    }
}
