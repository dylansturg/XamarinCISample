using System;
using System.Threading.Tasks;
using Autofac;
using Moq;
using NUnit.Framework;
using Xamarin.Forms;
using XamarinCI.Service;
using XamarinCI.ViewModel;

namespace XamarinCI.Tests
{
	[TestFixture]
	public class NavigationOptionsViewModelTests
	{
		IContainer container;
		Mock<INavigationService> mockNavigation;

		[SetUp]
		public void SetupDependencies()
		{
			var builder = new ContainerBuilder();
			mockNavigation = new Mock<INavigationService>();

			builder.RegisterType<NavigationOptionsViewModel>();
			builder.RegisterInstance(mockNavigation.Object).As<INavigationService>();

			container = builder.Build();
		}

		[Test]
		public void NavigationOptionsViewModel_ListTapped_Uses_Injected_NavigationService()
		{
			mockNavigation.Setup(mock => mock.PushPageAsync(It.IsAny<Page>()))
						  .Returns(Task.FromResult(0))
						  .Verifiable("ListTapped should push a page");

			NavigationOptionsViewModel viewModel;

			using (var scope = container.BeginLifetimeScope())
			{
				viewModel = scope.Resolve<NavigationOptionsViewModel>();
			}

			viewModel.ListTapped.Execute(null);

			mockNavigation.Verify();
		}

		[Test]
		public void NavigationOptionsViewModel_ListTapped_Pushes_ListPage()
		{
			mockNavigation.Setup(mock => mock.PushPageAsync(It.IsAny<ListPage>()))
						  .Returns(Task.FromResult(0))
						  .Verifiable("ListTapped should push a ListPage instance");

			NavigationOptionsViewModel viewModel;

			using (var scope = container.BeginLifetimeScope())
			{
				viewModel = scope.Resolve<NavigationOptionsViewModel>();
			}

			viewModel.ListTapped.Execute(null);

			mockNavigation.Verify();
		}

		[Test]
		public void NavigationOptionsViewModel_PageTitle_Is_Correct()
		{
			NavigationOptionsViewModel viewModel;

			using (var scope = container.BeginLifetimeScope())
			{
				viewModel = scope.Resolve<NavigationOptionsViewModel>();
			}

			Assert.AreEqual("Options", viewModel.PageTitle);
		}
	}
}

