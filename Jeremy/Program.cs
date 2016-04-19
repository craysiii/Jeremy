using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Jeremy
{
    static class Program
    {
        static PowerCfg powercfg;

        static TrayApplicationContext trayApp;

        [STAThread]
        static void Main()
        {
            // Default application setup
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Load powercfg
            powercfg = PowerCfg.Load();
            powercfg.Apply();

            // Setup our tray context
            Icon trayIcon = powercfg.active ?
                Jeremy.Properties.Resources.TrayIcon_Active : Jeremy.Properties.Resources.TrayIcon_Inactive;

            trayApp = new TrayApplicationContext("Jeremy", trayIcon);

            // Add event handlers
            trayApp.notifyIcon.ContextMenuStrip.Opening += Menu_Opening;

            trayApp.notifyIcon.MouseClick       += NotifyIcon_MouseClick;
            trayApp.notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;

            Application.Run(trayApp);
        }

        private static void Menu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Get our menu and clear it
            var menu = trayApp.notifyIcon.ContextMenuStrip;
            menu.Items.Clear();

            // SettingsForm
            menu.Items.Add("Timeouts", null, (s, ev) =>
            {
                SettingsForm settingsForm = new SettingsForm(powercfg);
                settingsForm.Show();
            });

            // AboutForm
            menu.Items.Add("About", null, (s, ev) =>
            {
                AboutForm aboutForm = new AboutForm();
                aboutForm.Show();
            });

            // Line seperator
            menu.Items.Add(new ToolStripSeparator());

            // Exit Application
            menu.Items.Add("Exit", null, (s, ev) =>
            {
                trayApp.ExitThread();
            });
        }

        private static void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                trayApp.notifyIcon.ContextMenuStrip.Show();
            }
        }

        private static void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            powercfg.SwitchState();

            trayApp.notifyIcon.Icon.Dispose();
            trayApp.notifyIcon.Icon = powercfg.active ?
                Jeremy.Properties.Resources.TrayIcon_Active : Jeremy.Properties.Resources.TrayIcon_Inactive;
        }
    }
}
