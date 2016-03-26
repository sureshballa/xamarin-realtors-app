using System;
using System.Threading.Tasks;
using UIKit;
using System.Net.Http;
using Foundation;

namespace Realtors
{
	public static class UIImageExtensions
	{
		public static async Task<UIImage> LoadImage (this UIImage image, string imageUrl)
		{
			var httpClient = new HttpClient();
			Task<byte[]> contentsTask = httpClient.GetByteArrayAsync (imageUrl);
			var contents = await contentsTask;
			return UIImage.LoadFromData (NSData.FromArray (contents));
		}
	}
}

