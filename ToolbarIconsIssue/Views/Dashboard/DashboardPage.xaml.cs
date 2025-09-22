namespace ToolbarIconsIssue.Views.Dashboard;

public partial class DashboardPage : CustomContentPage
{
    public DashboardPage()
    {
        InitializeComponent();
    }

    private void BackBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }


    private void TileOneBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TileOnePage());
    }
}