using System;
using System.IO;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Args;
using GoogleApi;

namespace MassmannTelegramBot
{
    class Program
    {
        static ITelegramBotClient botClient;
        static readonly string[] s_Scopes;

        static void Main(string[] args)
        {
            string[] s_ApiToken;
            try
            {
                s_ApiToken = File.ReadAllLines("../../telegrambot.token");
                // System.Console.WriteLine(sApiToken[0]);
            }
            catch (InvalidCastException e)
            {
                System.Console.WriteLine("error error: {0}", e);
                s_ApiToken = new string[1];
            }
            botClient = new TelegramBotClient(s_ApiToken[0]);
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
