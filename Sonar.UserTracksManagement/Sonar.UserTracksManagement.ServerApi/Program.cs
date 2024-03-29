using Microsoft.EntityFrameworkCore;
using ServerApi.Filters;
using Sonar.UserProfile.ApiClient;
using Sonar.UserProfile.ApiClient.Interfaces;
using Sonar.UserTracksManagement.Application.Database;
using Sonar.UserTracksManagement.Application.Interfaces;
using Sonar.UserTracksManagement.Application.Repositories;
using Sonar.UserTracksManagement.Application.Services;
using Sonar.UserTracksManagement.Core.Interfaces;
using Sonar.UserTracksManagement.Core.Services;
using Sonar.UserTracksManagement.ServiceFaker.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<IImageApplicationService, ImageApplicationService>();
builder.Services.AddScoped<IPlaylistApplicationService, PlaylistApplicationService>();
builder.Services.AddScoped<IUserTracksApplicationService, UserTracksApplicationService>();
builder.Services.AddScoped<ICheckAvailabilityService, CheckAvailabilityService>();

// builder.Services.AddScoped<IAuthorizationService, FakeAuthorizationService>();
// builder.Services.AddScoped<ICheckAvailabilityService, FakeCheckAvailabilityService>();

builder.Services.AddScoped<IPlaylistService, PlaylistService>();
builder.Services.AddScoped<IUserTrackService, UserTrackService>();
builder.Services.AddScoped<ITagService, TagService>();

builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
builder.Services.AddScoped<ITrackRepository, TrackRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IPlaylistTrackRepository, PlaylistTrackRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();



builder.Services.AddScoped<IUserApiClient, UserApiClient>(provider =>
    new UserApiClient("https://localhost:7062", provider.GetRequiredService<HttpClient>()));
builder.Services.AddScoped<IRelationshipApiClient, RelationshipApiClient>(provider =>
    new RelationshipApiClient("https://localhost:7062", provider.GetRequiredService<HttpClient>()));
builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ExceptionFilter());
});
builder.Services.AddDbContext<UserTracksManagementDatabaseContext>(opt =>
    opt.UseSqlite($"Filename={builder.Configuration["DatabaseFilename"]}"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(o => o.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();