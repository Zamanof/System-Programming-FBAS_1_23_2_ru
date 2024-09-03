using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SP_07._AsyncLove
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string url = @"https://habr.com/ru/articles/";
        WebClient client = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SimpleDownload(object sender, RoutedEventArgs e)
        {
            var txt = client.DownloadString(url);
            siteText.Text = txt;
        }
        private void DontClick(object sender, RoutedEventArgs e)
        {
            var tsk = client.DownloadStringTaskAsync(url);
            siteText.Text = tsk.Result;
        }

        private void TaskDownload(object sender, RoutedEventArgs e)
        {
           var task = client
                .DownloadStringTaskAsync(url)
                .ContinueWith(t =>
                {
                    siteText.Text = t.Result;
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void TaskContextDownload(object sender, RoutedEventArgs e)
        { 
            var context = SynchronizationContext.Current;
            var task = client
                .DownloadStringTaskAsync(url)
                .ContinueWith(t => {
                    context.Send(_ =>
                    {
                        siteText.Text = t.Result;
                    },null);
                
                });
        }

        private async void DownloadAsync(object sender, RoutedEventArgs e)
        {
            var txt = await client.DownloadStringTaskAsync(url);
            siteText.Text = txt;
        }

            private void Clear(object sender, RoutedEventArgs e)
        {
            siteText.Clear();
        }
    }
}