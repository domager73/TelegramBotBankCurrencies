using System.Text;
using TelegramBotBankCurrencies.DB;
using TelegramBotBankCurrencies.Models;
using TelegramBotBankCurrencies.Servise;
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

    public async Task<BotMessage> ProcessClickOnStartKeyboard(string callbackData)
    {
        if (callbackData == ButtonsStorage.ShowProfitableBuyUsd.CallBackData)
        {
            List<Currency> currencies = DBManager.Instance.TableCurrencies.GetMinCurrenciesBySell();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (Currency currency in currencies)
            {
                stringBuilder.Append($"Банк: {currency.BankName}, Покупка: {currency.UsdBankSell}\n");
            }

            return new BotMessage(stringBuilder.ToString());
        }
        else if (callbackData == ButtonsStorage.ShowProfitableSellUsd.CallBackData)
        {
            List<Currency> currencies = DBManager.Instance.TableCurrencies.GetMinCurrenciesByBuy();

            StringBuilder stringBuilder = new StringBuilder();

            foreach (Currency currency in currencies)
            {
                stringBuilder.Append($"Банк: {currency.BankName}, Продажа: {currency.UsdBankBuy}\n");
            }

            return new BotMessage(stringBuilder.ToString());
        }
        else if (callbackData == ButtonsStorage.ShowCbUsdCourse.CallBackData)
        {
            string usd = await CbApi.GetBillByBill("USD");
            
            return new BotMessage(usd);
        }
        
        throw new Exception("CallBackData не распознана");
    }
}