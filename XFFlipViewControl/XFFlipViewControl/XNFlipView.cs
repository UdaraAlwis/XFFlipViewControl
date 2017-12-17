using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFFlipViewControl
{
    /// <summary>
    /// Flip View Animation Control built with Xamarin Native Renderers
    /// </summary>
    public class XNFlipView : ContentView
    {
        private readonly RelativeLayout _contentHolder;

        public XNFlipView()
        {
            _contentHolder = new RelativeLayout();
            Content = _contentHolder;
        }

        public static readonly BindableProperty FrontViewProperty =
        BindableProperty.Create(
            nameof(FrontView),
            typeof(View),
            typeof(XNFlipView),
            null,
            BindingMode.Default,
            null,
            FrontViewPropertyChanged);

        private static void FrontViewPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                ((XNFlipView)bindable)
                    ._contentHolder
                    .Children
                    .Add(((XNFlipView)bindable).FrontView,
                        Constraint.Constant(0),
                        Constraint.Constant(0),
                        Constraint.RelativeToParent((parent) => parent.Width),
                        Constraint.RelativeToParent((parent) => parent.Height)
                    );
            }
        }

        /// <summary>
        /// Gets or Sets the front view
        /// </summary>
        public View FrontView
        {
            get { return (View)this.GetValue(FrontViewProperty); }
            set { this.SetValue(FrontViewProperty, value); }
        }



        public static readonly BindableProperty BackViewProperty =
        BindableProperty.Create(
            nameof(BackView),
            typeof(View),
            typeof(XNFlipView),
            null,
            BindingMode.Default,
            null,
            BackViewPropertyChanged);

        private static void BackViewPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            //Set BackView Rotation before rotating
            if (newvalue != null)
            {
                ((XNFlipView)bindable)
                    ._contentHolder
                    .Children
                    .Add(((XNFlipView)bindable).BackView,
                        Constraint.Constant(0),
                        Constraint.Constant(0),
                        Constraint.RelativeToParent((parent) => parent.Width),
                        Constraint.RelativeToParent((parent) => parent.Height)
                     );

                ((XNFlipView)bindable).BackView.IsVisible = false;
            }
        }

        /// <summary>
        /// Gets or Sets the back view
        /// </summary>
        public View BackView
        {
            get { return (View)this.GetValue(BackViewProperty); }
            set { this.SetValue(BackViewProperty, value); }
        }



        public static readonly BindableProperty IsFlippedProperty =
        BindableProperty.Create(
            nameof(IsFlipped),
            typeof(bool),
            typeof(XNFlipView),
            false,
            BindingMode.Default,
            null);

        /// <summary>
        /// Gets or Sets whether the view is already flipped
        /// ex : 
        /// </summary>
        public bool IsFlipped
        {
            get { return (bool)this.GetValue(IsFlippedProperty); }
            set { this.SetValue(IsFlippedProperty, value); }
        }
    }
}
