﻿// Decompiled with JetBrains decompiler
// Type: TeamExtensions
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using ExitGames.Client.Photon;
using System.Collections.Generic;
using UnityEngine;

public static class TeamExtensions
{
  public static PunTeams.Team GetTeam(this PhotonPlayer player)
  {
    object obj;
    if (((Dictionary<object, object>) player.CustomProperties).TryGetValue((object) "team", out obj))
      return (PunTeams.Team) obj;
    return PunTeams.Team.none;
  }

  public static void SetTeam(this PhotonPlayer player, PunTeams.Team team)
  {
    if (!PhotonNetwork.connectedAndReady)
    {
      Debug.LogWarning((object) ("JoinTeam was called in state: " + (object) PhotonNetwork.connectionStateDetailed + ". Not connectedAndReady."));
    }
    else
    {
      if (player.GetTeam() == team)
        return;
      PhotonPlayer photonPlayer = player;
      Hashtable hashtable = new Hashtable();
      ((Dictionary<object, object>) hashtable).Add((object) nameof (team), (object) team);
      Hashtable propertiesToSet = hashtable;
      // ISSUE: variable of the null type
      __Null local = null;
      int num = 0;
      photonPlayer.SetCustomProperties(propertiesToSet, (Hashtable) local, num != 0);
    }
  }
}
