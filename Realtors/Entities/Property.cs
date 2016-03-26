using System;

namespace Realtors
{
	public class Property
	{
		public int ListingID { get; set; }
		public string Address { get; set; }
		public string Features { get; set; }
		public int Beds { get; set; }
		public int Baths { get; set; }
		public double EstimatedValue { get; set; }
		public double changeOverLastYear { get; set; }
		public string Link { get; set; }
		public string Image { get; set; }

		public Property()
		{
		}

		public Property (int listingID, string address, int beds, int baths, string imageLink)
		{
			this.ListingID = listingID;
			this.Address = address;
			this.Beds = beds;
			this.Baths = baths;
			this.Image = imageLink;
		}

		public Property (int listingID, string address, int beds, int baths, string imageLink,
			string features, double estimatedValue, double changeOverLastYear, string link)
		{
			this.ListingID = listingID;
			this.Address = address;
			this.Beds = beds;
			this.Baths = baths;
			this.Image = imageLink;

			this.Features = features;
			this.EstimatedValue = estimatedValue;
			this.changeOverLastYear = changeOverLastYear;
			this.Link = link;
		}

	}
}

