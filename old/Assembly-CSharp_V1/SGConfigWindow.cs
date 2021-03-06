﻿// Decompiled with JetBrains decompiler
// Type: SGConfigWindow
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SGConfigWindow : MonoBehaviour
{
  [SerializeField]
  private List<Toggle> languageToggles;

  public SGConfigWindow()
  {
    base.\u002Ector();
  }

  private void Start()
  {
    this.updateLanguageToggles(GameUtility.Config_Language);
  }

  protected void updateLanguageToggles(string language)
  {
    for (int index = 0; index < this.languageToggles.Count; ++index)
    {
      Toggle languageToggle = this.languageToggles[index];
      languageToggle.set_isOn(((Object) languageToggle).get_name() == language);
      ((Selectable) languageToggle).set_interactable(!languageToggle.get_isOn());
    }
  }

  public void resetToggle()
  {
    for (int index = 0; index < this.languageToggles.Count; ++index)
    {
      Toggle languageToggle = this.languageToggles[index];
      if (((Object) languageToggle).get_name() == GameUtility.Config_Language)
      {
        languageToggle.set_isOn(true);
        ((Selectable) languageToggle).set_interactable(!languageToggle.get_isOn());
      }
    }
  }
}
