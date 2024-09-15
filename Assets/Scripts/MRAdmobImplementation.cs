
using System;
using System.Collections.Generic;

public class MRAdmobImplementation : BasicAdNetwork
{
	public string appIDAndroid;

	public string bannerIDAndroid;


	public string interstitialIDAndroid;

	public string rewardedVideoIDAndroid;

	public string appIDIOS;

	public string bannerIDIOS;


	public string interstitialIDIOS;

	public string rewardedVideoIDIOS;

	private string APPID;

	private string BANNERID;


	private string INTERSTITIALID;

	private string REWARDEDVIDEOID;

	private bool interstitialRequested;

	private bool interstitialLoaded;

	private bool interstitialForced;

	private bool videoRequested;

	private bool videoLoaded;


	public List<string> TEST_DEVICE_IDS;

	private void Start()
	{
		this.APPID = this.appIDAndroid;
		this.BANNERID = this.bannerIDAndroid;
	}

	public override void RequestBanner()
	{
        /*
		if (MRGame.Instance.showAds)
		{
			bool flag = true;
			if (flag)
			{
				this.smartBanner = new BannerView(this.BANNERID, AdSize.Banner, this.BANNERPOSITION);
				this.smartBanner.LoadAd(this.CreateAdRequest());
				if (MRUtilities.Instance)
				{
					MRUtilities.Instance.LogEvent(MRConstants.ADMOB, MRConstants.BANNER, MRConstants.REQUESTED);
				}
				MR.Log("Admob Banner Requested");
			}
		}
		*/
	}

	public override void DestroyBanner()
	{

	}


	public override void RequestInterstitial()
	{
		if (!this.interstitialRequested)
		{
			
			//if (MRUtilities.Instance)
			{
				//.Instance.LogEvent(MRConstants.ADMOB, MRConstants.INTERSTITIAL, MRConstants.REQUESTED);
			}
		}
	}

	public override void RequestVideoAd()
	{
		if (!this.videoRequested)
		{
			
			//if (MRUtilities.Instance)
			{
				//MRUtilities.Instance.LogEvent(MRConstants.ADMOB, MRConstants.REWARDEDVIDEO, MRConstants.REQUESTED);
			}
		}
	}

	public override void ShowInterstitialAd()
	{
		
		//if (MRUtilities.Instance)
		{
			//MRUtilities.Instance.LogEvent(MRConstants.ADMOB, MRConstants.INTERSTITIAL, MRConstants.SHOWN);
		}
	}

	public override void ShowVideoAd()
	{
		MR.Log("Admob Video Show");
	
		//if (MRUtilities.Instance)
		{
		//MRUtilities.Instance.LogEvent(MRConstants.ADMOB, MRConstants.REWARDEDVIDEO, MRConstants.SHOWN);
		}
	}

	public override void ShowForcedInterstitial()
	{
		if (!this.interstitialRequested && !this.interstitialLoaded)
		{
		
			this.interstitialForced = true;
			//if (MRUtilities.Instance)
			{
				//MRUtilities.Instance.LogEvent(MRConstants.ADMOB, MRConstants.FORCEDINTERSTITIAL, MRConstants.REQUESTED);
			}
		}
	}

	public override bool IsInterstitialRequested()
	{
		return this.interstitialRequested;
	}

	public override bool IsInterstitialLoaded()
	{
		return this.interstitialLoaded;
	}

	public override bool IsVideoAdRequested()
	{
		return this.videoRequested;
	}

	public override bool IsVideoAdLoaded()
	{
		return this.videoLoaded;
	}

	private void OnForcedInterstitialOpened(object sender, EventArgs args)
	{
		this.interstitialRequested = false;
		this.interstitialLoaded = false;
		if (this.interstitialForced)
		{
			this.interstitialForced = false;
		}
	//	if (MRUtilities.Instance)
		{
		//base.GetComponent<MRUtilities>().InterstitialOpened();
		}
	}

	private void OnInterstitialOpened(object sender, EventArgs args)
	{
		this.interstitialRequested = false;
		this.interstitialLoaded = false;
		if (this.interstitialForced)
		{
			this.interstitialForced = false;
		}
		//base.GetComponent<MRUtilities>().InterstitialOpened();
		///if (MRUtilities.Instance)
		{
			//MRUtilities.Instance.LogEvent(MRConstants.ADMOB, MRConstants.INTERSTITIAL, MRConstants.COMPLETED);
		}
	}

	private void OnInterstitialFailedLoading(object sender, EventArgs args)
	{
		MR.Log("Admob Interstitial Failed");
		this.interstitialRequested = false;
		this.interstitialLoaded = false;
		//base.GetComponent<MRUtilities>().InterstitialLoadFailed(this);
		//if (MRUtilities.Instance)
		{
			//MRUtilities.Instance.LogEvent(MRConstants.ADMOB, MRConstants.INTERSTITIAL, MRConstants.FAILED);
		}
	}

	private void OnInterstitialLoaded(object sender, EventArgs args)
	{
		MR.Log("Admob Interstitial Loaded");
		this.interstitialRequested = false;
		this.interstitialLoaded = true;
		if (!this.interstitialForced)
		{
			//base.GetComponent<MRUtilities>().InterstitialLoadSuccess(this);
		}
		//if (MRUtilities.Instance)
		{
		//	MRUtilities.Instance.LogEvent(MRConstants.ADMOB, MRConstants.INTERSTITIAL, MRConstants.LOADED);
		}
	}

	private void OnForcedInterstitialLoaded(object sender, EventArgs args)
	{
		
	}

	private void OnRewardedVideoLoaded(object sender, EventArgs args)
	{
		MR.Log("Admob Video Loaded");
		this.videoRequested = false;
		this.videoLoaded = true;
		//base.GetComponent<MRUtilities>().VideoAdLoadSuccess(this);
		//if (MRUtilities.Instance)
		{
			//MRUtilities.Instance.LogEvent(MRConstants.ADMOB, MRConstants.REWARDEDVIDEO, MRConstants.LOADED);
		}
	}

	private void OnRewardedVideoAdFailedToLoad(object sender, EventArgs args)
	{
		MR.Log("Admob Video Failed");
		this.videoRequested = false;
		this.videoLoaded = false;
		//base.GetComponent<MRUtilities>().VideoAdLoadFailed(this);
		//if (MRUtilities.Instance)
		{
			//MRUtilities.Instance.LogEvent(MRConstants.ADMOB, MRConstants.REWARDEDVIDEO, MRConstants.FAILED);
		}
	}

	private void OnRewardedVideoAdClosed(object sender, EventArgs args)
	{
		this.videoRequested = false;
		this.videoLoaded = false;
	//base.GetComponent<MRUtilities>().VideoAdCompleted(this);
		//if (MRUtilities.Instance)
		{
			//MRUtilities.Instance.LogEvent(MRConstants.ADMOB, MRConstants.REWARDEDVIDEO, MRConstants.COMPLETED);
		}
	}

	public void ShowBanner()
	{
	
	}

	public void HideBanner()
	{
		
	}
}
