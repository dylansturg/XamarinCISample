using System;
namespace XamarinCI.ViewModel
{
	public class ListItemViewModel : BaseViewModel
	{
		private string fileName;
		public string FileName
		{
			get
			{
				return fileName;
			}
			set
			{
				if (fileName != value)
				{
					fileName = value;
					RaisePropertyChanged();
				}
			}
		}

		private string catName;
		public string CatName
		{
			get
			{
				return catName;
			}
			set
			{
				if (catName != value)
				{
					catName = value;
					RaisePropertyChanged();
				}
			}
		}
	}
}

