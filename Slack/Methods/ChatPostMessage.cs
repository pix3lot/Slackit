using System.Collections.Generic;

namespace Slack
{
    public class ChatPostMessage
    {
        /// <summary>
        /// Required destination channel
        /// </summary>
        public string channel { get; set; }
        /// <summary>
        /// Required text that will be posted to the channel
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// Optional override of the username that is displayed
        /// </summary>
        public string username { get; set; }
        /// <summary>
        /// Optional override to post as user
        /// </summary>
        public bool as_user { get; set; }
        /// <summary>
        /// Optional override to change how messages are treated
        /// </summary>
        public string parse { get; set; }
        /// <summary>
        /// Optional override to find and link channel and usernames.
        /// </summary>
        public int link_names { get; set; }
        /// <summary>
        /// Optional attachment collection
        /// </summary>
        public Attachments[] attachments { get; set; }
        /// <summary>
        /// Optional override to unfurl links. True = enabled.
        /// </summary>
        public bool unfurl_links { get; set; }
        /// <summary>
        /// Optional override to unfurl media. True = enabled.
        /// </summary>
        public bool unfurl_media { get; set; }
        /// <summary>
        /// Optional icon displayed with the message
        /// </summary>
        public string icon_url { get; set; }
        /// <summary>
        /// Optional emoji displayed with the message
        /// </summary>
        public string icon_emoji { get; set; }

    }

    public class Attachments
    {
        /// <summary>
        /// Required text summary of the attachment that is shown by clients that understand attachments but choose not to show them.
        /// </summary>
        public string fallback { get; set; }
        /// <summary>
        /// Optional text that should appear within the attachment
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// Optional text that should appear above the formatted data
        /// </summary>
        public string pretext { get; set; }
        /// <summary>
        /// Can either be one of 'good', 'warning', 'danger', or any hex color code
        /// </summary>
        public string color { get; set; }
        /// <summary>
        /// Fields are displayed in a table on the message
        /// </summary>
        public Fields[] fields { get; set; }
        /// <summary>
        /// A valid URL to an image file that will be displayed inside a message attachment. GIF, JPEG, PNG, and BMP.
        /// </summary>
        public string image_url { get; set; }
        /// <summary>
        /// A valid URL to an image file that will be displayed as a thumbnail on the right side of a message attachment. GIF, JPEG, PNG, and BMP.
        /// </summary>
        public string thumb_url { get; set; }
    }

    public class Fields
    {
        public string title { get; set; }
        public string value { get; set; }
        public bool @short { get; set; }
    }

}

