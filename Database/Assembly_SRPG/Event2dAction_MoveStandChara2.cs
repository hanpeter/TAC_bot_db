﻿// Decompiled with JetBrains decompiler
// Type: SRPG.Event2dAction_MoveStandChara2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE644F5D-682F-4D6E-964D-A0DD77A288F7
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using UnityEngine;

namespace SRPG
{
  [EventActionInfo("立ち絵2/移動(2D)", "立ち絵2を指定した位置に移動させます。", 5592405, 4473992)]
  public class Event2dAction_MoveStandChara2 : EventAction
  {
    public float MoveTime = 1f;
    public string CharaID;
    public EventStandCharaController2.PositionTypes MoveTo;
    private EventStandCharaController2 mStandChara;
    private Vector3 FromPostion;
    private Vector3 ToPostion;
    private float offset;
    private Vector2 FromAnchorMin;
    private Vector2 FromAnchorMax;
    private RectTransform mStandCharaTransform;
    private Vector2 mToAnchor;

    public override void PreStart()
    {
      if (!Object.op_Equality((Object) this.mStandChara, (Object) null))
        return;
      this.mStandChara = EventStandCharaController2.FindInstances(this.CharaID);
    }

    public override void OnActivate()
    {
      if (Object.op_Equality((Object) this.mStandChara, (Object) null))
      {
        this.ActivateNext();
      }
      else
      {
        this.mStandCharaTransform = (RectTransform) ((Component) this.mStandChara).GetComponent<RectTransform>();
        this.FromAnchorMin = this.mStandCharaTransform.get_anchorMin();
        this.FromAnchorMax = this.mStandCharaTransform.get_anchorMax();
        this.mToAnchor = new Vector2(this.mStandChara.GetAnchorPostionX((int) this.MoveTo), 0.0f);
      }
    }

    public override void Update()
    {
      this.mStandCharaTransform.set_anchorMin(Vector2.op_Addition(this.FromAnchorMin, Vector2.Scale(Vector2.op_Subtraction(this.mToAnchor, this.FromAnchorMin), new Vector2(this.offset, this.offset))));
      this.mStandCharaTransform.set_anchorMax(Vector2.op_Addition(this.FromAnchorMax, Vector2.Scale(Vector2.op_Subtraction(this.mToAnchor, this.FromAnchorMax), new Vector2(this.offset, this.offset))));
      this.offset += Time.get_deltaTime() / this.MoveTime;
      if ((double) this.offset < 1.0)
        return;
      this.offset = 1f;
      RectTransform standCharaTransform = this.mStandCharaTransform;
      Vector2 mToAnchor = this.mToAnchor;
      this.mStandCharaTransform.set_anchorMax(mToAnchor);
      Vector2 vector2 = mToAnchor;
      standCharaTransform.set_anchorMin(vector2);
      this.ActivateNext();
    }
  }
}