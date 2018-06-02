using MobileTemplate.ViewModels;

namespace MobileTemplate.Views
{
    public partial class MainView : BaseView<MainViewModel>
    {
		public MainView(object parameter) : base(parameter)
		{
            InitializeComponent();
        }
    }
}
