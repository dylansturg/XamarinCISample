using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinCI.ViewModel;

namespace XamarinCI
{
	public partial class ListPage : ContentPage
	{
		private ListViewModel octocatsModel
		{
			get
			{
				return (ListViewModel)BindingContext;
			}
		}

		public ListPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (BindingContext == null)
			{
				BindingContext = ViewModelLocator.Octocats;
			}

			octocatsModel.LoadListItems();
		}

		void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return;
			}

			var list = sender as ListView;
			if (list != null)
			{
				list.SelectedItem = null;
			}

			octocatsModel.OctocatSelected?.Execute(e.SelectedItem);
		}
	}
}

