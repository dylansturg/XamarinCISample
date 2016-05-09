using System.Collections.Generic;
using System.Collections.ObjectModel;
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
			if (Items == null || Items.Count == 0)
			{
				var octocatsContents = fileService.ReadText("allcats.json");
				var octocats = JsonConvert.DeserializeObject<List<string>>(octocatsContents);
				if (octocats != null && octocats.Count > 0)
				{
					var listItems = octocats.Select(cat => new ListItemViewModel
					{
						CatName = Path.GetFileNameWithoutExtension(cat),
						FileName = cat.Replace(".png", "_thumbnail.png")
					});

					Items = new ObservableCollection<ListItemViewModel>(listItems);
				}
				else
				{
					Items = new ObservableCollection<ListItemViewModel>();
				}
			}
		}

		private async void NavigateToOctocat(object selected)
		{
			var selectedOctocat = selected as ListItemViewModel;
			var filename = selectedOctocat.FileName;
			if (filename.Contains("_thumbnail"))
			{
				filename = filename.Replace("_thumbnail", "");
			}
			var viewModel = ViewModelLocator.CreateViewModelForImage(selectedOctocat.CatName, filename);
			var imagePage = new ImagePage(viewModel);
			await navigation.PushPageAsync(imagePage);
		}
	}
}

