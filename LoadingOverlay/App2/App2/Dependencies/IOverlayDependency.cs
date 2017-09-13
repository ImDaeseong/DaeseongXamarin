﻿using System;
using Xamarin.Forms;

namespace App2.Dependencies
{
    public interface IOverlayDependency
    {
        void ShowOverlay(string message);
        void ShowOverlay(string message, Color backgroundColor, float backgroundOpacity);
        void HideOverlay();
    }
}
