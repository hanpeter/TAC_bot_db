﻿// Decompiled with JetBrains decompiler
// Type: SRPG.QuestCampaignTrust
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85BFDF7F-5712-4D45-9CD6-3465C703DFDF
// Assembly location: S:\Desktop\Assembly-CSharp.dll

namespace SRPG
{
  public class QuestCampaignTrust
  {
    public string iname;
    public string concept_card;
    public int card_trust_lottery_rate;
    public int card_trust_qe_bonus;

    public bool Deserialize(JSON_QuestCampaignTrust json)
    {
      this.iname = json.children_iname;
      this.concept_card = json.concept_card;
      this.card_trust_lottery_rate = json.card_trust_lottery_rate;
      this.card_trust_qe_bonus = json.card_trust_qe_bonus;
      return true;
    }
  }
}
