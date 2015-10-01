/*Example Slack post format
 * 
 * 
 * 
 */
                //Create client
                var slackClient = new SlackClient();

                //Delete message
                slackClient.DeleteMessage(msg_ts);
                msg_ts.Clear();

                //Post message
                string text = ""; //Keep "" as its required by the WebAPI, but not required to contain anything if included in attachments
                string botname = "Synching Info";
                string parse = null;
                bool linkNames = false;
                bool unfurl_links = false;
                string icon_url = Variables.icon_slacker;
                string icon_emoji = null;    

                var attachments = new Attachments
                {
                    fallback = Variables.logUsername + "has synched",
                    pretext = "Synchronize with central completed",
                    color = "good",
                    fields =
                        new Fields[]
                        {
                            new Fields
                            {
                                title = "Status",
                                value = Variables.logUsername + " has synched to central.\n[" + Variables.logFileCentralName + "]",
                                @short = true
                            },
                            new Fields
                            {
                                title = "Duration",
                                value = string.Format("{0:hh\\:mm\\:ss}", Variables.logSyncDuration),
                                @short = true
                            }
                        }
                };

                //Post & get response
                string msg_response = slackClient.PostMessage(text, botName: botname, attachments: attachments, icon_url: icon_url).Content;
                var resp = JsonConvert.DeserializeObject<ChatPostMessageResponse>(msg_response);
                
                //Add message timestamp (ts) to list for deleting
                msg_ts.Add(resp.ts);
 
                //Set last synched msg time for idle event
                synchedmsg = DateTime.Now;