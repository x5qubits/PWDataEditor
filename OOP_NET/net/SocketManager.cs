using PWDataEditorPaied;
using PWDataEditorPaied.OOP_NET.oops.mediator;
using PWDataEditorPaied.OOP_NET.oops.mediator.User;
using SharkShield.classes.oops;
using Shield.classes.net;
using Shield.classes.net.cmd;
using Shield.classes.oops;
using Shield.classes.oops.iNotif;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shield.classes
{
    public class SocketManager
    {
        private BaseSocket baseSocket;
        
        public static List<BaseSocketPacket> missList = new List<BaseSocketPacket>();

        public static Dictionary<string, INotification> up = new Dictionary<string, INotification>();
        public IFacade IFacade;
        public Boolean init()
        {
            IFacade = new IFacade();
            baseSocket = new BaseSocket();
            baseSocket.Socket(ProfileView.profile.serverIP, Int32.Parse(ProfileView.profile.serverPort));
            baseSocket.onRecive += onRecive;
            baseSocket.onConnect += onConnect;
            baseSocket.onDisconect += onDisconect;
            baseSocket.onSent += onSent;
            baseSocket.connect();
            return true;
        }

        public void disconect()
        {
            try { baseSocket.disconnect(); } catch { }
           
            baseSocket = null;
            try {baseSocket.onRecive -= onRecive; }catch { }
            try {baseSocket.onConnect -= onConnect; } catch { }
            try {baseSocket.onDisconect -= onDisconect; } catch { }
            try {baseSocket.onSent -= onSent; } catch { }

            try
            { remove(); }
            catch { }
        }

        private void onDisconect(object sender, EventArgs e)
        {
            String type = (e as BaseSocketEvent)._type;
            switch(type)
            {
                case BaseSocketEvent.IO_ERROR:
                    if (baseSocket != null  || baseSocket == null)
                    {
                        ProfileView.instance().progress_bar("Ready", 0, 0);
                        Constants.Authed = false;
                        try
                        {
                            PWAdmin.getInstance().resetallForm(false);
                            PWAdmin.getInstance().unlockMaps("Ready");

                            ProfileView.instance().DologinDone();
                        }
                        catch { }
                    }
                    break;
                case BaseSocketEvent.SECURITY_ERROR:
                    break;
                case BaseSocketEvent.CLOSE:
                    ProfileView.instance().progress_bar("Ready", 0, 0);
                    Constants.Authed = false;
                    try
                    {
                        PWAdmin.getInstance().resetallForm(false);
                        PWAdmin.getInstance().unlockMaps("Ready");
                        ProfileView.instance().DologinDone();
                    }
                    catch { }
                    disconect();
                    break;
            }
        }

        private void onSent(object sender, EventArgs e)
        {

        }

        private void onConnect(object sender, EventArgs e)
        {
            register();
            resendMiss();
        }

        private void onRecive(object sender, EventArgs e)
        {
            String t = (e as BaseSocketEvent)._type;
            String p = (e as BaseSocketEvent)._protocol;
            switch (t)
            {
                case BaseSocketEvent.RESPONSE_CODE_NO_RESULTS:
                    break;
                case BaseSocketEvent.RESPONSE_CODE_RESOLVE_ERROR:
                    break;
                case BaseSocketEvent.RESPONSE_CODE_NO_RIGHT:
                case BaseSocketEvent.RESPONSE_CODE_AUTH_CODE_ERROR:
                case BaseSocketEvent.RESPONSE_CODE_ERROR:
                    break;
                case BaseSocketEvent.RECEIVED:
                    IFacade.sendNotification(p, (e as BaseSocketEvent)._data);
                break;
            }
        }

        public void Send(BaseSocketPacket packet)
        {
            if (baseSocket != null)
            {
                baseSocket.Send(packet);
            }
            else
            {
                if (Constants.drawBack) { SocketManager.missList.Add(packet); }
                Constants.Authed = false;
                if (Iobserver.instance() != null)
                {
                    Iobserver.instance().init();
                }
            }
        }

        private void resendMiss()
        {
            for(int i = 0; i< SocketManager.missList.Count;i++)
            {
                BaseSocketPacket bs = SocketManager.missList[i];
                baseSocket.Send(bs);
                missList.Remove(bs);
            }
        }

        public Boolean remove()
        {
            IFacade.removeMediator(Cmd.SERVER_SENDS);
            IFacade.removeMediator(Cmd.HEART_CMD);
            IFacade.removeMediator(Cmd.AUTH_CMD);
            IFacade.removeMediator(Cmd.STATUS_CMD);
            IFacade.removeMediator(Cmd.STOPMAP_CMD);
            IFacade.removeMediator(Cmd.STARTMAP_CMD);
            IFacade.removeMediator(Cmd.STARTDEMON_CMD);
            IFacade.removeMediator(Cmd.STOPDEMON_CMD);
            IFacade.removeMediator(Cmd.SHOUTDOWN_WITHTIME_CMD);
            IFacade.removeMediator(Cmd.CHAT_REFRESH_CMD);
            IFacade.removeMediator(Cmd.GET_ROLE_DATA_CMD);
            IFacade.removeMediator(Cmd.SAVE_ROLE_DATA_CMD);
            IFacade.removeMediator(Cmd.ADDGM_CMD);
            IFacade.removeMediator(Cmd.DELETEGM_CMD);
            IFacade.removeMediator(Cmd.SAVEPERMISION_CMD);
            IFacade.removeMediator(Cmd.REG_ACCOUNT);
            IFacade.removeMediator(Cmd.CHANGE_ACCOUNT);
            IFacade.removeMediator(Cmd.DEL_ACCOUNT);
            IFacade.removeMediator(Cmd.CMD_CREATE_ACCOUNT);
            IFacade.removeMediator(Cmd.CMD_CHANGEPWD_ACCOUNT);
            IFacade.removeMediator(Cmd.CMD_SEND_CUBI);
            IFacade.removeMediator(Cmd.CMD_RUN_QUERY);
            IFacade.removeMediator(Cmd.CMD_SEARCH_PLAYERS);
            IFacade.removeMediator(Cmd.ANALLMAPUPDATE_CMD);
            return true;
        }

        public Boolean register(int priv = 2)
        {
            IFacade.registerMediator(Cmd.HEART_CMD, new HeartBeat());
            IFacade.registerMediator(Cmd.AUTH_CMD, new Auth());
            switch (priv)
            {
                case 0:
                case 1:
                    IFacade.registerMediator(Cmd.STATUS_CMD, new PWAdmin_med());
                    IFacade.registerMediator(Cmd.STOPMAP_CMD, new PWAMAP());
                    IFacade.registerMediator(Cmd.STARTMAP_CMD, new PWAMAP());
                    IFacade.registerMediator(Cmd.STARTDEMON_CMD, new PWADEMON());
                    IFacade.registerMediator(Cmd.STOPDEMON_CMD, new PWADEMON());
                    IFacade.registerMediator(Cmd.SHOUTDOWN_WITHTIME_CMD, new DownResp());
                    IFacade.registerMediator(Cmd.CHAT_REFRESH_CMD, new CHAT_UPDATE());
                    IFacade.registerMediator(Cmd.GET_ROLE_DATA_CMD, new GRoleData());
                    IFacade.registerMediator(Cmd.SAVE_ROLE_DATA_CMD, new SaveRoleVariousData());
                    IFacade.registerMediator(Cmd.ADDGM_CMD, new AddGM());
                    IFacade.registerMediator(Cmd.DELETEGM_CMD, new DeleteGM());
                    IFacade.registerMediator(Cmd.SAVEPERMISION_CMD, new SavePermisionGM());
                    IFacade.registerMediator(Cmd.DEL_ACCOUNT, new DeleteProfileAcc());
                    IFacade.registerMediator(Cmd.CHANGE_ACCOUNT, new UpdateProfileRow());
                    IFacade.registerMediator(Cmd.REG_ACCOUNT, new CreateNewProfileAccount());
                    IFacade.registerMediator(Cmd.CMD_CREATE_ACCOUNT, new CREATE_ACCOUNT_HANDLER());
                    IFacade.registerMediator(Cmd.CMD_CHANGEPWD_ACCOUNT, new CHANGEPWD_ACCOUNT_HANDLER());
                    IFacade.registerMediator(Cmd.CMD_SEND_CUBI, new SEND_CUBI_HANDLER());
                    IFacade.registerMediator(Cmd.CMD_RUN_QUERY, new RUN_QUERY_HANDLER());
                    IFacade.registerMediator(Cmd.CMD_SEARCH_PLAYERS, new SEARCH_PLAYERS_HANDLER());
                    IFacade.registerMediator(Cmd.SERVER_SENDS, new ServerSends());
                    IFacade.registerMediator(Cmd.ANALLMAPUPDATE_CMD, new AllMapsUpdate());
                    IFacade.registerMediator(Cmd.CMD_GETEVENT, new PWAdmin_UpdateGameEvents());
                    IFacade.registerMediator(Cmd.CMD_SETEVENT, new PWAdmin_UpdateGameEvents());
                    IFacade.registerMediator(Cmd.CMD_STARTEVENT, new ActivateWorldEvemnt());
                    IFacade.registerMediator(Cmd.CMD_BANCHAR, new BanCharacter());
                    break;
                case 2:
                    //To DO TeamWork Update Elements
                    break;
            }


            return true;
        }
    }
}
