﻿// Decompiled with JetBrains decompiler
// Type: GR.Singleton`1
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using System;

namespace GR
{
  public abstract class Singleton<T> where T : class, new()
  {
    private static T instance_;

    public static T Instance
    {
      get
      {
        if ((object) Singleton<T>.instance_ == null)
          Singleton<T>.instance_ = Activator.CreateInstance<T>();
        return Singleton<T>.instance_;
      }
    }
  }
}
