using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinCI
{
	public partial class NavigationOptionsPage : ContentPage
	{
		public NavigationOptionsPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (BindingContext == null)
			{
				BindingContext = ViewModelLocator.NavigationOptions;
			}
		}
	}
}

