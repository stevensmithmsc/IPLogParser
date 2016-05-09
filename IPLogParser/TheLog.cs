using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPLogParser
{
    public class TheLog
    {
        public ObservableCollection<LogEntry> LogList { get; private set; }
        public string stupidString { get; private set; }

        public bool readFromFile(string filename)
        {
            stupidString = "";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(filename))
                {
                    while(!sr.EndOfStream)
                    {
                        String line = sr.ReadLine();
                        stupidString += line;
                    }
                    
                }
                return true;
            }
            catch (Exception e)
            {
                stupidString ="The file could not be read:";
                stupidString += e.Message;
                return false;
            }
                        
        }
    }
}
