using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Jeremy
{
    public partial class SettingsForm : Form
    {
        PowerCfg powercfg;

        public SettingsForm(PowerCfg cfg)
        {
            Trace.WriteLine("SettingsForm: Initializing");

            InitializeComponent();
            this.powercfg = cfg;

            settingsGridView.Rows.Clear();
            foreach (var setting in this.powercfg.settings)
            {
                settingsGridView.Rows.Add(setting.Value, setting.Key, 
                    this.powercfg.timeoutActive[setting.Key], this.powercfg.timeoutInactive[setting.Key]);
            }
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Trace.WriteLine("SettingsForm: Exiting Gracefully");

            foreach (DataGridViewRow row in this.settingsGridView.Rows)
            {
                string setting = (string)row.Cells["SettingType"].Value;

                this.powercfg.settings[setting]        = (bool)row.Cells["Active"].Value;

                this.powercfg.timeoutActive[setting]   = Int32.Parse(row.Cells["ValueActive"].Value.ToString());
                this.powercfg.timeoutInactive[setting] = Int32.Parse(row.Cells["ValueInactive"].Value.ToString());
            }
            this.powercfg.Save();
            this.powercfg.Apply();
        }
    }
}
