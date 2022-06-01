using Sonar.UserTracksManagement.Core.Entities;

namespace DefaultNamespace;

public interface ITrackManagerService
{
    Task<IEnumerable<Track>> GetAvailableTracksAsync(int userId);
    Task<bool> CheckAvailabilityAsync(int userId, int trackId);
    IEnumerable<Track> GetAvailableTracks(int userId);
    bool CheckAvailability(int userId, int trackId);
    void AddTrackToUser(User user, Track track);
}