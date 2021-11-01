﻿using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Rent.Client.Services;
using Rent.Shared.Models;

namespace Rent.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTIxOTY5QDMxMzkyZTMzMmUzMEVGOFBRLzlkYWwyc2c0UTRieGY3cXR3L1lsMDhQMkd5b0p4dnhmZlFRamM9;NTIxOTcwQDMxMzkyZTMzMmUzMEZlQnhDYmlmU05Ja3dyTVUzYzFrTzZLejBYTFJIbDFsWEtpNGpZWTFGNms9;NTIxOTcxQDMxMzkyZTMzMmUzMFZPZXdvQ2ZhN1RTYVZPL0RWSTd4VzBINi96MU1VTUlVcVRrVXZITUExZjA9;NTIxOTcyQDMxMzkyZTMzMmUzMFFWNGl4YXlNYXJSL2VjUEdYQkhQUWNmYnNseXE2TGZVVkhzTXZOVlNMdVk9;NTIxOTczQDMxMzkyZTMzMmUzMG1tSnlnZll1ZHJXQi84RWtvTnVuVUdsVlV1eFFRUjJhRHA4TUUyUzJ5TjA9;NTIxOTc0QDMxMzkyZTMzMmUzMEhsY0hRV0p1VG10WkZqbmNTU3hQZGwvQ3pRMlAxYWFuUkNSM2FBWi9YakE9;NTIxOTc1QDMxMzkyZTMzMmUzMFpGVXdHRUt0YVFRS0k4M1l1NDRzZFdLd2NZNVBjQjFLeVFMVnV2bmcvalk9;NTIxOTc2QDMxMzkyZTMzMmUzMEFlbXhlaXNkbmI4b3pNU3lkVkdQSGlvR2NDYkRTbXNpeVF4TWdXMnpZcEE9;NTIxOTc3QDMxMzkyZTMzMmUzMFFUVHR2NytvOXVnS05jdXdCRmUrRndhdnNhN1BrblJ0RDJ1UHoyeVArNUE9;NTIxOTc4QDMxMzkyZTMzMmUzMFNscTZnNE5uMGxOajE2cU53eEFuTkdCWlRYREJjVHYzNTBRV3RtazZsSHM9;NTIxOTc5QDMxMzkyZTMzMmUzMFdyYVNxQUs5R1RZczd5dFM0NkVQRTRUd3lyNkxHTFBFWFZZRDc0LzdUcDQ9");
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient<ICitiesService, CitiesService>("Rent.ServerAPI", 
                client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
 
            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Rent.ServerAPI"));
            
            builder.Services.AddApiAuthorization();

            //builder.Services.AddSyncfusionBlazor();
            //builder.Services.AddScoped(typeof(AppDataAdaptor<>));

            await builder.Build().RunAsync();
        }
    }
}
