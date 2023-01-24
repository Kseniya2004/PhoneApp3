namespace PhoneApp3;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        this.BindingContext = new PhonesListViewModel();
    }
}

