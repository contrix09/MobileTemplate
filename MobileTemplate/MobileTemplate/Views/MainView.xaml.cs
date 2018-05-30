using MobileTemplate.ViewModels;

namespace MobileTemplate.Views
{
    public partial class MainView : BaseView<MainViewModel>
	{
		public MainView()
		{
            InitializeComponent();

            // Always bind view model after initialize component
            // There may be some cases where the UI have not yet been laid out
            this.BindingContext = this.ViewModel; 
        }
	}
}
