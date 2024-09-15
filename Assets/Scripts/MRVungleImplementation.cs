using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MRVungleImplementation : BasicAdNetwork
{
	private sealed class _CheckTimeOutVideoAd_c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal MRVungleImplementation _this;

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
					MR.Log("Vungle VideoAd Failed Timed Out");
					this._this.videoRequested = false;
					this._this.videoLoaded = false;
                        /*
					this._this.GetComponent<MRUtilities>().VideoAdLoadFailed(this._this);
					if (MRUtilities.Instance)
					{
						MRUtilities.Instance.LogEvent(MRConstants.VUNGLE, MRConstants.REWARDEDVIDEO, MRConstants.FAILED);
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
		internal MRVungleImplementation _this;

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
					MR.Log("Vungle Interstitial Failed Timed Out");
					this._this.interstitialRequested = false;
					this._this.interstitialLoaded = false;
                        /*
					this._this.GetComponent<MRUtilities>().InterstitialLoadFailed(this._this);
					if (MRUtilities.Instance)
					{
						MRUtilities.Instance.LogEvent(MRConstants.VUNGLE, MRConstants.INTERSTITIAL, MRConstants.FAILED);
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

	public string ANDROID_APP_ID;

	public string ANDROID_INT_PLCMT_ID;

	public string ANDROID_REWARDED_PLCMT_ID;

	public string IOS_APP_ID;

	public string IOS_INT_PLCMT_ID;

	public string IOS_REWARDED_PLCMT_ID;

	private bool videoRequested;

	private bool videoLoaded;

	private bool videoForced;

	private bool interstitialRequested;

	private bool interstitialLoaded;

	private string INT_PLCMT_ID;

	private string REWARDED_PLCMT_ID;

	private string APP_ID;

	private Dictionary<string, bool> placements;

	private string[] array;

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
		this.INT_PLCMT_ID = this.ANDROID_INT_PLCMT_ID;
		this.REWARDED_PLCMT_ID = this.ANDROID_REWARDED_PLCMT_ID;
		this.APP_ID = this.ANDROID_APP_ID;
		this.placements = new Dictionary<string, bool>
		{
			{
				this.INT_PLCMT_ID,
				false
			},
			{
				this.REWARDED_PLCMT_ID,
				false
			}
		};
		this.array = new string[this.placements.Keys.Count];
		this.placements.Keys.CopyTo(this.array, 0);
        /*
		Vungle.init(this.APP_ID, this.array);
		if (MRUtilities.Instance.USERCONSENT)
		{
			Vungle.updateConsentStatus(Vungle.Consent.Accepted);
		}
		else
		{
			Vungle.updateConsentStatus(Vungle.Consent.Denied);
		}
		*/
	}

	private void OnEnable()
	{
	//Vungle.adPlayableEvent += new Action<string, bool>(this.Vungle_adPlayableEvent);
	//	Vungle.onAdFinishedEvent += new Action<string, AdFinishedEventArgs>(this.Vungle_onAdFinishedEvent);
	}

	private void OnDisable()
	{
	//	Vungle.adPlayableEvent -= new Action<string, bool>(this.Vungle_adPlayableEvent);
	//	Vungle.onAdFinishedEvent -= new Action<string, AdFinishedEventArgs>(this.Vungle_onAdFinishedEvent);
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus)
		{
			//Vungle.onPause();
		}
		else
		{
			//Vungle.onResume();
		}
	}
    /*
	private void Vungle_onAdFinishedEvent(string placementID, AdFinishedEventArgs adFinished)
	{
		if (adFinished.IsCompletedView)
		{
			if (placementID == this.INT_PLCMT_ID)
			{
				MR.Log("Vungle Interstitial Completed");
				base.GetComponent<MRUtilities>().InterstitialOpened();
				if (MRUtilities.Instance)
				{
					MRUtilities.Instance.LogEvent(MRConstants.VUNGLE, MRConstants.INTERSTITIAL, MRConstants.COMPLETED);
				}
			}
			else if (placementID == this.REWARDED_PLCMT_ID)
			{
				MR.Log("Vungle Video Completed");
				this.videoRequested = false;
				this.videoLoaded = false;
				if (this.videoForced)
				{
					this.videoForced = false;
				}
				base.GetComponent<MRUtilities>().VideoAdCompleted(this);
				if (MRUtilities.Instance)
				{
					MRUtilities.Instance.LogEvent(MRConstants.VUNGLE, MRConstants.REWARDEDVIDEO, MRConstants.COMPLETED);
				}
			}
		}
	}
    */
	private void Vungle_adPlayableEvent(string placementID, bool isReady)
	{
		if (isReady)
		{
			if (placementID == this.INT_PLCMT_ID)
			{
				this.interstitialRequested = false;
				this.interstitialLoaded = true;
				MR.Log("Vungle Interstitial Loaded");
                /*
				base.GetComponent<MRUtilities>().InterstitialLoadSuccess(this);
				if (MRUtilities.Instance)
				{
					MRUtilities.Instance.LogEvent(MRConstants.VUNGLE, MRConstants.INTERSTITIAL, MRConstants.LOADED);
				}
				*/
			}
			else if (placementID == this.REWARDED_PLCMT_ID)
			{
				this.videoRequested = false;
				this.videoLoaded = true;
				if (!this.videoForced)
				{
					MR.Log("Vungle Video Loaded");
                    /*
					base.GetComponent<MRUtilities>().VideoAdLoadSuccess(this);
					if (MRUtilities.Instance)
					{
						MRUtilities.Instance.LogEvent(MRConstants.VUNGLE, MRConstants.REWARDEDVIDEO, MRConstants.LOADED);
					}
					*/
				}
				else
				{
					MR.Log("Vungle Forced Video Played");
                    /*
				    Vungle.playAd(this.REWARDED_PLCMT_ID);
					if (MRUtilities.Instance)
					{
						MRUtilities.Instance.LogEvent(MRConstants.VUNGLE, MRConstants.FORCEDREWARDEDVIDEO, MRConstants.SHOWN);
					}
					*/
				}
			}
		}
		else if (placementID == this.INT_PLCMT_ID)
		{
			MR.Log("Vungle Interstitial Failed");
			this.interstitialRequested = false;
			this.interstitialLoaded = false;
            /*
			base.GetComponent<MRUtilities>().InterstitialLoadFailed(this);
			if (MRUtilities.Instance)
			{
				MRUtilities.Instance.LogEvent(MRConstants.VUNGLE, MRConstants.INTERSTITIAL, MRConstants.FAILED);
			}
			*/
		}
		else if (placementID == this.REWARDED_PLCMT_ID)
		{
			MR.Log("Vungle Video Failed");
			this.videoRequested = false;
			this.videoLoaded = false;
			//base.GetComponent<MRUtilities>().VideoAdLoadFailed(this);
			if (this.videoForced)
			{
				this.videoForced = false;
			}
            /*
			if (MRUtilities.Instance)
			{
				MRUtilities.Instance.LogEvent(MRConstants.VUNGLE, MRConstants.REWARDEDVIDEO, MRConstants.FAILED);
			}
			*/
		}
	}

	public override void RequestVideoAd()
	{
		if (!this.videoRequested)
		{
			MR.Log("Vungle Video Requested");
			this.videoRequested = true;
			this.videoLoaded = false;
			//Vungle.loadAd(this.REWARDED_PLCMT_ID);
			base.StartCoroutine(this.CheckTimeOutVideoAd());
            /*
			if (MRUtilities.Instance)
			{
				MRUtilities.Instance.LogEvent(MRConstants.VUNGLE, MRConstants.REWARDEDVIDEO, MRConstants.REQUESTED);
			}
			*/
		}
	}

	public override void ShowForcedVideoAd()
	{
		if (!this.videoRequested && !this.videoLoaded)
		{
			MR.Log("Vungle Video Forced");
		//Vungle.init(this.APP_ID, this.array);
			this.videoRequested = true;
			this.videoLoaded = false;
			this.videoForced = true;
            /*
			if (MRUtilities.Instance)
			{
				MRUtilities.Instance.LogEvent(MRConstants.VUNGLE, MRConstants.FORCEDREWARDEDVIDEO, MRConstants.REQUESTED);
			}
			*/
		}
	}

	private IEnumerator CheckTimeOutVideoAd()
	{
		MRVungleImplementation._CheckTimeOutVideoAd_c__Iterator0 _CheckTimeOutVideoAd_c__Iterator = new MRVungleImplementation._CheckTimeOutVideoAd_c__Iterator0();
		_CheckTimeOutVideoAd_c__Iterator._this = this;
		return _CheckTimeOutVideoAd_c__Iterator;
	}

	public override void ShowVideoAd()
	{
		//Vungle.playAd(this.REWARDED_PLCMT_ID);
        /*
		if (MRUtilities.Instance)
		{
			MRUtilities.Instance.LogEvent(MRConstants.VUNGLE, MRConstants.REWARDEDVIDEO, MRConstants.SHOWN);
		}
		*/
	}

	public override void RequestInterstitial()
	{
		if (!this.interstitialRequested)
		{
			MR.Log("Vungle Interstitial Requested");
			this.interstitialRequested = true;
			this.interstitialLoaded = false;
			//Vungle.loadAd(this.INT_PLCMT_ID);
			base.StartCoroutine(this.CheckTimeOutInterstitial());
            /*
			if (MRUtilities.Instance)
			{
				MRUtilities.Instance.LogEvent(MRConstants.VUNGLE, MRConstants.INTERSTITIAL, MRConstants.REQUESTED);
			}
			*/
		}
	}

	private IEnumerator CheckTimeOutInterstitial()
	{
		MRVungleImplementation._CheckTimeOutInterstitial_c__Iterator1 _CheckTimeOutInterstitial_c__Iterator = new MRVungleImplementation._CheckTimeOutInterstitial_c__Iterator1();
		_CheckTimeOutInterstitial_c__Iterator._this = this;
		return _CheckTimeOutInterstitial_c__Iterator;
	}

	public override void ShowInterstitialAd()
	{
		//Vungle.playAd(this.INT_PLCMT_ID);
        /*
		if (MRUtilities.Instance)
		{
			MRUtilities.Instance.LogEvent(MRConstants.VUNGLE, MRConstants.INTERSTITIAL, MRConstants.SHOWN);
		}
		*/
	}
}
