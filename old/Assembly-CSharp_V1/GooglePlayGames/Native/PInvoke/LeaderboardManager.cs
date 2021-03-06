﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.LeaderboardManager
// Assembly: Assembly-CSharp, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9BA76916-D0BD-4DB6-A90B-FE0BCC53E511
// Assembly location: C:\Users\André\Desktop\Assembly-CSharp.dll

using AOT;
using GooglePlayGames.BasicApi;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;
using System;
using UnityEngine.SocialPlatforms;

namespace GooglePlayGames.Native.PInvoke
{
  internal class LeaderboardManager
  {
    private readonly GameServices mServices;

    internal LeaderboardManager(GameServices services)
    {
      this.mServices = Misc.CheckNotNull<GameServices>(services);
    }

    internal int LeaderboardMaxResults
    {
      get
      {
        return 25;
      }
    }

    internal void SubmitScore(string leaderboardId, long score, string metadata)
    {
      Misc.CheckNotNull<string>(leaderboardId, nameof (leaderboardId));
      Logger.d("Native Submitting score: " + (object) score + " for lb " + leaderboardId + " with metadata: " + metadata);
      GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_SubmitScore(this.mServices.AsHandle(), leaderboardId, (ulong) score, metadata ?? string.Empty);
    }

    internal void ShowAllUI(Action<CommonErrorStatus.UIStatus> callback)
    {
      Misc.CheckNotNull<Action<CommonErrorStatus.UIStatus>>(callback);
      GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_ShowAllUI(this.mServices.AsHandle(), new GooglePlayGames.Native.Cwrapper.LeaderboardManager.ShowAllUICallback(Callbacks.InternalShowUICallback), Callbacks.ToIntPtr((Delegate) callback));
    }

    internal void ShowUI(string leaderboardId, GooglePlayGames.BasicApi.LeaderboardTimeSpan span, Action<CommonErrorStatus.UIStatus> callback)
    {
      Misc.CheckNotNull<Action<CommonErrorStatus.UIStatus>>(callback);
      GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_ShowUI(this.mServices.AsHandle(), leaderboardId, (Types.LeaderboardTimeSpan) span, new GooglePlayGames.Native.Cwrapper.LeaderboardManager.ShowUICallback(Callbacks.InternalShowUICallback), Callbacks.ToIntPtr((Delegate) callback));
    }

    public void LoadLeaderboardData(string leaderboardId, GooglePlayGames.BasicApi.LeaderboardStart start, int rowCount, GooglePlayGames.BasicApi.LeaderboardCollection collection, GooglePlayGames.BasicApi.LeaderboardTimeSpan timeSpan, string playerId, Action<LeaderboardScoreData> callback)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      LeaderboardManager.\u003CLoadLeaderboardData\u003Ec__AnonStorey164 dataCAnonStorey164 = new LeaderboardManager.\u003CLoadLeaderboardData\u003Ec__AnonStorey164();
      // ISSUE: reference to a compiler-generated field
      dataCAnonStorey164.playerId = playerId;
      // ISSUE: reference to a compiler-generated field
      dataCAnonStorey164.rowCount = rowCount;
      // ISSUE: reference to a compiler-generated field
      dataCAnonStorey164.callback = callback;
      // ISSUE: reference to a compiler-generated field
      dataCAnonStorey164.\u003C\u003Ef__this = this;
      NativeScorePageToken nativeScorePageToken = new NativeScorePageToken(GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_ScorePageToken(this.mServices.AsHandle(), leaderboardId, (Types.LeaderboardStart) start, (Types.LeaderboardTimeSpan) timeSpan, (Types.LeaderboardCollection) collection));
      // ISSUE: reference to a compiler-generated field
      dataCAnonStorey164.token = new ScorePageToken((object) nativeScorePageToken, leaderboardId, collection, timeSpan);
      // ISSUE: reference to a compiler-generated method
      GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_Fetch(this.mServices.AsHandle(), Types.DataSource.CACHE_OR_NETWORK, leaderboardId, new GooglePlayGames.Native.Cwrapper.LeaderboardManager.FetchCallback(LeaderboardManager.InternalFetchCallback), Callbacks.ToIntPtr<FetchResponse>(new Action<FetchResponse>(dataCAnonStorey164.\u003C\u003Em__A1), new Func<IntPtr, FetchResponse>(FetchResponse.FromPointer)));
    }

    [MonoPInvokeCallback(typeof (GooglePlayGames.Native.Cwrapper.LeaderboardManager.FetchCallback))]
    private static void InternalFetchCallback(IntPtr response, IntPtr data)
    {
      Callbacks.PerformInternalCallback("LeaderboardManager#InternalFetchCallback", Callbacks.Type.Temporary, response, data);
    }

