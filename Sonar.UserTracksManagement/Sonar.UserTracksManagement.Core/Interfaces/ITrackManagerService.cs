using Sonar.UserTracksManagement.Core.Entities;

namespace DefaultNamespace;

public interface ITrackManagerService
{
    IEnumerable<Track> GetAvailableTracks(User user);
    bool CheckAvailability(User user, Track track);
    void AddTrackToUser(User user, Track track);
}