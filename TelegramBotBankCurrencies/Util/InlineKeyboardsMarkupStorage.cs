using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotBankCurrencies.Util;

public class InlineKeyboardsMarkupStorage
{
    public static InlineKeyboardMarkup Start = new(new[]
    {
        new[]
        {
            InlineKeyboardButton.WithCallbackData(ButtonsStorage.ShowProfitableBuyUsd.Name,
                ButtonsStorage.ShowProfitableBuyUsd.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(ButtonsStorage.ShowProfitableSellUsd.Name,
                ButtonsStorage.ShowProfitableSellUsd.CallBackData),
        },
        new[]
        {
            InlineKeyboardButton.WithCallbackData(ButtonsStorage.ShowCbUsdCourse.Name,
                ButtonsStorage.ShowCbUsdCourse.CallBackData),
        },
    });
}