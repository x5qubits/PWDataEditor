
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace sTASKedit
{
    [Serializable]
	public class ATaskTemplFixedData
    {
        private int m_ID;
        private byte[] m_szName;
        public bool m_bHasSign;
        private byte[] m_pszSignature;
        public int m_ulType;
        public uint m_ulTimeLimit;
        public bool m_bOfflineFail;
        public bool m_bAbsFail;
        public task_tm m_tmAbsFailTime;
        public bool m_bItemNotTakeOff;
        public bool m_bAbsTime;
        public int m_ulTimetable;
        public byte[] m_tmType;
        public task_tm[] m_tmStart;
        public task_tm[] m_tmEnd;
        public int m_lAvailFrequency;
        public int m_lPeriodLimit;
        public bool m_bChooseOne;
        public bool m_bRandOne;
        public bool m_bExeChildInOrder;
        public bool m_bParentAlsoFail;
        public bool m_bParentAlsoSucc;
        public bool m_bCanGiveUp;
        public bool m_bCanRedo;
        public bool m_bCanRedoAfterFailure;
        public bool m_bClearAsGiveUp;
        public bool m_bNeedRecord;
        public bool m_bFailAsPlayerDie;
        public int m_ulMaxReceiver;
        public bool m_bDelvInZone;
        public int m_ulDelvWorld;
        public int m_ulDelvRegionCnt;
        public Task_Region[] m_pDelvRegion;
        public bool m_bEnterRegionFail;
        public int m_ulEnterRegionWorld;
        public int m_ulEnterRegionCnt;
        public Task_Region[] m_pEnterRegion;
        public bool m_bLeaveRegionFail;
        public int m_ulLeaveRegionWorld;
        public int m_ulLeaveRegionCnt;
        public Task_Region[] m_pLeaveRegion;
        public bool m_bLeaveForceFail;
        public bool m_bTransTo;
        public int m_ulTransWldId;
        public ZONE_VERT m_TransPt;
        public int m_lMonsCtrl;
        public bool m_bTrigCtrl;
        public bool m_bAutoDeliver;
        public bool m_bDisplayInExclusiveUI;
        public bool m_bReadyToNotifyServer;
        public bool m_bUsedInTokenShop;
        public bool m_bDeathTrig;
        public bool m_bClearAcquired;
        public int m_ulSuitableLevel;
        public bool m_bShowPrompt;
        public bool m_bKeyTask;
        public int m_ulDelvNPC;
        public int m_ulAwardNPC;
        public bool m_bSkillTask;
        public bool m_bCanSeekOut;
        public bool m_bShowDirection;
        public bool m_bMarriage;
        public int m_ulChangeKeyCnt;
        public int[] m_plChangeKey;
        public int[] m_plChangeKeyValue;
        public bool[] m_pbChangeType;
        public bool m_bSwitchSceneFail;
        public bool m_bHidden;
        public bool m_bDeliverySkill;
        public int m_iDeliveredSkillID;
        public int m_iDeliveredSkillLevel;
        public bool m_bShowGfxFinished;
        public bool m_bChangePQRanking;
        public bool m_bCompareItemAndInventory;
        public int m_ulInventorySlotNum;
        public bool TowerTask;
        public bool HomeTask;
        public bool DelilverInHostHome;
        public bool FinishInHostHome;
        public bool m_bPQTask;
        public int m_ulPQExpCnt;
        public byte[][] m_pszPQExp;
        public TASK_EXPRESSION[] m_pPQExpArr;
        public bool m_bPQSubTask;
        public bool m_bClearContrib;
        public int m_ulMonsterContribCnt;
        public MONSTERS_CONTRIB[] m_MonstersContrib;
        public int m_iPremNeedRecordTasksNum;
        public bool m_bShowByNeedRecordTasksNum;
        public int m_iPremiseFactionContrib;
        public bool m_bShowByFactionContrib;
        public bool m_bAccountTaskLimit;
        public bool m_bRoleTaskLimit;
        public int m_ulAccountTaskLimitCnt;
        public bool m_bLeaveFactionFail;
        public bool m_bNotIncCntWhenFailed;
        public bool m_bNotClearItemWhenFailed;
        public bool m_bDisplayInTitleTaskUI;
        public byte m_ucPremiseTransformedForm;
        public bool m_bShowByTransformed;
        public int m_ulPremise_Lev_Min;
        public int m_ulPremise_Lev_Max;
        public int m_bPremCheckMaxHistoryLevel;
        public bool m_bShowByLev;
        public bool m_bPremCheckReincarnation;
        public int m_ulPremReincarnationMin;
        public int m_ulPremReincarnationMax;
        public bool m_bShowByReincarnation;
        public bool m_bPremCheckRealmLevel;
        public int m_ulPremRealmLevelMin;
        public int m_ulPremRealmLevelMax;
        public bool m_bPremCheckRealmExpFull;
        public bool m_bShowByRealmLevel;
        public int m_ulPremItems;
        public ITEM_WANTED[] m_PremItems;
        public bool m_bShowByItems;
        public bool m_bPremItemsAnyOne;
        public int m_ulGivenItems;
        public int m_ulGivenCmnCount;
        public int m_ulGivenTskCount;
        public ITEM_WANTED[] m_GivenItems;
        public int m_ulPremise_Deposit;
        public bool m_bShowByDeposit;
        public int m_lPremise_Reputation;
        public int m_lPremise_RepuMax;
        public bool m_bShowByRepu;
        public int m_ulPremise_Task_Count;
        public int[] m_ulPremise_Tasks;
        public bool m_bShowByPreTask;
        public int m_ulPremise_Task_Least_Num;
        public int m_ulPremise_Period;
		public bool m_bShowByPeriod;
		public int m_ulPremise_Faction;
		public int m_iPremise_FactionRole;
        public bool m_bShowByFaction;
        public int m_ulGender;
        public bool m_bShowByGender;
        public int m_ulOccupations;
        public int[] m_Occupations;
        public bool m_bShowByOccup;
        public bool m_bPremise_Spouse;
        public bool m_bShowBySpouse;
        public bool m_bPremiseWeddingOwner;
        public bool m_bShowByWeddingOwner;
        public bool m_bGM;
        public bool m_bShieldUser;
        public bool m_bShowByRMB;
        public int m_ulPremRMBMin;
        public int m_ulPremRMBMax;
        public bool m_bCharTime;
        public bool m_bShowByCharTime;
        public int m_iCharStartTime;
        public int m_iCharEndTime;
        public task_tm m_tmCharEndTime;
        public int m_ulCharTimeGreaterThan;
        public int m_ulPremise_Cotask;
        public int m_ulCoTaskCond;
        public int m_ulMutexTaskCount;
        public int[] m_ulMutexTasks;
        public int[] m_lSkillLev;
        public byte m_DynTaskType;
        public int m_ulSpecialAward;
        public bool m_bTeamwork;
        public bool m_bRcvByTeam;
        public bool m_bSharedTask;
        public bool m_bSharedAchieved;
        public bool m_bCheckTeammate;
        public float m_fTeammateDist;
        public bool m_bAllFail;
        public bool m_bCapFail;
        public bool m_bCapSucc;
        public float m_fSuccDist;
        public bool m_bDismAsSelfFail;
        public bool m_bRcvChckMem;
        public float m_fRcvMemDist;
        public bool m_bCntByMemPos;
        public float m_fCntMemDist;
        public bool m_bAllSucc;
        public bool m_bCoupleOnly;
        public bool m_bDistinguishedOcc;
        public int m_ulTeamMemsWanted;
        public TEAM_MEM_WANTED[] m_TeamMemsWanted;
        public bool m_bShowByTeam;
        public bool m_bPremNeedComp;
        public int m_nPremExp1AndOrExp2;
        public COMPARE_KEY_VALUE m_Prem1KeyValue;
        public COMPARE_KEY_VALUE m_Prem2KeyValue;
        public bool m_bPremCheckForce;
        public int m_iPremForce;
        public bool m_bShowByForce;
        public int m_iPremForceReputation;
        public bool m_bShowByForceReputation;
        public int m_iPremForceContribution;
        public bool m_bShowByForceContribution;
        public int m_iPremForceExp;
        public bool m_bShowByForceExp;
        public int m_iPremForceSP;
        public bool m_bShowByForceSP;
        public int m_iPremForceActivityLevel;
        public bool m_bShowByForceActivityLevel;
        public bool m_bPremIsKing;
        public bool m_bShowByKing;
        public bool m_bPremNotInTeam;
        public bool m_bShowByNotInTeam;
        public int m_iPremTitleNumTotal;
        public int m_iPremTitleNumRequired;
        public int[] m_PremTitles;
        public bool m_bShowByTitle;
        public int[] m_iPremHistoryStageIndex;
        public bool m_bShowByHistoryStage;
        public int m_ulPremGeneralCardCount;
        public bool m_bShowByGeneralCard;
        public int m_iPremGeneralCardRank;
        public int m_ulPremGeneralCardRankCount;
        public bool m_bShowByGeneralCardRank;
        public int PremiseIconStateID;
        public bool ShowByIconStateID;
        public int VIPLevelMin;
        public int VIPLevelMax;
        public bool ShowByVIPLevel;
        public bool PremNoHome;
        public int PremHomeLevelMin;
        public int PremHomeLevelMax;
        public bool ShowByHomeLevel;
        public int PremHomeResourceType;
        public int PremHomeResourceLevelMin;
        public int PremHomeResourceLevelMax;
        public bool ShowByHomeResourceLevel;
        public int PremHomeFactoryType;
        public int PremHomeFactoryLevelMin;
        public int PremHomeFactoryLevelMax;
        public bool ShowByHomeFactoryLevel;
        public int PremHomeFlourishMin;
        public int PremHomeFlourishMax;
        public bool ShowByHomeFlourish;
        public bool PremHomeStorageTask;
        public bool ShowByHomeStorageTask;
        public int m_enumMethod;
        public int m_enumFinishType;
        public int m_ulPlayerWanted;
        public PLAYER_WANTED[] m_PlayerWanted;
        public int m_ulMonsterWanted;
        public MONSTER_WANTED[] m_MonsterWanted;
        public int m_ulItemsWanted;
        public ITEM_WANTED[] m_ItemsWanted;
        public int m_ulGoldWanted;
        public int m_iFactionContribWanted;
        public int m_iFactionExpContribWanted;
        public int m_ulNPCToProtect;
        public uint m_ulProtectTimeLen;
        public int m_ulNPCMoving;
        public int m_ulNPCDestSite;
        public Task_Region[] m_pReachSite;
        public int m_ulReachSiteCnt;
        public int m_ulReachSiteId;
        public uint m_ulWaitTime;
        public ZONE_VERT m_TreasureStartZone;
        public byte m_ucZonesNumX;
        public byte m_ucZonesNumZ;
        public byte m_ucZoneSide;
        public Task_Region[] m_pLeaveSite;
        public int m_ulLeaveSiteCnt;
        public int m_ulLeaveSiteId;
        public bool m_bFinNeedComp;
        public int m_nFinExp1AndOrExp2;
        public COMPARE_KEY_VALUE m_Fin1KeyValue;
        public COMPARE_KEY_VALUE m_Fin2KeyValue;
        public int m_ulExpCnt;
        public byte[][] m_pszExp;
        public TASK_EXPRESSION[] m_pExpArr;
        public int m_ulTaskCharCnt;
        public byte[][] m_pTaskChar;
        public byte m_ucTransformedForm;
        public int m_ulReachLevel;
        public int m_ulReachReincarnationCount;
        public int m_ulReachRealmLevel;
        public int m_uiEmotion;
        public int TMIconStateID;
        public int TMHomeLevelType;
        public int TMReachHomeLevel;
        public int TMReachHomeFlourish;
        public int TMHomeItemCount;
        public HomeItemData[] TMHomeItemData;
        public int m_ulAwardType_S;
        public int m_ulAwardType_F;
        public AWARD_DATA m_Award_S;
        public AWARD_DATA m_Award_F;
        public AWARD_RATIO_SCALE m_AwByRatio_S;
        public AWARD_RATIO_SCALE m_AwByRatio_F;
        public AWARD_ITEMS_SCALE m_AwByItems_S;
        public AWARD_ITEMS_SCALE m_AwByItems_F;
        public int m_ulParent;
        public int m_ulPrevSibling;
        public int m_ulNextSibling;
        public int m_ulFirstChild;
        public bool m_bIsLibraryTask;
        public float m_fLibraryTasksProbability;
        public bool m_bIsUniqueStorageTask;
        public int WorldContrib;
        public CONVERSATION conversation;
        public talk_proc[] talk_procs;
		public int sub_quest_count;
		public ATaskTemplFixedData[] sub_quests;

        public byte[] m_pszSignaturePointer, m_ulTimetablePointer, m_pDelvRegionPointer, m_pEnterRegionPointer,
        m_pLeaveRegionPointer, m_ulChangeKeyPointer, m_pszPQExpPointer, m_MonstersContribPointer, m_PremItemsPointer,
        m_GivenItemsPointer, m_TeamMemsWantedPointer, m_PremTitlesPointer, m_PlayerWantedPointer, m_MonsterWantedPointer,
        m_ItemsWantedPointer, m_pReachSitePointer, m_pLeaveSitePointer, m_pszExpPointer, m_pTaskCharPointer, TMHomeItemPointer,
        m_Award_SPointer, m_Award_FPointer, m_AwByRatio_SPointer, m_AwByRatio_FPointer, m_AwByItems_SPointer, m_AwByItems_FPointer;

		public string AuthorText
		{
			get
			{
                return Extensions.decrypt(this.m_ID, this.m_pszSignature);
			}
			set
			{
                this.m_pszSignature = Extensions.encrypt(this.m_ID, value, 60, false);
			}
		}
		public int ID
		{
			get
			{
				return this.m_ID;
			}
			set
			{
				string m_szName = this.Name;
				string authorText = this.AuthorText;
                string pwstrDescript = this.conversation.Descript;
                string pwstrOkText = this.conversation.OkText;
                string pwstrNoText = this.conversation.NoText;
                string pwstrTribute = this.conversation.Tribute;
				this.m_ID = value;
				this.conversation.crypt_key = value;
				this.Name = m_szName;
				this.AuthorText = authorText;
                this.conversation.Descript = pwstrDescript;
                this.conversation.OkText = pwstrOkText;
                this.conversation.NoText = pwstrNoText;
                this.conversation.Tribute = pwstrTribute;
                for (int index = 0; index < this.talk_procs.Length; index++)
				{
                    string dialogText = this.talk_procs[index].DialogText;
                    this.talk_procs[index].crypt_key = value;
                    this.talk_procs[index].DialogText = dialogText;
                    for (int num2 = 0; num2 < this.talk_procs[index].windows.Length; num2++)
					{
                        string TalkText = this.talk_procs[index].windows[num2].talktext;
                        this.talk_procs[index].windows[num2].crypt_key = value;
                        this.talk_procs[index].windows[num2].talktext = TalkText;
                        for (int num3 = 0; num3 < this.talk_procs[index].windows[num2].options.Length; num3++)
						{
                            string OptionText = this.talk_procs[index].windows[num2].options[num3].optiontext;
                            this.talk_procs[index].windows[num2].options[num3].crypt_key = value;
                            this.talk_procs[index].windows[num2].options[num3].optiontext = OptionText;
						}
					}
				}
			}
		}
		public string Name
		{
			get
			{
                return Extensions.decrypt(this.m_ID, this.m_szName);
			}
			set
			{
                this.m_szName = Extensions.encrypt(this.m_ID, value, 60, false);
			}
		}
		public ATaskTemplFixedData()
		{
		}
		public ATaskTemplFixedData(int version, BinaryReader BinaryStream, int BaseStreamPosition, TreeNodeCollection Nodes)
		{
			this.Load(version, BinaryStream, BaseStreamPosition, Nodes);
		}
		public ATaskTemplFixedData Clone()
		{
			MemoryStream output = new MemoryStream();
			BinaryWriter bw = new BinaryWriter(output);
			BinaryReader binaryStream = new BinaryReader(output);
			this.Save(9999, bw);
			ATaskTemplFixedData task = new ATaskTemplFixedData(9999, binaryStream, 0, null);
			bw.Close();
			binaryStream.Close();
			output.Close();
			return task;
		}
		private void Load(int version, BinaryReader br, int stream_position, TreeNodeCollection nodes)
        {
            string m_szName = null;
            br.BaseStream.Position = (long)stream_position;
            this.m_ID = br.ReadInt32();
            this.m_szName = br.ReadBytes(60);
            this.m_bHasSign = br.ReadBoolean();
            this.m_pszSignaturePointer = br.ReadBytes(4);
            this.m_ulType = br.ReadInt32();
            this.m_ulTimeLimit = br.ReadUInt32();
            if (version >= 68)
            {
                this.m_bOfflineFail = br.ReadBoolean();
                this.m_bAbsFail = br.ReadBoolean();
                this.m_tmAbsFailTime = task_tm.Read(version, br);
                this.m_bItemNotTakeOff = br.ReadBoolean();
            }
            else
            {
                this.m_bOfflineFail = false;
                this.m_bAbsFail = false;
                this.m_tmAbsFailTime = new task_tm();
                this.m_tmAbsFailTime.year = 0;
                this.m_tmAbsFailTime.month = 0;
                this.m_tmAbsFailTime.day = 0;
                this.m_tmAbsFailTime.hour = 0;
                this.m_tmAbsFailTime.min = 0;
                this.m_tmAbsFailTime.wday = 0;
                this.m_bItemNotTakeOff = false;
            }
            if (version >= 53)
            {
                this.m_bAbsTime = br.ReadBoolean();
            }
            else
            {
                this.m_bAbsTime = false;
            }
            this.m_ulTimetable = br.ReadInt32();
            this.m_tmType = new byte[24];
            if (version >= 53)
            {
                if (version >= 69)
                {
                    for (int num27 = 0; num27 < 24; num27++)
                    {
                        this.m_tmType[num27] = br.ReadByte();
                    }
                }
                else
                {
                    for (int num28 = 0; num28 < 12; num28++)
                    {
                        this.m_tmType[num28] = br.ReadByte();
                    }
                }
            }
            else
            {
                for (int num27 = 0; num27 < 0; num27++)
                {
                    this.m_tmType[num27] = br.ReadByte();
                }
            }
            this.m_ulTimetablePointer = br.ReadBytes(8);
            if (version >= 53)
            {
                this.m_lAvailFrequency = br.ReadInt32();
            }
            else
            {
                this.m_lAvailFrequency = 0;
            }
            if (version >= 89)
            {
                this.m_lPeriodLimit = br.ReadInt32();
            }
            else
            {
                this.m_lPeriodLimit = 0;
            }
            this.m_bChooseOne = br.ReadBoolean();
            this.m_bRandOne = br.ReadBoolean();
            this.m_bExeChildInOrder = br.ReadBoolean();
            this.m_bParentAlsoFail = br.ReadBoolean();
            this.m_bParentAlsoSucc = br.ReadBoolean();
            this.m_bCanGiveUp = br.ReadBoolean();
            this.m_bCanRedo = br.ReadBoolean();
            this.m_bCanRedoAfterFailure = br.ReadBoolean();
            this.m_bClearAsGiveUp = br.ReadBoolean();
            this.m_bNeedRecord = br.ReadBoolean();
            this.m_bFailAsPlayerDie = br.ReadBoolean();
            this.m_ulMaxReceiver = br.ReadInt32();
            if (version >= 80)
            {
                this.m_bDelvInZone = br.ReadBoolean();
                this.m_ulDelvWorld = br.ReadInt32();
                this.m_ulDelvRegionCnt = br.ReadInt32();
                this.m_pDelvRegion = new Task_Region[this.m_ulDelvRegionCnt];
                this.m_pDelvRegionPointer = br.ReadBytes(4);
            }
            else
            {
                this.m_bDelvInZone = br.ReadBoolean();
                this.m_ulDelvWorld = br.ReadInt32();
                this.m_ulDelvRegionCnt = 1;
                this.m_pDelvRegion = new Task_Region[this.m_ulDelvRegionCnt];
                this.m_pDelvRegion[0] = Task_Region.Read(version, br);
                this.m_pDelvRegionPointer = new byte[4];
            }
            if (version >= 68)
            {
                if (version >= 80)
                {
                    this.m_bEnterRegionFail = br.ReadBoolean();
                    this.m_ulEnterRegionWorld = br.ReadInt32();
                    this.m_ulEnterRegionCnt = br.ReadInt32();
                    this.m_pEnterRegion = new Task_Region[this.m_ulEnterRegionCnt];
                    this.m_pEnterRegionPointer = br.ReadBytes(4);
                }
                else
                {
                    this.m_bEnterRegionFail = br.ReadBoolean();
                    this.m_ulEnterRegionWorld = br.ReadInt32();
                    this.m_ulEnterRegionCnt = 1;
                    this.m_pEnterRegion = new Task_Region[this.m_ulEnterRegionCnt];
                    this.m_pEnterRegion[0] = Task_Region.Read(version, br);
                    this.m_pEnterRegionPointer = new byte[4];
                }
            }
            else
            {
                this.m_bEnterRegionFail = false;
                this.m_ulEnterRegionWorld = 0;
                this.m_ulEnterRegionCnt = 0;
                this.m_pEnterRegion = new Task_Region[this.m_ulEnterRegionCnt];
                this.m_pEnterRegionPointer = new byte[4];
            }
            if (version >= 68)
            {
                if (version >= 80)
                {
                    this.m_bLeaveRegionFail = br.ReadBoolean();
                    this.m_ulLeaveRegionWorld = br.ReadInt32();
                    this.m_ulLeaveRegionCnt = br.ReadInt32();
                    this.m_pLeaveRegion = new Task_Region[this.m_ulLeaveRegionCnt];
                    this.m_pLeaveRegionPointer = br.ReadBytes(4);
                }
                else
                {
                    this.m_bLeaveRegionFail = br.ReadBoolean();
                    this.m_ulLeaveRegionWorld = br.ReadInt32();
                    this.m_ulLeaveRegionCnt = 1;
                    this.m_pLeaveRegion = new Task_Region[this.m_ulLeaveRegionCnt];
                    this.m_pLeaveRegion[0] = Task_Region.Read(version, br);
                    this.m_pLeaveRegionPointer = new byte[4];
                }
            }
            else
            {
                this.m_bLeaveRegionFail = false;
                this.m_ulLeaveRegionWorld = 0;
                this.m_ulLeaveRegionCnt = 0;
                this.m_pLeaveRegion = new Task_Region[this.m_ulLeaveRegionCnt];
                this.m_pLeaveRegionPointer = new byte[4];
            }
            if (version >= 99)
            {
                this.m_bLeaveForceFail = br.ReadBoolean();
            }
            else
            {
                this.m_bLeaveForceFail = false;
            }
            this.m_bTransTo = br.ReadBoolean();
            this.m_ulTransWldId = br.ReadInt32();
            this.m_TransPt = ZONE_VERT.Read(version, br);
            if (version >= 53)
            {
                this.m_lMonsCtrl = br.ReadInt32();
                this.m_bTrigCtrl = br.ReadBoolean();
            }
            else
            {
                this.m_lMonsCtrl = 0;
                this.m_bTrigCtrl = false;
            }
            this.m_bAutoDeliver = br.ReadBoolean();
            if (version >= 89)
            {
                this.m_bDisplayInExclusiveUI = br.ReadBoolean();
            }
            else
            {
                this.m_bDisplayInExclusiveUI = false;
            }
            if (version >= 89)
            {
                this.m_bReadyToNotifyServer = br.ReadBoolean();
                if (version >= 118)
                {
                    this.m_bUsedInTokenShop = br.ReadBoolean();
                }
                else
                {
                    this.m_bUsedInTokenShop = false;
                }
            }
            else
            {
                this.m_bReadyToNotifyServer = false;
            }
            this.m_bDeathTrig = br.ReadBoolean();
            this.m_bClearAcquired = br.ReadBoolean();
            this.m_ulSuitableLevel = br.ReadInt32();
            this.m_bShowPrompt = br.ReadBoolean();
            this.m_bKeyTask = br.ReadBoolean();
            this.m_ulDelvNPC = br.ReadInt32();
            this.m_ulAwardNPC = br.ReadInt32();
            this.m_bSkillTask = br.ReadBoolean();
            if (version >= 53)
            {
                this.m_bCanSeekOut = br.ReadBoolean();
                this.m_bShowDirection = br.ReadBoolean();
            }
            else
            {
                this.m_bCanSeekOut = false;
                this.m_bShowDirection = true;
            }
            if (version >= 55)
            {
                this.m_bMarriage = br.ReadBoolean();
            }
            else
            {
                this.m_bMarriage = false;
            }
            if (version >= 59)
            {
                this.m_ulChangeKeyCnt = br.ReadInt32();
                this.m_ulChangeKeyPointer = br.ReadBytes(12);
            }
            else
            {
                this.m_ulChangeKeyCnt = 0;
                this.m_ulChangeKeyPointer = new byte[12];
            }
            if (version >= 63)
            {
                this.m_bSwitchSceneFail = br.ReadBoolean();
                this.m_bHidden = br.ReadBoolean();
            }
            else
            {
                this.m_bSwitchSceneFail = false;
                this.m_bHidden = false;
            }
            if (version >= 78)
            {
                this.m_bDeliverySkill = br.ReadBoolean();
                this.m_iDeliveredSkillID = br.ReadInt32();
                this.m_iDeliveredSkillLevel = br.ReadInt32();
                this.m_bShowGfxFinished = br.ReadBoolean();
            }
            else
            {
                this.m_bDeliverySkill = false;
                this.m_iDeliveredSkillID = 0;
                this.m_iDeliveredSkillLevel = 0;
                this.m_bShowGfxFinished = false;
            }
            if (version >= 80)
            {
                this.m_bChangePQRanking = br.ReadBoolean();
            }
            else
            {
                this.m_bChangePQRanking = false;
            }
            if (version >= 82)
            {
                this.m_bCompareItemAndInventory = br.ReadBoolean();
                this.m_ulInventorySlotNum = br.ReadInt32();
            }
            else
            {
                this.m_bCompareItemAndInventory = false;
                this.m_ulInventorySlotNum = 0;
            }
            if (version >= 123)
            {
                this.TowerTask = br.ReadBoolean();
            }
            else
            {
                this.TowerTask = false;
            }
            if (version >= 127)
            {
                this.HomeTask = br.ReadBoolean();
            }
            else
            {
                this.HomeTask = false;
            }
            if (version >= 128)
            {
                this.DelilverInHostHome = br.ReadBoolean();
                this.FinishInHostHome = br.ReadBoolean();
            }
            else
            {
                this.DelilverInHostHome = false;
                this.FinishInHostHome = false;
            }
            if (version >= 75)
            {
                this.m_bPQTask = br.ReadBoolean();
                this.m_ulPQExpCnt = br.ReadInt32();
                this.m_pszPQExpPointer = br.ReadBytes(8);
                this.m_bPQSubTask = br.ReadBoolean();
                this.m_bClearContrib = br.ReadBoolean();
                this.m_ulMonsterContribCnt = br.ReadInt32();
                this.m_MonstersContribPointer = br.ReadBytes(4);
            }
            else
            {
                this.m_bPQTask = false;
                this.m_ulPQExpCnt = 0;
                this.m_pszPQExpPointer = new byte[8];
                this.m_bPQSubTask = false;
                this.m_bClearContrib = false;
                this.m_ulMonsterContribCnt = 0;
                this.m_MonstersContribPointer = new byte[4];
            }
            if (version >= 92)
            {
                this.m_iPremNeedRecordTasksNum = br.ReadInt32();
                this.m_bShowByNeedRecordTasksNum = br.ReadBoolean();
            }
            else
            {
                this.m_iPremNeedRecordTasksNum = 0;
                this.m_bShowByNeedRecordTasksNum = false;
            }
            if (version >= 89)
            {
                this.m_iPremiseFactionContrib = br.ReadInt32();
                this.m_bShowByFactionContrib = br.ReadBoolean();
            }
            else
            {
                this.m_iPremiseFactionContrib = 0;
                this.m_bShowByFactionContrib = false;
            }
            if (version >= 75)
            {
                this.m_bAccountTaskLimit = br.ReadBoolean();
            }
            else
            {
                this.m_bAccountTaskLimit = false;
            }
            if (version >= 118)
            {
                this.m_bRoleTaskLimit = br.ReadBoolean();
            }
            else
            {
                this.m_bRoleTaskLimit = false;
            }
            if (version >= 75)
            {
                this.m_ulAccountTaskLimitCnt = br.ReadInt32();
                this.m_pszPQExp = new byte[this.m_ulPQExpCnt][];
                this.m_pPQExpArr = new TASK_EXPRESSION[this.m_ulPQExpCnt];
                this.m_MonstersContrib = new MONSTERS_CONTRIB[this.m_ulMonsterContribCnt];
            }
            else
            {
                this.m_ulAccountTaskLimitCnt = 0;
                this.m_pszPQExp = new byte[0][];
                this.m_pPQExpArr = new TASK_EXPRESSION[0];
                this.m_MonstersContrib = new MONSTERS_CONTRIB[0];
            }
            if (version >= 105)
            {
                this.m_bLeaveFactionFail = br.ReadBoolean();
            }
            else
            {
                this.m_bLeaveFactionFail = false;
            }
            if (version >= 111)
            {
                this.m_bNotIncCntWhenFailed = br.ReadBoolean();
            }
            else
            {
                this.m_bNotIncCntWhenFailed = false;
            }
            if (version >= 108)
            {
                this.m_bNotClearItemWhenFailed = br.ReadBoolean();
            }
            else
            {
                this.m_bNotClearItemWhenFailed = false;
            }
            if (version >= 111)
            {
                this.m_bDisplayInTitleTaskUI = br.ReadBoolean();
            }
            else
            {
                this.m_bDisplayInTitleTaskUI = false;
            }
            if (version >= 99)
            {
                this.m_ucPremiseTransformedForm = br.ReadByte();
                this.m_bShowByTransformed = br.ReadBoolean();
            }
            else
            {
                this.m_ucPremiseTransformedForm = 255;
                this.m_bShowByTransformed = false;
            }
            this.m_ulPremise_Lev_Min = br.ReadInt32();
            this.m_ulPremise_Lev_Max = br.ReadInt32();
            if (version >= 118)
            {
                this.m_bPremCheckMaxHistoryLevel = br.ReadInt32();
            }
            else
            {
                this.m_bPremCheckMaxHistoryLevel = 0;
            }
            this.m_bShowByLev = br.ReadBoolean();
            if (version >= 118)
            {
                this.m_bPremCheckReincarnation = br.ReadBoolean();
                this.m_ulPremReincarnationMin = br.ReadInt32();
                this.m_ulPremReincarnationMax = br.ReadInt32();
                this.m_bShowByReincarnation = br.ReadBoolean();
                this.m_bPremCheckRealmLevel = br.ReadBoolean();
                this.m_ulPremRealmLevelMin = br.ReadInt32();
                this.m_ulPremRealmLevelMax = br.ReadInt32();
                this.m_bPremCheckRealmExpFull = br.ReadBoolean();
                this.m_bShowByRealmLevel = br.ReadBoolean();
            }
            else
            {
                this.m_bPremCheckReincarnation = false;
                this.m_ulPremReincarnationMin = 0;
                this.m_ulPremReincarnationMax = 0;
                this.m_bShowByReincarnation = true;
                this.m_bPremCheckRealmLevel = false;
                this.m_ulPremRealmLevelMin = 0;
                this.m_ulPremRealmLevelMax = 0;
                this.m_bPremCheckRealmExpFull = false;
                this.m_bShowByRealmLevel = true;
            }
            this.m_ulPremItems = br.ReadInt32();
            this.m_PremItemsPointer = br.ReadBytes(4);
            this.m_bShowByItems = br.ReadBoolean();
            if (version >= 99)
            {
                this.m_bPremItemsAnyOne = br.ReadBoolean();
            }
            else
            {
                this.m_bPremItemsAnyOne = false;
            }
            this.m_ulGivenItems = br.ReadInt32();
            this.m_ulGivenCmnCount = br.ReadInt32();
            this.m_ulGivenTskCount = br.ReadInt32();
            this.m_GivenItemsPointer = br.ReadBytes(4);
            this.m_ulPremise_Deposit = br.ReadInt32();
            this.m_bShowByDeposit = br.ReadBoolean();
            this.m_lPremise_Reputation = br.ReadInt32();
            if (version >= 53)
            {
                this.m_lPremise_RepuMax = br.ReadInt32();
            }
            else
            {
                this.m_lPremise_RepuMax = 0;
            }
            this.m_bShowByRepu = br.ReadBoolean();
            this.m_ulPremise_Task_Count = br.ReadInt32();
            this.m_ulPremise_Tasks = new int[20];
            if (version < 90)
            {
                for (int num27 = 0; num27 < 5; num27++)
                {
                    this.m_ulPremise_Tasks[num27] = br.ReadInt32();
                }
            }
            else
            {
                for (int num28 = 0; num28 < 20; num28++)
                {
                    this.m_ulPremise_Tasks[num28] = br.ReadInt32();
                }
            }
            this.m_bShowByPreTask = br.ReadBoolean();
            if (version >= 90)
            {
                this.m_ulPremise_Task_Least_Num = br.ReadInt32();
            }
            else
            {
                this.m_ulPremise_Task_Least_Num = 0;
            }
            this.m_ulPremise_Period = br.ReadInt32();
            this.m_bShowByPeriod = br.ReadBoolean();
            this.m_ulPremise_Faction = br.ReadInt32();
            if (version >= 93)
            {
                this.m_iPremise_FactionRole = br.ReadInt32();
            }
            else
            {
                this.m_iPremise_FactionRole = 6;
            }
            this.m_bShowByFaction = br.ReadBoolean();
            this.m_ulGender = br.ReadInt32();
            this.m_bShowByGender = br.ReadBoolean();
            this.m_Occupations = new int[12];
            this.m_ulOccupations = br.ReadInt32();
            if (version >= 89)
            {
                if (version >= 120)
                {
                    for (int num27 = 0; num27 < 12; num27++)
                    {
                        this.m_Occupations[num27] = br.ReadInt32();
                    }
                }
                else
                {
                    for (int num28 = 0; num28 < 10; num28++)
                    {
                        this.m_Occupations[num28] = br.ReadInt32();
                    }
                }
            }
            else
            {
                for (int num28 = 0; num28 < 8; num28++)
                {
                    this.m_Occupations[num28] = br.ReadInt32();
                }
            }
            this.m_bShowByOccup = br.ReadBoolean();
            this.m_bPremise_Spouse = br.ReadBoolean();
            this.m_bShowBySpouse = br.ReadBoolean();
            if (version >= 102)
            {
                this.m_bPremiseWeddingOwner = br.ReadBoolean();
                this.m_bShowByWeddingOwner = br.ReadBoolean();
            }
            else
            {
                this.m_bPremiseWeddingOwner = false;
                this.m_bShowByWeddingOwner = true;
            }
            if (version >= 53)
            {
                this.m_bGM = br.ReadBoolean();
            }
            else
            {
                this.m_bGM = false;
            }
            if (version >= 68)
            {
                this.m_bShieldUser = br.ReadBoolean();
            }
            else
            {
                this.m_bShieldUser = false;
            }
            if (version >= 75)
            {
                this.m_bShowByRMB = br.ReadBoolean();
                this.m_ulPremRMBMin = br.ReadInt32();
                this.m_ulPremRMBMax = br.ReadInt32();
                this.m_bCharTime = br.ReadBoolean();
                this.m_bShowByCharTime = br.ReadBoolean();
                this.m_iCharStartTime = br.ReadInt32();
                this.m_iCharEndTime = br.ReadInt32();
                this.m_tmCharEndTime = task_tm.Read(version, br);
                this.m_ulCharTimeGreaterThan = br.ReadInt32();
            }
            else
            {
                this.m_bShowByRMB = true;
                this.m_ulPremRMBMin = 0;
                this.m_ulPremRMBMax = 0;
                this.m_bCharTime = false;
                this.m_bShowByCharTime = true;
                this.m_iCharStartTime = 0;
                this.m_iCharEndTime = 0;
                this.m_tmCharEndTime = new task_tm();
                this.m_tmCharEndTime.year = 0;
                this.m_tmCharEndTime.month = 0;
                this.m_tmCharEndTime.day = 0;
                this.m_tmCharEndTime.wday = 0;
                this.m_tmCharEndTime.hour = 0;
                this.m_tmCharEndTime.min = 0;
                this.m_ulCharTimeGreaterThan = 0;
            }
            this.m_ulPremise_Cotask = br.ReadInt32();
            this.m_ulCoTaskCond = br.ReadInt32();
            this.m_ulMutexTaskCount = br.ReadInt32();
            this.m_ulMutexTasks = new int[5];
            for (int j = 0; j < this.m_ulMutexTasks.Length; j++)
            {
                this.m_ulMutexTasks[j] = br.ReadInt32();
            }
            this.m_lSkillLev = new int[4];
            for (int j = 0; j < this.m_lSkillLev.Length; j++)
            {
                this.m_lSkillLev[j] = br.ReadInt32();
            }
            this.m_DynTaskType = br.ReadByte();
            this.m_ulSpecialAward = br.ReadInt32();
            this.m_bTeamwork = br.ReadBoolean();
            this.m_bRcvByTeam = br.ReadBoolean();
            this.m_bSharedTask = br.ReadBoolean();
            this.m_bSharedAchieved = br.ReadBoolean();
            this.m_bCheckTeammate = br.ReadBoolean();
            this.m_fTeammateDist = br.ReadSingle();
            this.m_bAllFail = br.ReadBoolean();
            this.m_bCapFail = br.ReadBoolean();
            this.m_bCapSucc = br.ReadBoolean();
            this.m_fSuccDist = br.ReadSingle();
            this.m_bDismAsSelfFail = br.ReadBoolean();
            this.m_bRcvChckMem = br.ReadBoolean();
            this.m_fRcvMemDist = br.ReadSingle();
            this.m_bCntByMemPos = br.ReadBoolean();
            this.m_fCntMemDist = br.ReadSingle();
            if (version >= 68)
            {
                this.m_bAllSucc = br.ReadBoolean();
            }
            else
            {
                this.m_bAllSucc = false;
            }
            if (version >= 75)
            {
                this.m_bCoupleOnly = br.ReadBoolean();
            }
            else
            {
                this.m_bCoupleOnly = false;
            }
            if (version >= 89)
            {
                this.m_bDistinguishedOcc = br.ReadBoolean();
            }
            else
            {
                this.m_bDistinguishedOcc = false;
            }
            this.m_ulTeamMemsWanted = br.ReadInt32();
            this.m_TeamMemsWantedPointer = br.ReadBytes(4);
            this.m_bShowByTeam = br.ReadBoolean();
            if (version >= 59)
            {
                this.m_bPremNeedComp = br.ReadBoolean();
                this.m_nPremExp1AndOrExp2 = br.ReadInt32();
                this.m_Prem1KeyValue = COMPARE_KEY_VALUE.Read(version, br);
                this.m_Prem2KeyValue = COMPARE_KEY_VALUE.Read(version, br);
            }
            else
            {
                this.m_bPremNeedComp = false;
                this.m_nPremExp1AndOrExp2 = 0;
                this.m_Prem1KeyValue = new COMPARE_KEY_VALUE();
                this.m_Prem1KeyValue.nLeftType = 0;
                this.m_Prem1KeyValue.lLeftNum = 0;
                this.m_Prem1KeyValue.nCompOper = 0;
                this.m_Prem1KeyValue.nRightType = 0;
                this.m_Prem1KeyValue.lRightNum = 0;
                this.m_Prem2KeyValue = new COMPARE_KEY_VALUE();
                this.m_Prem2KeyValue.nLeftType = 0;
                this.m_Prem2KeyValue.lLeftNum = 0;
                this.m_Prem2KeyValue.nCompOper = 0;
                this.m_Prem2KeyValue.nRightType = 0;
                this.m_Prem2KeyValue.lRightNum = 0;
            }
            if (version >= 99)
            {
                this.m_bPremCheckForce = br.ReadBoolean();
                this.m_iPremForce = br.ReadInt32();
                this.m_bShowByForce = br.ReadBoolean();
                this.m_iPremForceReputation = br.ReadInt32();
                this.m_bShowByForceReputation = br.ReadBoolean();
                this.m_iPremForceContribution = br.ReadInt32();
                this.m_bShowByForceContribution = br.ReadBoolean();
                this.m_iPremForceExp = br.ReadInt32();
                this.m_bShowByForceExp = br.ReadBoolean();
                this.m_iPremForceSP = br.ReadInt32();
                this.m_bShowByForceSP = br.ReadBoolean();
                this.m_iPremForceActivityLevel = br.ReadInt32();
                this.m_bShowByForceActivityLevel = br.ReadBoolean();
            }
            else
            {
                this.m_bPremCheckForce = false;
                this.m_iPremForce = 0;
                this.m_bShowByForce = true;
                this.m_iPremForceReputation = 0;
                this.m_bShowByForceReputation = true;
                this.m_iPremForceContribution = 0;
                this.m_bShowByForceContribution = true;
                this.m_iPremForceExp = 0;
                this.m_bShowByForceExp = true;
                this.m_iPremForceSP = 0;
                this.m_bShowByForceSP = true;
                this.m_iPremForceActivityLevel = -1;
                this.m_bShowByForceActivityLevel = true;
            }
            if (version >= 107)
            {
                this.m_bPremIsKing = br.ReadBoolean();
                this.m_bShowByKing = br.ReadBoolean();
                this.m_bPremNotInTeam = br.ReadBoolean();
                this.m_bShowByNotInTeam = br.ReadBoolean();
            }
            else
            {
                this.m_bPremIsKing = false;
                this.m_bShowByKing = true;
                this.m_bPremNotInTeam = false;
                this.m_bShowByNotInTeam = true;
            }
            if (version >= 111)
            {
                this.m_iPremTitleNumTotal = br.ReadInt32();
                this.m_iPremTitleNumRequired = br.ReadInt32();
                this.m_PremTitlesPointer = br.ReadBytes(4);
                this.m_bShowByTitle = br.ReadBoolean();
            }
            else
            {
                this.m_iPremTitleNumTotal = 0;
                this.m_iPremTitleNumRequired = 0;
                this.m_PremTitlesPointer = new byte[4];
                this.m_bShowByTitle = false;
            }
            if (version < 118)
            {
                int[] iPremHistoryStageIndex = new int[2];
                this.m_iPremHistoryStageIndex = iPremHistoryStageIndex;
                this.m_bShowByHistoryStage = true;
                this.m_ulPremGeneralCardCount = 0;
                this.m_bShowByGeneralCard = true;
                this.m_iPremGeneralCardRank = -1;
                this.m_ulPremGeneralCardRankCount = 0;
                this.m_bShowByGeneralCardRank = true;
            }
            else
            {
                this.m_iPremHistoryStageIndex = new int[2];
                for (int num29 = 0; num29 < this.m_iPremHistoryStageIndex.Length; num29++)
                {
                    this.m_iPremHistoryStageIndex[num29] = br.ReadInt32();
                }
                this.m_bShowByHistoryStage = br.ReadBoolean();
                this.m_ulPremGeneralCardCount = br.ReadInt32();
                this.m_bShowByGeneralCard = br.ReadBoolean();
                this.m_iPremGeneralCardRank = br.ReadInt32();
                this.m_ulPremGeneralCardRankCount = br.ReadInt32();
                this.m_bShowByGeneralCardRank = br.ReadBoolean();
            }
            if (version >= 122)
            {
                this.PremiseIconStateID = br.ReadInt32();
                this.ShowByIconStateID = br.ReadBoolean();
            }
            else
            {
                this.PremiseIconStateID = 0;
                this.ShowByIconStateID = false;
            }
            if (version >= 125)
            {
                this.VIPLevelMin = br.ReadInt32();
                this.VIPLevelMax = br.ReadInt32();
                this.ShowByVIPLevel = br.ReadBoolean();
            }
            else
            {
                this.VIPLevelMin = 0;
                this.VIPLevelMax = 0;
                this.ShowByVIPLevel = false;
            }
            if (version >= 129)
            {
                this.PremNoHome = br.ReadBoolean();
            }
            else
            {
                this.PremNoHome = false;
            }
            if (version >= 127)
            {
                this.PremHomeLevelMin = br.ReadInt32();
                this.PremHomeLevelMax = br.ReadInt32();
                this.ShowByHomeLevel = br.ReadBoolean();
                this.PremHomeResourceType = br.ReadInt32();
                this.PremHomeResourceLevelMin = br.ReadInt32();
                this.PremHomeResourceLevelMax = br.ReadInt32();
                this.ShowByHomeResourceLevel = br.ReadBoolean();
                this.PremHomeFactoryType = br.ReadInt32();
                this.PremHomeFactoryLevelMin = br.ReadInt32();
                this.PremHomeFactoryLevelMax = br.ReadInt32();
                this.ShowByHomeFactoryLevel = br.ReadBoolean();
                this.PremHomeFlourishMin = br.ReadInt32();
                this.PremHomeFlourishMax = br.ReadInt32();
                this.ShowByHomeFlourish = br.ReadBoolean();
                this.PremHomeStorageTask = br.ReadBoolean();
                this.ShowByHomeStorageTask = br.ReadBoolean();
            }
            else
            {
                this.PremHomeLevelMin = 0;
                this.PremHomeLevelMax = 0;
                this.ShowByHomeLevel = false;
                this.PremHomeResourceType = 0;
                this.PremHomeResourceLevelMin = 0;
                this.PremHomeResourceLevelMax = 0;
                this.ShowByHomeResourceLevel = false;
                this.PremHomeFactoryType = 0;
                this.PremHomeFactoryLevelMin = 0;
                this.PremHomeFactoryLevelMax = 0;
                this.ShowByHomeFactoryLevel = false;
                this.PremHomeFlourishMin = 0;
                this.PremHomeFlourishMax = 0;
                this.ShowByHomeFlourish = false;
                this.PremHomeStorageTask = false;
                this.ShowByHomeStorageTask = false;
            }
            this.m_enumMethod = br.ReadInt32();
            this.m_enumFinishType = br.ReadInt32();
            if (version >= 103)
            {
                this.m_ulPlayerWanted = br.ReadInt32();
                this.m_PlayerWantedPointer = br.ReadBytes(4);
            }
            else
            {
                this.m_ulPlayerWanted = 0;
                this.m_PlayerWantedPointer = new byte[4];
            }
            this.m_ulMonsterWanted = br.ReadInt32();
            this.m_MonsterWantedPointer = br.ReadBytes(4);
            this.m_ulItemsWanted = br.ReadInt32();
            this.m_ItemsWantedPointer = br.ReadBytes(4);
            this.m_ulGoldWanted = br.ReadInt32();
            if (version >= 89)
            {
                this.m_iFactionContribWanted = br.ReadInt32();
                this.m_iFactionExpContribWanted = br.ReadInt32();
            }
            else
            {
                this.m_iFactionContribWanted = 0;
                this.m_iFactionExpContribWanted = 0;
            }
            this.m_ulNPCToProtect = br.ReadInt32();
            this.m_ulProtectTimeLen = br.ReadUInt32();
            this.m_ulNPCMoving = br.ReadInt32();
            this.m_ulNPCDestSite = br.ReadInt32();
            if (version >= 80)
            {
                this.m_pReachSitePointer = br.ReadBytes(4);
                this.m_ulReachSiteCnt = br.ReadInt32();
                this.m_pReachSite = new Task_Region[this.m_ulReachSiteCnt];
                this.m_ulReachSiteId = br.ReadInt32();
            }
            else
            {
                this.m_pReachSitePointer = new byte[4];
                this.m_ulReachSiteCnt = 1;
                this.m_pReachSite = new Task_Region[this.m_ulReachSiteCnt];
                this.m_pReachSite[0] = Task_Region.Read(version, br);
                this.m_ulReachSiteId = br.ReadInt32();
            }
            this.m_ulWaitTime = br.ReadUInt32();
            if (version >= 99)
            {
                this.m_TreasureStartZone = ZONE_VERT.Read(version, br);
                this.m_ucZonesNumX = br.ReadByte();
                this.m_ucZonesNumZ = br.ReadByte();
                this.m_ucZoneSide = br.ReadByte();
            }
            else
            {
                this.m_TreasureStartZone = new ZONE_VERT();
                this.m_ucZonesNumX = 1;
                this.m_ucZonesNumZ = 1;
                this.m_ucZoneSide = 10;
            }
            if (version >= 69)
            {
                if (version >= 80)
                {
                    this.m_pLeaveSitePointer = br.ReadBytes(4);
                    this.m_ulLeaveSiteCnt = br.ReadInt32();
                    this.m_pLeaveSite = new Task_Region[this.m_ulLeaveSiteCnt];
                    this.m_ulLeaveSiteId = br.ReadInt32();
                }
                else
                {
                    this.m_pLeaveSitePointer = new byte[4];
                    this.m_ulLeaveSiteCnt = 1;
                    this.m_pLeaveSite = new Task_Region[this.m_ulLeaveSiteCnt];
                    this.m_pLeaveSite[0] = Task_Region.Read(version, br);
                    this.m_ulLeaveSiteId = br.ReadInt32();
                }
            }
            else
            {
                this.m_pLeaveSitePointer = new byte[4];
                this.m_ulLeaveSiteCnt = 0;
                this.m_pLeaveSite = new Task_Region[this.m_ulLeaveSiteCnt];
                this.m_ulLeaveSiteId = 0;
            }
            if (version >= 59)
            {
                this.m_bFinNeedComp = br.ReadBoolean();
                this.m_nFinExp1AndOrExp2 = br.ReadInt32();
                this.m_Fin1KeyValue = COMPARE_KEY_VALUE.Read(version, br);
                this.m_Fin2KeyValue = COMPARE_KEY_VALUE.Read(version, br);
            }
            else
            {
                this.m_bFinNeedComp = true;
                this.m_nFinExp1AndOrExp2 = 0;
                this.m_Fin1KeyValue = new COMPARE_KEY_VALUE();
                this.m_Fin1KeyValue.nLeftType = 0;
                this.m_Fin1KeyValue.lLeftNum = 0;
                this.m_Fin1KeyValue.nCompOper = 0;
                this.m_Fin1KeyValue.nRightType = 0;
                this.m_Fin1KeyValue.lRightNum = 0;
                this.m_Fin2KeyValue = new COMPARE_KEY_VALUE();
                this.m_Fin2KeyValue.nLeftType = 0;
                this.m_Fin2KeyValue.lLeftNum = 0;
                this.m_Fin2KeyValue.nCompOper = 0;
                this.m_Fin2KeyValue.nRightType = 0;
                this.m_Fin2KeyValue.lRightNum = 0;
            }
            if (version >= 63)
            {
                this.m_ulExpCnt = br.ReadInt32();
                this.m_pszExpPointer = br.ReadBytes(8);
                this.m_pszExp = new byte[this.m_ulExpCnt][];
                this.m_pExpArr = new TASK_EXPRESSION[this.m_ulExpCnt];
                this.m_ulTaskCharCnt = br.ReadInt32();
                this.m_pTaskCharPointer = br.ReadBytes(4);
                this.m_pTaskChar = new byte[this.m_ulTaskCharCnt][];
            }
            else
            {
                this.m_ulExpCnt = 0;
                this.m_pszExpPointer = new byte[8];
                this.m_pszExp = new byte[this.m_ulExpCnt][];
                this.m_pExpArr = new TASK_EXPRESSION[this.m_ulExpCnt];
                this.m_ulTaskCharCnt = 0;
                this.m_pTaskCharPointer = new byte[4];
                this.m_pTaskChar = new byte[this.m_ulTaskCharCnt][];
            }
            if (version >= 105)
            {
                this.m_ucTransformedForm = br.ReadByte();
            }
            else
            {
                this.m_ucTransformedForm = 0;
            }
            if (version >= 118)
            {
                this.m_ulReachLevel = br.ReadInt32();
                this.m_ulReachReincarnationCount = br.ReadInt32();
                this.m_ulReachRealmLevel = br.ReadInt32();
                this.m_uiEmotion = br.ReadInt32();
            }
            else
            {
                this.m_ulReachLevel = 0;
                this.m_ulReachReincarnationCount = 0;
                this.m_ulReachRealmLevel = 0;
                this.m_uiEmotion = 0;
            }
            if (version >= 122)
            {
                this.TMIconStateID = br.ReadInt32();
            }
            else
            {
                this.TMIconStateID = 0;
            }
            if (version >= 127)
            {
                this.TMHomeLevelType = br.ReadInt32();
                this.TMReachHomeLevel = br.ReadInt32();
                this.TMReachHomeFlourish = br.ReadInt32();
                this.TMHomeItemCount = br.ReadInt32();
                this.TMHomeItemPointer = br.ReadBytes(4);
            }
            else
            {
                this.TMHomeLevelType = 0;
                this.TMReachHomeLevel = 0;
                this.TMReachHomeFlourish = 0;
                this.TMHomeItemCount = 0;
                this.TMHomeItemPointer = new byte[4];
            }
            this.m_ulAwardType_S = br.ReadInt32();
            this.m_ulAwardType_F = br.ReadInt32();
            this.m_Award_SPointer = br.ReadBytes(4);
            this.m_Award_FPointer = br.ReadBytes(4);
            this.m_AwByRatio_SPointer = br.ReadBytes(4);
            this.m_AwByRatio_FPointer = br.ReadBytes(4);
            this.m_AwByItems_SPointer = br.ReadBytes(4);
            this.m_AwByItems_FPointer = br.ReadBytes(4);
            this.m_ulParent = br.ReadInt32();
            this.m_ulPrevSibling = br.ReadInt32();
            this.m_ulNextSibling = br.ReadInt32();
            this.m_ulFirstChild = br.ReadInt32();
            if (version >= 89)
            {
                this.m_bIsLibraryTask = br.ReadBoolean();
                this.m_fLibraryTasksProbability = br.ReadSingle();
            }
            else
            {
                this.m_bIsLibraryTask = false;
                this.m_fLibraryTasksProbability = 0f;
            }
            if (version >= 99)
            {
                this.m_bIsUniqueStorageTask = br.ReadBoolean();
            }
            else
            {
                this.m_bIsUniqueStorageTask = false;
            }
            if (version >= 119)
            {
                this.WorldContrib = br.ReadInt32();
            }
            else
            {
                this.WorldContrib = 0;
            }
            this.m_pszSignature = new byte[0];
            if (this.m_bHasSign)
            {
                this.m_pszSignature = br.ReadBytes(60);
            }
            this.m_tmStart = new task_tm[this.m_ulTimetable];
            this.m_tmEnd = new task_tm[this.m_ulTimetable];
            for (int k = 0; k < this.m_tmStart.Length; k++)
            {
                this.m_tmStart[k] = task_tm.Read(version, br);
                this.m_tmEnd[k] = task_tm.Read(version, br);
            }
            if (version >= 59)
            {
                this.m_plChangeKey = new int[this.m_ulChangeKeyCnt];
                this.m_plChangeKeyValue = new int[this.m_ulChangeKeyCnt];
                this.m_pbChangeType = new bool[this.m_ulChangeKeyCnt];
                for (int num30 = 0; num30 < this.m_ulChangeKeyCnt; num30++)
                {
                    this.m_plChangeKey[num30] = br.ReadInt32();
                    this.m_plChangeKeyValue[num30] = br.ReadInt32();
                    this.m_pbChangeType[num30] = br.ReadBoolean();
                }
            }
            else
            {
                this.m_plChangeKey = new int[0];
                this.m_plChangeKeyValue = new int[0];
                this.m_pbChangeType = new bool[0];
            }
            if (version >= 75)
            {
                for (int num31 = 0; num31 < this.m_ulPQExpCnt; num31++)
                {
                    this.m_pszPQExp[num31] = br.ReadBytes(64);
                    this.m_pPQExpArr[num31] = TASK_EXPRESSION.Read(version, br);
                }
                for (int num32 = 0; num32 < this.m_ulMonsterContribCnt; num32++)
                {
                    this.m_MonstersContrib[num32] = MONSTERS_CONTRIB.Read(version, br);
                }
            }
            if (version >= 80)
            {
                for (int num33 = 0; num33 < this.m_ulDelvRegionCnt; num33++)
                {
                    this.m_pDelvRegion[num33] = Task_Region.Read(version, br);
                }
                for (int num34 = 0; num34 < this.m_ulEnterRegionCnt; num34++)
                {
                    this.m_pEnterRegion[num34] = Task_Region.Read(version, br);
                }
                for (int num35 = 0; num35 < this.m_ulLeaveRegionCnt; num35++)
                {
                    this.m_pLeaveRegion[num35] = Task_Region.Read(version, br);
                }
            }
            this.m_PremItems = new ITEM_WANTED[this.m_ulPremItems];
            for (int l = 0; l < this.m_PremItems.Length; l++)
            {
                this.m_PremItems[l] = ITEM_WANTED.Read(version, br);
            }
            this.m_GivenItems = new ITEM_WANTED[this.m_ulGivenItems];
            for (int m = 0; m < this.m_GivenItems.Length; m++)
            {
                this.m_GivenItems[m] = ITEM_WANTED.Read(version, br);
            }
            this.m_TeamMemsWanted = new TEAM_MEM_WANTED[this.m_ulTeamMemsWanted];
            for (int num36 = 0; num36 < this.m_TeamMemsWanted.Length; num36++)
            {
                this.m_TeamMemsWanted[num36] = TEAM_MEM_WANTED.Read(version, br);
            }
            if (version >= 111)
            {
                this.m_PremTitles = new int[this.m_iPremTitleNumTotal];
                for (int num37 = 0; num37 < this.m_PremTitles.Length; num37++)
                {
                    this.m_PremTitles[num37] = br.ReadInt32();
                }
            }
            else
            {
                this.m_PremTitles = new int[0];
            }
            this.m_MonsterWanted = new MONSTER_WANTED[this.m_ulMonsterWanted];
            for (int num38 = 0; num38 < this.m_MonsterWanted.Length; num38++)
            {
                this.m_MonsterWanted[num38] = MONSTER_WANTED.Read(version, br);
            }
            if (version >= 103)
            {
                this.m_PlayerWanted = new PLAYER_WANTED[this.m_ulPlayerWanted];
                for (int num37 = 0; num37 < this.m_PlayerWanted.Length; num37++)
                {
                    this.m_PlayerWanted[num37] = PLAYER_WANTED.Read(version, br);
                }
            }
            else
            {
                this.m_PlayerWanted = new PLAYER_WANTED[0];
            }
            this.m_ItemsWanted = new ITEM_WANTED[this.m_ulItemsWanted];
            for (int num39 = 0; num39 < this.m_ItemsWanted.Length; num39++)
            {
                this.m_ItemsWanted[num39] = ITEM_WANTED.Read(version, br);
            }
            if (version >= 80)
            {
                for (int num40 = 0; num40 < this.m_ulReachSiteCnt; num40++)
                {
                    this.m_pReachSite[num40] = Task_Region.Read(version, br);
                }
                for (int num41 = 0; num41 < this.m_ulLeaveSiteCnt; num41++)
                {
                    this.m_pLeaveSite[num41] = Task_Region.Read(version, br);
                }
            }
            if (version >= 63)
            {
                for (int num42 = 0; num42 < this.m_ulExpCnt; num42++)
                {
                    this.m_pszExp[num42] = br.ReadBytes(64);
                    this.m_pExpArr[num42] = TASK_EXPRESSION.Read(version, br);
                }
                for (int num43 = 0; num43 < this.m_ulTaskCharCnt; num43++)
                {
                    this.m_pTaskChar[num43] = br.ReadBytes(128);
                }
            }
            if (version >= 127)
            {
                this.TMHomeItemData = new HomeItemData[this.TMHomeItemCount];
                for (int num37 = 0; num37 < this.TMHomeItemData.Length; num37++)
                {
                    this.TMHomeItemData[num37] = HomeItemData.Read(version, br);
                }
            }
            else
            {
                this.TMHomeItemData = new HomeItemData[0];
            }
            this.m_Award_S = AWARD_DATA.Read(version, br);
            this.m_Award_F = AWARD_DATA.Read(version, br);
            this.m_AwByRatio_S = AWARD_RATIO_SCALE.Read(version, br);
            this.m_AwByRatio_F = AWARD_RATIO_SCALE.Read(version, br);
            this.m_AwByItems_S = AWARD_ITEMS_SCALE.Read(version, br);
            this.m_AwByItems_F = AWARD_ITEMS_SCALE.Read(version, br);
            this.conversation = new CONVERSATION();
            this.conversation.crypt_key = this.m_ID;
            this.conversation.m_pwstrDescript_len = br.ReadInt32();
            /*if (this.id == 969)
            {
                this.conversation.m_pwstrDescript_len++;
            }
            if (this.id == 26518 && this.conversation.m_pwstrDescript_len != 58)
            {
                this.conversation.m_pwstrDescript_len = 84;
            }*/
            this.conversation.m_pwstrDescript = br.ReadBytes(this.conversation.m_pwstrDescript_len * 2);
            this.conversation.m_pwstrOkText_len = br.ReadInt32();
            this.conversation.m_pwstrOkText = br.ReadBytes(this.conversation.m_pwstrOkText_len * 2);
            this.conversation.m_pwstrNoText_len = br.ReadInt32();
            this.conversation.m_pwstrNoText = br.ReadBytes(this.conversation.m_pwstrNoText_len * 2);
            this.conversation.m_pwstrTribute_len = br.ReadInt32();
            /*if (this.id == 26518 && this.conversation.m_pwstrDescript_len == 84)
            {
                this.conversation.m_pwstrTribute_len = 0;
            }*/
            if (this.conversation.m_pwstrTribute_len > 65535)
            {
                MessageBox.Show(string.Format("Error in Quest: {0}", this.m_ID));
                return;
            }
            this.conversation.m_pwstrTribute = br.ReadBytes(this.conversation.m_pwstrTribute_len * 2);
            this.talk_procs = new talk_proc[5];
            for (int index = 0; index < talk_procs.Length; ++index)
            {
                this.talk_procs[index] = talk_proc.Read(version, br, this.m_ID);
            }
            if (nodes != null)
            {
                Color white = Color.White;
                int ImageIndex = 0;
                int SelectedImageIndex = 1;
                int type = m_ulType;
                switch (type)
                {
                    case 0:
                        ImageIndex = 0;
                        SelectedImageIndex = 1;
                        break;
                    case 1:
                        ImageIndex = 8;
                        SelectedImageIndex = 9;
                        break;
                    case 2:
                        ImageIndex = 0;
                        SelectedImageIndex = 1;
                        break;
                    case 3:
                        ImageIndex = 0;
                        SelectedImageIndex = 1;
                        break;
                    case 4:
                        ImageIndex = 0;
                        SelectedImageIndex = 1;
                        break;
                    case 5:
                        ImageIndex = 0;
                        SelectedImageIndex = 1;
                        break;
                    case 6:
                        ImageIndex = 4;
                        SelectedImageIndex = 5;
                        break;
                    case 7:
                        ImageIndex = 0;
                        SelectedImageIndex = 1;
                        break;
                    case 8:
                        ImageIndex = 0;
                        SelectedImageIndex = 1;
                        break;
                    case 9:
                        ImageIndex = 6;
                        SelectedImageIndex = 7;
                        break;
                    case 10:
                        ImageIndex = 0;
                        SelectedImageIndex = 1;
                        break;
                    case 11:
                        ImageIndex = 6;
                        SelectedImageIndex = 7;
                        break;
                    case 12:
                        ImageIndex = 0;
                        SelectedImageIndex = 1;
                        break;
                    case 100:
                        if (TaskEditor.version >= 120) white = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(185)))), ((int)(((byte)(250)))));
                        ImageIndex = 8;
                        SelectedImageIndex = 9;
                        break;
                    case 101:
                        if (TaskEditor.version >= 120) white = Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(156)))), ((int)(((byte)(15)))));
                        ImageIndex = 0;
                        SelectedImageIndex = 1;
                        break;
                    case 102:
                        if (TaskEditor.version >= 120) white = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(255)))));
                        ImageIndex = 10;
                        SelectedImageIndex = 11;
                        break;
                    case 103:
                        if (TaskEditor.version >= 120) white = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                        ImageIndex = 0;
                        SelectedImageIndex = 1;
                        break;
                    case 104:
                        if (TaskEditor.version >= 120) white = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                        ImageIndex = 8;
                        SelectedImageIndex = 9;
                        break;
                    case 105:
                        if (TaskEditor.version >= 120) white = Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
                        ImageIndex = 6;
                        SelectedImageIndex = 7;
                        break;
                    case 106:
                        if (TaskEditor.version >= 120) white = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                        ImageIndex = 4;
                        SelectedImageIndex = 5;
                        break;
                    case 107:
                        if (TaskEditor.version >= 120) white = Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))));
                        ImageIndex = 4;
                        SelectedImageIndex = 5;
                        break;
                    case 108:
                        if (TaskEditor.version >= 120)
                        {
                            if (TaskEditor.version >= 127) white = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                            else white = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
                        }
                        ImageIndex = 0;
                        SelectedImageIndex = 1;
                        break;
                    case 109:
                        if (TaskEditor.version >= 120) white = Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(255)))), ((int)(((byte)(216)))));
                        ImageIndex = 0;
                        SelectedImageIndex = 1;
                        break;
                    case 110:
                        if (TaskEditor.version >= 120) white = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
                        ImageIndex = 0;
                        SelectedImageIndex = 1;
                        break;
                }
                if (m_bKeyTask == true)
                {
                    white = Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(156)))), ((int)(((byte)(15)))));
                    ImageIndex = 2;
                    SelectedImageIndex = 3;
                }
                if (m_bGM == true)
                {
                    ImageIndex = 12;
                    SelectedImageIndex = 12;
                }
                m_szName = this.Name;
                if (m_szName.StartsWith("^"))
                {
                    try
                    {
                        if (TaskEditor.version <= 99999)
                        {
                            white = Color.FromArgb(int.Parse(m_szName.Substring(1, 6), NumberStyles.HexNumber));
                        }
                        else if (m_ulType == 105 || m_ulType == 110)
                        {
                            if (m_bKeyTask == false)
                            {
                                white = Color.FromArgb(int.Parse(m_szName.Substring(1, 6), NumberStyles.HexNumber));
                            }
                        }
                        m_szName = m_szName.Substring(7);
                    }
                    catch
                    {
                        white = Color.White;
                    }
                }
                int num48 = this.m_ID;
                if (num48 > TaskEditor.tmpNewID) TaskEditor.tmpNewID = num48;
                nodes.Add(num48.ToString() + " - " + m_szName);
                nodes[nodes.Count - 1].ForeColor = white;
                nodes[nodes.Count - 1].ImageIndex = ImageIndex;
                nodes[nodes.Count - 1].SelectedImageIndex = SelectedImageIndex;
            }
            this.sub_quest_count = br.ReadInt32();
            this.sub_quests = new ATaskTemplFixedData[this.sub_quest_count];
            for (int num49 = 0; num49 < this.sub_quest_count; num49++)
            {
                if (nodes != null)
                {
                    this.sub_quests[num49] = new ATaskTemplFixedData(version, br, (int)br.BaseStream.Position, nodes[nodes.Count - 1].Nodes);
                }
                else
                {
                    this.sub_quests[num49] = new ATaskTemplFixedData(version, br, (int)br.BaseStream.Position, null);
                }
            }
        }
		public void Save(int version, BinaryWriter bw)
        {
            bw.Write(this.m_ID);
            bw.Write(this.m_szName);
            bw.Write(this.m_bHasSign);
            bw.Write(this.m_pszSignaturePointer);
            bw.Write(this.m_ulType);
            bw.Write(this.m_ulTimeLimit);
            if (version >= 68)
            {
                bw.Write(this.m_bOfflineFail);
                bw.Write(this.m_bAbsFail);
                task_tm.Write(version, bw, this.m_tmAbsFailTime);
                bw.Write(this.m_bItemNotTakeOff);
            }
            if (version >= 53)
            {
                bw.Write(this.m_bAbsTime);
            }
            bw.Write(this.m_ulTimetable);
            if (version >= 53)
            {
                if (version >= 69)
                {
                    for (byte num29 = 0; num29 < 24; num29++)
                    {
                        bw.Write(this.m_tmType[num29]);
                    }
                }
                else
                {
                    for (byte num30 = 0; num30 < 12; num30++)
                    {
                        bw.Write(this.m_tmType[num30]);
                    }
                }
            }
            else
            {
                for (byte num30 = 0; num30 < 0; num30++)
                {
                    bw.Write(this.m_tmType[num30]);
                }
            }
            bw.Write(this.m_ulTimetablePointer);
            if (version >= 53)
            {
                bw.Write(this.m_lAvailFrequency);
            }
            if (version >= 89)
            {
                bw.Write(this.m_lPeriodLimit);
            }
            bw.Write(this.m_bChooseOne);
            bw.Write(this.m_bRandOne);
            bw.Write(this.m_bExeChildInOrder);
            bw.Write(this.m_bParentAlsoFail);
            bw.Write(this.m_bParentAlsoSucc);
            bw.Write(this.m_bCanGiveUp);
            bw.Write(this.m_bCanRedo);
            bw.Write(this.m_bCanRedoAfterFailure);
            bw.Write(this.m_bClearAsGiveUp);
            bw.Write(this.m_bNeedRecord);
            bw.Write(this.m_bFailAsPlayerDie);
            bw.Write(this.m_ulMaxReceiver);
            if (version >= 80)
            {
                bw.Write(this.m_bDelvInZone);
                bw.Write(this.m_ulDelvWorld);
                bw.Write(this.m_ulDelvRegionCnt);
                bw.Write(this.m_pDelvRegionPointer);
            }
            else
            {
                bw.Write(this.m_bDelvInZone);
                bw.Write(this.m_ulDelvWorld);
                if (this.m_pDelvRegion.Length != 0)
                {
                    Task_Region.Write(version, bw, this.m_pDelvRegion[0]);
                }
                else
                {
                    bw.Write(0);
                    bw.Write(0);
                    bw.Write(0);
                    bw.Write(0);
                    bw.Write(0);
                    bw.Write(0);
                }
            }
            if (version >= 68)
            {
                if (version >= 80)
                {
                    bw.Write(this.m_bEnterRegionFail);
                    bw.Write(this.m_ulEnterRegionWorld);
                    bw.Write(this.m_ulEnterRegionCnt);
                    bw.Write(this.m_pEnterRegionPointer);
                }
                else
                {
                    bw.Write(this.m_bEnterRegionFail);
                    bw.Write(this.m_ulEnterRegionWorld);
                    if (this.m_pEnterRegion.Length != 0)
                    {
                        Task_Region.Write(version, bw, this.m_pEnterRegion[0]);
                    }
                    else
                    {
                        bw.Write(0);
                        bw.Write(0);
                        bw.Write(0);
                        bw.Write(0);
                        bw.Write(0);
                        bw.Write(0);
                    }
                }
            }
            if (version >= 68)
            {
                if (version >= 80)
                {
                    bw.Write(this.m_bLeaveRegionFail);
                    bw.Write(this.m_ulLeaveRegionWorld);
                    bw.Write(this.m_ulLeaveRegionCnt);
                    bw.Write(this.m_pLeaveRegionPointer);
                }
                else
                {
                    bw.Write(this.m_bLeaveRegionFail);
                    bw.Write(this.m_ulLeaveRegionWorld);
                    if (this.m_pLeaveRegion.Length != 0)
                    {
                        Task_Region.Write(version, bw, this.m_pLeaveRegion[0]);
                    }
                    else
                    {
                        bw.Write(0);
                        bw.Write(0);
                        bw.Write(0);
                        bw.Write(0);
                        bw.Write(0);
                        bw.Write(0);
                    }
                }
            }
            if (version >= 99)
            {
                bw.Write(this.m_bLeaveForceFail);
            }
            bw.Write(this.m_bTransTo);
            bw.Write(this.m_ulTransWldId);
            ZONE_VERT.Write(version, bw, this.m_TransPt);
            if (version >= 53)
            {
                bw.Write(this.m_lMonsCtrl);
                bw.Write(this.m_bTrigCtrl);
            }
            bw.Write(this.m_bAutoDeliver);
            if (version >= 89)
            {
                bw.Write(this.m_bDisplayInExclusiveUI);
            }
            if (version >= 89)
            {
                bw.Write(this.m_bReadyToNotifyServer);
                if (version >= 118)
                {
                    bw.Write(this.m_bUsedInTokenShop);
                }
            }
            bw.Write(this.m_bDeathTrig);
            bw.Write(this.m_bClearAcquired);
            bw.Write(this.m_ulSuitableLevel);
            bw.Write(this.m_bShowPrompt);
            bw.Write(this.m_bKeyTask);
            bw.Write(this.m_ulDelvNPC);
            bw.Write(this.m_ulAwardNPC);
            bw.Write(this.m_bSkillTask);
            if (version >= 53)
            {
                bw.Write(this.m_bCanSeekOut);
                bw.Write(this.m_bShowDirection);
            }
            if (version >= 55)
            {
                bw.Write(this.m_bMarriage);
            }
            if (version >= 59)
            {
                bw.Write(this.m_ulChangeKeyCnt);
                bw.Write(this.m_ulChangeKeyPointer);
            }
            if (version >= 63)
            {
                bw.Write(this.m_bSwitchSceneFail);
                bw.Write(this.m_bHidden);
            }
            if (version >= 78)
            {
                bw.Write(this.m_bDeliverySkill);
                bw.Write(this.m_iDeliveredSkillID);
                bw.Write(this.m_iDeliveredSkillLevel);
                bw.Write(this.m_bShowGfxFinished);
            }
            if (version >= 80)
            {
                bw.Write(this.m_bChangePQRanking);
            }
            if (version >= 82)
            {
                bw.Write(this.m_bCompareItemAndInventory);
                bw.Write(this.m_ulInventorySlotNum);
            }
            if (version >= 123)
            {
                bw.Write(this.TowerTask);
            }
            if (version >= 127)
            {
                bw.Write(this.HomeTask);
            }
            if (version >= 128)
            {
                bw.Write(this.DelilverInHostHome);
                bw.Write(this.FinishInHostHome);
            }
            if (version >= 75)
            {
                bw.Write(this.m_bPQTask);
                bw.Write(this.m_ulPQExpCnt);
                bw.Write(this.m_pszPQExpPointer);
                bw.Write(this.m_bPQSubTask);
                bw.Write(this.m_bClearContrib);
                bw.Write(this.m_ulMonsterContribCnt);
                bw.Write(this.m_MonstersContribPointer);
            }
            if (version >= 92)
            {
                bw.Write(this.m_iPremNeedRecordTasksNum);
                bw.Write(this.m_bShowByNeedRecordTasksNum);
            }
            if (version >= 89)
            {
                bw.Write(this.m_iPremiseFactionContrib);
                bw.Write(this.m_bShowByFactionContrib);
            }
            if (version >= 75)
            {
                bw.Write(this.m_bAccountTaskLimit);
            }
            if (version >= 118)
            {
                bw.Write(this.m_bRoleTaskLimit);
            }
            if (version >= 75)
            {
                bw.Write(this.m_ulAccountTaskLimitCnt);
            }
            if (version >= 105)
            {
                bw.Write(this.m_bLeaveFactionFail);
            }
            if (version >= 111)
            {
                bw.Write(this.m_bNotIncCntWhenFailed);
            }
            if (version >= 108)
            {
                bw.Write(this.m_bNotClearItemWhenFailed);
            }
            if (version >= 111)
            {
                bw.Write(this.m_bDisplayInTitleTaskUI);
            }
            if (version >= 99)
            {
                bw.Write(this.m_ucPremiseTransformedForm);
                bw.Write(this.m_bShowByTransformed);
            }
            bw.Write(this.m_ulPremise_Lev_Min);
            bw.Write(this.m_ulPremise_Lev_Max);
            if (version >= 118)
            {
                bw.Write(this.m_bPremCheckMaxHistoryLevel);
            }
            bw.Write(this.m_bShowByLev);
            if (version >= 118)
            {
                bw.Write(this.m_bPremCheckReincarnation);
                bw.Write(this.m_ulPremReincarnationMin);
                bw.Write(this.m_ulPremReincarnationMax);
                bw.Write(this.m_bShowByReincarnation);
                bw.Write(this.m_bPremCheckRealmLevel);
                bw.Write(this.m_ulPremRealmLevelMin);
                bw.Write(this.m_ulPremRealmLevelMax);
                bw.Write(this.m_bPremCheckRealmExpFull);
                bw.Write(this.m_bShowByRealmLevel);
            }
            bw.Write(this.m_ulPremItems);
            bw.Write(this.m_PremItemsPointer);
            bw.Write(this.m_bShowByItems);
            if (version >= 99)
            {
                bw.Write(this.m_bPremItemsAnyOne);
            }
            bw.Write(this.m_ulGivenItems);
            bw.Write(this.m_ulGivenCmnCount);
            bw.Write(this.m_ulGivenTskCount);
            bw.Write(this.m_GivenItemsPointer);
            bw.Write(this.m_ulPremise_Deposit);
            bw.Write(this.m_bShowByDeposit);
            bw.Write(this.m_lPremise_Reputation);
            if (version >= 53)
            {
                bw.Write(this.m_lPremise_RepuMax);
            }
            bw.Write(this.m_bShowByRepu);
            if (version < 90)
            {
                for (int num28 = 5; num28 < this.m_ulPremise_Tasks.Length; num28++)
                {
                    if (this.m_ulPremise_Tasks[num28] > 0)
                    {
                        this.m_ulPremise_Task_Count--;
                    }
                }
            }
            bw.Write(this.m_ulPremise_Task_Count);
            if (version >= 90)
            {
                for (int num29 = 0; num29 < 20; num29++)
                {
                    bw.Write(this.m_ulPremise_Tasks[num29]);
                }
            }
            else
            {
                for (int num30 = 0; num30 < 5; num30++)
                {
                    bw.Write(this.m_ulPremise_Tasks[num30]);
                }
            }
            bw.Write(this.m_bShowByPreTask);
            if (version >= 90)
            {
                bw.Write(this.m_ulPremise_Task_Least_Num);
            }
            bw.Write(this.m_ulPremise_Period);
            bw.Write(this.m_bShowByPeriod);
            bw.Write(this.m_ulPremise_Faction);
            if (version >= 93)
            {
                bw.Write(this.m_iPremise_FactionRole);
            }
            bw.Write(this.m_bShowByFaction);
            bw.Write(this.m_ulGender);
            bw.Write(this.m_bShowByGender);
            if (version >= 89)
            {
                if (version >= 120)
                {
                    for (int num28 = 12; num28 < this.m_Occupations.Length; num28++)
                    {
                        if (this.m_Occupations[num28] > 0)
                        {
                            this.m_ulOccupations--;
                        }
                    }
                }
                else
                {
                    for (int num28 = 10; num28 < this.m_Occupations.Length; num28++)
                    {
                        if (this.m_Occupations[num28] > 0)
                        {
                            this.m_ulOccupations--;
                        }
                    }
                }
            }
            else
            {
                for (int num28 = 8; num28 < this.m_Occupations.Length; num28++)
                {
                    if (this.m_Occupations[num28] > 0)
                    {
                        this.m_ulOccupations--;
                    }
                }
            }
            bw.Write(this.m_ulOccupations);
            if (version >= 89)
            {
                if (version >= 120)
                {
                    for (int num29 = 0; num29 < 12; num29++)
                    {
                        bw.Write(this.m_Occupations[num29]);
                    }
                }
                else
                {
                    for (int num30 = 0; num30 < 10; num30++)
                    {
                        bw.Write(this.m_Occupations[num30]);
                    }
                }
            }
            else
            {
                for (int num30 = 0; num30 < 8; num30++)
                {
                    bw.Write(this.m_Occupations[num30]);
                }
            }
            bw.Write(this.m_bShowByOccup);
            bw.Write(this.m_bPremise_Spouse);
            bw.Write(this.m_bShowBySpouse);
            if (version >= 102)
            {
                bw.Write(this.m_bPremiseWeddingOwner);
                bw.Write(this.m_bShowByWeddingOwner);
            }
            if (version >= 53)
            {
                bw.Write(this.m_bGM);
            }
            if (version >= 68)
            {
                bw.Write(this.m_bShieldUser);
            }
            if (version >= 75)
            {
                bw.Write(this.m_bShowByRMB);
                bw.Write(this.m_ulPremRMBMin);
                bw.Write(this.m_ulPremRMBMax);
                bw.Write(this.m_bCharTime);
                bw.Write(this.m_bShowByCharTime);
                bw.Write(this.m_iCharStartTime);
                bw.Write(this.m_iCharEndTime);
                task_tm.Write(version, bw, this.m_tmCharEndTime);
                bw.Write(this.m_ulCharTimeGreaterThan);
            }
            bw.Write(this.m_ulPremise_Cotask);
            bw.Write(this.m_ulCoTaskCond);
            bw.Write(this.m_ulMutexTaskCount);
            for (int j = 0; j < this.m_ulMutexTasks.Length; j++)
            {
                bw.Write(this.m_ulMutexTasks[j]);
            }
            for (int j = 0; j < this.m_lSkillLev.Length; j++)
            {
                bw.Write(this.m_lSkillLev[j]);
            }
            bw.Write(this.m_DynTaskType);
            bw.Write(this.m_ulSpecialAward);
            bw.Write(this.m_bTeamwork);
            bw.Write(this.m_bRcvByTeam);
            bw.Write(this.m_bSharedTask);
            bw.Write(this.m_bSharedAchieved);
            bw.Write(this.m_bCheckTeammate);
            bw.Write(this.m_fTeammateDist);
            bw.Write(this.m_bAllFail);
            bw.Write(this.m_bCapFail);
            bw.Write(this.m_bCapSucc);
            bw.Write(this.m_fSuccDist);
            bw.Write(this.m_bDismAsSelfFail);
            bw.Write(this.m_bRcvChckMem);
            bw.Write(this.m_fRcvMemDist);
            bw.Write(this.m_bCntByMemPos);
            bw.Write(this.m_fCntMemDist);
            if (version >= 68)
            {
                bw.Write(this.m_bAllSucc);
            }
            if (version >= 75)
            {
                bw.Write(this.m_bCoupleOnly);
            }
            if (version >= 89)
            {
                bw.Write(this.m_bDistinguishedOcc);
            }
            bw.Write(this.m_ulTeamMemsWanted);
            bw.Write(this.m_TeamMemsWantedPointer);
            bw.Write(this.m_bShowByTeam);
            if (version >= 59)
            {
                bw.Write(this.m_bPremNeedComp);
                bw.Write(this.m_nPremExp1AndOrExp2);
                COMPARE_KEY_VALUE.Write(version, bw, this.m_Prem1KeyValue);
                COMPARE_KEY_VALUE.Write(version, bw, this.m_Prem2KeyValue);
            }
            if (version >= 99)
            {
                bw.Write(this.m_bPremCheckForce);
                bw.Write(this.m_iPremForce);
                bw.Write(this.m_bShowByForce);
                bw.Write(this.m_iPremForceReputation);
                bw.Write(this.m_bShowByForceReputation);
                bw.Write(this.m_iPremForceContribution);
                bw.Write(this.m_bShowByForceContribution);
                bw.Write(this.m_iPremForceExp);
                bw.Write(this.m_bShowByForceExp);
                bw.Write(this.m_iPremForceSP);
                bw.Write(this.m_bShowByForceSP);
                bw.Write(this.m_iPremForceActivityLevel);
                bw.Write(this.m_bShowByForceActivityLevel);
            }
            if (version >= 107)
            {
                bw.Write(this.m_bPremIsKing);
                bw.Write(this.m_bShowByKing);
                bw.Write(this.m_bPremNotInTeam);
                bw.Write(this.m_bShowByNotInTeam);
            }
            if (version >= 111)
            {
                bw.Write(this.m_iPremTitleNumTotal);
                bw.Write(this.m_iPremTitleNumRequired);
                bw.Write(this.m_PremTitlesPointer);
                bw.Write(this.m_bShowByTitle);
            }
            if (version >= 118)
            {
                for (int num31 = 0; num31 < this.m_iPremHistoryStageIndex.Length; num31++)
                {
                    bw.Write(this.m_iPremHistoryStageIndex[num31]);
                }
                bw.Write(this.m_bShowByHistoryStage);
                bw.Write(this.m_ulPremGeneralCardCount);
                bw.Write(this.m_bShowByGeneralCard);
                bw.Write(this.m_iPremGeneralCardRank);
                bw.Write(this.m_ulPremGeneralCardRankCount);
                bw.Write(this.m_bShowByGeneralCardRank);
            }
            if (version >= 122)
            {
                bw.Write(this.PremiseIconStateID);
                bw.Write(this.ShowByIconStateID);
            }
            if (version >= 125)
            {
                bw.Write(this.VIPLevelMin);
                bw.Write(this.VIPLevelMax);
                bw.Write(this.ShowByVIPLevel);
            }
            if (version >= 129)
            {
                bw.Write(this.PremNoHome);
            }
            if (version >= 127)
            {
                bw.Write(this.PremHomeLevelMin);
                bw.Write(this.PremHomeLevelMax);
                bw.Write(this.ShowByHomeLevel);
                bw.Write(this.PremHomeResourceType);
                bw.Write(this.PremHomeResourceLevelMin);
                bw.Write(this.PremHomeResourceLevelMax);
                bw.Write(this.ShowByHomeResourceLevel);
                bw.Write(this.PremHomeFactoryType);
                bw.Write(this.PremHomeFactoryLevelMin);
                bw.Write(this.PremHomeFactoryLevelMax);
                bw.Write(this.ShowByHomeFactoryLevel);
                bw.Write(this.PremHomeFlourishMin);
                bw.Write(this.PremHomeFlourishMax);
                bw.Write(this.ShowByHomeFlourish);
                bw.Write(this.PremHomeStorageTask);
                bw.Write(this.ShowByHomeStorageTask);
            }
            bw.Write(this.m_enumMethod);
            bw.Write(this.m_enumFinishType);
            if (version >= 103)
            {
                bw.Write(this.m_ulPlayerWanted);
                bw.Write(this.m_PlayerWantedPointer);
            }
            bw.Write(this.m_ulMonsterWanted);
            bw.Write(this.m_MonsterWantedPointer);
            bw.Write(this.m_ulItemsWanted);
            bw.Write(this.m_ItemsWantedPointer);
            bw.Write(this.m_ulGoldWanted);
            if (version >= 89)
            {
                bw.Write(this.m_iFactionContribWanted);
                bw.Write(this.m_iFactionExpContribWanted);
            }
            bw.Write(this.m_ulNPCToProtect);
            bw.Write(this.m_ulProtectTimeLen);
            bw.Write(this.m_ulNPCMoving);
            bw.Write(this.m_ulNPCDestSite);
            if (version >= 80)
            {
                bw.Write(this.m_pReachSitePointer);
            }
            if (version >= 80)
            {
                bw.Write(this.m_ulReachSiteCnt);
                bw.Write(this.m_ulReachSiteId);
            }
            else
            {
                if (this.m_pReachSite.Length != 0)
                {
                    Task_Region.Write(version, bw, this.m_pReachSite[0]);
                }
                else
                {
                    bw.Write(0);
                    bw.Write(0);
                    bw.Write(0);
                    bw.Write(0);
                    bw.Write(0);
                    bw.Write(0);
                }
                bw.Write(this.m_ulReachSiteId);
            }
            bw.Write(this.m_ulWaitTime);
            if (version >= 99)
            {
                ZONE_VERT.Write(version, bw, this.m_TreasureStartZone);
                bw.Write(this.m_ucZonesNumX);
                bw.Write(this.m_ucZonesNumZ);
                bw.Write(this.m_ucZoneSide);
            }
            if (version >= 80)
            {
                bw.Write(this.m_pLeaveSitePointer);
            }
            if (version >= 69)
            {
                if (version >= 80)
                {
                    bw.Write(this.m_ulLeaveSiteCnt);
                    bw.Write(this.m_ulLeaveSiteId);
                }
                else
                {
                    if (this.m_pLeaveSite.Length != 0)
                    {
                        Task_Region.Write(version, bw, this.m_pLeaveSite[0]);
                    }
                    else
                    {
                        bw.Write(0);
                        bw.Write(0);
                        bw.Write(0);
                        bw.Write(0);
                        bw.Write(0);
                        bw.Write(0);
                    }
                    bw.Write(this.m_ulLeaveSiteId);
                }
            }
            if (version >= 59)
            {
                bw.Write(this.m_bFinNeedComp);
                bw.Write(this.m_nFinExp1AndOrExp2);
                COMPARE_KEY_VALUE.Write(version, bw, this.m_Fin1KeyValue);
                COMPARE_KEY_VALUE.Write(version, bw, this.m_Fin2KeyValue);
            }
            if (version >= 63)
            {
                bw.Write(this.m_ulExpCnt);
                bw.Write(this.m_pszExpPointer);
                bw.Write(this.m_ulTaskCharCnt);
                bw.Write(this.m_pTaskCharPointer);
            }
            if (version >= 105)
            {
                bw.Write(this.m_ucTransformedForm);
            }
            if (version >= 118)
            {
                bw.Write(this.m_ulReachLevel);
                bw.Write(this.m_ulReachReincarnationCount);
                bw.Write(this.m_ulReachRealmLevel);
                bw.Write(this.m_uiEmotion);
            }
            if (version >= 122)
            {
                bw.Write(this.TMIconStateID);
            }
            if (version >= 127)
            {
                bw.Write(this.TMHomeLevelType);
                bw.Write(this.TMReachHomeLevel);
                bw.Write(this.TMReachHomeFlourish);
                bw.Write(this.TMHomeItemCount);
                bw.Write(this.TMHomeItemPointer);
            }
            bw.Write(this.m_ulAwardType_S);
            bw.Write(this.m_ulAwardType_F);
            bw.Write(this.m_Award_SPointer);
            bw.Write(this.m_Award_FPointer);
            bw.Write(this.m_AwByRatio_SPointer);
            bw.Write(this.m_AwByRatio_FPointer);
            bw.Write(this.m_AwByItems_SPointer);
            bw.Write(this.m_AwByItems_FPointer);
            bw.Write(this.m_ulParent);
            bw.Write(this.m_ulPrevSibling);
            bw.Write(this.m_ulNextSibling);
            bw.Write(this.m_ulFirstChild);
            if (version >= 89)
            {
                bw.Write(this.m_bIsLibraryTask);
                bw.Write(this.m_fLibraryTasksProbability);
            }
            if (version >= 99)
            {
                bw.Write(this.m_bIsUniqueStorageTask);
            }
            if (version >= 119)
            {
                bw.Write(this.WorldContrib);
            }
            if (this.m_bHasSign)
            {
                bw.Write(this.m_pszSignature);
            }
            for (int k = 0; k < this.m_tmStart.Length; k++)
            {
                task_tm.Write(version, bw, this.m_tmStart[k]);
                task_tm.Write(version, bw, this.m_tmEnd[k]);
            }
            if (version >= 59)
            {
                for (int num32 = 0; num32 < this.m_ulChangeKeyCnt; num32++)
                {
                    bw.Write(this.m_plChangeKey[num32]);
                    bw.Write(this.m_plChangeKeyValue[num32]);
                    bw.Write(this.m_pbChangeType[num32]);
                }
            }
            if (version >= 75)
            {
                for (int num33 = 0; num33 < this.m_ulPQExpCnt; num33++)
                {
                    bw.Write(this.m_pszPQExp[num33]);
                    TASK_EXPRESSION.Write(version, bw, this.m_pPQExpArr[num33]);
                }
                for (int num34 = 0; num34 < this.m_ulMonsterContribCnt; num34++)
                {
                    MONSTERS_CONTRIB.Write(version, bw, this.m_MonstersContrib[num34]);
                }
            }
            if (version >= 80)
            {
                for (int num35 = 0; num35 < this.m_ulDelvRegionCnt; num35++)
                {
                    Task_Region.Write(version, bw, this.m_pDelvRegion[num35]);
                }
                for (int num36 = 0; num36 < this.m_ulEnterRegionCnt; num36++)
                {
                    Task_Region.Write(version, bw, this.m_pEnterRegion[num36]);
                }
                for (int num37 = 0; num37 < this.m_ulLeaveRegionCnt; num37++)
                {
                    Task_Region.Write(version, bw, this.m_pLeaveRegion[num37]);
                }
            }
            for (int l = 0; l < this.m_PremItems.Length; l++)
            {
                ITEM_WANTED.Write(version, bw, this.m_PremItems[l]);
            }
            for (int m = 0; m < this.m_GivenItems.Length; m++)
            {
                ITEM_WANTED.Write(version, bw, this.m_GivenItems[m]);
            }
            for (int num38 = 0; num38 < this.m_TeamMemsWanted.Length; num38++)
            {
                TEAM_MEM_WANTED.Write(version, bw, this.m_TeamMemsWanted[num38]);
            }
            if (version >= 111)
            {
                for (int num39 = 0; num39 < this.m_PremTitles.Length; num39++)
                {
                    bw.Write(this.m_PremTitles[num39]);
                }
            }
            for (int num40 = 0; num40 < this.m_MonsterWanted.Length; num40++)
            {
                MONSTER_WANTED.Write(version, bw, this.m_MonsterWanted[num40]);
            }
            if (version >= 103)
            {
                for (int num39 = 0; num39 < this.m_PlayerWanted.Length; num39++)
                {
                    PLAYER_WANTED.Write(version, bw, this.m_PlayerWanted[num39]);
                }
            }
            for (int num41 = 0; num41 < this.m_ItemsWanted.Length; num41++)
            {
                ITEM_WANTED.Write(version, bw, this.m_ItemsWanted[num41]);
            }
            if (version >= 80)
            {
                for (int num42 = 0; num42 < this.m_ulReachSiteCnt; num42++)
                {
                    Task_Region.Write(version, bw, this.m_pReachSite[num42]);
                }
                for (int num43 = 0; num43 < this.m_ulLeaveSiteCnt; num43++)
                {
                    Task_Region.Write(version, bw, this.m_pLeaveSite[num43]);
                }
            }
            if (version >= 63)
            {
                for (int num44 = 0; num44 < this.m_ulExpCnt; num44++)
                {
                    bw.Write(this.m_pszExp[num44]);
                    TASK_EXPRESSION.Write(version, bw, this.m_pExpArr[num44]);
                }
                for (int num45 = 0; num45 < this.m_ulTaskCharCnt; num45++)
                {
                    bw.Write(this.m_pTaskChar[num45]);
                }
            }
            if (version >= 127)
            {
                for (int num39 = 0; num39 < this.TMHomeItemData.Length; num39++)
                {
                    HomeItemData.Write(version, bw, this.TMHomeItemData[num39]);
                }
            }
            AWARD_DATA.Write(version, bw, this.m_Award_S);
            AWARD_DATA.Write(version, bw, this.m_Award_F);
            AWARD_RATIO_SCALE.Write(version, bw, this.m_AwByRatio_S);
            AWARD_RATIO_SCALE.Write(version, bw, this.m_AwByRatio_F);
            AWARD_ITEMS_SCALE.Write(version, bw, this.m_AwByItems_S);
            AWARD_ITEMS_SCALE.Write(version, bw, this.m_AwByItems_F);
            bw.Write(this.conversation.m_pwstrDescript_len);
            bw.Write(this.conversation.m_pwstrDescript);
            bw.Write(this.conversation.m_pwstrOkText_len);
            bw.Write(this.conversation.m_pwstrOkText);
            bw.Write(this.conversation.m_pwstrNoText_len);
            bw.Write(this.conversation.m_pwstrNoText);
            bw.Write(this.conversation.m_pwstrTribute_len);
            bw.Write(this.conversation.m_pwstrTribute);
            for (int index = 0; index < this.talk_procs.Length; index++)
            {
                talk_proc.Write(version, bw, this.talk_procs[index]);
            }
            bw.Write(this.sub_quest_count);
            for (int num50 = 0; num50 < this.sub_quest_count; num50++)
            {
                this.sub_quests[num50].Save(version, bw);
            }
        }
	}
}

