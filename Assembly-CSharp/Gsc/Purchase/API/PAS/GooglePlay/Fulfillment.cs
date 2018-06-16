﻿// Decompiled with JetBrains decompiler
// Type: Gsc.Purchase.API.PAS.GooglePlay.Fulfillment
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FE644F5D-682F-4D6E-964D-A0DD77A288F7
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using Gsc.Network;
using Gsc.Network.Support.MiniJsonHelper;
using System;
using System.Collections.Generic;

namespace Gsc.Purchase.API.PAS.GooglePlay
{
  public class Fulfillment : Request<Fulfillment, Gsc.Purchase.API.Response.Fulfillment>
  {
    private const string ___path = "{0}/pas/googleplay/{1}/fulfill";

    public Fulfillment(string deviceId, List<Fulfillment.PurchaseData_t> purchaseDataList)
    {
      this.DeviceId = deviceId;
      this.PurchaseDataList = purchaseDataList;
    }

    public string DeviceId { get; set; }

    public List<Fulfillment.PurchaseData_t> PurchaseDataList { get; set; }

    public override string GetUrl()
    {
      return string.Format("{0}/pas/googleplay/{1}/fulfill", (object) SDK.Configuration.Env.NativeBaseUrl, (object) SDK.Configuration.AppName);
    }

    public override string GetPath()
    {
      return (string) null;
    }

    public override string GetMethod()
    {
      return "POST";
    }

    protected override Dictionary<string, object> GetParameters()
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      dictionary["receipts"] = Serializer.Instance.WithArray<Fulfillment.PurchaseData_t>().Add<Fulfillment.PurchaseData_t>(new Func<Fulfillment.PurchaseData_t, object>(Serializer.FromObject<Fulfillment.PurchaseData_t>)).Serialize<List<Fulfillment.PurchaseData_t>>(this.PurchaseDataList);
      dictionary["platform"] = (object) "googleplay";
      dictionary["version"] = (object) "v1";
      dictionary["device_id"] = (object) this.DeviceId;
      return dictionary;
    }

    public class PurchaseData_t : IObject, IRequestObject
    {
      public PurchaseData_t(string currency, float price, string signature, string receiptData)
      {
        this.Currency = currency;
        this.Price = price;
        this.Signature = signature;
        this.ReceiptData = receiptData;
      }

      public string Currency { get; set; }

      public float Price { get; set; }

      public string Signature { get; set; }

      public string ReceiptData { get; set; }

      public Dictionary<string, object> GetPayload()
      {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        dictionary["currency"] = Serializer.Instance.Add<string>(new Func<string, object>(Serializer.From<string>)).Serialize<string>(this.Currency);
        dictionary["price"] = Serializer.Instance.Add<float>(new Func<float, object>(Serializer.From<float>)).Serialize<float>(this.Price);
        dictionary["signature"] = Serializer.Instance.Add<string>(new Func<string, object>(Serializer.From<string>)).Serialize<string>(this.Signature);
        dictionary["receipt_data"] = Serializer.Instance.Add<string>(new Func<string, object>(Serializer.From<string>)).Serialize<string>(this.ReceiptData);
        return dictionary;
      }
    }
  }
}