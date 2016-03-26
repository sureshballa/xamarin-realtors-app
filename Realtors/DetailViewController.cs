using System;

using UIKit;
using System.Threading.Tasks;
using System.Net.Http;
using Foundation;

namespace Realtors
{
	public partial class DetailViewController : UIViewController
	{
		public Property DetailItem { get; set; }
		readonly PropertyService PropertyService = new PropertyService();

		public DetailViewController (IntPtr handle) : base (handle)
		{
		}

		public async void SetDetailItem (Property newDetailItem)
		{
			if (DetailItem != newDetailItem) {
				DetailItem = newDetailItem;
				
				// Update the view
				await ConfigureView ();
			}
		}

		async Task ConfigureView()
		{
			// Update the user interface for the detail item
			if (IsViewLoaded && DetailItem != null) {
				
				var result = await PropertyService.GetProperty (this.DetailItem.ListingID);
				this.DetailItem = result;

				this.Address.Text = this.DetailItem.Address;
				this.Title = this.DetailItem.Address;
				this.Summary.Text = "Beds: " + this.DetailItem.Beds + ", Baths: " + this.DetailItem.Baths;
				this.Features.Text = this.DetailItem.Features;

				var taskResult = await this.LoadImage (this.DetailItem.Image);
				this.PropertyImage.Image = taskResult;
			}
		}

		public async override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.Address.Text = string.Empty;
			this.Summary.Text = string.Empty;
			this.Features.Text = string.Empty;
			await ConfigureView ();
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
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


