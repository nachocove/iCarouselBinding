using System;

namespace iCarouselBinding
{
    public enum iCarouselType : uint {
        Linear = 0,
        Rotary,
        InvertedRotary,
        Cylinder,
        InvertedCylinder,
        Wheel,
        InvertedWheel,
        CoverFlow,
        CoverFlow2,
        TimeMachine,
        InvertedTimeMachine,
        Custom
    }

    public enum iCarouselOption : uint {
        Wrap = 0,
        ShowBackfaces,
        OffsetMultiplier,
        VisibleItems,
        Count,
        Arc,
        Angle,
        Radius,
        Tilt,
        Spacing,
        FadeMin,
        FadeMax,
        FadeRange,
        FadeMinAlpha
    }
}

