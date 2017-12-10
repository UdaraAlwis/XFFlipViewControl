using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFFlipViewControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XFFlipViewDemoPage : ContentPage
    {
        public XFFlipViewDemoPage()
        {
            InitializeComponent();

            TimerRunner();
        }

        private void flipItButton_OnClicked(object sender, EventArgs e)
        {
            flipItButton.IsEnabled = false;
            XFFlipViewControl1.IsFlipped = !XFFlipViewControl1.IsFlipped;
            flipItButton.IsEnabled = true;
        }

        private void moreButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DemoPage1());
        }

        private void TimerRunner()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1),
                () =>
                {
                    frontViewTimeLabel.Text = $"{DateTime.Now.ToString("F")}";

                    backViewTimeLabel.Text = $"{DateTime.Now.ToString("F")}";

                    return true;
                });
        }
    }
}