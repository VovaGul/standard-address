using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace StandardAddress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandardAddressController : ControllerBase
    {
        private readonly DadataService _dadataService;
        private readonly IMapper _mapper;

        public StandardAddressController(DadataService dadataService, IMapper mapper)
        {
            _dadataService = dadataService;
            _mapper = mapper;
        }

        [HttpGet(Name = "StandardizeAddress")]
        public async Task<AddressDto> StandardizeAddressAsync(string rawAddress = "мск сухонска 11/-89")
        {
            var address = await _dadataService.CleanAsync(rawAddress);
            var addressDto = _mapper.Map<AddressDto>(address);
            return addressDto;
        }
    }
}
