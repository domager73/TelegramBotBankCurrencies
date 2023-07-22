using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace TelegramBotBankCurrencies.BotInitializer;

public class Bot
{
    private TelegramBotClient _botClient;
    private CancellationTokenSource _cancellationTokenSource;

    public Bot()
    {
        _botClient = new TelegramBotClient("6594005009:AAFLa3LTeN25RWcWZtoibxxn4mQtjtd-ke0");
        _cancellationTokenSource = new CancellationTokenSource();
    }

    public void Start()
    {
        ReceiverOptions receiverOptions = new ReceiverOptions
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        BotRequestHandlers _botRequestHandlers = new BotRequestHandlers();

        _botClient.StartReceiving(
            _botRequestHandlers.HandleUpdateAsync, _botRequestHandlers.HandlePollingErrorAsync, receiverOptions,
            _cancellationTokenSource.Token);
    }

    public string? GetBotName() => _botClient.GetMeAsync().Result.Username;

    public void Stop()
    {
        _cancellationTokenSource.Cancel();
    }
}