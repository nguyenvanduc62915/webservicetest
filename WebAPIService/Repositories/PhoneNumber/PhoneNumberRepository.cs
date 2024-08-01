using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIService.DTO;
using WebAPIService.Models;

namespace WebAPIService.Repositories.PhoneNumber
{
    public class PhoneNumberRepository : IPhoneNumberRepository
    {
        private readonly AppDbContext _context;

        public PhoneNumberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PhoneNumberDTO>> GetPhoneNumbersAsync()
        {
            return await _context.PhoneNumbers
                .Select(phoneNumber => new PhoneNumberDTO
                {
                    Id = phoneNumber.Id,
                    Phone = phoneNumber.Phone,
                    Type = phoneNumber.Type,
                    UserDTO = phoneNumber.User != null ? new UserDTO
                    {
                        Id = phoneNumber.User.Id,
                        Email = phoneNumber.User.Email,
                        FullName = phoneNumber.User.FullName
                        // Populate other fields as needed
                    } : null
                })
                .ToListAsync();
        }

        public async Task<PhoneNumberDTO> GetPhoneNumberByIdAsync(int id)
        {
            var phoneNumber = await _context.PhoneNumbers
                .Include(pn => pn.User) // Include related User if necessary
                .FirstOrDefaultAsync(pn => pn.Id == id);

            if (phoneNumber == null)
                return null;

            return new PhoneNumberDTO
            {
                Id = phoneNumber.Id,
                Phone = phoneNumber.Phone,
                Type = phoneNumber.Type,
                UserDTO = phoneNumber.User != null ? new UserDTO
                {
                    Id = phoneNumber.User.Id,
                    Email = phoneNumber.User.Email,
                    FullName = phoneNumber.User.FullName
                    // Populate other fields as needed
                } : null
            };
        }

        public async Task AddPhoneNumbersAsync(PhoneNumberDTO phoneNumberDTO)
        {
            var phoneNumber = new Models.PhoneNumber
            {
                Phone = phoneNumberDTO.Phone,
                Type = phoneNumberDTO.Type,
                Id = phoneNumberDTO.Id // Ensure UserDTO is not null
            };

            _context.PhoneNumbers.Add(phoneNumber);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePhoneNumbersAsync(PhoneNumberDTO phoneNumberDTO)
        {
            var phoneNumber = await _context.PhoneNumbers.FindAsync(phoneNumberDTO.Id);

            if (phoneNumber == null)
                throw new KeyNotFoundException("Phone number not found.");

            phoneNumber.Phone = phoneNumberDTO.Phone;
            phoneNumber.Type = phoneNumberDTO.Type;
            phoneNumber.Id = phoneNumberDTO.Id; 
            _context.PhoneNumbers.Update(phoneNumber);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeletePhoneNumbersAsync(int phoneNumberId)
        {
            var phoneNumber = await _context.PhoneNumbers.FindAsync(phoneNumberId);

            if (phoneNumber == null)
                return false;

            _context.PhoneNumbers.Remove(phoneNumber);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
