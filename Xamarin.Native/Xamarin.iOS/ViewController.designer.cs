// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Xamarin.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton AppleMapButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton GoogleMapButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton HereWeGoButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton WazeButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AppleMapButton != null) {
                AppleMapButton.Dispose ();
                AppleMapButton = null;
            }

            if (GoogleMapButton != null) {
                GoogleMapButton.Dispose ();
                GoogleMapButton = null;
            }

            if (HereWeGoButton != null) {
                HereWeGoButton.Dispose ();
                HereWeGoButton = null;
            }

            if (WazeButton != null) {
                WazeButton.Dispose ();
                WazeButton = null;
            }
        }
    }
}