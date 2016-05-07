using System;
namespace XamarinCI.ViewModel
{
	public class ImageViewModel : BaseViewModel
	{

		private string title;
		public string Title
		{
			get { return title; }
			set
			{
				if (title != value)
				{
					title = value;
					RaisePropertyChanged();
				}
			}
		}

		private string imageFile;
		public string ImageFile
		{
			get { return imageFile; }
			set
			{
				if (imageFile != value)
				{
					imageFile = value;
					RaisePropertyChanged();
				}
			}
		}

	}
}

