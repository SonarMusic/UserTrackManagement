namespace Sonar.UserTracksManagement.Application.Interfaces;

public interface IUsersApplicationService
{
    Task<Guid> AddUserAsync(string token, string name);
    Task<bool> CheckAccessToUserAsync(string token, Guid trackId);
    Task<IEnumerable<TrackDto>> GetAllTracksAsync(string token);
    Task<TrackDto> GetTrackAsync(string token, Guid trackId);
}