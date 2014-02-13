using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;
using iCarouselBinding;

namespace AdvancedDemo
{
    public partial class AdvancedDemoViewController : UIViewController, IUIActionSheetDelegate
    {
        bool wrap;
        List<string> items;

        static bool UserInterfaceIdiomIsPhone {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public AdvancedDemoViewController ()
            : base (UserInterfaceIdiomIsPhone ? "AdvancedDemoViewController_iPhone" : "AdvancedDemoViewController_iPad", null)
        {
            setUp ();
        }

        public override void DidReceiveMemoryWarning ()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning ();
            
            // Release any cached data, images, etc that aren't in use.
        }

        void setUp ()
        {
            wrap = true;
            items = new List<string> ();
            for (int i = 0; i < 1000; i++) {
                items.Add (i.ToString ());
            }
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            carousel.DataSource = new CarouselDataSource (this);
            carousel.Delegate = new CarouselDelegate (this);  

            // configure carousel
            carousel.Type = iCarouselType.CoverFlow2;
            navItem.Title = "CoverFlow2";          
        }

        public override bool ShouldAutorotate ()
        {
            return true;
        }

        partial void insertItem (MonoTouch.Foundation.NSObject sender)
        {
            Console.WriteLine ("insertItem touched");
            int index = Math.Max (0, carousel.CurrentItemIndex);
            var newItem = items.Count.ToString ();
            items.Insert (index, newItem);
            carousel.InsertItemAtIndex (index, true);
        }

        partial void removeItem (MonoTouch.Foundation.NSObject sender)
        {
            Console.WriteLine ("removeItem touched");
            if (carousel.NumberOfItems > 0) {
                int index = carousel.CurrentItemIndex;
                items.RemoveAt (index);
                carousel.RemoveItemAtIndex (index, true);
            }
        }

        partial void switchCarouselType (MonoTouch.Foundation.NSObject sender)
        {
            Console.WriteLine ("switchCarouselType touched");
            var otherButtons = new string[] {
                "Linear",
                "Rotary",
                "Inverted Rotary",
                "Cylinder",
                "Inverted Cylinder",
                "Wheel",
                "Inverted Wheel",
                "CoverFlow",
                "CoverFlow2",
                "Time Machine",
                "Inverted Time Machine",
                "Custom",
            };
            var sheet = new UIActionSheet ("Select Carousel Type", null, null, null, otherButtons);

            sheet.Dismissed += (object o, UIButtonEventArgs e) => {
                if (e.ButtonIndex >= 0) {
                    // map button index to carousel type
                    var type = (iCarouselType)e.ButtonIndex;
                    // carousel can smoothly animate between types
                    UIView.BeginAnimations (null, IntPtr.Zero);
                    carousel.Type = type;
                    UIView.CommitAnimations ();
                    // update title
                    var s = (UIActionSheet)o;
                    navItem.Title = s.ButtonTitle (e.ButtonIndex);
                }
            };

            sheet.ShowInView (this.View);
        }

        partial void toggleOrientation (MonoTouch.Foundation.NSObject sender)
        {
            Console.WriteLine ("toggleOrientation touched");
            //carousel orientation can be animated
            UIView.BeginAnimations (null, IntPtr.Zero);
            carousel.Vertical = !carousel.Vertical;
            UIView.CommitAnimations ();

            //update button
            orientationBarItem.Title = carousel.Vertical ? "Vertical" : "Horizontal";
        }

        partial void toggleWrap (MonoTouch.Foundation.NSObject sender)
        {
            Console.WriteLine ("toggleWrap touched");
            wrap = !wrap;
            wrapBarItem.Title = wrap ? "Wrap: ON" : "Wrap: OFF";
            carousel.ReloadData ();
        }

        public class CarouselDataSource : iCarouselDataSource
        {
            AdvancedDemoViewController owner;

            public CarouselDataSource (AdvancedDemoViewController o)
            {
                owner = o;
            }

            public override uint NumberOfItemsInCarousel (iCarousel carousel)
            {
                return (uint)owner.items.Count;
            }

            public override UIView ViewForItemAtIndex (iCarousel carousel, uint index, UIView view)
            {
                //create new view if no view is available for recycling
                if (view == null) {
                    var v = new UIImageView (new RectangleF (0f, 0f, 200.0f, 200.0f));
                    v.Image = UIImage.FromBundle ("page.png");
                    v.ContentMode = UIViewContentMode.Center;
                    var l = new UILabel (v.Bounds);
                    l.BackgroundColor = UIColor.Clear;
                    l.TextAlignment = UITextAlignment.Center;
                    l.Font = l.Font.WithSize (50f);
                    l.Tag = 1;
                    l.Text = owner.items [(int)index].ToString ();
                    v.AddSubview (l);
                    return v;
                }
                var label = (UILabel)view.ViewWithTag (1);
                label.Text = owner.items [(int)index].ToString ();
                return view;
            }

            public override uint NumberOfPlaceholdersInCarousel (iCarousel carousel)
            {
                return 2;
            }

            public override UIView PlaceholderViewAtIndex (iCarousel carousel, uint index, UIView view)
            {
                UILabel label = null;
                UIImageView imageView = null;

                //create new view if no view is available for recycling
                if (null == view) {
                    //don't do anything specific to the index within
                    //this `if (view == nil) {...}` statement because the view will be
                    //recycled and used with other index values later
                    imageView = new UIImageView (new RectangleF (0f, 0f, 200.0f, 200.0f));
                    imageView.Image = UIImage.FromBundle ("page.png");
                    imageView.ContentMode = UIViewContentMode.Center;
                    label = new UILabel (imageView.Bounds);
                    label.BackgroundColor = UIColor.Clear;
                    label.TextAlignment = UITextAlignment.Center;
                    label.Font = label.Font.WithSize (50f);
                    label.Tag = 1;
                    imageView.AddSubview (label);
                } else {
                    label = (UILabel)view.ViewWithTag (1);
                    imageView = (UIImageView)view;
                }
                //set item label
                //remember to always set any properties of your carousel item
                //views outside of the `if (view == nil) {...}` check otherwise
                //you'll get weird issues with carousel item content appearing
                //in the wrong place in the carousel
                label.Text = (index == 0) ? "[" : "]";

                return imageView;
            }
        }

        public class CarouselDelegate : iCarouselDelegate
        {
            AdvancedDemoViewController owner;

            public CarouselDelegate (AdvancedDemoViewController o)
            {
                owner = o;
            }

            public override MonoTouch.CoreAnimation.CATransform3D ItemTransformForOffset (iCarousel carousel, float offset, MonoTouch.CoreAnimation.CATransform3D transform)
            {
                // implement 'flip3D' style carousel
                transform = CATransform3D.MakeRotation (((float)Math.PI) / 8.0f, 0.0f, 1.0f, 0.0f);
                return CATransform3D.MakeTranslation (0f, 0f, offset * carousel.ItemWidth);
            }

            public override float ValueForOption (iCarousel carousel, iCarouselOption option, float value)
            {
                // customize carousel display
                switch (option) {
                case iCarouselOption.Wrap:
                    // normally you would hard-code this to true or false
                    return (owner.wrap ? 1.0f : 0.0f);
                case iCarouselOption.Spacing:
                    // add a bit of spacing between the item views
                    return value * 1.05f;
                case iCarouselOption.FadeMax:
                    if (iCarouselType.Custom == carousel.Type) {
                        return 0.0f;
                    }
                    return value;
                default:
                    return value;
                }

            }
        }
    }
}

