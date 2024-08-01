using WebAPIService.DTO;

namespace WebAPIService.Repositories.PhoneNumber
{
    public interface IPhoneNumberRepository
    {
        Task<IEnumerable<PhoneNumberDTO>> GetPhoneNumbersAsync();
        Task UpdatePhoneNumbersAsync(PhoneNumberDTO phoneNumberDTO);
        Task AddPhoneNumbersAsync(PhoneNumberDTO phoneNumberDTO);
        Task<bool> DeletePhoneNumbersAsync(int phongNumberId);
    }
}
