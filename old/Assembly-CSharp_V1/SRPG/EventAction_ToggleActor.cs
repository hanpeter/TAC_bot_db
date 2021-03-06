﻿// Decompiled with JetBrains decompiler
// Type: SRPG.EventAction_ToggleActor
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using System.Collections;
using System.Diagnostics;
using UnityEngine;

namespace SRPG
{
  [EventActionInfo("アクター/表示切替", "シーン上のアクターの表示状態を切り替えます", 5592405, 4473992)]
  public class EventAction_ToggleActor : EventAction
  {
    [StringIsActorID]
    public string ActorID;
    public EventAction_ToggleActor.ToggleTypes Type;
    private GameObject mSummonEffect;

    public override bool IsPreloadAssets
    {
      get
      {
        return true;
      }
    }

    [DebuggerHidden]
    public override IEnumerator PreloadAssets()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new EventAction_ToggleActor.\u003CPreloadAssets\u003Ec__Iterator70() { \u003C\u003Ef__this = this };
    }

    public override void OnActivate()
    {
      TacticsUnitController byUniqueName = TacticsUnitController.FindByUniqueName(this.ActorID);
      switch (this.Type)
      {
        case EventAction_ToggleActor.ToggleTypes.Hide:
          if (Object.op_Inequality((Object) byUniqueName, (Object) null))
          {
            byUniqueName.SetVisible(false);
            break;
          }
          break;
        case EventAction_ToggleActor.ToggleTypes.Show:
        case EventAction_ToggleActor.ToggleTypes.Summon:
          if (Object.op_Inequality((Object) byUniqueName, (Object) null))
          {
            byUniqueName.SetVisible(true);
            if (Object.op_Inequality((Object) this.mSummonEffect, (Object) null))
            {
              GameUtility.RequireComponent<OneShotParticle>((Object.Instantiate((Object) this.mSummonEffect, ((Component) byUniqueName).get_transform().get_position(), ((Component) byUniqueName).get_transform().get_rotation()) as GameObject).get_gameObject());
              break;
            }
            break;
          }
          break;
      }
      this.ActivateNext();
    }

    public enum ToggleTypes
    {
      Hide,
      Show,
      Summon,
    }
  }
}
