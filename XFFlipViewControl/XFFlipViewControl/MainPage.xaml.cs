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

            TimerRunner();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            //FlipControl.MoveToPreviousCommand?.Execute(null);

            XFFlipViewControl.IsFlipped = !XFFlipViewControl.IsFlipped;
        }

        private void TimerRunner()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), 
                ()=>
                {
                    frontViewTimeLabel.Text = $"Timestamp: {DateTime.Now}";

                    backViewTimeLabel.Text = $"Timestamp: {DateTime.Now}";

                    return true;
                });
        }
    }
}
