using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IPLogParser
{
    public class LogEntry : INotifyPropertyChanged
    {
        public string Entry { get; set; }
        private bool _hasError;
        public bool hasError { get { return _hasError; } private set { _hasError = value; NotifyPropertyChanged(); } }  //determines if entry contains an error message
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

            Entry += addNewLine ? Environment.NewLine + newString : newString;

            if (newString.Length > 7 && newString.Substring(0, 7) == "Counted") doneCount = true;
            if (newString.ToLower().Contains("error")) hasError = true;
        }

        override public string  ToString()
        {
            return Entry;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
