using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIService.DTO;
using WebAPIService.Models;

namespace WebAPIService.Repositories.Address
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _dbContext;

        public AddressRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAddresssAsync(AddressDTO addressDTO)
        {
            if (addressDTO == null)
                throw new ArgumentNullException(nameof(addressDTO));

            var address = new Models.Address
            {
                Street = addressDTO.Street,
                City = addressDTO.City,
                State = addressDTO.State,
                Country = addressDTO.Country,
            };

            await _dbContext.Address.AddAsync(address);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAddresssAsync(int addressId)
        {
            var address = await _dbContext.Address.FindAsync(addressId);
            if (address == null)
                return false; 

            _dbContext.Address.Remove(address);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AddressDTO>> GetAddresssAsync()
        {
            return await _dbContext.Address
                .Select(address => new AddressDTO
                {
                    Id = address.Id,
                    Street = address.Street,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    UserDTO = address.User != null ? new UserDTO
                    {
                        Id = address.User.Id,
                        Email = address.User.Email,
                        FullName = address.User.FullName
                    } : null
                })
                .ToListAsync();
        }

        public async Task UpdateAddresssAsync(AddressDTO addressDTO)
        {
            if (addressDTO == null)
                throw new ArgumentNullException(nameof(addressDTO));

            var address = await _dbContext.Address.FindAsync(addressDTO.Id);
            if (address == null)
                throw new KeyNotFoundException("Address not found.");

            address.Street = addressDTO.Street;
            address.City = addressDTO.City;
            address.State = addressDTO.State;
            address.Country = addressDTO.Country;


            _dbContext.Address.Update(address);
            await _dbContext.SaveChangesAsync();
        }
    }
}
