﻿namespace Sonar.UserTracksManagement.Core.Entities;

public class Track
{
    private Track()
    {
    }

    public Track(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; private init; }
    public string Name { get; private set; }
}