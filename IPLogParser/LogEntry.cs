using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPLogParser
{
    public class LogEntry 
    {
        public string Entry { get; set; }
        public bool hasError { get; private set; }  //determines if entry contains an error message
        private bool doneCount;                     //determines if Counted.... line has been reached

        public LogEntry(string startString)
        {
            Entry = startString;
            doneCount = false;
            hasError = false;
        }

        public LogEntry()
        {
            Entry = "";
            doneCount = false;
            hasError = false;
        }

        public void AddLine(string newString)
        {
            bool addNewLine = false;
            if ((!string.IsNullOrEmpty(newString) && char.IsUpper(newString[0]))||(newString.Length>2 && newString[1] == '-')) addNewLine = true;
            if (doneCount) addNewLine = true;
            if (Entry == "") addNewLine = false;

            newString = newString.TrimEnd(' ');

            Entry += addNewLine ? Environment.NewLine + newString : newString;

            if (newString.Length > 7 && newString.Substring(0, 7) == "Counted") doneCount = true;
            if (newString.ToLower().Contains("error")) hasError = true;
        }

        override public string  ToString()
        {
            return Entry;
        }

        
    }
}
