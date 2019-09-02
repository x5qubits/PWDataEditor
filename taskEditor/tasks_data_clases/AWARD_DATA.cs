
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class AWARD_DATA
    {
        public int m_ulGoldNum;
        public int m_ulExp;
        public int m_ulRealmExp;
        public bool m_bExpandRealmLevelMax;
        public int m_ulNewTask;
        public int m_ulSP;
        public int m_lReputation;
        public int m_ulNewPeriod;
        public int m_ulNewRelayStation;
        public int m_ulStorehouseSize;
        public int m_ulStorehouseSize2;
        public int m_ulStorehouseSize3;
        public int m_ulStorehouseSize4;
        public int m_lInventorySize;
        public int m_ulPetInventorySize;
        public int m_ulFuryULimit;
        public int m_ulTransWldId;
        public ZONE_VERT m_TransPt;
        public int m_lMonsCtrl;
        public bool m_bTrigCtrl;
        public bool m_bUseLevCo;
        public bool m_bDivorce;
        public bool m_bSendMsg;
        public int m_nMsgChannel;
        public int m_ulCandItems;
        public AWARD_ITEMS_CAND[] m_CandItems;
        public int m_ulSummonedMonsters;
        public AWARD_MONSTERS_SUMMONED m_SummonedMonsters;
        public bool m_bAwardDeath;
        public bool m_bAwardDeathWithLoss;
        public int m_ulDividend;
        public bool m_bAwardSkill;
        public int m_iAwardSkillID;
        public int m_iAwardSkillLevel;
        public int AwardSoloTowerChallengeScore;
        public int m_ulSpecifyContribTaskID;
        public int m_ulSpecifyContribSubTaskID;
        public int m_ulSpecifyContrib;
        public int m_ulContrib;
        public int m_ulRandContrib;
        public int m_ulLowestcontrib;
        public int m_iFactionContrib;
        public int m_iFactionExpContrib;
        public int m_ulPQRankingAwardCnt;
        public AWARD_PQ_RANKING m_PQRankingAward;
        public int m_ulChangeKeyCnt;
        public int[] m_plChangeKey;
        public int[] m_plChangeKeyValue;
        public bool[] m_pbChangeType;
        public int m_ulHistoryChangeCnt;
        public int[] m_plHistoryChangeKey;
        public int[] m_plHistoryChangeKeyValue;
        public bool[] m_pbHistoryChangeType;
        public bool m_bMulti;
        public int m_nNumType;
        public int m_lNum;
        public int m_ulDisplayKeyCnt;
        public int[] m_plDisplayKey;
        public int m_ulExpCnt;
        public byte[][] m_pszExp;
        public TASK_EXPRESSION[] m_pExpArr;
        public int m_ulTaskCharCnt;
        public byte[][] m_pTaskChar;
        public int m_iForceContribution;
        public int m_iForceReputation;
        public int m_iForceActivity;
        public int m_iForceSetRepu;
        public int m_iTaskLimit;
        public int m_ulTitleNum;
        public TITLE_AWARD[] m_pTitleAward;
		public int m_iLeaderShip;
        public int AwardWorldContrib;
        public int[] AwardHomeResource;
        public bool AwardCreateHome;

        public byte[] m_CandItemsPointer, m_MonstersPointer, m_RankingAwardPointer, m_ulChangeKeyPointer,
        m_plHistoryChangeKeyPointer, m_plHistoryChangeKeyValuePointer, m_pbHistoryChangeTypePointer,
        m_ulDisplayKeyCntPointer, m_pszExpPointer, m_pTaskCharPointer, m_pTitleAwardPointer;

        internal static AWARD_DATA Read(int version, BinaryReader br)
        {
            AWARD_DATA reward = new AWARD_DATA();
            reward.m_ulGoldNum = br.ReadInt32();
            reward.m_ulExp = br.ReadInt32();
            if (version >= 118)
            {
                reward.m_ulRealmExp = br.ReadInt32();
                reward.m_bExpandRealmLevelMax = br.ReadBoolean();
            }
            else
            {
                reward.m_ulRealmExp = 0;
                reward.m_bExpandRealmLevelMax = false;
            }
            reward.m_ulNewTask = br.ReadInt32();
            reward.m_ulSP = br.ReadInt32();
            reward.m_lReputation = br.ReadInt32();
            reward.m_ulNewPeriod = br.ReadInt32();
            reward.m_ulNewRelayStation = br.ReadInt32();
            reward.m_ulStorehouseSize = br.ReadInt32();
            if (version >= 57)
            {
                reward.m_ulStorehouseSize2 = br.ReadInt32();
                reward.m_ulStorehouseSize3 = br.ReadInt32();
            }
            else
            {
                reward.m_ulStorehouseSize2 = 0;
                reward.m_ulStorehouseSize3 = 0;
            }
            if (version >= 75)
            {
                reward.m_ulStorehouseSize4 = br.ReadInt32();
            }
            else
            {
                reward.m_ulStorehouseSize4 = 0;
            }
            if (version >= 53)
            {
                reward.m_lInventorySize = br.ReadInt32();
                reward.m_ulPetInventorySize = br.ReadInt32();
            }
            else
            {
                reward.m_lInventorySize = 0;
                reward.m_ulPetInventorySize = 0;
            }
            reward.m_ulFuryULimit = br.ReadInt32();
            reward.m_ulTransWldId = br.ReadInt32();
            reward.m_TransPt = ZONE_VERT.Read(version, br);
            if (version >= 53)
            {
                reward.m_lMonsCtrl = br.ReadInt32();
                reward.m_bTrigCtrl = br.ReadBoolean();
            }
            else
            {
                reward.m_lMonsCtrl = 0;
                reward.m_bTrigCtrl = false;
            }
            if (version >= 54)
            {
                reward.m_bUseLevCo = br.ReadBoolean();
            }
            else
            {
                reward.m_bUseLevCo = false;
            }
            if (version >= 55)
            {
                reward.m_bDivorce = br.ReadBoolean();
            }
            else
            {
                reward.m_bDivorce = false;
            }
            if (version >= 56)
            {
                reward.m_bSendMsg = br.ReadBoolean();
                reward.m_nMsgChannel = br.ReadInt32();
            }
            else
            {
                reward.m_bSendMsg = false;
                reward.m_nMsgChannel = 0;
            }
            reward.m_ulCandItems = br.ReadInt32();
            reward.m_CandItemsPointer = br.ReadBytes(4);
            if (version >= 68)
            {
                reward.m_ulSummonedMonsters = br.ReadInt32();
                reward.m_MonstersPointer = br.ReadBytes(4);
            }
            else
            {
                reward.m_ulSummonedMonsters = 0;
                reward.m_MonstersPointer = new byte[4];
            }
            if (version >= 69)
            {
                reward.m_bAwardDeath = br.ReadBoolean();
                reward.m_bAwardDeathWithLoss = br.ReadBoolean();
            }
            else
            {
                reward.m_bAwardDeath = false;
                reward.m_bAwardDeathWithLoss = false;
            }
            if (version >= 75)
            {
                reward.m_ulDividend = br.ReadInt32();
            }
            else
            {
                reward.m_ulDividend = 0;
            }
            if (version >= 78)
            {
                reward.m_bAwardSkill = br.ReadBoolean();
                reward.m_iAwardSkillID = br.ReadInt32();
                reward.m_iAwardSkillLevel = br.ReadInt32();
            }
            else
            {
                reward.m_bAwardSkill = false;
                reward.m_iAwardSkillID = 0;
                reward.m_iAwardSkillLevel = 0;
            }
            reward.AwardSoloTowerChallengeScore = ((version < 124) ? 0 : br.ReadInt32());
            if (version >= 75)
            {
                reward.m_ulSpecifyContribTaskID = br.ReadInt32();
            }
            else
            {
                reward.m_ulSpecifyContribTaskID = 0;
            }
            if (version >= 78)
            {
                reward.m_ulSpecifyContribSubTaskID = br.ReadInt32();
            }
            else
            {
                reward.m_ulSpecifyContribSubTaskID = 0;
            }
            if (version >= 75)
            {
                reward.m_ulSpecifyContrib = br.ReadInt32();
                reward.m_ulContrib = br.ReadInt32();
                reward.m_ulRandContrib = br.ReadInt32();
                reward.m_ulLowestcontrib = br.ReadInt32();
            }
            else
            {
                reward.m_ulSpecifyContrib = 0;
                reward.m_ulContrib = 0;
                reward.m_ulRandContrib = 0;
                reward.m_ulLowestcontrib = 0;
            }
            if (version >= 89)
            {
                reward.m_iFactionContrib = br.ReadInt32();
                reward.m_iFactionExpContrib = br.ReadInt32();
            }
            else
            {
                reward.m_iFactionContrib = 0;
                reward.m_iFactionExpContrib = 0;
            }
            if (version >= 75)
            {
                reward.m_ulPQRankingAwardCnt = br.ReadInt32();
                reward.m_RankingAwardPointer = br.ReadBytes(4);
            }
            else
            {
                reward.m_ulPQRankingAwardCnt = 0;
                reward.m_RankingAwardPointer = new byte[4];
            }
            if (version >= 59)
            {
                reward.m_ulChangeKeyCnt = br.ReadInt32();
                reward.m_ulChangeKeyPointer = br.ReadBytes(12);
            }
            else
            {
                reward.m_ulChangeKeyCnt = 0;
                reward.m_ulChangeKeyPointer = new byte[12];
            }
            if (version >= 118)
            {
                reward.m_ulHistoryChangeCnt = br.ReadInt32();
                reward.m_plHistoryChangeKeyPointer = br.ReadBytes(4);
                reward.m_plHistoryChangeKeyValuePointer = br.ReadBytes(4);
                reward.m_pbHistoryChangeTypePointer = br.ReadBytes(4);
            }
            else
            {
                reward.m_ulHistoryChangeCnt = 0;
                reward.m_plHistoryChangeKeyPointer = new byte[4];
                reward.m_plHistoryChangeKeyValuePointer = new byte[4];
                reward.m_pbHistoryChangeTypePointer = new byte[4];
            }
            if (version >= 59)
            {
                reward.m_bMulti = br.ReadBoolean();
                reward.m_nNumType = br.ReadInt32();
                reward.m_lNum = br.ReadInt32();
                reward.m_ulDisplayKeyCnt = br.ReadInt32();
                reward.m_ulDisplayKeyCntPointer = br.ReadBytes(4);
            }
            else
            {
                reward.m_bMulti = false;
                reward.m_nNumType = 0;
                reward.m_lNum = 0;
                reward.m_ulDisplayKeyCnt = 0;
                reward.m_ulDisplayKeyCntPointer = new byte[4];
            }
            if (version >= 63)
            {
                reward.m_ulExpCnt = br.ReadInt32();
                reward.m_pszExpPointer = br.ReadBytes(8);
                reward.m_ulTaskCharCnt = br.ReadInt32();
                reward.m_pTaskCharPointer = br.ReadBytes(4);
            }
            else
            {
                reward.m_ulExpCnt = 0;
                reward.m_pszExpPointer = new byte[8];
                reward.m_ulTaskCharCnt = 0;
                reward.m_pTaskCharPointer = new byte[4];
            }
            reward.m_SummonedMonsters = new AWARD_MONSTERS_SUMMONED();
            reward.m_SummonedMonsters.m_bRandChoose = false;
            reward.m_SummonedMonsters.m_ulSummonRadius = 0;
            reward.m_SummonedMonsters.m_bDeathDisappear = false;
            reward.m_SummonedMonsters.m_Monsters = new MONSTERS_SUMMONED[0];
            reward.m_PQRankingAward = new AWARD_PQ_RANKING();
            reward.m_PQRankingAward.m_bAwardByProf = false;
            reward.m_PQRankingAward.m_RankingAward = new RANKING_AWARD[0];
            reward.m_plChangeKey = new int[0];
            reward.m_plChangeKeyValue = new int[0];
            reward.m_pbChangeType = new bool[0];
            reward.m_plHistoryChangeKey = new int[0];
            reward.m_plHistoryChangeKeyValue = new int[0];
            reward.m_pbHistoryChangeType = new bool[0];
            reward.m_plDisplayKey = new int[0];
            reward.m_pszExp = new byte[0][];
            reward.m_pExpArr = new TASK_EXPRESSION[0];
            reward.m_pTaskChar = new byte[0][];
            if (version >= 99)
            {
                reward.m_iForceContribution = br.ReadInt32();
                reward.m_iForceReputation = br.ReadInt32();
                reward.m_iForceActivity = br.ReadInt32();
            }
            else
            {
                reward.m_iForceContribution = 0;
                reward.m_iForceReputation = 0;
                reward.m_iForceActivity = 0;
            }
            if (version >= 100)
            {
                reward.m_iForceSetRepu = br.ReadInt32();
            }
            else
            {
                reward.m_iForceSetRepu = 0;
            }
            reward.m_iTaskLimit = ((version < 101) ? 0 : br.ReadInt32());
            if (version >= 111)
            {
                reward.m_ulTitleNum = br.ReadInt32();
                reward.m_pTitleAwardPointer = br.ReadBytes(4);
            }
            else
            {
                reward.m_ulTitleNum = 0;
                reward.m_pTitleAwardPointer = new byte[4];
            }
            reward.m_iLeaderShip = ((version < 118) ? 0 : br.ReadInt32());
            reward.AwardWorldContrib = ((version < 119) ? 0 : br.ReadInt32());
            if (version >= 127)
            {
                reward.AwardHomeResource = new int[5];
                for (int num29 = 0; num29 < reward.AwardHomeResource.Length; num29++)
                {
                    reward.AwardHomeResource[num29] = br.ReadInt32();
                }
                reward.AwardCreateHome = br.ReadBoolean();
            }
            else
            {
                int[] AwardHome = new int[5];
                reward.AwardHomeResource = AwardHome;
                reward.AwardCreateHome = false;
            }
            reward.m_CandItems = new AWARD_ITEMS_CAND[reward.m_ulCandItems];
            for (int index = 0; index < reward.m_CandItems.Length; index++)
            {
                reward.m_CandItems[index] = AWARD_ITEMS_CAND.Read(version, br);
            }
            if (version >= 68 && reward.m_ulSummonedMonsters > 0)
            {
                reward.m_SummonedMonsters = AWARD_MONSTERS_SUMMONED.Read(version, br, reward.m_ulSummonedMonsters);
            }
            if (version >= 75 && reward.m_ulPQRankingAwardCnt > 0)
            {
                reward.m_PQRankingAward = AWARD_PQ_RANKING.Read(version, br, reward.m_ulPQRankingAwardCnt);
            }
            if (version >= 59 && reward.m_ulChangeKeyCnt > 0)
            {
                reward.m_plChangeKey = new int[reward.m_ulChangeKeyCnt];
                reward.m_plChangeKeyValue = new int[reward.m_ulChangeKeyCnt];
                reward.m_pbChangeType = new bool[reward.m_ulChangeKeyCnt];
                for (int index5 = 0; index5 < reward.m_ulChangeKeyCnt; index5++)
                {
                    reward.m_plChangeKey[index5] = br.ReadInt32();
                    reward.m_plChangeKeyValue[index5] = br.ReadInt32();
                    reward.m_pbChangeType[index5] = br.ReadBoolean();
                }
            }
            if (version >= 118 && reward.m_ulHistoryChangeCnt > 0)
            {
                reward.m_plHistoryChangeKey = new int[reward.m_ulHistoryChangeCnt];
                reward.m_plHistoryChangeKeyValue = new int[reward.m_ulHistoryChangeCnt];
                reward.m_pbHistoryChangeType = new bool[reward.m_ulHistoryChangeCnt];
                for (int index4 = 0; index4 < reward.m_ulHistoryChangeCnt; index4++)
                {
                    reward.m_plHistoryChangeKey[index4] = br.ReadInt32();
                    reward.m_plHistoryChangeKeyValue[index4] = br.ReadInt32();
                    reward.m_pbHistoryChangeType[index4] = br.ReadBoolean();
                }
            }
            if (version >= 59 && reward.m_ulDisplayKeyCnt > 0)
            {
                reward.m_plDisplayKey = new int[reward.m_ulDisplayKeyCnt];
                for (int index4 = 0; index4 < reward.m_ulDisplayKeyCnt; index4++)
                {
                    reward.m_plDisplayKey[index4] = new int();
                    reward.m_plDisplayKey[index4] = br.ReadInt32();
                }
            }
            if (version >= 63 && reward.m_ulExpCnt > 0)
            {
                reward.m_pszExp = new byte[reward.m_ulExpCnt][];
                reward.m_pExpArr = new TASK_EXPRESSION[reward.m_ulExpCnt];
                for (int index6 = 0; index6 < reward.m_ulExpCnt; index6++)
                {
                    reward.m_pszExp[index6] = br.ReadBytes(64);
                    reward.m_pExpArr[index6] = TASK_EXPRESSION.Read(version, br);
                }
            }
            if (version >= 63 && reward.m_ulTaskCharCnt > 0)
            {
                reward.m_pTaskChar = new byte[reward.m_ulTaskCharCnt][];
                for (int index7 = 0; index7 < reward.m_ulTaskCharCnt; index7++)
                {
                    reward.m_pTaskChar[index7] = br.ReadBytes(128);
                }
            }
            if (version >= 111)
            {
                reward.m_pTitleAward = new TITLE_AWARD[reward.m_ulTitleNum];
                for (int index8 = 0; index8 < reward.m_pTitleAward.Length; index8++)
                {
                    reward.m_pTitleAward[index8] = TITLE_AWARD.Read(version, br);
                }
            }
            else
            {
                reward.m_pTitleAward = new TITLE_AWARD[0];
            }
            return reward;
        }

        internal static void Write(int version, BinaryWriter bw, AWARD_DATA reward)
        {
            bw.Write(reward.m_ulGoldNum);
            bw.Write(reward.m_ulExp);
            if (version >= 118)
            {
                bw.Write(reward.m_ulRealmExp);
                bw.Write(reward.m_bExpandRealmLevelMax);
            }
            bw.Write(reward.m_ulNewTask);
            bw.Write(reward.m_ulSP);
            bw.Write(reward.m_lReputation);
            bw.Write(reward.m_ulNewPeriod);
            bw.Write(reward.m_ulNewRelayStation);
            bw.Write(reward.m_ulStorehouseSize);
            if (version >= 57)
            {
                bw.Write(reward.m_ulStorehouseSize2);
                bw.Write(reward.m_ulStorehouseSize3);
            }
            if (version >= 75)
            {
                bw.Write(reward.m_ulStorehouseSize4);
            }
            if (version >= 53)
            {
                bw.Write(reward.m_lInventorySize);
                bw.Write(reward.m_ulPetInventorySize);
            }
            bw.Write(reward.m_ulFuryULimit);
            bw.Write(reward.m_ulTransWldId);
            ZONE_VERT.Write(version, bw, reward.m_TransPt);
            if (version >= 53)
            {
                bw.Write(reward.m_lMonsCtrl);
                bw.Write(reward.m_bTrigCtrl);
            }
            if (version >= 54)
            {
                bw.Write(reward.m_bUseLevCo);
            }
            if (version >= 55)
            {
                bw.Write(reward.m_bDivorce);
            }
            if (version >= 56)
            {
                bw.Write(reward.m_bSendMsg);
                bw.Write(reward.m_nMsgChannel);
            }
            bw.Write(reward.m_ulCandItems);
            bw.Write(reward.m_CandItemsPointer);
            if (version >= 68)
            {
                bw.Write(reward.m_ulSummonedMonsters);
                bw.Write(reward.m_MonstersPointer);
            }
            if (version >= 69)
            {
                bw.Write(reward.m_bAwardDeath);
                bw.Write(reward.m_bAwardDeathWithLoss);
            }
            if (version >= 75)
            {
                bw.Write(reward.m_ulDividend);
            }
            if (version >= 78)
            {
                bw.Write(reward.m_bAwardSkill);
                bw.Write(reward.m_iAwardSkillID);
                bw.Write(reward.m_iAwardSkillLevel);
            }
            if (version >= 124)
            {
                bw.Write(reward.AwardSoloTowerChallengeScore);
            }
            if (version >= 75)
            {
                bw.Write(reward.m_ulSpecifyContribTaskID);
            }
            if (version >= 78)
            {
                bw.Write(reward.m_ulSpecifyContribSubTaskID);
            }
            if (version >= 75)
            {
                bw.Write(reward.m_ulSpecifyContrib);
                bw.Write(reward.m_ulContrib);
                bw.Write(reward.m_ulRandContrib);
                bw.Write(reward.m_ulLowestcontrib);
            }
            if (version >= 89)
            {
                bw.Write(reward.m_iFactionContrib);
                bw.Write(reward.m_iFactionExpContrib);
            }
            if (version >= 75)
            {
                bw.Write(reward.m_ulPQRankingAwardCnt);
                bw.Write(reward.m_RankingAwardPointer);
            }
            if (version >= 59)
            {
                bw.Write(reward.m_ulChangeKeyCnt);
                bw.Write(reward.m_ulChangeKeyPointer);
            }
            if (version >= 118)
            {
                bw.Write(reward.m_ulHistoryChangeCnt);
                bw.Write(reward.m_plHistoryChangeKeyPointer);
                bw.Write(reward.m_plHistoryChangeKeyValuePointer);
                bw.Write(reward.m_pbHistoryChangeTypePointer);
            }
            if (version >= 59)
            {

                bw.Write(reward.m_bMulti);
                bw.Write(reward.m_nNumType);
                bw.Write(reward.m_lNum);
                bw.Write(reward.m_ulDisplayKeyCnt);
                bw.Write(reward.m_ulDisplayKeyCntPointer);
            }
            if (version >= 63)
            {
                bw.Write(reward.m_ulExpCnt);
                bw.Write(reward.m_pszExpPointer);
                bw.Write(reward.m_ulTaskCharCnt);
                bw.Write(reward.m_pTaskCharPointer);
            }
            if (version >= 99)
            {
                bw.Write(reward.m_iForceContribution);
                bw.Write(reward.m_iForceReputation);
                bw.Write(reward.m_iForceActivity);
            }
            if (version >= 100)
            {
                bw.Write(reward.m_iForceSetRepu);
            }
            if (version >= 101)
            {
                bw.Write(reward.m_iTaskLimit);
            }
            if (version >= 111)
            {
                bw.Write(reward.m_ulTitleNum);
                bw.Write(reward.m_pTitleAwardPointer);
            }
            if (version >= 118)
            {
                bw.Write(reward.m_iLeaderShip);
            }
            if (version >= 119)
            {
                bw.Write(reward.AwardWorldContrib);
            }
            if (version >= 127)
            {
                for (int num31 = 0; num31 < reward.AwardHomeResource.Length; num31++)
                {
                    bw.Write(reward.AwardHomeResource[num31]);
                }
                bw.Write(reward.AwardCreateHome);
            }
            for (int index = 0; index < reward.m_CandItems.Length; index++)
            {
                AWARD_ITEMS_CAND.Write(version, bw, reward.m_CandItems[index]);
            }
            if (version >= 68 && reward.m_ulSummonedMonsters > 0)
            {
                AWARD_MONSTERS_SUMMONED.Write(version, bw, reward.m_SummonedMonsters);
            }
            if (version >= 75 && reward.m_ulPQRankingAwardCnt > 0)
            {
                AWARD_PQ_RANKING.Write(version, bw, reward.m_PQRankingAward);
            }
            if (version >= 59 && reward.m_ulChangeKeyCnt > 0)
            {
                for (int index5 = 0; index5 < reward.m_ulChangeKeyCnt; index5++)
                {
                    bw.Write(reward.m_plChangeKey[index5]);
                    bw.Write(reward.m_plChangeKeyValue[index5]);
                    bw.Write(reward.m_pbChangeType[index5]);
                }
            }
            if (version >= 118 && reward.m_ulHistoryChangeCnt > 0)
            {
                for (int index4 = 0; index4 < reward.m_ulHistoryChangeCnt; index4++)
                {
                    bw.Write(reward.m_plHistoryChangeKey[index4]);
                    bw.Write(reward.m_plHistoryChangeKeyValue[index4]);
                    bw.Write(reward.m_pbHistoryChangeType[index4]);
                }
            }
            if (version >= 59 && reward.m_ulDisplayKeyCnt > 0)
            {
                for (int index4 = 0; index4 < reward.m_ulDisplayKeyCnt; index4++)
                {
                    bw.Write(reward.m_plDisplayKey[index4]);
                }
            }
            if (version >= 63 && reward.m_ulExpCnt > 0)
            {
                for (int index6 = 0; index6 < reward.m_ulExpCnt; index6++)
                {
                    bw.Write(reward.m_pszExp[index6]);
                    TASK_EXPRESSION.Write(version, bw, reward.m_pExpArr[index6]);
                }
            }
            if (version >= 63 && reward.m_ulTaskCharCnt > 0)
            {
                for (int index7 = 0; index7 < reward.m_ulTaskCharCnt; index7++)
                {
                    bw.Write(reward.m_pTaskChar[index7]);
                }
            }
            if (version < 111)
            {
                return;
            }
            for (int index8 = 0; index8 < reward.m_pTitleAward.Length; index8++)
            {
                TITLE_AWARD.Write(version, bw, reward.m_pTitleAward[index8]);
            }
        }
	}
}

