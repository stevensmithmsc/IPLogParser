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
        public int noEntries { get { return LogList.Count; } }
        public int noErrors { get; private set;}

        public TheLog()
        {
            stupidString = "Hello";
            LogList = new ObservableCollection<LogEntry>();
            LogList.Add(new LogEntry("Stupid"));
            LogList.Add(new LogEntry("Rubbish"));
            noErrors = 0;
            this.readFromFile("C:\\Users\\steven.smith\\Source\\Repos\\IPLogParser\\IPLogParser\\Data\\inpatient_testrun_20160504.log");
        }

        public async void readFromFile(string filename)
        {
            LogList.Clear();
            noErrors = 0;
            try
            {   
                LogEntry currentEntry = new LogEntry();                
                // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(filename))
                {

                    while(!sr.EndOfStream)
                    {
                        String line = await sr.ReadLineAsync();
                        if (line.Length > 8 && line.Substring(0,8)=="Spell ID")
                        {
                            if (currentEntry.hasError) noErrors++;
                            LogList.Add(currentEntry);
                            currentEntry = new LogEntry(line);
                        } else
                        {
                            currentEntry.AddLine(line);
                        }
                    }     
                }
                stupidString = filename;
                if (currentEntry.hasError) noErrors++;
                LogList.Add(currentEntry);
                
            }
            catch (Exception e)
            {
                stupidString = "The file could not be read:\n";
                stupidString += e.Message;
            }
            
        }
    }
}



/*
 * http://www.c-sharpcorner.com/uploadfile/mahesh/openfiledialog-in-wpf/
// Create OpenFileDialog 

Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();            

// Set filter for file extension and default file extension 
dlg.DefaultExt = ".txt"; 
dlg.Filter = "Text documents (.txt)|*.txt";  


// Display OpenFileDialog by calling ShowDialog method 
Nullable<bool> result = dlg.ShowDialog(); 

// Get the selected file name and display in a TextBox 
if (result == true) 
{ 
    // Open document 
    string filename = dlg.FileName; 
    FileNameTextBox.Text = filename; 
 }
*/
