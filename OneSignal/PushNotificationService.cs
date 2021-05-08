using Microsoft.Extensions.Options;
using OneSignal.DTOs;
using OneSignal.RestAPIv3.Client;
using OneSignal.RestAPIv3.Client.Resources;
using OneSignal.RestAPIv3.Client.Resources.Notifications;
using System;
using System.Threading.Tasks;

namespace OneSignal
{
    public interface IPushNotificationService
    {
        public Task<string> Send(NotificationRequestDTO request);
    }

    public abstract class PushNotificationService : IPushNotificationService
    {
        public abstract Task<string> Send(NotificationRequestDTO request);
    }

    public class OneSignalService : PushNotificationService
    {
        private readonly IOneSignalClient _signalClient;
        private readonly Config _appConfig;
        public OneSignalService(IOptions<Config> appConfig)
        {
            _appConfig = appConfig.Value;
            _signalClient = new OneSignalClient(_appConfig?.Signal?.RESTKey);
        }

        public override async Task<string> Send(NotificationRequestDTO request)
        {
            var option = BuildOptions(request);
            var result = await _signalClient.Notifications.CreateAsync(option);
            return result.Id;
        }

        private NotificationCreateOptions BuildOptions(NotificationRequestDTO request)
        {
            var opt = new NotificationCreateOptions
            {
                AppId = new Guid(_appConfig.Signal.AppId),
                IncludePlayerIds = request.PlayerIds
            };
            opt.Headings.Add(LanguageCodes.English, request.Title);
            opt.Contents.Add(LanguageCodes.English, request.Content);
            return opt;
        }
    }

}
