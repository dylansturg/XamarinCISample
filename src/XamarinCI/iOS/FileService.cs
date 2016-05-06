using System;
using System.IO;
using Foundation;
using XamarinCI.Service;

namespace XamarinCI.iOS
{
	public class FileService : IFileService
	{
		public string ReadText(string filename)
		{
			var filetype = Path.GetExtension(filename);
			var name = Path.GetFileNameWithoutExtension(filename);

			var bundlePath = NSBundle.MainBundle.PathForResource(name, filetype);

			return File.ReadAllText(bundlePath);
		}
	}
}

