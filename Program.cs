using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace GrooveboxApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    public class MainForm : Form
    {
        private readonly WebView2 webView;

        public MainForm()
        {
            Text = "Groovebox";
            Width = 1000;
            Height = 760;
            MinimumSize = new System.Drawing.Size(640, 500);
            StartPosition = FormStartPosition.CenterScreen;

            webView = new WebView2 { Dock = DockStyle.Fill };
            Controls.Add(webView);

            Load += MainForm_Load;
        }

        private async void MainForm_Load(object? sender, EventArgs e)
        {
            try
            {
                await webView.EnsureCoreWebView2Async(null);
                string htmlPath = Path.Combine(AppContext.BaseDirectory, "Groovebox.html");
                webView.CoreWebView2.Navigate(new Uri(htmlPath).AbsoluteUri);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Groovebox needs the Microsoft Edge WebView2 Runtime, which isn't installed.\n\n" +
                    "Get it free from Microsoft (search \"WebView2 Runtime download\"), then relaunch Groovebox.\n\n" +
                    "Details: " + ex.Message,
                    "Groovebox", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
