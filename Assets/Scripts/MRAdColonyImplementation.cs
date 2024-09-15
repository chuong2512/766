//using AdColony;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MRAdColonyImplementation : BasicAdNetwork
{
	private sealed class _CheckTimeOutVideoAd_c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal MRAdColonyImplementation _this;

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

		public _CheckTimeOutVideoAd_c__Iterator0()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._current = new WaitForSeconds(4f);
				if (!this._disposing)
				{
					this._PC = 1;
				}
				return true;
			case 1u:
				if (!this._this.videoLoaded)
				{
					MR.Log("AdColony VideoAd Failed Timed Out");
					this._this.videoRequested = false;
					this._this.videoLoaded = false;
                        /*
					this._this.GetComponent<MRUtilities>().VideoAdLoadFailed(this._this);
					if (MRUtilities.Instance)
					{
						MRUtilities.Instance.LogEvent(MRConstants.ADCOLONY, MRConstants.REWARDEDVIDEO, MRConstants.FAILED);
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

	private sealed class _CheckTimeOutInterstitial_c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal MRAdColonyImplementation _this;

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

		public _CheckTimeOutInterstitial_c__Iterator1()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._current = new WaitForSeconds(2.5f);
				if (!this._disposing)
				{
					this._PC = 1;
				}
				return true;
			case 1u:
				if (!this._this.interstitialLoaded)
				{
					MR.Log("AdColony Interstitial Failed Timed Out");
					this._this.interstitialRequested = false;
					this._this.interstitialLoaded = false;
					//this._this.GetComponent<MRUtilities>().InterstitialLoadFailed(this._this);
                    /*
					if (MRUtilities.Instance)
					{
						MRUtilities.Instance.LogEvent(MRConstants.ADCOLONY, MRConstants.INTERSTITIAL, MRConstants.FAILED);
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

	///public AdOrientationType adsOrientation;

	public string ANDROID_APP_ID;

	public string ANDROID_INT_ZONE_ID;

	public string ANDROID_REWARDED_ZONE_ID;

	public string IOS_APP_ID;

	public string IOS_INT_ZONE_ID;

	public string IOS_REWARDED_ZONE_ID;

	public bool TEST_MODE_ENABLED;

	private bool videoRequested;

	private bool videoLoaded;

	private bool interstitialRequested;

	private bool interstitialLoaded;

	private string INT_ZONE_ID;

	private string REWARDED_ZONE_ID;

	private string APP_ID;

	private string[] zoneIds;

	//private InterstitialAd interstitialAd;

	//private InterstitialAd rewardedVideoAd;

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

	private void Start()
	{
        /*
		this.INT_ZONE_ID = this.ANDROID_INT_ZONE_ID;
		this.REWARDED_ZONE_ID = this.ANDROID_REWARDED_ZONE_ID;
		this.APP_ID = this.ANDROID_APP_ID;
		AppOptions appOptions = new AppOptions();
		appOptions.AdOrientation = this.adsOrientation;
		appOptions.TestModeEnabled = this.TEST_MODE_ENABLED;
		appOptions.GdprRequired = true;
		if (MRUtilities.Instance.USERCONSENT)
		{
			appOptions.GdprConsentString = "1";
		}
		else
		{
			appOptions.GdprConsentString = "0";
		}
		this.zoneIds = new string[]
		{
			this.INT_ZONE_ID,
			this.REWARDED_ZONE_ID
		};
		Ads.Configure(this.APP_ID, appOptions, this.zoneIds);
		Ads.OnRequestInterstitial += delegate(InterstitialAd ad_)
		{
			if (ad_.ZoneId == this.INT_ZONE_ID)
			{
				this.interstitialAd = ad_;
				this.interstitialRequested = false;
				this.interstitialLoaded = true;
				MR.Log("AdColony Interstitial Loaded");
				base.GetComponent<MRUtilities>().InterstitialLoadSuccess(this);
				if (MRUtilities.Instance)
				{
					MRUtilities.Instance.LogEvent(MRConstants.ADCOLONY, MRConstants.INTERSTITIAL, MRConstants.LOADED);
				}
			}
			else if (ad_.ZoneId == this.REWARDED_ZONE_ID)
			{
				this.rewardedVideoAd = ad_;
				this.videoRequested = false;
				this.videoLoaded = true;
				MR.Log("AdColony Video Loaded");
				base.GetComponent<MRUtilities>().VideoAdLoadSuccess(this);
				if (MRUtilities.Instance)
				{
					MRUtilities.Instance.LogEvent(MRConstants.ADCOLONY, MRConstants.REWARDEDVIDEO, MRConstants.LOADED);
				}
			}
		};
		Ads.OnRequestInterstitialFailedWithZone += delegate(string zoneId)
		{
			UnityEngine.Debug.Log("AdColony.Ads.OnRequestInterstitialFailedWithZone called, zone: " + zoneId);
			if (zoneId == this.INT_ZONE_ID)
			{
				MR.Log("AdColony Interstitial Failed");
				this.interstitialRequested = false;
				this.interstitialLoaded = false;
				base.GetComponent<MRUtilities>().InterstitialLoadFailed(this);
				if (MRUtilities.Instance)
				{
					MRUtilities.Instance.LogEvent(MRConstants.ADCOLONY, MRConstants.INTERSTITIAL, MRConstants.FAILED);
				}
			}
			else if (zoneId == this.REWARDED_ZONE_ID)
			{
				MR.Log("AdColony Video Failed");
				this.videoRequested = false;
				this.videoLoaded = false;
				base.GetComponent<MRUtilities>().VideoAdLoadFailed(this);
				if (MRUtilities.Instance)
				{
					MRUtilities.Instance.LogEvent(MRConstants.ADCOLONY, MRConstants.REWARDEDVIDEO, MRConstants.FAILED);
				}
			}
		};
		Ads.OnClosed += delegate(InterstitialAd ad_)
		{
			UnityEngine.Debug.Log("AdColony.Ads.OnClosed called, expired: " + ad_.Expired);
			if (ad_.ZoneId == this.INT_ZONE_ID)
			{
				MR.Log("AdColony Interstitial Opened");
				this.interstitialRequested = false;
				this.interstitialLoaded = false;
				base.GetComponent<MRUtilities>().InterstitialOpened();
				if (MRUtilities.Instance)
				{
					MRUtilities.Instance.LogEvent(MRConstants.ADCOLONY, MRConstants.INTERSTITIAL, MRConstants.COMPLETED);
				}
			}
		};
		Ads.OnRewardGranted += delegate(string zoneId, bool success, string name, int amount)
		{
			if (zoneId == this.REWARDED_ZONE_ID)
			{
				MR.Log("AdColony Video Completed");
				this.videoRequested = false;
				this.videoLoaded = false;
				base.GetComponent<MRUtilities>().VideoAdCompleted(this);
				if (MRUtilities.Instance)
				{
					MRUtilities.Instance.LogEvent(MRConstants.ADCOLONY, MRConstants.REWARDEDVIDEO, MRConstants.COMPLETED);
				}
			}
		};
		*/
	}

	public override void RequestVideoAd()
	{
        /*
		if (!this.videoRequested)
		{
			MR.Log("AdColony Video Requested");
			this.videoRequested = true;
			this.videoLoaded = false;
			Ads.RequestInterstitialAd(this.REWARDED_ZONE_ID, null);
			base.StartCoroutine(this.CheckTimeOutVideoAd());
			if (MRUtilities.Instance)
			{
				MRUtilities.Instance.LogEvent(MRConstants.ADCOLONY, MRConstants.REWARDEDVIDEO, MRConstants.REQUESTED);
			}
		}
		*/
	}

	private IEnumerator CheckTimeOutVideoAd()
	{
		MRAdColonyImplementation._CheckTimeOutVideoAd_c__Iterator0 _CheckTimeOutVideoAd_c__Iterator = new MRAdColonyImplementation._CheckTimeOutVideoAd_c__Iterator0();
		_CheckTimeOutVideoAd_c__Iterator._this = this;
		return _CheckTimeOutVideoAd_c__Iterator;
	}

	public override void ShowVideoAd()
	{
        /*
		if (this.rewardedVideoAd != null)
		{
			Ads.ShowAd(this.rewardedVideoAd);
			if (MRUtilities.Instance)
			{
				MRUtilities.Instance.LogEvent(MRConstants.ADCOLONY, MRConstants.REWARDEDVIDEO, MRConstants.SHOWN);
			}
		}
		*/
	}

	public override void RequestInterstitial()
	{
        /*
       if (!this.interstitialRequested)
       {
           MR.Log("AdColony Interstitial Requested");
           this.interstitialRequested = true;
           this.interstitialLoaded = false;
           Ads.RequestInterstitialAd(this.INT_ZONE_ID, null);
           base.StartCoroutine(this.CheckTimeOutInterstitial());
           if (MRUtilities.Instance)
           {
               MRUtilities.Instance.LogEvent(MRConstants.ADCOLONY, MRConstants.INTERSTITIAL, MRConstants.REQUESTED);
           }
       }
         */
    }
    /*
   private IEnumerator CheckTimeOutInterstitial()
   {
       MRAdColonyImplementation._CheckTimeOutInterstitial_c__Iterator1 _CheckTimeOutInterstitial_c__Iterator = new MRAdColonyImplementation._CheckTimeOutInterstitial_c__Iterator1();
       _CheckTimeOutInterstitial_c__Iterator._this = this;
       return _CheckTimeOutInterstitial_c__Iterator;
   }
    */
    public override void ShowInterstitialAd()
	{
        /*
       if (this.interstitialAd != null)
       {
           Ads.ShowAd(this.interstitialAd);
           if (MRUtilities.Instance)
           {
               MRUtilities.Instance.LogEvent(MRConstants.ADCOLONY, MRConstants.INTERSTITIAL, MRConstants.SHOWN);
           }
       }
        */
    }
}
