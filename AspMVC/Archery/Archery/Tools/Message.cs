using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Archery.Tools
{
    public sealed class Message
    {
        public MessageType MessageType { get; private set; }

        public string Text { get; private set; }

        public Message(MessageType messageType, string text)
        {
            MessageType = messageType;
            Text = text;
        }

    }

    public enum MessageType
    {
        SUCCESS,
        ERROR
    }
}