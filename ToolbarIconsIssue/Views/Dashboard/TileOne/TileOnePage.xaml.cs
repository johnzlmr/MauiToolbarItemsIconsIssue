
namespace ToolbarIconsIssue.Views.Dashboard;

public partial class TileOnePage : CustomContentPage
{
    public TileOnePage()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        InitializeFakeList();
    }

    private void InitializeFakeList()
    {
        List<string> itemsSource = [];
        for (int i = 1; i < 50; i++)
            itemsSource.Add($"Item {i}");
        FakeListCv.ItemsSource = itemsSource;
    }

    private void BackBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void TileTwoBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TileTwoPage());
    }
}