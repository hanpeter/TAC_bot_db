﻿// Decompiled with JetBrains decompiler
// Type: SRPG.ItemGetUnlockWindow
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using GR;
using UnityEngine;

namespace SRPG
{
  [FlowNode.Pin(1, "Refresh", FlowNode.PinTypes.Input, 1)]
  [FlowNode.Pin(100, "Unlock", FlowNode.PinTypes.Output, 100)]
  [FlowNode.Pin(101, "Selected Quest", FlowNode.PinTypes.Output, 101)]
  public class ItemGetUnlockWindow : MonoBehaviour, IFlowInterface
  {
    private ItemParam UnlockItem;

    public ItemGetUnlockWindow()
    {
      base.\u002Ector();
    }

    private void Start()
    {
      this.Refresh();
    }

    public void Activated(int pinID)
    {
      if (pinID != 1)
        return;
      this.Refresh();
    }

    private void Refresh()
    {
      this.UnlockItem = MonoSingleton<GameManager>.Instance.GetItemParam(GlobalVars.ItemSelectListItemData.iiname);
      DataSource.Bind<ItemParam>(((Component) this).get_gameObject(), this.UnlockItem);
      DataSource.Bind<ItemSelectListItemData>(((Component) this).get_gameObject(), GlobalVars.ItemSelectListItemData);
      ItemData itemDataByItemParam = MonoSingleton<GameManager>.Instance.Player.FindItemDataByItemParam(this.UnlockItem);
      if (itemDataByItemParam != null)
        DataSource.Bind<ItemData>(((Component) this).get_gameObject(), itemDataByItemParam);
      GameParameter.UpdateAll(((Component) this).get_gameObject());
    }
  }
}
