using Microsoft.AspNetCore.Mvc;
using WebAPIService.DTO;
using WebAPIService.Repositories.Address;
using System.Threading.Tasks;

namespace WebAPIService.Controllers
{
    [ApiController]
    [Route("api/address")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await _addressRepository.GetAddresssAsync();
            return Ok(addresses);
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress([FromBody] AddressDTO addressDTO)
        {
            if (addressDTO == null)
            {
                return BadRequest("Address data is null.");
            }

            await _addressRepository.AddAddresssAsync(addressDTO);
            return CreatedAtAction(nameof(GetAddresses), new { id = addressDTO.Id }, addressDTO);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] AddressDTO addressDTO)
        {
            if (addressDTO == null)
            {
                return BadRequest("Address data is null.");
            }

            try
            {
                await _addressRepository.UpdateAddresssAsync(addressDTO);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var result = await _addressRepository.DeleteAddresssAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
