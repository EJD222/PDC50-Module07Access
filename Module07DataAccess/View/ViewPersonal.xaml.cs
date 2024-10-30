using Module07DataAccess.Services;
using Module07DataAccess.ViewModel;

namespace Module07DataAccess.View;

public partial class ViewPersonal : ContentPage
{
    public ViewPersonal()
    {
        InitializeComponent();

        var personalViewModel = new PersonalViewModel();
        BindingContext = personalViewModel;

    }

    private async void OpenMainPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }


}