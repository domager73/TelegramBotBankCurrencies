namespace TelegramBotBankCurrencies.Models;

public class Bill
{
    public string name;
    public decimal value;

    public Bill(dynamic map, string bill)
    {
        name = map["Valute"][bill]["Name"];
        value = Convert.ToDecimal(Convert.ToDecimal(map["Valute"][bill]["Value"]));
    }

    public override string ToString()
    {
        return $"Название: {name}, Цена: {value}";
    }
}