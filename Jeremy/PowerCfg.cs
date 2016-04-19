using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Jeremy
{
    [Serializable]
    public class PowerCfg
    {
        public Dictionary<string, int> timeoutActive;
        public Dictionary<string, int> timeoutInactive;

        public Dictionary<string, bool> settings = new Dictionary<string, bool>()
        {
            { "monitor-timeout-ac",    true },
            { "monitor-timeout-dc",    true },
            { "disk-timeout-ac",       false },
            { "disk-timeout-dc",       false },
            { "standby-timeout-ac",    false },
            { "standby-timeout-dc",    false },
            { "hibernate-timeout-ac",  false },
            { "hibernate-timeout-dc",  false },
        };

        public bool active;

        public PowerCfg()
        {
            Trace.WriteLine("PowerCfg: Initializing");
            this.active  = true;

            this.timeoutActive   = new Dictionary<string, int>();
            this.timeoutInactive = new Dictionary<string, int>();

            foreach (var entry in this.settings)
            {
                this.timeoutActive.Add(entry.Key, 0);
                this.timeoutInactive.Add(entry.Key, 15);
            }
        }

        public static PowerCfg Load()
        {
            PowerCfg cfg;

            Stream stream = null;
            IFormatter formatter = new BinaryFormatter();

            try
            {
                stream = new FileStream("jeremy.cfg", FileMode.Open, FileAccess.Read, FileShare.Read);
                cfg = (PowerCfg)formatter.Deserialize(stream);
            }
            catch (FileNotFoundException ex)
            {
                Trace.WriteLine("PowerCfg#Load: power.cfg Not Found - Creating New PowerCfg");
                cfg = new PowerCfg();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(String.Format("PowerCfg#Load: Unhandled Exception - {0}", ex.Message));
                cfg = new PowerCfg();
            }
            finally
            {
                if (stream != null) stream.Close();
            }

            cfg.Save();
            return cfg;
        }

        public void Save()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = null;
            try
            {
                stream = new FileStream("jeremy.cfg", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, this);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(String.Format("PowerCfg#Save: Unhandled Exception - {0}", ex.Message));
            }
            finally
            {
                if (stream != null) stream.Close();
            }
        }

        public void Apply()
        {
            foreach (var setting in this.settings)
            {
                if (setting.Value)
                {
                    Process powercfg = new Process();
                    powercfg.StartInfo.UseShellExecute = false;
                    powercfg.StartInfo.CreateNoWindow  = true;
                    powercfg.StartInfo.FileName = "powercfg";
                    powercfg.StartInfo.Arguments = String.Format("-change -{0} {1}", setting.Key, this.active ?
                        this.timeoutActive[setting.Key] : this.timeoutInactive[setting.Key]);

                    Trace.WriteLine(String.Format("PowerCfg#Apply: powercfg {0}", powercfg.StartInfo.Arguments));

                    powercfg.Start();
                }
            }
        }

        public void SwitchState()
        {
            Trace.WriteLine("PowerCfg#SwitchState: Switching State");

            this.active = !this.active;

            this.Save();
            this.Apply();
        }
    }
}
