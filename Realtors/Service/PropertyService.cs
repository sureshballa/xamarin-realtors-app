using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Realtors
{
	public class PropertyService
	{
		private const string ServiceUrl = "https://sample-listings.herokuapp.com";

		public PropertyService ()
		{
		}

		public async Task<List<Property>> GetAllPropertyListings ()
		{
			var uri = new Uri ("https://sample-listings.herokuapp.com/listings");

			HttpClient client = new HttpClient ();
			var response = await client.GetAsync (uri);

			if (response.IsSuccessStatusCode) {
				var content = await response.Content.ReadAsStringAsync ();
				var listings = JsonConvert.DeserializeObject <List<Property>> (content);

				listings.ForEach (l => {
					l.Image = ServiceUrl + l.Image;
				});

				return listings;
			}

			return null;
		}

		public async Task<Property> GetProperty(int listingID)
		{
			var uri = new Uri (ServiceUrl + @"/listings/" + listingID);

			HttpClient client = new HttpClient ();
			var response = await client.GetAsync (uri);

			if (response.IsSuccessStatusCode) {
				var content = await response.Content.ReadAsStringAsync ();
				var property = JsonConvert.DeserializeObject <Property> (content);
				property.Image = ServiceUrl + property.Image;
				return property;
			}

			return null;
		}
	}
}

