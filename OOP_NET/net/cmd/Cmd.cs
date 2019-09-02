using Shield.classes.net.modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shield.classes.net.cmd
{
    public static class Cmd
    {
        public static int HEART = 0;
        public static int AUTH = 1;
        public static int SERVER = 100;
        public static int REG = 2;
        public static int CHANGE = 3;
        public static int DEL = 4;
        public static string HEART_CMD = (Module.USER + "_" + HEART);
        public static string AUTH_CMD = (Module.USER + "_" + AUTH);
        public static string SERVER_SENDS = (Module.USER + "_" + SERVER);

        public static string REG_ACCOUNT = (Module.USER + "_" + REG);
        public static string CHANGE_ACCOUNT = (Module.USER + "_" + CHANGE);
        public static string DEL_ACCOUNT = (Module.USER + "_" + DEL);

        public static int STATUS = 0;
        public static string STATUS_CMD = (Module.PWADMIN + "_" + STATUS);
        public static int STOPMAP = 1;
        public static string STOPMAP_CMD = (Module.PWADMIN + "_" + STOPMAP);
        public static int STARTMAP = 2;
        public static string STARTMAP_CMD = (Module.PWADMIN + "_" + STARTMAP);
        public static int STARTDEMON = 3;
        public static string STARTDEMON_CMD = (Module.PWADMIN + "_" + STARTDEMON);
        public static int STOPDEMON = 4;
        public static string STOPDEMON_CMD = (Module.PWADMIN + "_" + STOPDEMON);
        public static int SHOUTDOWN_WITHTIME = 5;
        public static string SHOUTDOWN_WITHTIME_CMD = (Module.PWADMIN + "_" + SHOUTDOWN_WITHTIME);
        public static int CHAT_REFRESH = 6;
        public static string CHAT_REFRESH_CMD = (Module.PWADMIN + "_" + CHAT_REFRESH);
        public static int CHAT_Send = 7;
        public static string CHAT_Send_CMD = (Module.PWADMIN + "_" + CHAT_Send);
        public static int UPDATE_AUTO_DEMONS_MAP_SETTINGS = 8;
       
        public static int ANALLMAPUPDATE = 9;
        public static string ANALLMAPUPDATE_CMD = (Module.PWADMIN + "_" + ANALLMAPUPDATE);


        public static int GET_ROLE_DATA = 0;
        public static string GET_ROLE_DATA_CMD = (Module.ROLEDATA + "_" + GET_ROLE_DATA);
        public static int SAVE_ROLE_DATA = 1;
        public static string SAVE_ROLE_DATA_CMD = (Module.ROLEDATA + "_" + SAVE_ROLE_DATA);


        public static int ADDGM = 2;
        public static int DELETEGM = 3;
        public static int SAVEPERMISION = 4;
        public static string ADDGM_CMD = (Module.ROLEDATA + "_" + ADDGM);
        public static string DELETEGM_CMD = (Module.ROLEDATA + "_" + DELETEGM);
        public static string SAVEPERMISION_CMD = (Module.ROLEDATA + "_" + SAVEPERMISION);

        public static int CREATE_ACCOUNT = 0;
        public static string CMD_CREATE_ACCOUNT = (Module.ACCOUNT_MANAGMENT + "_" + CREATE_ACCOUNT);
        public static int CHANGEPWD_ACCOUNT = 1;
        public static string CMD_CHANGEPWD_ACCOUNT = (Module.ACCOUNT_MANAGMENT + "_" + CHANGEPWD_ACCOUNT);
        public static int SEND_CUBI = 2;
        public static string CMD_SEND_CUBI = (Module.ACCOUNT_MANAGMENT + "_" + SEND_CUBI);
        public static int RUN_QUERY = 3;
        public static string CMD_RUN_QUERY = (Module.ACCOUNT_MANAGMENT + "_" + RUN_QUERY);
        public static int SEARCH_PLAYERS = 4;
        public static string CMD_SEARCH_PLAYERS = (Module.ACCOUNT_MANAGMENT + "_" + SEARCH_PLAYERS);


        public static int SETEVENT = 10;
        public static int GETEVENT = 11;
        public static string CMD_GETEVENT = (Module.PWADMIN + "_" + GETEVENT);
        public static string CMD_SETEVENT = (Module.PWADMIN + "_" + SETEVENT);
        public static int STARTEVENT = 12;
        public static string CMD_STARTEVENT = (Module.PWADMIN + "_" + STARTEVENT);
        public static int BANCHAR = 13;
        public static string CMD_BANCHAR = (Module.PWADMIN + "_" + BANCHAR);
    }
}
