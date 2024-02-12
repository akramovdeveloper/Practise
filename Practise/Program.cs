using DocumentFormat.OpenXml.Wordprocessing;
using Practise.CombineTwoExcelFiles;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using static System.Net.WebRequestMethods;

namespace Practise;

internal class Program
{
    public static string botToken = "6258639001:AAFDjpTwuIQZxEBHf1XgJvaD7yDKemkPll0";
    //public long sourceGroupId = -1001238611612;
    public static long destinationGroupId = -1001898663340;
    public static TelegramBotClient botClient = new TelegramBotClient(botToken);

    static void Main(string[] args)
    {
        CombineTwoExcelSolution.Solution();

        //var updateHandler = new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync);

        //botClient.StartReceiving(updateHandler);

        //Console.WriteLine("Dasturni to'xtatish uchun 'Enter' tugmasini bosing.");
        //Console.ReadLine();

        //botClient.StopReceiving();
    }

    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is Message message)
        {
            await Console.Out.WriteLineAsync($"{message.Chat.Id}\n{message.Text}");
            await ForwardMessageToDestinationGroup(message, destinationGroupId);
        }
    }

    private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n[{apiRequestException.Message}]",
            _ => exception.ToString()
        };
        Console.WriteLine(errorMessage);
        return Task.CompletedTask;
    }

    /*private async void Bot_OnMessage(object sender, Update e)
    {
        var message = e.Message;

        if (message is not null)
            await ForwardMessageToDestinationGroup(message, destinationGroupId);
    }*/

    private static async Task ForwardMessageToDestinationGroup(
        Message message, long destinationGroupId)
    {
        try
        {
            await botClient.ForwardMessageAsync(
                chatId: destinationGroupId,
                fromChatId: message.Chat.Id,
                messageId: message.MessageId
            );

            Console.WriteLine($"Xabar boshqa guruhga yuborildi: {message.Text}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Xabar yuborishda xatolik: {ex.Message}");
        }
    }
}
