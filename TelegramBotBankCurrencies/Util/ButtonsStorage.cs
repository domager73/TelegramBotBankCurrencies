namespace TelegramBotBankCurrencies.Util;

public class ButtonsStorage
{
    public static Button ShowProfitableBuyUsd { get; } = new Button("Показать выгодную покупку", "ButtonShowProfitableBuyUsd");
    public static Button ShowProfitableSellUsd { get; } = new Button("Показать выгодную продажу", "ButtonShowProfitableSellUsd");
    public static Button ShowCbUsdCourse { get; } = new Button("Курс ЦБ", "ButtonShowCbUsdCourse");
}