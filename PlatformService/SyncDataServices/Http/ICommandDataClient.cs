using System.Threading.Tasks;
using PlatformService.Dtos;

namespace PlatformsService.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformCreateDto platform);
    }
}