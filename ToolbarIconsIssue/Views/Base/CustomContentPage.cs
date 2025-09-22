namespace ToolbarIconsIssue.Views.Base;

public class CustomContentPage : ContentPage
{
    // For printing debug informations but nothing relevant
    private readonly bool _activeDebugPrint = false;

    public CustomContentPage()
    {
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        PrintToolbarItems();
    }

    protected override void OnDisappearing()
    {
        base.OnAppearing();
        PrintToolbarItems();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        PrintToolbarItems();
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
        PrintToolbarItems();
    }

    /// <summary>
    /// Print some informations from toolbaritems but nothing wrong seems to appear
    /// </summary>
    /// <param name="name"></param>
    protected void PrintToolbarItems([CallerMemberName] string? name = null)
    {
        if (!_activeDebugPrint)
            return;

        if (ToolbarItems is null || ToolbarItems.Count == 0)
        {
            Debug.WriteLine("####### NO TOOLBARITEMS");
            return;
        }

        var toolbarItems = ToolbarItems.Where(x => x.Order == ToolbarItemOrder.Primary || x.Order == ToolbarItemOrder.Default);

        var toolbarDesc = $"############ Toolbar items : >>{name} - {GetType()}<<" + Environment.NewLine;
        List<string> listItems = [];
        foreach (var item in toolbarItems)
        {
            listItems.Add(GetDescItem(item));
        }

        toolbarDesc += string.Join(Environment.NewLine, listItems);
        Debug.WriteLine(toolbarDesc);
    }

    private string GetDescItem(ToolbarItem toolbarItem)
    {
        if (toolbarItem is null)
            return "none";

        var desc = string.Empty;
        desc += $"ToolbarItem[{nameof(toolbarItem.Text)}:{toolbarItem.Text} | {nameof(toolbarItem.Priority)}:{toolbarItem.Priority}]";

        if (toolbarItem.IconImageSource is not IFontImageSource fontSource)
            return desc;

        try
        {
            var glyphBytes = Encoding.Unicode.GetBytes(fontSource.Glyph);
            var glyph = BitConverter.ToString(glyphBytes);

            desc += $"&ImageSource[{nameof(fontSource.Glyph)}:{glyph} | {nameof(fontSource.Font)}:{fontSource.Font}]";
        }
        catch (Exception)
        {
            desc += $"&ImageSource[decoding error]";
        }

        return desc;
    }
}
