using TelegramBotBankCurrencies.BotInitializer;

Bot bot = new Bot();
bot.Start();

Console.WriteLine($"Bot @{bot.GetBotName()} started");

Console.WriteLine("Press enter fr stop");
Console.ReadKey();

bot.Stop();

Console.WriteLine("Bot stopped");