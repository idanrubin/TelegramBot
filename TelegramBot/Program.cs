using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot
{
    class Program
    {
     private static readonly  TelegramBotClient Bot = new TelegramBotClient("u");

        static void Main(string[] args)
        {
            Bot.OnMessage += BotOnOnMessage;
            Bot.OnMessageEdited += BotOnOnMessage;
            
            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void BotOnOnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
            {
                if (e.Message.Text.ToLower() == "need food" || e.Message.Text.ToLower() == "/need_food")
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, RandomEat());
                }
                else if(e.Message.Text.ToLower() == "/start")
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "please text me: need food");
                }
                else if (e.Message.Text.ToLower() == "/help" || e.Message.Text.ToLower() == "help")
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, "אני מחליט מה אוכלים היום");
                }
                else
                {
                    Bot.SendTextMessageAsync(e.Message.Chat.Id, @"Don't be smart,
                    Usage Only : need food or help command");
                }
            }
        }

        private static string RandomEat()
        {
            var foodList = new List<string> {"שלושה", "חומוס", "ג'ירף", "חויה", "שוק", "מזנון"};
            var random = new Random();
            var randomNumber = random.Next(0, foodList.Count);
            return foodList[randomNumber];
        }
    }
}
