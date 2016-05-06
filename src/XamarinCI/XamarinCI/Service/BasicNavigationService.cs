using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinCI.Service
{
	public class BasicNavigationService : INavigationService
	{
		private NavigationPage navigation;
		public BasicNavigationService(NavigationPage root)
		{
			navigation = root;
		}

		public Task<Page> PopPageAsync()
		{
			return navigation.PopAsync();
		}

		public Task PushPageAsync(Page nextPage)
		{
			return navigation.PushAsync(nextPage);
		}
	}
}

