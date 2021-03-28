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
using System.Threading;
using System.IO;

namespace progress_bar
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double progressoDellaBarra;
        int caratteriPresenti;
        public MainWindow()
        {
            InitializeComponent();
            progressoDellaBarra = progressbar.Minimum;
            caratteriPresenti = 0;
            ProgressoDellaBarra();
        }

        private void btn_leggiFile_Click(object sender, RoutedEventArgs e)
        {

            using (StreamReader sr = new StreamReader("Data.txt"))
            {

                while (!sr.EndOfStream)
                {
                    string[] appoggio = sr.ReadLine().Split();
                    caratteriPresenti += appoggio.Length;
                    progressoDellaBarra++;
                }
            }
            //lbl_caratteri.Content(caratteriPresenti.ToString());
        }

        private async void ProgressoDellaBarra()
        {
            await Task.Run(() =>
            {
                while (true) 
                {
                    Thread.Sleep(1);
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        progressbar.Value = progressoDellaBarra;
                    }));

                }
            });
        }
    }
}
