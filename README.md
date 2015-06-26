# NTelegramBot
[Telegram Bot API](https://core.telegram.org/bots/api)

Usage:
```cs
    var bot = new TelegramLoader( token );
    var upds = bot.GetUpdates();

    foreach ( Update upd in upds.Result )
    {
		var msg = upd.Message;

        if ( msg.Text != null )
        {
            var message = bot.SendMessage( msg.Text );
			continue;
        }

        if ( msg.Loacaton != null )
        {
            bot.SendLocation( msg.From.Id, msg.Loacaton );
            continue;
        }

		//...
    }
```