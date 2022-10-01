using AspNetCoreHero.ToastNotification;

namespace Bookify.Extensions;

public static class UiServiceExtension
{
    public static IServiceCollection AddUiService(this IServiceCollection services)
    {
        services.AddNotyf(config=> { config.DurationInSeconds = 10;config.IsDismissable = true;config.Position = NotyfPosition.BottomRight; });
        return services;
    }
}