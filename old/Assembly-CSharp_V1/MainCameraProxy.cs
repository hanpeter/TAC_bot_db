﻿// Decompiled with JetBrains decompiler
// Type: MainCameraProxy
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (Camera))]
public class MainCameraProxy : MonoBehaviour
{
  public MainCameraProxy()
  {
    base.\u002Ector();
  }

  private void Update()
  {
    Camera main = Camera.get_main();
    Camera component = (Camera) ((Component) this).GetComponent<Camera>();
    if (Object.op_Equality((Object) main, (Object) null) || Object.op_Equality((Object) component, (Object) null))
      return;
    Transform transform1 = ((Component) main).get_transform();
    Transform transform2 = ((Component) this).get_transform();
    transform1.set_position(transform2.get_position());
    transform1.set_rotation(transform2.get_rotation());
    main.set_fieldOfView(component.get_fieldOfView());
    main.set_farClipPlane(component.get_farClipPlane());
    main.set_nearClipPlane(component.get_nearClipPlane());
    main.set_orthographic(component.get_orthographic());
    main.set_orthographicSize(component.get_orthographicSize());
  }
}
