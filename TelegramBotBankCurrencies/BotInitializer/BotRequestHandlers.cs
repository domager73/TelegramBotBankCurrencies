using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBotBankCurrencies.BotInitializer;

public class BotRequestHandlers
{
    private BotLogic _botLogic;

    public BotRequestHandlers()
    {
        _botLogic = new BotLogic();
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update,
        CancellationToken cancellationToken)
    {
        long chatId = 0;
        BotMessage responseBotMessage = null!;
        int messageId = 0;
        try
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                    chatId = update.Message!.Chat.Id;
                    messageId = update.Message.MessageId;
                    string textData = update.Message!.Text!;
                    responseBotMessage = _botLogic.ProcessCommandStart(textData);
                    break;

                case UpdateType.CallbackQuery:
                    chatId = update.CallbackQuery!.Message!.Chat.Id;
                    messageId = update.CallbackQuery.Message.MessageId;
                    string callbackData = update.CallbackQuery!.Data!;
                    responseBotMessage =  await _botLogic.ProcessClickOnStartKeyboard(callbackData);
                    break;
            }

            await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: responseBotMessage.Text,
                replyMarkup: responseBotMessage.InlineKeyboardMarkup,
                cancellationToken: cancellationToken);
        }
        catch (Exception e)
        {
            await botClient.DeleteMessageAsync(
                chatId: chatId,
                messageId: messageId,
                cancellationToken: cancellationToken);
        }
    }

    public Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception,
        CancellationToken cancellationToken)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };

        Console.WriteLine(errorMessage);
        return Task.CompletedTask;
    }
}