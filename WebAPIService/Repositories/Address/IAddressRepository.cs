using WebAPIService.DTO;

namespace WebAPIService.Repositories.Address
{
    public interface IAddressRepository
    {
        Task<IEnumerable<AddressDTO>> GetAddresssAsync();
        Task UpdateAddresssAsync(AddressDTO addressDTO);
        Task AddAddresssAsync(AddressDTO addressDTO);
        Task<bool> DeleteAddresssAsync(int addressId);
    }
}
