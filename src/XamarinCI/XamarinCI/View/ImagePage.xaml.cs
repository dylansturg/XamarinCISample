using Xamarin.Forms;
using XamarinCI.ViewModel;

namespace XamarinCI
{
	public partial class ImagePage : ContentPage
	{
		public ImagePage(ImageViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = viewModel;
		}
	}
}

