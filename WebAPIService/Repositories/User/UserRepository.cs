using Microsoft.EntityFrameworkCore;
using WebAPIService.DTO;
using WebAPIService.Models;

namespace WebAPIService.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddUsersAsync(UserDTO userDTO)
        {
            try
            {
                var user = new WebAPIService.Models.User
                {
                    Id = userDTO.Id,
                    Password = userDTO.Password,
                    CreatedDate = DateTime.UtcNow,
                    Email = userDTO.Email,
                    FullName = userDTO.FullName,
                };

                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while adding the user.", ex);
            }
        }

        public async Task<bool> DeleteUsersAsync(int userId)
        {
            try
            {
                var user = await dbContext.Users.FindAsync(userId);
                if (user == null)
                {
                    return false;
                }

                dbContext.Users.Remove(user);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("An error occurred while deleting the user.", ex);
            }
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            try
            {
                return await dbContext.Users
                    .Select(user => new UserDTO
                    {
                        Id = user.Id,
                        Password = user.Password,
                        CreatedDate = user.CreatedDate, 
                        Email = user.Email,
                        FullName = user.FullName,
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while retrieving users.", ex);
            }
        }

        public async Task UpdateUsersAsync(UserDTO userDTO)
        {
            try
            {
                var user = await dbContext.Users.FindAsync(userDTO.Id);
                if (user == null)
                {
                    throw new KeyNotFoundException("User not found.");
                }
               
                user.Password = userDTO.Password;
                user.Email = userDTO.Email;
                user.FullName = userDTO.FullName;


                dbContext.Users.Update(user);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while updating the user.", ex);
            }
        }
    }
}
