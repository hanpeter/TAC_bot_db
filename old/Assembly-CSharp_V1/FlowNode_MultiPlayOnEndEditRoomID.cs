﻿// Decompiled with JetBrains decompiler
// Type: FlowNode_MultiPlayOnEndEditRoomID
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using SRPG;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[AddComponentMenu("")]
[FlowNode.NodeType("Event/OnEndEditMultiPlayRoomID", 58751)]
[FlowNode.Pin(1, "Edited", FlowNode.PinTypes.Output, 0)]
public class FlowNode_MultiPlayOnEndEditRoomID : FlowNodePersistent
{
  [FlowNode.DropTarget(typeof (InputField), true)]
  [FlowNode.ShowInInfo]
  public InputField Target;

  private void Start()
  {
    if (!Object.op_Inequality((Object) this.Target, (Object) null))
      return;
    GlobalVars.SelectedMultiPlayRoomID = 0;
    // ISSUE: method pointer
    ((UnityEvent<string>) this.Target.get_onEndEdit()).AddListener(new UnityAction<string>((object) this, __methodptr(\u003CStart\u003Em__1F4)));
    ((Behaviour) this).set_enabled(true);
  }

  protected override void OnDestroy()
  {
    base.OnDestroy();
    GUtility.SetImmersiveMove();
    if (!Object.op_Inequality((Object) this.Target, (Object) null) || this.Target.get_onEndEdit() == null)
      return;
    ((UnityEventBase) this.Target.get_onEndEdit()).RemoveAllListeners();
  }

  private void OnEndEdit(InputField field)
  {
    GUtility.SetImmersiveMove();
    if (field.get_text().Length <= 0)
      return;
    int result = 0;
    if (int.TryParse(field.get_text(), out result))
      GlobalVars.SelectedMultiPlayRoomID = result;
    this.Activate(1);
  }

  public override void OnActivate(int pinID)
  {
    if (pinID != 1)
      return;
    this.ActivateOutputLinks(1);
  }
}
