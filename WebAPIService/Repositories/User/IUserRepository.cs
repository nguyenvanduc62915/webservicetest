using System.Collections;
using WebAPIService.Models;
using System.Threading.Tasks;
using WebAPIService.DTO;

namespace WebAPIService.Repositories.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task UpdateUsersAsync(UserDTO userDTO);
        Task AddUsersAsync(UserDTO userDTO);
        Task<bool> DeleteUsersAsync(int userId);
    }
}
