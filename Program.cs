using System;
using System.IO;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace MassmannTelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            static ITelegramBotClient botClient;
            string[] sApiToken;
            try
            {
                sApiToken = File.ReadAllLines("../../telegrambot.token");
                // System.Console.WriteLine(sApiToken[0]);
            }
            catch (InvalidCastException e)
            {
                System.Console.WriteLine("error error: {0}", e);
                sApiToken = new string[1];
            }
            botClient = new TelegramBotClient(sApiToken[0]);
            var me = botClient.GetMeAsync().Result;
            System.Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
        }
        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text != null)
            {
                Console.WriteLine($"Received a text message in chat {e.Message.Chat.Id}.");

                await botClient.SendTextMessageAsync(
                  chatId: e.Message.Chat,
                  text: "You said:\n" + e.Message.Text
                );
            }
        }
    }
}
