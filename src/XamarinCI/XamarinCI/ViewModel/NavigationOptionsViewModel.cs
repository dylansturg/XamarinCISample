using System;
using System.Diagnostics;
using Xamarin.Forms;
using XamarinCI.Service;

namespace XamarinCI.ViewModel
{
	public class NavigationOptionsViewModel : BaseViewModel
	{

		public Command ListTapped { get { return new Command(NavigateToList); } }

		public Command ImageTapped { get { return new Command(NavigateToImage); } }

		public Command AboutTapped { get { return new Command(NavigateToAbout); } }

		public string PageTitle { get { return "Options"; } }

		private INavigationService navigation;
		public NavigationOptionsViewModel(INavigationService navigation)
		{
			this.navigation = navigation;
		}

		private async void NavigateToList()
		{
			await navigation.PushPageAsync(new ListPage());
		}

		private void NavigateToImage()
		{
			Debug.WriteLine("Going to an Image!");
		}

		private void NavigateToAbout()
		{
			Debug.WriteLine("Going to an About!");
		}
	}
}

