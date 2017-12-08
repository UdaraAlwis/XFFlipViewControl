using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFFlipViewControl
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void xfFlipAnimationButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new XFFlipViewDemoPage());
        }

        private void xnFlipAnimationButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new XNFlipViewDemoPage());
        }


        private void flipViewDemo1Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DemoPage1());
        }

        private void flipViewDemo2Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DemoPage2());
        }
    }
}
