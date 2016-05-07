using System;
using System.IO;
using XamarinCI.Service;

namespace XamarinCI.Droid
{
	public class FileService : IFileService
	{
		public string ReadText(string filename)
		{
			var currentContext = Xamarin.Forms.Forms.Context;
			using (var readStream = currentContext.Assets.Open(filename))
			using (var reader = new StreamReader(readStream))
			{
				return reader.ReadToEnd();
			}
		}
	}
}

