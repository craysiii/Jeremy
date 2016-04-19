using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;

namespace Jeremy
{
    class TrayApplicationContext : ApplicationContext
    {
        public NotifyIcon notifyIcon;

        private Container container;

        public TrayApplicationContext(string _text, Icon _icon)
        {
            Trace.WriteLine("TrayApplicationContext: Initializing");

            this.container  = new Container();
            this.notifyIcon = new NotifyIcon(container)
            {
                ContextMenuStrip = new ContextMenuStrip(),
                Icon             = _icon,
                Text             = _text,
                Visible          = true
            };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.container != null)
            {
                this.container.Dispose();
            }
        }

        protected override void ExitThreadCore()
        {
            Trace.WriteLine("TrayApplicationContext: Exiting Gracefully");

            this.notifyIcon.Visible = false;
            base.ExitThreadCore();
        }
    }
}
