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

		public static ListViewModel Octocats
		{
			get
			{
				return ResolveViewModel<ListViewModel>();
			}
		}

		public static ImageViewModel CreateViewModelForImage(string title, string filename)
		{
			var viewModel = ResolveViewModel<ImageViewModel>();
			viewModel.Title = title;
			viewModel.ImageFile = filename;
			return viewModel;
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

