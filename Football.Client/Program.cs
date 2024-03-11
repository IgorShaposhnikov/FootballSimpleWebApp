using Football.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7116/api/") });

builder.Services.AddSingleton(sp => {
    var navigationManager = sp.GetRequiredService<NavigationManager>();
    return new HubConnectionBuilder()
      .WithUrl("https://localhost:7116/football-hub")
      .WithAutomaticReconnect()
      .Build();
});

builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
