using Newtonsoft.Json;
using TelegramBotBankCurrencies.Models;

namespace TelegramBotBankCurrencies.Servise;

public static class CbApi
{
    private static string _url = "https://www.cbr-xml-daily.ru/daily_json.js";
    private static HttpClient _client = new();

    public static async Task<string> GetBillByBill(string billName)
    {
        var json =  await _client.GetStringAsync(
            "https://www.cbr-xml-daily.ru/daily_json.js");
        dynamic map = JsonConvert.DeserializeObject(json)!;

        Bill bill = new Bill(map, billName);
        
        return bill.ToString();
    }
}