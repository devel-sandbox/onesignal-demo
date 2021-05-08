using System;
using System.Collections.Generic;
using System.Text;

namespace OneSignal.DTOs
{
    public class NotificationRequestDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> PlayerIds { get; set; }
    }
}
