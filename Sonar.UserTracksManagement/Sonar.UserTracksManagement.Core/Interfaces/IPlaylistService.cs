﻿using Sonar.UserTracksManagement.Core.Entities;

namespace Sonar.UserTracksManagement.Core.Interfaces;

public interface IPlaylistService
{
    public Playlist CreateNewPlaylist(Guid userId, string name);
    public bool CheckPlaylistForTrack(Playlist playlist, Track track);
    
    public PlaylistTrack AddTrackToPlaylist(Playlist playlist, Track track);

    public PlaylistTrack RemoveTrackFromPlaylist(Playlist playlist, Track track);

    public IEnumerable<Track> GetTracksFromPlaylist(Playlist playlist);

}