using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MRAppLovinImplementation : BasicAdNetwork
{
	public enum BannerPosition
	{
		TOP,
		BOTTOM
	}

	private sealed class _CheckTimeOutInterstitial_c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal MRAppLovinImplementation _this;

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
                        /*
					MR.Log("AppLovin Interstitial Failed Timed Out");
					this._this.interstitialRequested = false;
					this._this.interstitialLoaded = false;
					this._this.GetComponent<MRUtilities>().InterstitialLoadFailed(this._this);
					if (MRUtilities.Instance)
					{
						MRUtilities.Instance.LogEvent(MRConstants.APPLOVIN, MRConstants.INTERSTITIAL, MRConstants.FAILED);
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

	public string SDKKEY;

	public MRAppLovinImplementation.BannerPosition bannerAdPosition;

	private bool currentIsRewardedVideo;

	public override bool IsVideoAdRequested()
	{
		return this.interstitialRequested;
	}

	public override bool IsVideoAdLoaded()
	{
		return this.interstitialLoaded;
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
		if (MRUtilities.Instance.USERCONSENT)
		{
			AppLovin.SetHasUserConsent("true");
		}
		else
		{
			AppLovin.SetHasUserConsent("false");
		}
		AppLovin.SetSdkKey(this.SDKKEY);
		AppLovin.InitializeSdk();
		AppLovin.SetUnityAdListener("MRUtilities");
		*/      
	}

	public override void RequestBanner()
	{
		if (MRGame.Instance.showAds)
		{
			bool flag = true;
			if (flag)
			{
				if (this.bannerAdPosition == MRAppLovinImplementation.BannerPosition.TOP)
				{
					//AppLovin.ShowAd(-10000f, -40000f);
				}
				else
				{
					//AppLovin.ShowAd(-10000f, -50000f);
				}
				//if (MRUtilities.Instance)
				{
					//MRUtilities.Instance.LogEvent(MRConstants.APPLOVIN, MRConstants.BANNER, MRConstants.REQUESTED);
				}
				MR.Log("Applovin Banner Requested");
			}
		}
	}

	public override void DestroyBanner()
	{
	//AppLovin.HideAd();
	}

	public override void RequestInterstitial()
	{
		if (!this.interstitialRequested)
		{
			MR.Log("AppLovin Interstitial Requested");
		//AppLovin.PreloadInterstitial(null);
			this.interstitialRequested = true;
			this.interstitialLoaded = false;
			base.StartCoroutine(this.CheckTimeOutInterstitial());
			//MRUtilities.Instance.LogEvent(MRConstants.APPLOVIN, MRConstants.INTERSTITIAL, MRConstants.REQUESTED);
		}
	}

	private IEnumerator CheckTimeOutInterstitial()
	{
		MRAppLovinImplementation._CheckTimeOutInterstitial_c__Iterator0 _CheckTimeOutInterstitial_c__Iterator = new MRAppLovinImplementation._CheckTimeOutInterstitial_c__Iterator0();
		_CheckTimeOutInterstitial_c__Iterator._this = this;
		return _CheckTimeOutInterstitial_c__Iterator;
	}

	public override void RequestVideoAd()
	{
		if (!this.interstitialRequested)
		{
			MR.Log("AppLovin Interstitial Requested");
			//AppLovin.PreloadInterstitial(null);
			this.interstitialRequested = true;
			this.interstitialLoaded = false;
			base.StartCoroutine(this.CheckTimeOutInterstitial());
			//MRUtilities.Instance.LogEvent(MRConstants.APPLOVIN, MRConstants.REWARDEDVIDEO, MRConstants.REQUESTED);
		}
	}

	public override void ShowInterstitialAd()
	{
		//AppLovin.ShowInterstitial();
		this.currentIsRewardedVideo = false;
		//if (MRUtilities.Instance)
		{
		//MRUtilities.Instance.LogEvent(MRConstants.APPLOVIN, MRConstants.INTERSTITIAL, MRConstants.SHOWN);
		}
	}

	public override void ShowVideoAd()
	{
		//AppLovin.ShowInterstitial();
		this.currentIsRewardedVideo = true;
	//if (MRUtilities.Instance)
		{
		//MRUtilities.Instance.LogEvent(MRConstants.APPLOVIN, MRConstants.REWARDEDVIDEO, MRConstants.SHOWN);
		}
	}

	private void onAppLovinEventReceived(string ev)
	{
        /*
		if (ev.Contains("DISPLAYEDINTER"))
		{
			this.interstitialRequested = false;
			this.interstitialLoaded = false;
			if (this.currentIsRewardedVideo)
			{
				base.GetComponent<MRUtilities>().VideoAdCompleted(this);
				if (MRUtilities.Instance)
				{
					MRUtilities.Instance.LogEvent(MRConstants.APPLOVIN, MRConstants.REWARDEDVIDEO, MRConstants.COMPLETED);
				}
			}
			else
			{
				base.GetComponent<MRUtilities>().InterstitialOpened();
				if (MRUtilities.Instance)
				{
					MRUtilities.Instance.LogEvent(MRConstants.APPLOVIN, MRConstants.INTERSTITIAL, MRConstants.COMPLETED);
				}
			}
		}
		else if (ev.Contains("LOADEDINTER"))
		{
			MR.Log("AppLovin Loaded");
			this.interstitialRequested = false;
			this.interstitialLoaded = true;
			base.GetComponent<MRUtilities>().InterstitialLoadSuccess(this);
			base.GetComponent<MRUtilities>().VideoAdLoadSuccess(this);
			if (MRUtilities.Instance)
			{
				MRUtilities.Instance.LogEvent(MRConstants.APPLOVIN, MRConstants.INTERSTITIAL, MRConstants.LOADED);
			}
		}
		else if (string.Equals(ev, "LOADINTERFAILED"))
		{
			MR.Log("AppLovin Failed");
			this.interstitialRequested = false;
			this.interstitialLoaded = false;
			base.GetComponent<MRUtilities>().InterstitialLoadFailed(this);
			base.GetComponent<MRUtilities>().VideoAdLoadFailed(this);
			if (MRUtilities.Instance)
			{
				MRUtilities.Instance.LogEvent(MRConstants.APPLOVIN, MRConstants.REWARDEDVIDEO, MRConstants.FAILED);
			}
		}
		*/
	}
}
