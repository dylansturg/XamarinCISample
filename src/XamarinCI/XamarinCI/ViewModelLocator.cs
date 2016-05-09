using System;
using Autofac;
using XamarinCI.ViewModel;

namespace XamarinCI
{
	public class ViewModelLocator
	{
		private static ViewModelLocator instance;

		private IContainer container;
		public ViewModelLocator(IContainer dependencyContainer)
		{
			instance = this;
			container = dependencyContainer;
		}

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
			if (instance == null)
			{
				throw new InvalidOperationException("ViewModelLocator used before initialization complete");
			}

			return instance.ResolveViewModelOfType<T>();
		}

		private T ResolveViewModelOfType<T>() where T : class
		{
			using (var scope = container.BeginLifetimeScope())
			{
				return scope.Resolve<T>();
			}
		}
	}
}

