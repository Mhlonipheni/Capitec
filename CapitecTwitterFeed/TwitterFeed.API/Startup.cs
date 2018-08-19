using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NJsonSchema;
using NSwag.AspNetCore;
using TwitterFeed.API.Helpers;
using TwitterFeed.DataAccess.DataStores;
using TwitterFeed.Logic.Follower;
using TwitterFeed.Logic.TwitterUser;

namespace TwitterFeed.API
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{

			Configuration = configuration;//builder.Build();
		}


		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
			LoadSettings();
			TwitterUserManager.RegisterManager(new TwitterUserManager(), new TwitterUserDataStore(SettingsHelper.Settings.CapitecFeed_ConnectionString));
			FollowerManager.RegisterManager(new FollowerManager(), new FollowerDataStore(SettingsHelper.Settings.CapitecFeed_ConnectionString));
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
		
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}
			app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
			{
				settings.GeneratorSettings.DefaultPropertyNameHandling =
						PropertyNameHandling.CamelCase;
			});
			app.UseHttpsRedirection();
			app.UseMvc();
			
		}
		protected Settings LoadSettings()
		{

			SettingsHelper.Settings = new Settings
			{
				CapitecFeed_ConnectionString = Configuration.GetSection("ConnectionStrings")["DefaultConnection"],
				BaseUri = Configuration.GetSection("App")["BaseUri"],
			};
			return SettingsHelper.Settings;
		}
	}
}
