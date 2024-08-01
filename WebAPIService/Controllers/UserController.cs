using Microsoft.AspNetCore.Mvc;
using WebAPIService.DTO;
using WebAPIService.Repositories.User;

namespace WebAPIService.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("User data is null.");
            }

            await _userRepository.AddUsersAsync(userDTO);
            // Trả về phản hồi với thông tin của người dùng vừa tạo, bạn có thể chỉnh sửa để cung cấp thông tin chi tiết hơn nếu cần
            return CreatedAtAction(nameof(GetUsers), new { id = userDTO.Id }, userDTO);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("User data is null.");
            }

            await _userRepository.UpdateUsersAsync(userDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userRepository.DeleteUsersAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
