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
    public partial class DemoPage1 : ContentPage
    {
        public DemoPage1()
        {
            InitializeComponent();
        }

        private async void FlippedButton_OnClicked(object sender, EventArgs e)
        {
            ((Button) sender).IsEnabled = false;

            Random rand = new Random();

            XFFlipViewControl1.IsFlipped = !XFFlipViewControl1.IsFlipped;

            await Task.Delay(rand.Next(200, 1000));

            XFFlipViewControl2.IsFlipped = !XFFlipViewControl2.IsFlipped;

            await Task.Delay(rand.Next(200, 1000));

            XFFlipViewControl3.IsFlipped = !XFFlipViewControl3.IsFlipped;

            await Task.Delay(rand.Next(200, 1000));

            XFFlipViewControl4.IsFlipped = !XFFlipViewControl4.IsFlipped;

            ((Button)sender).IsEnabled = true;
        }
    }
}