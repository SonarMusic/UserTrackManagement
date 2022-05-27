using Sonar.UserTracksManagement.Core.Entities;

namespace DefaultNamespace;

public class TrackManagerService : ITrackManagerService
{
    public IEnumerable<Track> GetAvailableTracks(User user)
    {
        return user.Tracks;
    }

    public bool CheckAvailability(User user, Track track)
    {
        return GetAvailableTracks(user).Contains(track);
    }

    public void AddTrackToUser(User user, Track track)
    {
        user.AddTrack(track);
    }
}