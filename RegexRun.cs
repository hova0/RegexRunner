using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RegExHelper
{

	public class RegexRun 
	{
		
		public string regex_replace;
		public string input_text;
		public string regex_match;
		public System.Text.RegularExpressions.RegexOptions iregexoptions;
		public bool regex_checkbox_multiLine;
		public bool regex_checkBox_singleline;
		public bool regex_match_mode;
        public bool casesensitive = false;
        public bool ignoreduplicates = false;
		public event MessageHandler OnMessage;
		public delegate void MessageHandler(object sender, MessageEventArgs e);
		public class MessageEventArgs : System.EventArgs
		{
			public string messagetype;
			public string message;
		}

		//public event RunRegexCompleted as RunRegexCompletedHandler;
		public delegate void RunRegexCompletedHandler(object sender, EventArgs e);
		public event RunRegexCompletedHandler RegexFinished;



		System.Threading.Thread oth;
		public void RunRegexAsync()
		{
			if(oth != null && oth.IsAlive)
			{
				//Only allow one thread per class
				oth.Abort();
			}
			
			oth = new System.Threading.Thread(new System.Threading.ThreadStart(RunRegex));
			oth.Start();
			// and off we go!
		}


		private void RunRegex() {

			
			string regex_output_text;
			iregexoptions = RegexOptions.None;
			System.Text.RegularExpressions.Regex thisregex;

			//Replace any \t with actual tabs in replace expression
			//regex_replace = Regex.Replace(regex_replace, @"[^\\]?\\t", "\t");
            regex_replace = regex_replace.Replace("\\t", "\t");     // replace \t with a tab
            regex_replace = regex_replace.Replace("\\\t", "\\t");   // restore \[tab] with \\t
			//regex_replace = Regex.Replace(regex_replace, @"[^\\]?\\n", "\n");
            regex_replace = regex_replace.Replace("\\n", "\n");
            regex_replace = regex_replace.Replace("\\\n", "\\n");
			//regex_replace = Regex.Replace(regex_replace, @"[^\\]?\\r", "\r");
            regex_replace = regex_replace.Replace("\\r", "\r");
            regex_replace = regex_replace.Replace("\\\r", "\\r");


			regex_replace = Regex.Replace(regex_replace, @"[^\\]?\\d", System.DateTime.Now.ToShortDateString());
            //regex_replace = regex_replace.Replace("\\d", "\n");
            //regex_replace = regex_replace.Replace("\\\n", "\\n");

            regex_match = regex_match.Replace("\\t", "\t");     // replace \t with a tab
            regex_match = regex_match.Replace("\\\t", "\\t");   // restore \[tab] with \\t
            //regex_replace = Regex.Replace(regex_replace, @"[^\\]?\\n", "\n");
            regex_match = regex_match.Replace("\\n", "\n");
            regex_match = regex_match.Replace("\\\n", "\\n");
            //regex_replace = Regex.Replace(regex_replace, @"[^\\]?\\r", "\r");
            regex_match = regex_match.Replace("\\r", "");   // \r is removed through end of line normalization
            //regex_match = regex_match.Replace("\\\r", "\\r");

			if(regex_checkbox_multiLine)
			{
				iregexoptions |= System.Text.RegularExpressions.RegexOptions.Multiline;
			}
			if(regex_checkBox_singleline)
			{
				iregexoptions |= System.Text.RegularExpressions.RegexOptions.Singleline;
			}
            try
            {
                thisregex = new System.Text.RegularExpressions.Regex(regex_match, (casesensitive ? System.Text.RegularExpressions.RegexOptions.IgnoreCase : 0) | iregexoptions);
            }
            catch (System.Exception ex)
            {
                OnMessageEvent("output", "EXCEPTION:" + ex.Message);
        		RegexFinished.BeginInvoke(this, System.EventArgs.Empty, null, null);
                return ;
            }
			//The Actual regular expression
			
			if(!regex_match_mode)
			{

				input_text = input_text.Replace("\r", "");  //Normalize CRLFs
                // Run the user-entered regex and normalize LF's back to CRLFs
                try
                {
                    regex_output_text = thisregex.Replace(input_text, regex_replace).Replace("\n", "\r\n");
                }
                catch (Exception ex)
                {
                     
                    OnMessageEvent("output", "EXCEPTION:" + ex.Message);
        		    RegexFinished.BeginInvoke(this, System.EventArgs.Empty, null, null);
                    return ;

                }
				//HANDLE THE \l operator
				int lpos = 0;
				while(regex_output_text.IndexOf(@"\l") != -1)
				{
					lpos = regex_output_text.IndexOf(@"\l");
					regex_output_text = regex_output_text.Substring(0, lpos) + regex_output_text.Substring(lpos + 2, 1).ToLower() + regex_output_text.Substring(lpos + 3);
				}
				OnMessageEvent("output", regex_output_text);
				RegexFinished.Invoke(this, System.EventArgs.Empty);
			} else
			{
				// Output contains only matches : ignore the rest
				input_text = input_text.Replace("\r", "");
				System.Text.StringBuilder tempstring = new System.Text.StringBuilder();
//				output_textbox.Text = "";
				System.Text.RegularExpressions.MatchCollection mymatches = thisregex.Matches(input_text);

				if(mymatches.Count == 0) { OnMessageEvent("label", "No occurances found."); /*output_textbox.Text = "";*/ }
				string backupreplace;
				int icounter = 0;
                // Initializes the incrementing counter with starting value in replace expression
				if(System.Text.RegularExpressions.Regex.Match(regex_replace, @"\\i\d+").Success)
				{
					icounter = Convert.ToInt32(System.Text.RegularExpressions.Regex.Match(regex_replace, @"\\i(\d+)").Groups[1].Value);
					regex_replace = System.Text.RegularExpressions.Regex.Replace(regex_replace, @"\\i\d+", @"\i");  //remove initial value
				}

                string matchvalue = "";
                System.Collections.Generic.List<string> previousmatches = new List<string>(mymatches.Count);
                try
                {
                    for (int i = 0; i < mymatches.Count; i++)
                    {
                        matchvalue = mymatches[i].Value;
                        if (ignoreduplicates && previousmatches.Contains(matchvalue))
                        {
                            continue;
                        }
                        if (regex_replace.Length == 0)   //If they didn't provide a replace expression, then output the matches
                            tempstring.Append(matchvalue + "\r\n");
                        else
                        {
                            if (regex_replace.IndexOf(@"\i") != -1)
                            {
                                // System.Windows.Forms.MessageBox.Show("found a number" + icounter.ToString());
                                backupreplace = regex_replace;
                                regex_replace = regex_replace.Replace(@"\i", icounter.ToString());
                                icounter++;

                                tempstring.Append(System.Text.RegularExpressions.Regex.Replace(matchvalue, regex_match, regex_replace, System.Text.RegularExpressions.RegexOptions.IgnoreCase | iregexoptions));
                                regex_replace = backupreplace;
                            }
                            else
                            {
                                tempstring.Append(System.Text.RegularExpressions.Regex.Replace(matchvalue, regex_match, regex_replace, System.Text.RegularExpressions.RegexOptions.IgnoreCase | iregexoptions));
                            }
                        }
                        previousmatches.Add(matchvalue);
                    }
                    OnMessageEvent("output", tempstring.ToString().Replace("\n", "\r\n"));
                }
                catch (System.Exception ex)
                {
                    OnMessageEvent("output", "EXCEPTION:" + ex.Message);
                }
				//output_textbox.Text = tempstring.ToString().Replace("\n", "\r\n");
			}
			//Perform line terminator massaging

			RegexFinished.BeginInvoke(this, System.EventArgs.Empty, null, null);

			return ;
		}

	private void OnMessageEvent(string messagetype, string message) {
		MessageEventArgs mea = new MessageEventArgs();
		mea.messagetype = messagetype;
		mea.message = message;
		OnMessage.BeginInvoke(this, mea, null, null);

	}

	}



}
