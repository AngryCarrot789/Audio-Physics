using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace AudioPhysics.Helpers
{
    class AnimationLib
    {

        //Made by ADeltaX :P

        /// <summary>
        /// Use this method to make an animation for a control in Y axis
        /// </summary>
        /// <param name="cntrl">The targhetting Control</param>
        /// <param name="YPos">Here the position to add</param>
        /// <param name="TimeSecond">The duration of the animation</param>
        /// <param name="TimeMillisecond">The delay of the animation</param>
        public static void MoveToTargetY(Control cntrl, double YPos, double TimeSecond, double TimeMillisecond = 0)
        {
            cntrl.Margin = new Thickness(cntrl.Margin.Left, cntrl.Margin.Top - YPos, cntrl.Margin.Right, cntrl.Margin.Bottom + YPos);
            QuadraticEase EP = new QuadraticEase();
            EP.EasingMode = EasingMode.EaseOut;

            var DirY = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(TimeSecond)),
                From = 0,
                To = YPos,
                BeginTime = TimeSpan.FromMilliseconds(TimeMillisecond),
                EasingFunction = EP,
                AutoReverse = false
            };
            cntrl.RenderTransform = new TranslateTransform();
            cntrl.RenderTransform.BeginAnimation(TranslateTransform.YProperty, DirY);
        }

        /// <summary>
        /// Use this method to make an animation for a control in X axis
        /// </summary>
        /// <param name="cntrl">The targhetting Control</param>
        /// <param name="XPos">Here the position to add</param>
        /// <param name="TimeSecond">The duration of the animation</param>
        /// <param name="TimeMillisecond">The delay of the animation</param>
        public static void MoveToTargetX(Control cntrl, double XPos, double TimeSecond, double TimeMillisecond = 0)
        {
            cntrl.Margin = new Thickness(cntrl.Margin.Left - XPos, cntrl.Margin.Top, cntrl.Margin.Right + XPos, cntrl.Margin.Bottom);
            QuinticEase EP = new QuinticEase();
            EP.EasingMode = EasingMode.EaseOut;

            var DirX = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(TimeSecond)),
                From = 0,
                To = XPos,
                BeginTime = TimeSpan.FromMilliseconds(TimeMillisecond),
                EasingFunction = EP,
                AutoReverse = false
            };
            cntrl.RenderTransform = new TranslateTransform();
            cntrl.RenderTransform.BeginAnimation(TranslateTransform.XProperty, DirX);
        }
        public static void OpacityControl(Control cntrl, double From, double To, double TimeSecond, double TimeMillisecond = 0)
        {
            QuinticEase EP = new QuinticEase();
            EP.EasingMode = EasingMode.EaseOut;

            var Dir = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(TimeSecond)),
                From = From,
                To = To,
                BeginTime = TimeSpan.FromMilliseconds(TimeMillisecond),
                EasingFunction = EP,
                AutoReverse = false
            };
            cntrl.BeginAnimation(UIElement.OpacityProperty, Dir);
        }
    }
}
