using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace GroupGathererBot.ServiceLayer.Telegrambot;
public class TelegrambotService : ITelegrambotService
{
    public TelegramBotClient BotClient { get; }

    public TelegrambotService(string apiKey)
    {
        BotClient = new(apiKey);
    }

    public Task TgBotClient()
    {
        using CancellationTokenSource cts = new();
        ReceiverOptions options = new ReceiverOptions()
        {
            AllowedUpdates = Array.Empty<UpdateType>()
        };

        BotClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: options,
                cancellationToken: cts.Token
            );

        return Task.CompletedTask;
    }

    private async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { } message) return;

        if (update.Message is not { } messageText) return;

        var chatId = message.Chat.Id;
        await Console.Out.WriteLineAsync($"Xabar: {messageText}\nChatId: {chatId}");

        Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "You said:\n" + messageText,
                cancellationToken: cancellationToken
            );
    }

    private Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
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
}   
