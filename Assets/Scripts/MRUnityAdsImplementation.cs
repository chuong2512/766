using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Advertisements;

public class MRUnityAdsImplementation : BasicAdNetwork
{
    /*
	private sealed class _UnityAdsCheckLoop_c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal MRUnityAdsImplementation _this;

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

		public _UnityAdsCheckLoop_c__Iterator0()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._current = new WaitForSeconds(0.1f);
				if (!this._disposing)
				{
					this._PC = 1;
				}
				return true;
			case 1u:
				if (this._this.videoRequested)
				{
					this._this.videoLoaded = Advertisement.IsReady(this._this.rewardedVideoPlacementString);
					if (this._this.videoLoaded)
					{
						this._this.videoRequested = false;
						this._this.videoLoaded = true;
						this._this.timeOut = 0f;
						if (!this._this.videoForced)
						{
							MR.Log("Unity Video Loaded");
							this._this.GetComponent<MRUtilities>().VideoAdLoadSuccess(this._this);
							if (MRUtilities.Instance)
							{
								MRUtilities.Instance.LogEvent(MRConstants.UNITY, MRConstants.REWARDEDVIDEO, MRConstants.LOADED);
							}
						}
						else
						{
							MR.Log("Unity Video Forced Show");
							ShowOptions showOptions = new ShowOptions();
							showOptions.resultCallback = new Action<ShowResult>(this._this.HandleShowResult);
							Advertisement.Show(this._this.rewardedVideoPlacementString, showOptions);
							if (MRUtilities.Instance)
							{
								MRUtilities.Instance.LogEvent(MRConstants.UNITY, MRConstants.FORCEDREWARDEDVIDEO, MRConstants.SHOWN);
							}
						}
					}
					else
					{
						this._this.timeOut += 0.1f;
						if (this._this.timeOut >= 4f)
						{
							MR.Log("Unity Video Failed Timed Out");
							this._this.videoRequested = true;
							this._this.videoLoaded = false;
							if (this._this.videoForced)
							{
								this._this.videoForced = false;
							}
							this._this.timeOut = 0f;
							this._this.GetComponent<MRUtilities>().VideoAdLoadFailed(this._this);
							if (MRUtilities.Instance)
							{
								MRUtilities.Instance.LogEvent(MRConstants.UNITY, MRConstants.REWARDEDVIDEO, MRConstants.FAILED);
							}
						}
					}
				}
				if (this._this.interstitialRequested)
				{
					this._this.interstitialLoaded = Advertisement.IsReady(this._this.videoPlacementString);
					if (this._this.interstitialLoaded)
					{
						this._this.interstitialRequested = false;
						this._this.interstitialLoaded = true;
						this._this.timeOutInterstitial = 0f;
						MR.Log("Unity Interstitial Loaded");
						this._this.GetComponent<MRUtilities>().InterstitialLoadSuccess(this._this);
						if (MRUtilities.Instance)
						{
							MRUtilities.Instance.LogEvent(MRConstants.UNITY, MRConstants.INTERSTITIAL, MRConstants.LOADED);
						}
					}
					else
					{
						this._this.timeOutInterstitial += 0.1f;
						if (this._this.timeOutInterstitial >= 4f)
						{
							MR.Log("Unity Interstitial Failed Timed Out");
							this._this.interstitialRequested = true;
							this._this.interstitialLoaded = false;
							this._this.timeOutInterstitial = 0f;
							this._this.GetComponent<MRUtilities>().InterstitialLoadFailed(this._this);
							if (MRUtilities.Instance)
							{
								MRUtilities.Instance.LogEvent(MRConstants.UNITY, MRConstants.INTERSTITIAL, MRConstants.FAILED);
							}
						}
					}
				}
				this._this.StartCoroutine(this._this.UnityAdsCheckLoop());
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
    */
	public string ANDROIDID;

	public string IOSID;

	public string rewardedVideoPlacementString = "rewardedVideo";

	public string videoPlacementString = "video";

	private bool videoRequested;

	private bool videoLoaded;

	private bool interstitialRequested;

	private bool interstitialLoaded;

	private bool videoForced;

	public bool TEST_MODE;

