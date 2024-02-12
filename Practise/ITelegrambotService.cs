using Telegram.Bot;

namespace GroupGathererBot.ServiceLayer.Telegrambot;
public interface ITelegrambotService
{
    TelegramBotClient BotClient { get; }
    Task TgBotClient();
}
