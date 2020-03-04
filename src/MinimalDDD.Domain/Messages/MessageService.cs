using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;
using System.Threading;

namespace MinimalDDD.Domain
{
    public class MessageService
    {
        public static string Message(MessageSystem msg)
            => Message(msg, Thread.CurrentThread.CurrentCulture);

        public static string Message(MessageSystem msg, params string[] parameters)
            => string.Format(Message(msg, CultureInfo.CurrentCulture), parameters);

        public static string Message(MessageSystem message, CultureInfo culture)
            => !string.IsNullOrEmpty(ResourceMgr.GetString(message.ToString(), culture)) ? ResourceMgr.GetString(message.ToString(), culture) : string.Empty;

        public static ResourceManager ResourceMgr
            => new ResourceManager("MinimalDDD.Api.Message.Languages", typeof(MessageService).Assembly);
    }
}
