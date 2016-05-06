using Autofac;
using XamarinCI.ViewModel;

namespace XamarinCI
{
	public static class ViewModelLocator
	{
		public static NavigationOptionsViewModel NavigationOptions
		{
			get
			{
				return ResolveViewModel<NavigationOptionsViewModel>();
			}
		}

		private static T ResolveViewModel<T>() where T : class
		{
			using (var scope = App.DependencyContainer.BeginLifetimeScope())
			{
				return scope.Resolve<T>();
			}
		}
	}
}

