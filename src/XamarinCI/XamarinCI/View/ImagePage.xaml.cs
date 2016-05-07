using Xamarin.Forms;
using XamarinCI.ViewModel;

namespace XamarinCI
{
	public partial class ImagePage : ContentPage
	{
		private string imageFileName;

		public ImagePage(ImageViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = viewModel;
		}
	}
}

