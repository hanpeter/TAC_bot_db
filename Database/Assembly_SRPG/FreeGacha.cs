﻿// Decompiled with JetBrains decompiler
// Type: SRPG.FreeGacha
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE644F5D-682F-4D6E-964D-A0DD77A288F7
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

namespace SRPG
{
  public class FreeGacha
  {
    public int num;
    public long at;

    public bool Deserialize(Json_FreeGacha json)
    {
      this.num = json.num;
      this.at = json.at;
      return true;
    }
  }
}
