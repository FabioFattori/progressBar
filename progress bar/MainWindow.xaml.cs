using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace progress_bar
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double progressoDellaBarra;
        int caratteriPresenti;

        string fileName;
        public MainWindow()
        {
            InitializeComponent();
            fileName = "Data.txt";


            progressoDellaBarra = progressbar.Minimum;
            progressbar.Maximum = CalcoloRighe();
            caratteriPresenti = 0;
            ProgressoDellaBarra();
        }

        public int CalcoloRighe()
        {
            int i = 0;
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    sr.ReadLine();
                    i++;
                }
            }
            return i;
        }

        private void btn_leggiFile_Click(object sender, RoutedEventArgs e)
        {

            using (StreamReader sr = new StreamReader(fileName))
            {

                while (!sr.EndOfStream)
                {

                    char[] appoggio = sr.ReadLine().ToCharArray();
                    caratteriPresenti += appoggio.Length;
                    progressoDellaBarra+=1;
                    Thread.Sleep(200);
                }
            }
            lbl_caratteri.Content = caratteriPresenti.ToString();
        }

        private async void ProgressoDellaBarra()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(200);
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        progressbar.Value = progressoDellaBarra;
                    }));

                }
            });
        }
    }
}
