using System;
using Moq;
using NUnit.Framework;
using XamarinCI.Service;
using XamarinCI.ViewModel;

namespace XamarinCI.Tests
{
	[TestFixture]
	public class ListViewModelTests
	{
		[Test]
		public void ListViewModel_LoadListItems_Reads_From_Injected_File_Service()
		{
			var mockFileService = new Mock<IFileService>();
			mockFileService.Setup(mock => mock.ReadText(It.IsAny<string>()))
						   .Returns(string.Empty)
						   .Verifiable("LoadListItems should use file service to read octocats list");

			var mockNavigationService = new Mock<INavigationService>();

			var testViewModel = new ListViewModel(mockNavigationService.Object, mockFileService.Object);

			testViewModel.LoadListItems();

			mockFileService.Verify();
		}
	}
}

