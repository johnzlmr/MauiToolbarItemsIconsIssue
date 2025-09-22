namespace ToolbarIconsIssue;

public partial class MainPage : CustomContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void DashboardBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DashboardPage());
    }
}
