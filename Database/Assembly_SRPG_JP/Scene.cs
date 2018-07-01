﻿// Decompiled with JetBrains decompiler
// Type: SRPG.Scene
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 85BFDF7F-5712-4D45-9CD6-3465C703DFDF
// Assembly location: S:\Desktop\Assembly-CSharp.dll

using GR;
using UnityEngine;

namespace SRPG
{
  public abstract class Scene : MonoBehaviour
  {
    protected Scene()
    {
      base.\u002Ector();
    }

    protected bool IsLoaded { get; set; }

    protected void Awake()
    {
      MonoSingleton<SystemInstance>.Instance.Ensure();
      GameUtility.RemoveDuplicatedMainCamera();
    }
  }
}