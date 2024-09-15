using System;
using UnityEngine;

public class MRGame
{
	private static MRGame instance;

	private static bool IsGameInitialized;

	public static MRGame Instance
	{
		get
		{
			if (MRGame.instance == null)
			{
				MRGame.instance = new MRGame();
				if (!MRGame.IsGameInitialized)
				{
					MRGame.InitializeGame();
				}
			}
			return MRGame.instance;
		}
	}

	public bool soundEnabled
	{
		get
		{
			if (!PlayerPrefs.HasKey("soundEnabled"))
			{
				PlayerPrefs.SetInt("soundEnabled", 1);
			}
			return PlayerPrefs.GetInt("soundEnabled") == 1;
		}
		set
		{
			if (value)
			{
				PlayerPrefs.SetInt("soundEnabled", 1);
			}
			else
			{
				PlayerPrefs.SetInt("soundEnabled", 0);
			}
		}
	}

	public bool showAds
	{
		get
		{
			if (!PlayerPrefs.HasKey("showAds"))
			{
				PlayerPrefs.SetInt("showAds", 1);
			}
			return PlayerPrefs.GetInt("showAds") == 1;
		}
		set
		{
			if (value)
			{
				PlayerPrefs.SetInt("showAds", 1);
			}
			else
			{
				PlayerPrefs.SetInt("showAds", 0);
			}
		}
	}

	public bool rateClicked
	{
		get
		{
			if (!PlayerPrefs.HasKey("rateClicked"))
			{
				PlayerPrefs.SetInt("rateClicked", 0);
			}
			return PlayerPrefs.GetInt("rateClicked") == 1;
		}
		set
		{
			if (value)
			{
				PlayerPrefs.SetInt("rateClicked", 1);
			}
			else
			{
				PlayerPrefs.SetInt("rateClicked", 0);
			}
		}
	}

	private MRGame()
	{
	}

	public static void InitializeGame()
	{
		if (MRGame.IsGameInitialized)
		{
			return;
		}
		if (!PlayerPrefs.HasKey("prefsSet"))
		{
			PlayerPrefs.SetInt("prefsSet", 1);
			MRGame.IsGameInitialized = true;
		}
	}

	public void AllAdsRemoved()
	{
		MRGame.Instance.showAds = false;
		//if (MRUtilities.Instance)
		{
			//MRUtilities.Instance.DestroyBannerAd();
		}
	}
}
