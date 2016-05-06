using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Xamarin.Forms;
using XamarinCI.Service;

namespace XamarinCI.ViewModel
{
	public class ListViewModel : BaseViewModel
	{
		private ObservableCollection<ListItemViewModel> items;
		public ObservableCollection<ListItemViewModel> Items
		{
			get { return items; }
			set
			{
				if (items != value)
				{
					items = value;
					RaisePropertyChanged();
				}
			}
		}

		public Command OctocatSelected
		{
			get
			{
				return new Command(NavigateToOctocat);
			}
		}

		private INavigationService navigation;
		private IFileService fileService;

		public ListViewModel(INavigationService navigation, IFileService fileService)
		{
			this.navigation = navigation;
			this.fileService = fileService;
		}

		public void LoadListItems()
		{
			var octocatsContents = fileService.ReadText("allcats.json");
			var octocats = JsonConvert.DeserializeObject<List<string>>(octocatsContents);

			var listItems = octocats.Select(cat => new ListItemViewModel
			{
				CatName = Path.GetFileNameWithoutExtension(cat),
				FileName = cat
			});

			Items = new ObservableCollection<ListItemViewModel>(listItems);
		}

		private void NavigateToOctocat(object selected)
		{
			var selectedOctocat = selected as ListItemViewModel;

			Debug.WriteLine("selected cat: " + selectedOctocat?.CatName);
		}
	}
}

