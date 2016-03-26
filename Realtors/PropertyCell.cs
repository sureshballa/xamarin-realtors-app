using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Threading.Tasks;
using System.Net.Http;

namespace Realtors
{
	partial class PropertyCell : UITableViewCell
	{
		private Property _property;

		public Property Property {
			set {
				this._property = value;
				refreshUI ();
			}
		}

		public PropertyCell (IntPtr handle) : base (handle)
		{
			
		}

		private async void refreshUI()
		{
			this.Address.Text = this._property.Address;
			this.Summary.Text = "Beds: " + this._property.Beds + ", Baths: " + this._property.Baths;
			var taskResult = await this.LoadImage(this._property.Image);
			this.PropertyImage.Image = taskResult;
		}

		private async Task<UIImage> LoadImage (string imageUrl)
		{
			var httpClient = new HttpClient();
			Task<byte[]> contentsTask = httpClient.GetByteArrayAsync (imageUrl);
			var contents = await contentsTask;
			return UIImage.LoadFromData (NSData.FromArray (contents));
		}
	}
}
