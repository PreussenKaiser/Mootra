namespace Mootra.Blazor.Data;

/// <summary>
/// 
/// </summary>
public class WeatherForecastService
{
	/// <summary>
	/// 
	/// </summary>
	private static readonly string[] Summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

	/// <summary>
	/// 
	/// </summary>
	/// <param name="startDate"></param>
	/// <returns></returns>
	public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
	{
		return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
		{
			Date = startDate.AddDays(index),
			TemperatureC = Random.Shared.Next(-20, 55),
			Summary = Summaries[Random.Shared.Next(Summaries.Length)]
		}).ToArray());
	}
}

