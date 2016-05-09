using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPLogParser
{
    class TheLog
    {
        ObservableCollection<LogEntry> LogList { get; }

        public bool readfromfile(string filename)
        {
            return false;
        }
    }
}
