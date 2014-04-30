using System.Drawing;
using System;

using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreFoundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.CoreAnimation;

namespace iCarouselBinding {

	[BaseType (typeof (UIView))]
    public partial interface iCarousel {

		[Export ("dataSource", ArgumentSemantic.Assign)]
		iCarouselDataSource DataSource { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		iCarouselDelegate Delegate { get; set; }

		[Export ("type")]
		iCarouselType Type { get; set; }

		[Export ("perspective")]
		float Perspective { get; set; }

		[Export ("decelerationRate")]
		float DecelerationRate { get; set; }

		[Export ("scrollSpeed")]
		float ScrollSpeed { get; set; }

		[Export ("bounceDistance")]
		float BounceDistance { get; set; }

		[Export ("scrollEnabled")]
		bool ScrollEnabled { [Bind ("isScrollEnabled")] get; set; }

		[Export ("pagingEnabled")]
		bool PagingEnabled { [Bind ("isPagingEnabled")] get; set; }

		[Export ("vertical")]
		bool Vertical { [Bind ("isVertical")] get; set; }

		[Export ("wrapEnabled")]
		bool WrapEnabled { [Bind ("isWrapEnabled")] get; }

		[Export ("bounces")]
		bool Bounces { get; set; }

		[Export ("scrollOffset")]
		float ScrollOffset { get; set; }

		[Export ("offsetMultiplier")]
		float OffsetMultiplier { get; }

		[Export ("contentOffset", ArgumentSemantic.Assign)]
		SizeF ContentOffset { get; set; }

		[Export ("viewpointOffset", ArgumentSemantic.Assign)]
		SizeF ViewpointOffset { get; set; }

		[Export ("numberOfItems")]
		int NumberOfItems { get; }

		[Export ("numberOfPlaceholders")]
		int NumberOfPlaceholders { get; }

		[Export ("currentItemIndex")]
		int CurrentItemIndex { get; set; }

		[Export ("currentItemView", ArgumentSemantic.Retain)]
		UIView CurrentItemView { get; }

		[Export ("indexesForVisibleItems", ArgumentSemantic.Retain)]
		NSObject [] IndexesForVisibleItems { get; }

		[Export ("numberOfVisibleItems")]
		int NumberOfVisibleItems { get; }

        [Export ("visibleItemViews", ArgumentSemantic.Retain)]
		NSObject [] VisibleItemViews { get; }

		[Export ("itemWidth")]
		float ItemWidth { get; }

		[Export ("contentView", ArgumentSemantic.Retain)]
		UIView ContentView { get; }

		[Export ("toggle")]
		float Toggle { get; }

		[Export ("autoscroll")]
		float Autoscroll { get; set; }

		[Export ("stopAtItemBoundary")]
		bool StopAtItemBoundary { get; set; }

		[Export ("scrollToItemBoundary")]
		bool ScrollToItemBoundary { get; set; }

		[Export ("ignorePerpendicularSwipes")]
		bool IgnorePerpendicularSwipes { get; set; }

		[Export ("centerItemWhenSelected")]
		bool CenterItemWhenSelected { get; set; }

		[Export ("dragging")]
		bool Dragging { [Bind ("isDragging")] get; }

		[Export ("decelerating")]
		bool Decelerating { [Bind ("isDecelerating")] get; }

		[Export ("scrolling")]
		bool Scrolling { [Bind ("isScrolling")] get; }

		[Export ("scrollByOffset:duration:")]
		void ScrollByOffset (float offset, double duration);

		[Export ("scrollToOffset:duration:")]
		void ScrollToOffset (float offset, double duration);

		[Export ("scrollByNumberOfItems:duration:")]
		void ScrollByNumberOfItems (int itemCount, double duration);

		[Export ("scrollToItemAtIndex:duration:")]
		void ScrollToItemAtIndex (int index, double duration);

		[Export ("scrollToItemAtIndex:animated:")]
		void ScrollToItemAtIndex (int index, bool animated);

		[Export ("itemViewAtIndex:")]
		UIView ItemViewAtIndex (int index);

		[Export ("indexOfItemView:")]
		int IndexOfItemView (UIView view);

		[Export ("indexOfItemViewOrSubview:")]
		int IndexOfItemViewOrSubview (UIView view);

		[Export ("offsetForItemAtIndex:")]
		float OffsetForItemAtIndex (int index);

		[Export ("itemViewAtPoint:")]
		UIView ItemViewAtPoint (PointF point);

		[Export ("removeItemAtIndex:animated:")]
		void RemoveItemAtIndex (int index, bool animated);

		[Export ("insertItemAtIndex:animated:")]
		void InsertItemAtIndex (int index, bool animated);

		[Export ("reloadItemAtIndex:animated:")]
		void ReloadItemAtIndex (int index, bool animated);

		[Export ("reloadData")]
		void ReloadData ();
	}

	[Model, BaseType (typeof (NSObject))]
    [Protocol]
    public partial interface iCarouselDataSource {

		[Export ("numberOfItemsInCarousel:")]
		uint NumberOfItemsInCarousel (iCarousel carousel);

		[Export ("carousel:viewForItemAtIndex:reusingView:")]
        UIView ViewForItemAtIndex (iCarousel carousel, uint index, UIView view);

		[Export ("numberOfPlaceholdersInCarousel:")]
		uint NumberOfPlaceholdersInCarousel (iCarousel carousel);

		[Export ("carousel:placeholderViewAtIndex:reusingView:")]
        UIView PlaceholderViewAtIndex (iCarousel carousel, uint index, UIView view);
	}

	[Model, BaseType (typeof (NSObject))]
    [Protocol]
    public partial interface iCarouselDelegate {

		[Export ("carouselWillBeginScrollingAnimation:")]
        void  CarouselWillBeginScrollingAnimation(iCarousel carousel);

		[Export ("carouselDidEndScrollingAnimation:")]
        void  CarouselDidEndScrollingAnimation(iCarousel carousel);

		[Export ("carouselDidScroll:")]
        void  CarouselDidScroll(iCarousel carousel);

		[Export ("carouselCurrentItemIndexDidChange:")]
        void  CarouselCurrentItemIndexDidChange(iCarousel carousel);

		[Export ("carouselWillBeginDragging:")]
        void  CarouselWillBeginDragging(iCarousel carousel);

		[Export ("carouselDidEndDragging:willDecelerate:")]
        void CarouselDidEndDragging (iCarousel carousel, bool decelerate);

		[Export ("carouselWillBeginDecelerating:")]
        void  CarouselWillBeginDecelerating(iCarousel carousel);

		[Export ("carouselDidEndDecelerating:")]
        void  CarouselDidEndDecelerating(iCarousel carousel);

		[Export ("carousel:shouldSelectItemAtIndex:")]
		bool ShouldSelectItemAtIndex (iCarousel carousel, int index);

		[Export ("carousel:didSelectItemAtIndex:")]
		void DidSelectItemAtIndex (iCarousel carousel, int index);

		[Export ("carouselItemWidth:")]
        float  CarouselItemWidth(iCarousel carousel);

		[Export ("carousel:itemTransformForOffset:baseTransform:")]
		CATransform3D ItemTransformForOffset (iCarousel carousel, float offset, CATransform3D transform);

		[Export ("carousel:valueForOption:withDefault:")]
		float ValueForOption (iCarousel carousel, iCarouselOption option, float value);
	}
}
