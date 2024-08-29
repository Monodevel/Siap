using Blazored.LocalStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using Siap.GUI;
using Siap.GUI.Authentication;
using Siap.GUI.Components;
using Siap.GUI.Services;
using Siap.GUI.Services.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5120") });
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();


//Servicios
builder.Services.ModelosServices();
builder.Services.AddMudServices();
builder.Services.AddSweetAlert2();
builder.Services.AddAuthentication();
builder.Services.AddCascadingAuthenticationState();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
