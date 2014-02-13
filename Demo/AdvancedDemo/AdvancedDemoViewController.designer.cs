// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace AdvancedDemo
{
	[Register ("AdvancedDemoViewController")]
	partial class AdvancedDemoViewController
	{
		[Outlet]
        iCarouselBinding.iCarousel carousel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UINavigationItem navItem { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem orientationBarItem { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem wrapBarItem { get; set; }

		[Action ("insertItem:")]
		partial void insertItem (MonoTouch.Foundation.NSObject sender);

		[Action ("removeItem:")]
		partial void removeItem (MonoTouch.Foundation.NSObject sender);

		[Action ("switchCarouselType:")]
		partial void switchCarouselType (MonoTouch.Foundation.NSObject sender);

		[Action ("toggleOrientation:")]
		partial void toggleOrientation (MonoTouch.Foundation.NSObject sender);

		[Action ("toggleWrap:")]
		partial void toggleWrap (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (carousel != null) {
				carousel.Dispose ();
				carousel = null;
			}

			if (navItem != null) {
				navItem.Dispose ();
				navItem = null;
			}

			if (wrapBarItem != null) {
				wrapBarItem.Dispose ();
				wrapBarItem = null;
			}

			if (orientationBarItem != null) {
				orientationBarItem.Dispose ();
				orientationBarItem = null;
			}
		}
	}
}
