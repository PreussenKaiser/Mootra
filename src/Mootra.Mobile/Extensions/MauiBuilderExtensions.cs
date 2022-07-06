﻿using Mootra.Mobile.Views;

using Mootra.Core.Services;
using Mootra.Core.Models;
using Mootra.Infrastructure.Abstractions;
using Mootra.Infrastructure.Data;
using Mootra.Infrastructure.Services;

namespace Mootra.Mobile.Extensions;

/// <summary>
/// Contains extension methods for the <see cref="MauiAppBuilder"/> class.
/// </summary>
public static class MauiBuilderExtensions
{
	/// <summary>
	/// Adds views to <see cref="MauiAppBuilder.Services"/>.
	/// </summary>
	/// <param name="builder">The builder to add views to.</param>
	/// <returns>The builder with views added.</returns>
	public static MauiAppBuilder ConfigureViews(this MauiAppBuilder builder)
	{
		builder.Services.AddTransient<AddEmotionPage>()
						.AddTransient<BrowseEmotionsPage>()
						.AddTransient<ProfilePage>();

		return builder;
	}

	/// <summary>
	/// Adds data access to <see cref="MauiAppBuilder.Services"/>.
	/// </summary>
	/// <param name="builder">The builder to add data access classes to.</param>
	/// <returns>The builder with data access added.</returns>
	public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
	{
		string connectionString = "mootra.db";
		EmotionRepository repository = new(connectionString);

		builder.Services.AddSingleton<IRepository<Emotion>>(repository)
						.AddSingleton<IEmotionService, EmotionService>();

		return builder;
	}
}