    internal void HandleFetch(ScorePageToken token, FetchResponse response, string selfPlayerId, int maxResults, Action<LeaderboardScoreData> callback)
    {
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      LeaderboardManager.\u003CHandleFetch\u003Ec__AnonStorey165 fetchCAnonStorey165 = new LeaderboardManager.\u003CHandleFetch\u003Ec__AnonStorey165();
      // ISSUE: reference to a compiler-generated field
      fetchCAnonStorey165.selfPlayerId = selfPlayerId;
      // ISSUE: reference to a compiler-generated field
      fetchCAnonStorey165.maxResults = maxResults;
      // ISSUE: reference to a compiler-generated field
      fetchCAnonStorey165.token = token;
      // ISSUE: reference to a compiler-generated field
      fetchCAnonStorey165.callback = callback;
      // ISSUE: reference to a compiler-generated field
      fetchCAnonStorey165.\u003C\u003Ef__this = this;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      fetchCAnonStorey165.data = new LeaderboardScoreData(fetchCAnonStorey165.token.LeaderboardId, (GooglePlayGames.BasicApi.ResponseStatus) response.GetStatus());
      if (response.GetStatus() != CommonErrorStatus.ResponseStatus.VALID && response.GetStatus() != CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
      {
        Logger.w("Error returned from fetch: " + (object) response.GetStatus());
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        fetchCAnonStorey165.callback(fetchCAnonStorey165.data);
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        fetchCAnonStorey165.data.Title = response.Leaderboard().Title();
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        fetchCAnonStorey165.data.Id = fetchCAnonStorey165.token.LeaderboardId;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchScoreSummary(this.mServices.AsHandle(), Types.DataSource.CACHE_OR_NETWORK, fetchCAnonStorey165.token.LeaderboardId, (Types.LeaderboardTimeSpan) fetchCAnonStorey165.token.TimeSpan, (Types.LeaderboardCollection) fetchCAnonStorey165.token.Collection, new GooglePlayGames.Native.Cwrapper.LeaderboardManager.FetchScoreSummaryCallback(LeaderboardManager.InternalFetchSummaryCallback), Callbacks.ToIntPtr<FetchScoreSummaryResponse>(new Action<FetchScoreSummaryResponse>(fetchCAnonStorey165.\u003C\u003Em__A2), new Func<IntPtr, FetchScoreSummaryResponse>(FetchScoreSummaryResponse.FromPointer)));
      }
    }

    [MonoPInvokeCallback(typeof (GooglePlayGames.Native.Cwrapper.LeaderboardManager.FetchScoreSummaryCallback))]
    private static void InternalFetchSummaryCallback(IntPtr response, IntPtr data)
    {
      Callbacks.PerformInternalCallback("LeaderboardManager#InternalFetchSummaryCallback", Callbacks.Type.Temporary, response, data);
    }

    internal void HandleFetchScoreSummary(LeaderboardScoreData data, FetchScoreSummaryResponse response, string selfPlayerId, int maxResults, ScorePageToken token, Action<LeaderboardScoreData> callback)
    {
      if (response.GetStatus() != CommonErrorStatus.ResponseStatus.VALID && response.GetStatus() != CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
      {
        Logger.w("Error returned from fetchScoreSummary: " + (object) response);
        data.Status = (GooglePlayGames.BasicApi.ResponseStatus) response.GetStatus();
        callback(data);
      }
      else
      {
        NativeScoreSummary scoreSummary = response.GetScoreSummary();
        data.ApproximateCount = scoreSummary.ApproximateResults();
        data.PlayerScore = (IScore) scoreSummary.LocalUserScore().AsScore(data.Id, selfPlayerId);
        if (maxResults <= 0)
          callback(data);
        else
          this.LoadScorePage(data, maxResults, token, callback);
      }
    }

    public void LoadScorePage(LeaderboardScoreData data, int maxResults, ScorePageToken token, Action<LeaderboardScoreData> callback)
    {
      if (data == null)
        data = new LeaderboardScoreData(token.LeaderboardId);
      GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchScorePage(this.mServices.AsHandle(), Types.DataSource.CACHE_OR_NETWORK, ((BaseReferenceHolder) token.InternalObject).AsPointer(), (uint) maxResults, new GooglePlayGames.Native.Cwrapper.LeaderboardManager.FetchScorePageCallback(LeaderboardManager.InternalFetchScorePage), Callbacks.ToIntPtr<FetchScorePageResponse>((Action<FetchScorePageResponse>) (rsp => this.HandleFetchScorePage(data, token, rsp, callback)), new Func<IntPtr, FetchScorePageResponse>(FetchScorePageResponse.FromPointer)));
    }

    [MonoPInvokeCallback(typeof (GooglePlayGames.Native.Cwrapper.LeaderboardManager.FetchScorePageCallback))]
    private static void InternalFetchScorePage(IntPtr response, IntPtr data)
    {
      Callbacks.PerformInternalCallback("LeaderboardManager#InternalFetchScorePage", Callbacks.Type.Temporary, response, data);
    }

    internal void HandleFetchScorePage(LeaderboardScoreData data, ScorePageToken token, FetchScorePageResponse rsp, Action<LeaderboardScoreData> callback)
    {
      data.Status = (GooglePlayGames.BasicApi.ResponseStatus) rsp.GetStatus();
      if (rsp.GetStatus() != CommonErrorStatus.ResponseStatus.VALID && rsp.GetStatus() != CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
        callback(data);
      NativeScorePage scorePage = rsp.GetScorePage();
      if (!scorePage.Valid())
        callback(data);
      if (scorePage.HasNextScorePage())
        data.NextPageToken = new ScorePageToken((object) scorePage.GetNextScorePageToken(), token.LeaderboardId, token.Collection, token.TimeSpan);
      if (scorePage.HasPrevScorePage())
        data.PrevPageToken = new ScorePageToken((object) scorePage.GetPreviousScorePageToken(), token.LeaderboardId, token.Collection, token.TimeSpan);
      foreach (NativeScoreEntry nativeScoreEntry in scorePage)
        data.AddScore(nativeScoreEntry.AsScore(data.Id));
      callback(data);
    }
  }
}
