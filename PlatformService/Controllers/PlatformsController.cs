using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data.Interfaces;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformsService.SyncDataServices.Http;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformsController(IPlatformRepository platformRepository, IMapper mapper, ICommandDataClient commandDataClient)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            var platforms = _platformRepository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var platform = _platformRepository.GetPlatform(id);
            if (platform != null)
                return Ok(_mapper.Map<PlatformReadDto>(platform));

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            var newPlatform = _mapper.Map<Platform>(platformCreateDto);
            _platformRepository.CreatePlatform(newPlatform);
            _platformRepository.SaveChanges();

            try
            {
                await _commandDataClient.SendPlatformToCommand(platformCreateDto);
            }
            catch (System.Exception)
            {

                throw;
            }

            var result = _platformRepository.GetPlatform(newPlatform.Id);
            return CreatedAtRoute(nameof(GetPlatformById), new { id = result.Id }, result);
        }
    }
}