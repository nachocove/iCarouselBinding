using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libiCarouselLibSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true)]
