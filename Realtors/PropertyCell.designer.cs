// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Realtors
{
	[Register ("PropertyCell")]
	partial class PropertyCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel Address { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView PropertyImage { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel Summary { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (Address != null) {
				Address.Dispose ();
				Address = null;
			}
			if (PropertyImage != null) {
				PropertyImage.Dispose ();
				PropertyImage = null;
			}
			if (Summary != null) {
				Summary.Dispose ();
				Summary = null;
			}
		}
	}
}
