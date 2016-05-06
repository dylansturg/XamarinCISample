using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace XamarinCI.UITests
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class NavigationPageTests
	{
		IApp app;
		Platform platform;

		public NavigationPageTests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void ListButton_Exists_And_Opens_ListPage()
		{
			app.WaitForElement("ListButton");
			app.Screenshot("List Button Found");

			app.Tap("ListButton");
		}

		[Test]
		public void ImageButton_Exists_And_Opens_ListPage()
		{
			app.WaitForElement("ImageButton");
			app.Screenshot("Image Button Found");

			app.Tap("ImageButton");
		}

		[Test]
		public void AboutButton_Exists_And_Opens_ListPage()
		{
			app.WaitForElement("AboutButton");
			app.Screenshot("About Button Found");

			app.Tap("AboutButton");
		}
	}
}

