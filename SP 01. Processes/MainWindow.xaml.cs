using System.Diagnostics;
using System.Windows;


namespace SP_01._Processes;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //Process.Start("cmd");
        //Process.Start("calc");
        //Process.Start("mspaint");
        //Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");

        //procTextBox.Text = Process.GetCurrentProcess().ProcessName;
        //procTextBox.Text = Process.GetCurrentProcess().Id.ToString();

        //var process = Process.GetProcessById(20620);
        //process.Kill();
        //var proc = Process.GetProcessesByName("CalculatorApp");
        //proc[0].Kill();

        var processes = Process.GetProcesses().ToList();

        foreach (var process in processes)
        {
            procLstBox.Items.Add($"{process.Id}. {process.ProcessName}");
        };
        ProcessStartInfo startInfo = new ProcessStartInfo("calc");
        Process.Start(startInfo);

    }
}