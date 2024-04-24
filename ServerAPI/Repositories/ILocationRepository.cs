using Core.Models;

namespace ServerAPI.Repositories;

public interface ILocationRepository
{
    public List<Location> SendLocations();
}