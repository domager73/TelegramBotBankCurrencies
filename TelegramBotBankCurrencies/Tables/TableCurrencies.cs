using System.Globalization;
using System.Text;
using TelegramBotBankCurrencies.Models;
using Npgsql;

namespace TelegramBotBankCurrencies.Tables;

public class TableCurrencies
{
    private NpgsqlConnection _connection;

    public TableCurrencies(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public List<Currency> GetMinCurrenciesBySell()
    {
        List<Currency> currencies = new List<Currency>();

        string sqlRequest = "SELECT * From currencies Where usd_bank_sell = (Select min(usd_bank_sell) from currencies where usd_bank_sell > 0) ";
        NpgsqlCommand command = new NpgsqlCommand(sqlRequest, _connection);

        NpgsqlDataReader dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            string bankName = dataReader.GetString(dataReader.GetOrdinal("bank_name"));
            decimal usdBankSell = dataReader.GetDecimal(dataReader.GetOrdinal("usd_bank_sell"));

            currencies.Add(new Currency()
            {
                BankName = bankName,
                UsdBankSell = usdBankSell,
            });
        }

        dataReader.Close();

        return currencies;
    }
    
    public List<Currency> GetMinCurrenciesByBuy()
    {
        List<Currency> currencies = new List<Currency>();

        string sqlRequest = "SELECT * From currencies Where usd_bank_buy = (Select min(usd_bank_buy) from currencies where usd_bank_buy > 0)";
        NpgsqlCommand command = new NpgsqlCommand(sqlRequest, _connection);

        NpgsqlDataReader dataReader = command.ExecuteReader();

        while (dataReader.Read())
        {
            string bankName = dataReader.GetString(dataReader.GetOrdinal("bank_name"));
            decimal usdBankBuy = dataReader.GetDecimal(dataReader.GetOrdinal("usd_bank_buy"));

            currencies.Add(new Currency()
            {
                BankName = bankName,
                UsdBankBuy = usdBankBuy,
            });
        }

        dataReader.Close();

        return currencies;
    }
}