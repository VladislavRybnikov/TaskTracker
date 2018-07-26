using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Messaging.Entities
{
    /// <summary>
    /// Data mail part. Contains all mail content.
    /// </summary>
    public class DataMailEntity
    {
        public bool IsHtml { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public List<string> Attachments { get; }

        public DataMailEntity()
        {
            Attachments = new List<string>();
        }

    }
}
