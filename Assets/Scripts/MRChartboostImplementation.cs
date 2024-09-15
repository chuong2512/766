//using ChartboostSDK;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MRChartboostImplementation : BasicAdNetwork
{
	private sealed class _CheckTimeOutInterstitial_c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal MRChartboostImplementation _this;

		internal object _current;

		internal bool _disposing;

		internal int _PC;

		object IEnumerator<object>.Current
		{
			get
			{
				return this._current;
			}
		}

		object IEnumerator.Current
		{
			get
			{
				return this._current;
			}
		}

		public _CheckTimeOutInterstitial_c__Iterator0()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._current = new WaitForSeconds(5f);
				if (!this._disposing)
				{
					this._PC = 1;
				}
				return true;
			case 1u:
				if (!this._this.interstitialLoaded)
				{
					MR.Log("Chartboost Interstitial Failed Timed Out");
					this._this.interstitialRequested = false;
					this._this.interstitialLoaded = false;
                        /*
					this._this.GetComponent<MRUtilities>().InterstitialLoadFailed(this._this);
					if (MRUtilities.Instance)
					{
						MRUtilities.Instance.LogEvent(MRConstants.CHARTBOOST, MRConstants.INTERSTITIAL, MRConstants.FAILED);
					}
					*/
				}
				this._PC = -1;
				break;
			}
			return false;
		}

		public void Dispose()
		{
			this._disposing = true;
			this._PC = -1;
		}

		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class _CheckTimeOutVideoAd_c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal MRChartboostImplementation _this;

		internal object _current;

		internal bool _disposing;

		internal int _PC;

		object IEnumerator<object>.Current
		{
			get
			{
				return this._current;
			}
		}

		object IEnumerator.Current
		{
			get
			{
				return this._current;
			}
		}

		public _CheckTimeOutVideoAd_c__Iterator1()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._current = new WaitForSeconds(5f);
				if (!this._disposing)
				{
					this._PC = 1;
				}
				return true;
			case 1u:
				if (!this._this.videoLoaded)
				{
					MR.Log("Chartboost VideoAd Failed Timed Out");
					this._this.videoRequested = false;
					this._this.videoLoaded = false;
                        /*
					this._this.GetComponent<MRUtilities>().VideoAdLoadFailed(this._this);
					if (MRUtilities.Instance)
					{
						MRUtilities.Instance.LogEvent(MRConstants.CHARTBOOST, MRConstants.REWARDEDVIDEO, MRConstants.FAILED);
					}
					*/
				}
				this._PC = -1;
				break;
			}
			return false;
		}

		public void Dispose()
		{
			this._disposing = true;
			this._PC = -1;
		}

		public void Reset()
		{
			throw new NotSupportedException();
		}
	}

	private bool interstitialRequested;

	private bool interstitialLoaded;

	private bool videoRequested;

	private bool videoLoaded;

	public override bool IsVideoAdRequested()
	{
		return this.videoRequested;
	}

	public override bool IsVideoAdLoaded()
	{
		return this.videoLoaded;
	}

	public override bool IsInterstitialRequested()
	{
		return this.interstitialRequested;
	}

	public override bool IsInterstitialLoaded()
	{
		return this.interstitialLoaded;
	}

	private void OnEnable()
	{
        /*
		Chartboost.didFailToLoadInterstitial += new Action<CBLocation, CBImpressionError>(this.Chartboost_didFailToLoadInterstitial);
		Chartboost.didDismissInterstitial += new Action<CBLocation>(this.Chartboost_didDismissInterstitial);
		Chartboost.didCloseInterstitial += new Action<CBLocation>(this.Chartboost_didCloseInterstitial);
		Chartboost.didClickInterstitial += new Action<CBLocation>(this.Chartboost_didClickInterstitial);
		Chartboost.didCacheInterstitial += new Action<CBLocation>(this.Chartboost_didCacheInterstitial);
		Chartboost.didFailToLoadRewardedVideo += new Action<CBLocation, CBImpressionError>(this.Chartboost_didFailToLoadRewardedVideo);
		Chartboost.didDismissRewardedVideo += new Action<CBLocation>(this.Chartboost_didDismissRewardedVideo);
		Chartboost.didCloseRewardedVideo += new Action<CBLocation>(this.Chartboost_didCloseRewardedVideo);
		Chartboost.didClickRewardedVideo += new Action<CBLocation>(this.Chartboost_didClickRewardedVideo);
		Chartboost.didCacheRewardedVideo += new Action<CBLocation>(this.Chartboost_didCacheRewardedVideo);
		Chartboost.didCompleteRewardedVideo += new Action<CBLocation, int>(this.Chartboost_didCompleteRewardedVideo);
		*/      
	}

	private void OnDisable()
	{
        /*
     Chartboost.didFailToLoadInterstitial -= new Action<CBLocation, CBImpressionError>(this.Chartboost_didFailToLoadInterstitial);
     Chartboost.didDismissInterstitial -= new Action<CBLocation>(this.Chartboost_didDismissInterstitial);
     Chartboost.didCloseInterstitial -= new Action<CBLocation>(this.Chartboost_didCloseInterstitial);
     Chartboost.didClickInterstitial -= new Action<CBLocation>(this.Chartboost_didClickInterstitial);
     Chartboost.didCacheInterstitial -= new Action<CBLocation>(this.Chartboost_didCacheInterstitial);
     Chartboost.didFailToLoadRewardedVideo -= new Action<CBLocation, CBImpressionError>(this.Chartboost_didFailToLoadRewardedVideo);
     Chartboost.didDismissRewardedVideo -= new Action<CBLocation>(this.Chartboost_didDismissRewardedVideo);
     Chartboost.didCloseRewardedVideo -= new Action<CBLocation>(this.Chartboost_didCloseRewardedVideo);
     Chartboost.didClickRewardedVideo -= new Action<CBLocation>(this.Chartboost_didClickRewardedVideo);
     Chartboost.didCacheRewardedVideo -= new Action<CBLocation>(this.Chartboost_didCacheRewardedVideo);
     Chartboost.didCompleteRewardedVideo -= new Action<CBLocation, int>(this.Chartboost_didCompleteRewardedVideo);
       */
    }
    /*
private void Chartboost_didCompleteRewardedVideo(CBLocation arg1, int arg2)
{
    MR.Log("Chartboost Video Completed");
    this.videoRequested = false;
    this.videoLoaded = false;
    base.GetComponent<MRUtilities>().VideoAdCompleted(this);
    if (MRUtilities.Instance)
    {
        MRUtilities.Instance.LogEvent(MRConstants.CHARTBOOST, MRConstants.REWARDEDVIDEO, MRConstants.COMPLETED);
    }
}
 */
    /*
      private void Chartboost_didCacheRewardedVideo(CBLocation obj)
      {
          MR.Log("Chartboost Video Loaded");
          this.videoRequested = false;
          this.videoLoaded = true;
          base.GetComponent<MRUtilities>().VideoAdLoadSuccess(this);
          if (MRUtilities.Instance)
          {
              MRUtilities.Instance.LogEvent(MRConstants.CHARTBOOST, MRConstants.REWARDEDVIDEO, MRConstants.LOADED);
          }
      }
       */
    /*
private void Chartboost_didClickRewardedVideo(CBLocation obj)
  {
  }

  private void Chartboost_didCloseRewardedVideo(CBLocation obj)
  {
  }

  private void Chartboost_didDismissRewardedVideo(CBLocation obj)
  {
  }

  private void Chartboost_didFailToLoadRewardedVideo(CBLocation arg1, CBImpressionError arg2)
  {
      MR.Log("Chartboost Video Failed");
      this.videoRequested = false;
      this.videoLoaded = false;
      base.GetComponent<MRUtilities>().VideoAdLoadFailed(this);
      if (MRUtilities.Instance)
      {
          MRUtilities.Instance.LogEvent(MRConstants.CHARTBOOST, MRConstants.REWARDEDVIDEO, MRConstants.FAILED);
      }
  }

  private void Chartboost_didCacheInterstitial(CBLocation obj)
  {
      MR.Log("Chartboost Inter Loaded");
      this.interstitialRequested = false;
      this.interstitialLoaded = true;
      base.GetComponent<MRUtilities>().InterstitialLoadSuccess(this);
      if (MRUtilities.Instance)
      {
          MRUtilities.Instance.LogEvent(MRConstants.CHARTBOOST, MRConstants.INTERSTITIAL, MRConstants.LOADED);
      }
  }

  private void Chartboost_didClickInterstitial(CBLocation obj)
  {
  }

  private void Chartboost_didCloseInterstitial(CBLocation obj)
  {
      this.interstitialRequested = false;
      this.interstitialLoaded = false;
      base.GetComponent<MRUtilities>().InterstitialOpened();
      if (MRUtilities.Instance)
      {
          MRUtilities.Instance.LogEvent(MRConstants.CHARTBOOST, MRConstants.INTERSTITIAL, MRConstants.COMPLETED);
      }
  }

  private void Chartboost_didDismissInterstitial(CBLocation obj)
  {
  }

  private void Chartboost_didFailToLoadInterstitial(CBLocation arg1, CBImpressionError arg2)
  {
      MR.Log("Chartboost Interstitial Failed");
      this.interstitialRequested = false;
      this.interstitialLoaded = false;
      base.GetComponent<MRUtilities>().InterstitialLoadFailed(this);
      if (MRUtilities.Instance)
      {
          MRUtilities.Instance.LogEvent(MRConstants.CHARTBOOST, MRConstants.INTERSTITIAL, MRConstants.FAILED);
      }
  }
   */
  private IEnumerator CheckTimeOutInterstitial()
  {
      MRChartboostImplementation._CheckTimeOutInterstitial_c__Iterator0 _CheckTimeOutInterstitial_c__Iterator = new MRChartboostImplementation._CheckTimeOutInterstitial_c__Iterator0();
      _CheckTimeOutInterstitial_c__Iterator._this = this;
      return _CheckTimeOutInterstitial_c__Iterator;
  }

  public override void RequestInterstitial()
  {
        /*
      if (MRUtilities.Instance.USERCONSENT)
      {
          Chartboost.restrictDataCollection(false);
      }
      else
      {
          Chartboost.restrictDataCollection(true);
      }
      if (!this.interstitialRequested)
      {
          MR.Log("Chartboost Interstitital Requested");
          Chartboost.cacheInterstitial(CBLocation.Default);
          base.StartCoroutine(this.CheckTimeOutInterstitial());
          this.interstitialRequested = true;
          this.interstitialLoaded = false;
          if (MRUtilities.Instance)
          {
              MRUtilities.Instance.LogEvent(MRConstants.CHARTBOOST, MRConstants.INTERSTITIAL, MRConstants.REQUESTED);
          }
      }
      */
  }

  private IEnumerator CheckTimeOutVideoAd()
  {
      MRChartboostImplementation._CheckTimeOutVideoAd_c__Iterator1 _CheckTimeOutVideoAd_c__Iterator = new MRChartboostImplementation._CheckTimeOutVideoAd_c__Iterator1();
      _CheckTimeOutVideoAd_c__Iterator._this = this;
      return _CheckTimeOutVideoAd_c__Iterator;
  }

  public override void RequestVideoAd()
  {
        /*
      if (MRUtilities.Instance.USERCONSENT)
      {
          Chartboost.restrictDataCollection(false);
      }
      else
      {
          Chartboost.restrictDataCollection(true);
      }
      if (!this.videoRequested)
      {
          MR.Log("Chartboost Video Requested");
          this.videoRequested = true;
          this.videoLoaded = false;
          Chartboost.cacheRewardedVideo(CBLocation.Default);
          base.StartCoroutine(this.CheckTimeOutVideoAd());
          if (MRUtilities.Instance)
          {
              MRUtilities.Instance.LogEvent(MRConstants.CHARTBOOST, MRConstants.REWARDEDVIDEO, MRConstants.REQUESTED);
          }
      }
      */
  }

  public override void ShowInterstitialAd()
  {
        /*
     Chartboost.showInterstitial(CBLocation.Default);
     if (MRUtilities.Instance)
     {
         MRUtilities.Instance.LogEvent(MRConstants.CHARTBOOST, MRConstants.INTERSTITIAL, MRConstants.SHOWN);
     }
      */
    }

public override void ShowVideoAd()
  {
        /*
  Chartboost.showRewardedVideo(CBLocation.Default);
  if (MRUtilities.Instance)
  {
      MRUtilities.Instance.LogEvent(MRConstants.CHARTBOOST, MRConstants.REWARDEDVIDEO, MRConstants.SHOWN);
  }
     */
    }
}
