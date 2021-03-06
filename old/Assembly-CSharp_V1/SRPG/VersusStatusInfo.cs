﻿// Decompiled with JetBrains decompiler
// Type: SRPG.VersusStatusInfo
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using GR;
using UnityEngine;
using UnityEngine.UI;

namespace SRPG
{
  public class VersusStatusInfo : MonoBehaviour
  {
    public Text FreeCnt;
    public Text TowerCnt;
    public Text FriendCnt;

    public VersusStatusInfo()
    {
      base.\u002Ector();
    }

    private void Start()
    {
      this.RefreshData();
    }

    private void RefreshData()
    {
      PlayerData player = MonoSingleton<GameManager>.Instance.Player;
      if (Object.op_Inequality((Object) this.FreeCnt, (Object) null))
        this.FreeCnt.set_text(player.VersusFreeWinCnt.ToString());
      if (Object.op_Inequality((Object) this.TowerCnt, (Object) null))
        this.TowerCnt.set_text(player.VersusTowerWinCnt.ToString());
      if (Object.op_Inequality((Object) this.FriendCnt, (Object) null))
        this.FriendCnt.set_text(player.VersusFriendWinCnt.ToString());
      DataSource.Bind<PlayerData>(((Component) this).get_gameObject(), MonoSingleton<GameManager>.Instance.Player);
    }
  }
}
