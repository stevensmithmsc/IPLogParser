using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IPLogParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            TheLog theLog = new TheLog();
            theLog.readFromFile("C:\\Users\\steven.smith\\Source\\Repos\\IPLogParser\\IPLogParser\\Data\\inpatient_testrun_20160504_5.log");
            InitializeComponent();
            
        }
    }
}
