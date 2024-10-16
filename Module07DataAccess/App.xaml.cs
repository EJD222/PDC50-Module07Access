using Module07DataAccess.Resources.Styles;
namespace Module07DataAccess
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                this.Resources.MergedDictionaries.Add(new WebResources());
            }
        }
    }
}
