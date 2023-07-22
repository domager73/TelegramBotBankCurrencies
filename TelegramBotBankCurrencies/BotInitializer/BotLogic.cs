using System.Text;
using TelegramBotBankCurrencies.DB;
using TelegramBotBankCurrencies.Models;
using TelegramBotBankCurrencies.Util;

namespace TelegramBotBankCurrencies.BotInitializer;

public class BotLogic
{
    public BotMessage ProcessCommandStart(string textData)
    {
        if (textData == "/start")
        {
            return new BotMessage("Привет, выбери один из пунктов меню", InlineKeyboardsMarkupStorage.Start);
        }

        return new BotMessage("Нажмите /start");
    }

    public BotMessage ProcessClickOnStartKeyboard(string callbackData)
    {
        if (callbackData == ButtonsStorage.ShowProfitableBuyUsd.CallBackData)
        {
            List<Currency> currencies = DBManager.Instance.TableCurrencies.GetMinCurrenciesBySell();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (Currency currency in currencies)
            {
                stringBuilder.Append($"Банк: {currency.BankName}, Цена: {currency.UsdBankSell}\n");
            }

            return new BotMessage(stringBuilder.ToString());
        }
        else if (callbackData == ButtonsStorage.ShowProfitableSellUsd.CallBackData)
        {
            return new BotMessage(ButtonsStorage.ShowProfitableSellUsd.CallBackData);
        }
        else if (callbackData == ButtonsStorage.ShowCbUsdCourse.CallBackData)
        {
            return new BotMessage(ButtonsStorage.ShowCbUsdCourse.CallBackData);
        }
        
        throw new Exception("CallBackData не распознана");
    }
}