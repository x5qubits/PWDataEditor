using PWDataEditorPaied;
using SharkShield;
using SharkShield.classes.oops;
using Shield.classes.net;
using Shield.classes.net.cmd;
using Shield.classes.net.modules;
using Shield.classes.oops.IClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Shield.classes.oops
{
    public class Iobserver : IDisposable
    {
        internal delegate void UpdateProgressDelegate(String value, int min, int max);
        internal event UpdateProgressDelegate progress_bar2;
        private ProfileView mainform = null;
        private static Iobserver _this = null;
        protected Timer auto;
        protected Dictionary<string, SimpleComand> observers;
        private SocketManager bs;
        protected int bp = Constants.fp * 10;
        protected int hb = Constants.fp * 10;

        protected bool ps = false;
        
        public Iobserver()
        {
            observers = new Dictionary<string, SimpleComand>();
            auto = new Timer();
            auto.Tick += new EventHandler(tick);
            auto.Interval = 1000 / Constants.fp;
            auto.Enabled = true;
            bs = new SocketManager();
            _this = this;
        }

        
        public void init()
        {
            if (Constants.canRecoonect)
            {
                bs.init();
            }
        }

        public void registerCMDS(int priv)
        {
            bs.register(priv);
        }

        public void close()
        {
            bs.disconect();
        }

        public static Iobserver instance()
        {
            return _this;
        }

        public void send(BaseSocketPacket data)
        {
            this.bs.Send(data);
        }

        public void progress_bar(string v1, int v2, int v3)
        {
            Application.DoEvents();
            this.progress_bar2(v1, v2, v3);
        }

        public void registerMain(ProfileView _mainform)
        {
            mainform = _mainform;
        }

        public ProfileView getMain()
        {
            return mainform;
        }

        private void tick(object source, EventArgs e)
        {
            try
            {
                if (Constants.Authed)
                {
                    hb--;
                    if (hb <= 0)
                    {
                        hb = bp;
                        HashMap<string, object> sd = new HashMap<string, object>();
                        sd["buildId"] = Constants.build;
                        sd["yek"] = Constants.ke;
                        BaseSocketPacket packet = new BaseSocketPacket();
                        packet.module = Module.USER;
                        packet.cmd = Cmd.HEART;
                        packet.value = sd;
                        this.send(packet);
                    }
                }
                foreach (SimpleComand observer in observers.Values)
                {
                    observer.update();
                }
            }
            catch { }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        public void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    mainform = null;
                    _this = null;
                    auto.Stop();
                    auto = null;
                    observers = null;
                    bs = null;
                    ps = false;
                    GC.Collect();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Iobserver() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
