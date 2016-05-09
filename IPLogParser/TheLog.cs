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

        public TheLog()
        {
            stupidString = "Hello";
            this.readFromFile("C:\\Users\\Steve\\Source\\Repos\\IPLogParser\\IPLogParser\\Data\\inpatient_testrun_20160504_5.log");
        }

        public async void readFromFile(string filename)
        {
            stupidString = "";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(filename))
                {
                    while(!sr.EndOfStream)
                    {
                        String line = await sr.ReadLineAsync();
                        stupidString += line;
                        stupidString += Environment.NewLine;
                    }
                    
                }
            }
            catch (Exception e)
            {
                stupidString ="The file could not be read:";
                stupidString += e.Message;
            }
            stupidString += "\n";
        }
    }
}
