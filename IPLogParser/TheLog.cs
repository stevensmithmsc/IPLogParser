using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IPLogParser
{
    public class TheLog : INotifyPropertyChanged
    {

        public ObservableCollection<LogEntry> LogList { get; private set; }
        public IEnumerable <LogEntry> ErrList { get { return LogList.Where(l => l.hasError == true); } }
        private string _fileString; 
        public string fileString { get { return _fileString; } private set { _fileString = value; NotifyPropertyChanged(); } }
        public int noEntries { get { return LogList.Count-1; } }
        public int _noErrors;
        public int noErrors { get { return _noErrors; } private set { _noErrors = value; NotifyPropertyChanged(); } }
        private bool _isLoading;
        public bool IsLoading { get { return _isLoading; } set { _isLoading = value; NotifyPropertyChanged(); } }

        public TheLog()
        {
            LoadLogFileCommand = new DelegateCommand<object>(LoadLogFile);
            fileString = "Hello";
            LogList = new ObservableCollection<LogEntry>();
            LogList.Add(new LogEntry("Stupid"));
            LogList.Add(new LogEntry("Rubbish"));
            noErrors = 0;
            this.readFromFile("C:\\Users\\steven.smith\\Source\\Repos\\IPLogParser\\IPLogParser\\Data\\inpatient_testrun_20160504.log");
        }

        public async void readFromFile(string filename)
        {
            IsLoading = true;
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
                            NotifyPropertyChanged("noEntries");
                            NotifyPropertyChanged("ErrList");
                            currentEntry = new LogEntry(line);
                        } else
                        {
                            currentEntry.AddLine(line);
                        }
                    }     
                }
                fileString = filename;
                if (currentEntry.hasError) noErrors++;
                LogList.Add(currentEntry);
                NotifyPropertyChanged("noEntries");

            }
            catch (Exception e)
            {
                fileString = "The file could not be read:\n";
                fileString += e.Message;
            }
            IsLoading = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand LoadLogFileCommand { get; private set; }

        private void LoadLogFile(object parameter)
        {
            // Create OpenFileDialog 

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".log";
            dlg.Filter = "Log Files (.log)|*.log";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                readFromFile(filename);
            }
        }

        
    }
}

