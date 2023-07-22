namespace TelegramBotBankCurrencies.Util;

public class Button
{
    public readonly string Name;
    public readonly string CallBackData;

    public Button(string name, string callBackData)
    {
        Name = name;
        CallBackData = callBackData;
    }
}