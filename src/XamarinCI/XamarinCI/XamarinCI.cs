﻿using Autofac;
using Xamarin.Forms;
using XamarinCI.Service;
using XamarinCI.ViewModel;

namespace XamarinCI
{
	public class App : Application
	{
		public static IContainer DependencyContainer { get; private set; }

		public App(ContainerBuilder builder)
		{
			var optionsPage = new NavigationOptionsPage();
			var rootNavigation = new NavigationPage(optionsPage);

			builder.RegisterType<BasicNavigationService>().As<INavigationService>();
			builder.RegisterType<NavigationOptionsViewModel>();

			builder.RegisterInstance(rootNavigation).AsSelf();

			DependencyContainer = builder.Build();

			MainPage = rootNavigation;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

	}
}
