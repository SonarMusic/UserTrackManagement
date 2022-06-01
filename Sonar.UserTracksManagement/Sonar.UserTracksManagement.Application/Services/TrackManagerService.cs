using Sonar.UserTracksManagement.Application.Database;
using Sonar.UserTracksManagement.Core.Entities;

namespace DefaultNamespace;

public class TrackManagerService : ITrackManagerService
{
    private UserTracksManagementDatabaseContext _dbContext;
    
    public TrackManagerService(UserTracksManagementDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Track>> GetAvailableTracksAsync(int userId)
    {
        var user = await _dbContext.Users.FindAsync(userId);
        if (user is null)
        {
            throw new ArgumentException("user with given Id doesn't exists");
        }
        return user.Tracks;
    }

    public async Task<bool> CheckAvailabilityAsync(int userId, int trackId)
    {
        var availableTracks = await GetAvailableTracksAsync(userId);
        var track = await _dbContext.Tracks.FindAsync(trackId);
        if (track is null)
        {
            throw new ArgumentException("track with given Id doesn't exists");
        }
        return availableTracks.Contains(track);
    }

    public IEnumerable<Track> GetAvailableTracks(int userId)
    {
        var user = _dbContext.Users.Find(userId);
        if (user is null)
        {
            throw new ArgumentException("user with given Id doesn't exists");
        }
        return user.Tracks;
    }

    public bool CheckAvailability(int userId, int trackId)
    {
        var availableTracks = GetAvailableTracks(userId);
        var track = _dbContext.Tracks.Find(trackId);
        if (track is null)
        {
            throw new ArgumentException("track with given Id doesn't exists");
        }
        return availableTracks.Contains(track);
    }

    public void AddTrackToUser(User user, Track track)
    {
        user.AddTrack(track);
    }
}