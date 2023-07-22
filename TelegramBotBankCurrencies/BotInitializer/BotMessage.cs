using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotBankCurrencies.BotInitializer;

public class BotMessage
{
    public string Text { get; }
    public InlineKeyboardMarkup InlineKeyboardMarkup { get; }

    public BotMessage(string text)
    {
        Text = text;
        InlineKeyboardMarkup = InlineKeyboardMarkup.Empty();
    }

    public BotMessage(string text, InlineKeyboardMarkup inlineKeyboardMarkup)
    {
        Text = text;
        InlineKeyboardMarkup = inlineKeyboardMarkup;
    }
}