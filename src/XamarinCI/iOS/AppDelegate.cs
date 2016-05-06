using Autofac;
using Foundation;
using UIKit;

namespace XamarinCI.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			// Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif

			var builder = new ContainerBuilder();

			LoadApplication(new App(builder));

			return base.FinishedLaunching(app, options);
		}
	}
}