	private float timeOut;

	private float timeOutInterstitial;

	private void Start()
	{
        /*
		MetaData metaData = new MetaData("gdpr");
		if (MRUtilities.Instance.USERCONSENT)
		{
			metaData.Set("consent", "true");
		}
		else
		{
			metaData.Set("consent", "false");
		}
		Advertisement.SetMetaData(metaData);
		Advertisement.Initialize(this.ANDROIDID, this.TEST_MODE);
		base.StartCoroutine(this.UnityAdsCheckLoop());
		*/      
	}
    /*
	private IEnumerator UnityAdsCheckLoop()
	{
		MRUnityAdsImplementation._UnityAdsCheckLoop_c__Iterator0 _UnityAdsCheckLoop_c__Iterator = new MRUnityAdsImplementation._UnityAdsCheckLoop_c__Iterator0();
		_UnityAdsCheckLoop_c__Iterator._this = this;
		return _UnityAdsCheckLoop_c__Iterator;
	}
    */
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

	public override void RequestVideoAd()
	{
		if (!this.videoRequested)
		{
			MR.Log("UnityAds Video Requested");
			this.videoRequested = true;
			//if (MRUtilities.Instance)
			{
			//	MRUtilities.Instance.LogEvent(MRConstants.UNITY, MRConstants.REWARDEDVIDEO, MRConstants.REQUESTED);
			}
		}
	}

	public override void RequestInterstitial()
	{
		if (!this.interstitialRequested)
		{
			MR.Log("UnityAds Interstitial Requested");
			this.interstitialRequested = true;
			//if (MRUtilities.Instance)
			{
				//MRUtilities.Instance.LogEvent(MRConstants.UNITY, MRConstants.INTERSTITIAL, MRConstants.REQUESTED);
			}
		}
	}

	public override void ShowVideoAd()
	{
        /*
		MR.Log("UnityAds Video Show");
		ShowOptions showOptions = new ShowOptions();
		showOptions.resultCallback = new Action<ShowResult>(this.HandleShowResult);
		Advertisement.Show(this.rewardedVideoPlacementString, showOptions);
		if (MRUtilities.Instance)
		{
			MRUtilities.Instance.LogEvent(MRConstants.UNITY, MRConstants.REWARDEDVIDEO, MRConstants.SHOWN);
		}
		*/
	}

	public override void ShowForcedVideoAd()
	{
		if (!this.videoRequested && !this.videoLoaded)
		{
			MR.Log("UnityAds Video Forced");
			this.videoRequested = true;
			this.videoLoaded = false;
			this.videoForced = true;
			//if (MRUtilities.Instance)
			{
			//MRUtilities.Instance.LogEvent(MRConstants.UNITY, MRConstants.FORCEDREWARDEDVIDEO, MRConstants.REQUESTED);
			}
		}
	}

	public override void ShowInterstitialAd()
	{
        /*
		MR.Log("UnityAds Interstitial Show");
		Advertisement.Show(this.videoPlacementString);
		if (MRUtilities.Instance)
		{
			MRUtilities.Instance.LogEvent(MRConstants.UNITY, MRConstants.INTERSTITIAL, MRConstants.SHOWN);
		}
		this.interstitialLoaded = false;
		this.interstitialRequested = false;
		base.GetComponent<MRUtilities>().InterstitialOpened();
		if (MRUtilities.Instance)
		{
			MRUtilities.Instance.LogEvent(MRConstants.APPLOVIN, MRConstants.INTERSTITIAL, MRConstants.COMPLETED);
		}
		*/
	}
    /*
	private void HandleShowResult(ShowResult result)
	{
		if (result == ShowResult.Finished)
		{
			MR.Log("Unity Ads Video Completed");
			this.videoRequested = false;
			this.videoLoaded = false;
			if (this.videoForced)
			{
				this.videoForced = false;
			}
			base.GetComponent<MRUtilities>().VideoAdCompleted(this);
			if (MRUtilities.Instance)
			{
				MRUtilities.Instance.LogEvent(MRConstants.UNITY, MRConstants.REWARDEDVIDEO, MRConstants.COMPLETED);
			}
		}
	}
	*/
}
