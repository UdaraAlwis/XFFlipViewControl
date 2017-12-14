using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using XFFlipViewControl.Droid;
using Android.Animation;
using System.ComponentModel;
using XFFlipViewControl;

[assembly: ExportRenderer(typeof(XNFlipView), typeof(XNFlipViewRenderer))]
namespace XFFlipViewControl.Droid
{
    public class XNFlipViewRenderer : ViewRenderer
    {
        private float _cameraDistance;

        private readonly ObjectAnimator _animateYAxis0To90;
        private readonly ObjectAnimator _animateYAxis90To180;

        public XNFlipViewRenderer(Context context) : base(context)
        {
            // Initiating the first half of the animation
            _animateYAxis0To90 = ObjectAnimator.OfFloat(this, "RotationY", 0.0f, -90f);
            _animateYAxis0To90.SetDuration(500);
            _animateYAxis0To90.Update += (sender, args) =>
            {
                // On every animation Frame we have to update the Camera Distance since Xamarin overrides it somewhere
                SetCameraDistance(_cameraDistance);
            };
            _animateYAxis0To90.AnimationEnd += (sender, args) =>
            {
                if (((XNFlipView)Element).IsFlipped)
                {
                    // Change the visible content
                    ((XNFlipView)Element).FrontView.IsVisible = false;
                    ((XNFlipView)Element).BackView.IsVisible = true;
                }
                else
                {
                    // Change the visible content
                    ((XNFlipView)Element).BackView.IsVisible = false;
                    ((XNFlipView)Element).FrontView.IsVisible = true;
                }

                this.RotationY = -270;

                _animateYAxis90To180.Start();
            };
            
            // Initiating the second half of the animation
            _animateYAxis90To180 = ObjectAnimator.OfFloat(this, "RotationY", -270f, -360f);
            _animateYAxis90To180.SetDuration(500);
            _animateYAxis90To180.Update += (sender1, args1) =>
            {
                // On every animation Frame we have to update the Camera Distance since Xamarin overrides it somewhere
                SetCameraDistance(_cameraDistance);
            };
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            if (((XNFlipView)e.NewElement) != null)
            {
                // Calculating Camera Distance to be used at Animation Runtime
                // https://forums.xamarin.com/discussion/49978/changing-default-perspective-after-rotation
                var distance = 8000;
                _cameraDistance = Context.Resources.DisplayMetrics.Density * distance;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == XNFlipView.IsFlippedProperty.PropertyName)
            {
                if (!((XNFlipView)sender).IsFlipped)
                {
                    this.RotationY = 0;
                }

                AnimateFlipHorizontally();
            }
        }

        private void AnimateFlipHorizontally()
        {
            SetCameraDistance(_cameraDistance);

            _animateYAxis0To90.Start();
        }
    }
}