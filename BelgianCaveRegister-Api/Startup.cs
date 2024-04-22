namespace BelgianCaveRegister_Api
{
	public class Startup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddCors(options =>
			{
				options.AddPolicy("AllowSpecificOrigin",
					builder =>
					{
						builder.WithOrigins("https://localhost:7267/bibliography")
						.AllowAnyHeader()
						.AllowAnyMethod();

					});
			});
		}
	}
}
