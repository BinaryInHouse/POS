﻿using System;
using System.Reflection;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.Interfaces;
using POS.Application.Services;
using POS.Infraestructure.FileStorage;
using POS.Infraestructure.Persistences.Interfaces;
using POS.Infraestructure.Persistences.Repositories;

namespace POS.Application.Extensions
{
	public static class InjectionExtensions
	{
		public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton(configuration);

			 services.AddFluentValidation(options =>
			{
				options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
			});

			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddScoped<ICategoryApplication, CategoryApplication>();
			services.AddScoped<IUserApplication, UserApplication>();
			services.AddTransient<IAzureStorage, AzureStorage>();
			return services;
		}
	}
}

