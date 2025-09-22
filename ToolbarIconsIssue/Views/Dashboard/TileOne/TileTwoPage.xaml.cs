namespace ToolbarIconsIssue.Views.Dashboard.TileOne;

public partial class TileTwoPage : CustomContentPage
{
    public TileTwoPage()
    {
        InitializeComponent();
    }

    private void BackBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}