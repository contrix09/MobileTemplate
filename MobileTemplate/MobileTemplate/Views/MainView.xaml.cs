using MobileTemplate.ViewModels;

namespace MobileTemplate.Views
{
    public partial class MainView : BaseMainView
    {
		public MainView()
		{
            InitializeComponent();
        }

        public override void CleanUp()
        {
            base.CleanUp();
            this.WelcomeLabel.GestureRecognizers.Clear();
        }
    }

    public class BaseMainView : BaseView<MainViewModel> { }
}
