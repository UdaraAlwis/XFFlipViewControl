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

        private void flipViewDemoButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DemoPage());
        }

        private void xfFlipAnimationButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new XFFlipViewDemoPage());
        }

        private void xnFlipAnimationButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new XNFlipViewDemoPage());
        }
    }
}
