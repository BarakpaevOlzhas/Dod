using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
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

namespace NodeApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        static UserText bufText = new UserText();        

        Timer timer = new Timer(SaveText, bufText, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(10));

        

        public MainWindow()
        {
            Timer timerLoad = new Timer(LoadText, null, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1));
            bufText.TextBox = mainText;
            InitializeComponent();            
            mainText = bufText.TextBox;
            timerLoad.Dispose();
        }

        ~MainWindow()
        {
            timer.Dispose();
        }

        private static void SaveText(object textBox)
        {           

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream("Buf.bit", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, bufText);
            }
        }

        private void LoadText(object textBox)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if (System.IO.File.Exists("Buf.bit"))
                using (FileStream fileStream = new FileStream("Buf.bit", FileMode.OpenOrCreate))
            {
                bufText = (UserText)formatter.Deserialize(fileStream);
                    mainText = bufText.TextBox;
            }
        }
    }
}
