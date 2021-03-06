﻿// Decompiled with JetBrains decompiler
// Type: RadialBlurEffect
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
public class RadialBlurEffect : MonoBehaviour
{
  public Material BlurMaterial;
  [Range(0.0f, 1f)]
  public float Strength;
  public Vector2 Focus;

  public RadialBlurEffect()
  {
    base.\u002Ector();
  }

  private void OnRenderImage(RenderTexture src, RenderTexture dest)
  {
    if (Object.op_Inequality((Object) this.BlurMaterial, (Object) null) && (double) this.Strength > 0.0)
    {
      this.BlurMaterial.SetVector("_focus", Vector4.op_Implicit(this.Focus));
      this.BlurMaterial.SetFloat("_strength", this.Strength);
      Graphics.Blit((Texture) src, dest, this.BlurMaterial);
    }
    else
      Graphics.Blit((Texture) src, dest);
  }
}
