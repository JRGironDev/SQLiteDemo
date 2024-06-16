using SQLiteDemo.MVVM.ViewModels;

namespace SQLiteDemo.MVVM.Views;

public partial class MainPager : ContentPage
{
	public MainPager()
	{
		InitializeComponent();
		BindingContext = new MainPagerViewModel();
	}
}