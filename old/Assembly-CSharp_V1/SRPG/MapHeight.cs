﻿// Decompiled with JetBrains decompiler
// Type: SRPG.MapHeight
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using UnityEngine;

namespace SRPG
{
  public class MapHeight : MonoBehaviour
  {
    private int oldHeight;
    public int Height;
    public BitmapText MapHeightText;
    private Unit mFocusUnit;

    public MapHeight()
    {
      base.\u002Ector();
    }

    public Unit FocusUnit
    {
      set
      {
        this.mFocusUnit = value;
      }
    }

    private void Start()
    {
      this.MapHeightText.text = this.Height.ToString();
    }

    private void Update()
    {
      if (this.mFocusUnit != null)
        this.Height = SceneBattle.Instance.GetDisplayHeight(this.mFocusUnit);
      if (this.oldHeight != this.Height)
        this.MapHeightText.text = this.Height.ToString();
      this.oldHeight = this.Height;
    }
  }
}
