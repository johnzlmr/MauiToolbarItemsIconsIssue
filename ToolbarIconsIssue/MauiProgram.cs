using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace ToolbarIconsIssue
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
#if ANDROID
                // Workaround test here https://github.com/dotnet/maui/issues/19673#issuecomment-1984906912
                // But not working
                //.ConfigureMauiHandlers((handlers) =>
                //{
                //    ToolbarHandler.Mapper.ModifyMapping("test", (h, t, action)
                //        =>
                //    {
                //        int menuItemCount = h.PlatformView.Menu?.Size() ?? 0;

                //        if (menuItemCount <= 0 || t is not Toolbar toolbar)
                //            return;

                //        ToolbarItem[] toolbarItems = [.. toolbar.ToolbarItems];

                //        for (int menuItemIndex = 0; menuItemIndex < menuItemCount; menuItemIndex++)
                //        {
                //            IMenuItem? menuItem = h.PlatformView.Menu?.GetItem(menuItemIndex);
                //            menuItem?.SetIcon(null);
                //        }
                //    });
                //    ToolbarHandler.Mapper.PrependToMapping("ToolbarItems", (h, t)
                //        =>
                //    {
                //        int menuItemCount = h.PlatformView.Menu?.Size() ?? 0;

                //        if (menuItemCount <= 0 || t is not Toolbar toolbar)
                //            return;

                //        ToolbarItem[] toolbarItems = [.. toolbar.ToolbarItems];

                //        for (int menuItemIndex = 0; menuItemIndex < menuItemCount; menuItemIndex++)
                //        {
                //            IMenuItem? menuItem = h.PlatformView.Menu?.GetItem(menuItemIndex);
                //            menuItem?.SetIcon(null);
                //        }
                //    });
                //})
#endif
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("MaterialIcons-Regular.ttf", Constants.MaterialIcons.FontName);
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
