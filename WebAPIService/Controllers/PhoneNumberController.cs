using Microsoft.AspNetCore.Mvc;
using WebAPIService.DTO;
using WebAPIService.Repositories.PhoneNumber;

namespace WebAPIService.Controllers
{
    [ApiController]
    [Route("api/phonenumber")]
    public class PhoneNumberController : ControllerBase
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;

        public PhoneNumberController(IPhoneNumberRepository phoneNumberRepository)
        {
            _phoneNumberRepository = phoneNumberRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhoneNumbers()
        {
            var phoneNumbers = await _phoneNumberRepository.GetPhoneNumbersAsync();
            return Ok(phoneNumbers);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoneNumber([FromBody] PhoneNumberDTO phoneNumberDTO)
        {
            if (phoneNumberDTO == null)
            {
                return BadRequest("Phone number data is null.");
            }

            await _phoneNumberRepository.AddPhoneNumbersAsync(phoneNumberDTO);
            return CreatedAtAction(nameof(GetPhoneNumbers), new { id = phoneNumberDTO.Id }, phoneNumberDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhoneNumber(int id, [FromBody] PhoneNumberDTO phoneNumberDTO)
        {
            if (phoneNumberDTO == null || phoneNumberDTO.Id != id)
            {
                return BadRequest("Phone number data is incorrect.");
            }

            try
            {
                await _phoneNumberRepository.UpdatePhoneNumbersAsync(phoneNumberDTO);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneNumber(int id)
        {
            var result = await _phoneNumberRepository.DeletePhoneNumbersAsync(id);
            if (result)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
