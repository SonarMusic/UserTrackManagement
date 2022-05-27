﻿using Sonar.UserTracksManagement.Core.Entities;

namespace Sonar.UserTracksManagement.Core.Interfaces;

public interface IPlaylistService
{

    public Playlist CreateNewPlaylist(User user, string name);
    public bool CheckPlaylistForTrack(Playlist playlist, Track track);
    
    public void AddTrackToPlaylist(Playlist playlist, Track track);

    public void RemoveTrackFromPlaylist(Playlist playlist, Track track);

}