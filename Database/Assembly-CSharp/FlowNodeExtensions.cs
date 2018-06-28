﻿// Decompiled with JetBrains decompiler
// Type: FlowNodeExtensions
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE644F5D-682F-4D6E-964D-A0DD77A288F7
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using UnityEngine;

public static class FlowNodeExtensions
{
  public static string GetPinNameForPinID(this FlowNode inFlowNode, int inPinID)
  {
    for (int index = 0; index < inFlowNode.Pins.Length; ++index)
    {
      if (inFlowNode.Pins[index].PinID == inPinID)
        return inFlowNode.Pins[index].Name;
    }
    return string.Empty;
  }

  public static bool IsPinMineAndPartOfMyOutputLinks(this FlowNode inFlowNode, int inPinID)
  {
    if (inFlowNode.FindPin(inPinID) == -1)
      return false;
    for (int index = 0; index < inFlowNode.OutputLinks.Length; ++index)
    {
      if (inFlowNode.OutputLinks[index].SrcPinID == inPinID)
        return true;
    }
    return false;
  }

  public static bool GetOutputLinkThatIsPartOfID(this FlowNode inFlowNode, out FlowNode.Link foundLink, int inPinID)
  {
    if (inFlowNode.FindPin(inPinID) == -1)
    {
      foundLink = new FlowNode.Link();
      return false;
    }
    for (int index = 0; index < inFlowNode.OutputLinks.Length; ++index)
    {
      if (inFlowNode.OutputLinks[index].SrcPinID == inPinID)
      {
        foundLink = inFlowNode.OutputLinks[index];
        return true;
      }
    }
    foundLink = new FlowNode.Link();
    return false;
  }

  public static string ShortName(this FlowNode inFlowNode)
  {
    if (Object.op_Equality((Object) inFlowNode, (Object) null))
      return string.Empty;
    return ((Object) inFlowNode).ToString().ToLower().Replace("flownode_", string.Empty).Replace(((Object) inFlowNode).get_name().ToLower(), string.Empty);
  }
}