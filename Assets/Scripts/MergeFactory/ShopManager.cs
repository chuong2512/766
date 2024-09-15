using Mindravel.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace MergeFactory
{
	public class ShopManager : MonoBehaviour
	{
		public static ShopManager instance;

		public GameObject removeAdsButton;

		public GameObject shopButton;

		public GameObject starterPackButton;

		public GameObject doubleCoinButton;

		public GameObject landFillButton;

		[Header("Shop Items")]
		public GameObject removeAds;

		public GameObject moreCoins;
		

		public GameObject autoFill300;

		public GameObject autoFill1000;

		[Header("Shop Item Disc")]
		public Text betterCrate_Disc;

		public Text betterCrate_Price;

		public Text coin_Disc;

		public Text megaCoin_Disc;

		[Header("StarterPack Disc")]
		public Text boxLevel_SP;

		public Text bonusCoin_SP;

		public Text bonusCoin_MP;

		public Image crateImage;

		public Sprite[] crateSprites;

		[Header("IAP banners")]
		public GameObject fasterCrate_Banner;

		public GameObject moreMystry_Banner;

		private float instantCoinsToBuy;

		private float megaCoinsToBuy;

		private bool FIRSTADIMPRESSIONSHOWN
		{
			get
			{
				return PlayerPrefs.HasKey("firstAdImprssionsShown");
			}
			set
			{
				if (value)
				{
					PlayerPrefs.SetInt("firstAdImprssionsShown", 1);
				}
				else
				{
					PlayerPrefs.DeleteKey("firstAdImprssionsShown");
				}
			}
		}

		public bool firstTime_StarterPackSHOWN
		{
			get
			{
				return PlayerPrefs.HasKey("firstTime_StarterPackSHOWN");
			}
			set
			{
				if (value)
				{
					PlayerPrefs.SetInt("firstTime_StarterPackSHOWN", 1);
				}
				else
				{
					PlayerPrefs.DeleteKey("firstTime_StarterPackSHOWN");
				}
			}
		}

		private void Awake()
		{
			ShopManager.instance = this;
		}

		private void Start()
		{
			this.UpdateShop();
		}

		public void ShowInterstitialAd()
		{
			if (!this.FIRSTADIMPRESSIONSHOWN)
			{
				this.FIRSTADIMPRESSIONSHOWN = true;
			}
			else
			{
                //MRUtilities.Instance.ShowInterstitialAd(true);
                AdsControl.Instance.showAds();
			}
			this.UpdateShop();
		}

		public void UpdateStarterPackUI()
		{
			if (((LevelManager.instance.currentLevel.levelNo == 5 && DataProvider.instance.gameData.playerLevelValue > LevelManager.instance.currentLevel.MaxRange / 2) || LevelManager.instance.currentLevel.levelNo > 5) && !StarterPackManager.instance.StarterPackBought)
			{
				if (DataProvider.instance.gameData.currentBoxLevel < 2)
				{
					this.boxLevel_SP.text = string.Concat(new object[]
					{
						"Level ",
						DataProvider.instance.gameData.currentBoxLevel + 1,
						" --> ",
						DataProvider.instance.gameData.currentBoxLevel + 3
					});
				}
				else
				{
					this.boxLevel_SP.text = "Level " + (DataProvider.instance.gameData.currentBoxLevel + 1) + " --> 5";
				}
				this.bonusCoin_SP.text = (DataProvider.instance.gameData.playerCoins * 3f).ToShortHandString();
				this.bonusCoin_MP.text = (DataProvider.instance.gameData.playerCoins * 6f).ToShortHandString();
				if (this.firstTime_StarterPackSHOWN)
				{
					this.starterPackButton.SetActive(true);
				}
				else
				{
					this.firstTime_StarterPackSHOWN = true;
					StarterPackManager.instance.SaveStarterPackEndTime();
				}
				StarterPackManager.instance.UpdateStarterPack();
			}
			else
			{
				this.starterPackButton.SetActive(false);
			}
		}

		public void UpdateShop()
		{
			UnityEngine.Debug.Log(LevelManager.instance.currentLevelIndex);
			if (LevelManager.instance.currentLevelIndex >= 9)
			{
				this.autoFill300.SetActive(true);
				this.autoFill1000.SetActive(true);
			}
			else
			{
				this.autoFill300.SetActive(true);
				this.autoFill1000.SetActive(true);
			}
			if (!this.FIRSTADIMPRESSIONSHOWN)
			{
				this.removeAdsButton.SetActive(false);
			}
			else if (LevelManager.instance.currentLevel.levelNo < 5 && DataProvider.instance.gameData.removeAds == 0)
			{
				this.removeAdsButton.SetActive(true);
			}
			else
			{
				this.removeAdsButton.SetActive(false);
			}
			if (LevelManager.instance.currentLevel.levelNo > 9)
			{
				this.landFillButton.SetActive(true);
			}
			else
			{
				this.landFillButton.SetActive(false);
			}
			this.UpdateStarterPackUI();
			if (TutorialManager.instance.TUTCompleted)
			{
				this.doubleCoinButton.SetActive(true);
			}
			else
			{
				this.doubleCoinButton.SetActive(false);
			}
			if (LevelManager.instance.currentLevel.levelNo >= 5)
			{
				this.shopButton.SetActive(true);
			}
			else
			{
				this.shopButton.SetActive(false);
			}
			if (DataProvider.instance.gameData.currentBoxLevel < 4)
			{
				this.crateImage.sprite = this.crateSprites[DataProvider.instance.gameData.currentBoxLevel + 1];
				if (DataProvider.instance.gameData.currentBoxLevel == 0)
				{
					this.betterCrate_Price.text = "$ 0.99";
				}
				else if (DataProvider.instance.gameData.currentBoxLevel == 1)
				{
					this.betterCrate_Price.text = "$ 1.99";
				}
				else if (DataProvider.instance.gameData.currentBoxLevel == 2)
				{
					this.betterCrate_Price.text = "$ 2.99";
				}
				else if (DataProvider.instance.gameData.currentBoxLevel == 3)
				{
					this.betterCrate_Price.text = "$ 3.99";
				}
				this.betterCrate_Disc.text = string.Concat(new object[]
				{
					"Level ",
					DataProvider.instance.gameData.currentBoxLevel + 1,
					" --> ",
					DataProvider.instance.gameData.currentBoxLevel + 2
				});
			}
			
			this.removeAds.SetActive(false);
		
			this.instantCoinsToBuy = UnitManager.instance.units[UnitManager.instance.MaxItemID].price * 15f;
			this.coin_Disc.text = this.instantCoinsToBuy.ToShortHandString();
			this.megaCoinsToBuy = UnitManager.instance.units[UnitManager.instance.MaxItemID].price * 150f;
			this.megaCoin_Disc.text = this.megaCoinsToBuy.ToShortHandString();
		}

		public void BuyStarterPack()
		{
			MRInAppPurchaseManager.Instance.Purchase("com.threelanestudios.mergegarden.starterpack");
		}

		public void BuyMegaPack()
		{
			MRInAppPurchaseManager.Instance.Purchase("com.threelanestudios.mergegarden.megapack");
		}

		public void StarterPackPurchasedSuccessfully()
		{
			if (GUIManager.Instance.CURRENTSCREENNAME == ScreenName.StarterPack)
			{
				GUIManager.Instance.Back();
			}
			DataProvider.instance.gameData.playerCoins = DataProvider.instance.gameData.playerCoins * 3f;
			if (DataProvider.instance.gameData.currentBoxLevel < 3)
			{
				DataProvider.instance.gameData.currentBoxLevel += 2;
			}
			else
			{
				DataProvider.instance.gameData.currentBoxLevel = 4;
			}
			BoxManager.instance.UpdateBoxSprite();
			this.RemoveAdsWorker();
			StarterPackManager.instance.StarterPackBought = true;
			this.UpdateShop();
			GridManager.instance.ReplaceUpdatedItems();
		}

		public void MegaPackPurchasedSuccessfully()
		{
			if (GUIManager.Instance.CURRENTSCREENNAME == ScreenName.StarterPack)
			{
				GUIManager.Instance.Back();
			}
			DataProvider.instance.gameData.playerCoins = DataProvider.instance.gameData.playerCoins * 6f;
			DataProvider.instance.gameData.currentBoxLevel = 4;
			BoxManager.instance.UpdateBoxSprite();
			this.RemoveAdsWorker();
			this.MoreMysteryPurchasedSuccessfully();
			this.FasterCratesPurchasedSuccessfully();
			StarterPackManager.instance.StarterPackBought = true;
			this.UpdateShop();
			GridManager.instance.ReplaceUpdatedItems();
		}

		public void BuyLandFill(int id)
		{
			MRInAppPurchaseManager.Instance.Purchase("com.threelanestudios.mergegarden.landfill" + id);
		}

		public void BuyCoins()
		{
			MRInAppPurchaseManager.Instance.Purchase("com.threelanestudios.mergegarden.instantcoins");
		}

		public void CoinsPurchasedSuccessfully()
		{
			this.RemoveAdsWorker();
			DataProvider.instance.gameData.playerCoins += this.instantCoinsToBuy;
		}

		public void BuyMegaCoins()
		{
			MRInAppPurchaseManager.Instance.Purchase("com.threelanestudios.mergegarden.megacash");
		}

		public void MegaCoinsPurchasedSuccessfully()
		{
			this.RemoveAdsWorker();
			this.megaCoinsToBuy = UnitManager.instance.units[UnitManager.instance.MaxItemID].price * 150f;
			DataProvider.instance.gameData.playerCoins += this.megaCoinsToBuy;
		}

		public void Button_MoreMystry()
		{
			MRInAppPurchaseManager.Instance.Purchase("com.threelanestudios.mergegarden.moremystery");
		}

		public void MoreMysteryPurchasedSuccessfully()
		{
			this.RemoveAdsWorker();
			DataProvider.instance.gameData.giftProbMultiplier = 2;
			this.UpdateShop();
		}

		public void Button_MoreCoins()
		{
			this.RemoveAdsWorker();
			DataProvider.instance.gameData.playerCoinsMultiplier = 2;
			this.UpdateShop();
		}

		private void RemoveAdsWorker()
		{
            PlayerPrefs.SetInt("RemoveAds", 1);
            AdsControl.Instance.HideBanner();
            DataProvider.instance.gameData.removeAds = 1;
			MRGame.Instance.AllAdsRemoved();
			this.UpdateShop();
		}

		public void Button_RemoveAds()
		{
			GUIManager.Instance.OpenScreenExplicitly(ScreenName.MessagePanel);
			GUIManager.Instance.CURRENTPANEL.GetComponent<MessagePanel>().ShowMessage("REMOVE ADS", "REMOVE ADDS PERMANENTLY ?", "REMOVE", delegate
			{
				GUIManager.Instance.Back();
				this.Button_RemoveAdsClicked();
			}, null, false);
		}

		public void Button_RemoveAdsClicked()
		{
			MRInAppPurchaseManager.Instance.Purchase("com.threelanestudios.mergegarden.removeads");
		}

		public void RemoveAdsPurchasedSuccessfully()
		{
			this.RemoveAdsWorker();
		}

		public void Button_FasterCrates()
		{
			MRInAppPurchaseManager.Instance.Purchase("com.threelanestudios.mergegarden.fastercrates");
		}

		public void FasterCratesPurchasedSuccessfully()
		{
			this.RemoveAdsWorker();
			DataProvider.instance.gameData.boxIAPMultiplier = 2;
			this.UpdateShop();
		}

		public void Button_UpgradeCrate()
		{
			MRInAppPurchaseManager.Instance.Purchase(string.Concat(new object[]
			{
				"com.threelanestudios.mergegarden.bettercrates",
				DataProvider.instance.gameData.currentBoxLevel,
				string.Empty,
				DataProvider.instance.gameData.currentBoxLevel + 1
			}));
		}

		public void UpgradedCrateLevelSuccessfully(int boxValue)
		{
			this.RemoveAdsWorker();
			if (DataProvider.instance.gameData.currentBoxLevel < boxValue)
			{
				DataProvider.instance.gameData.currentBoxLevel = boxValue;
				BoxManager.instance.UpdateBoxSprite();
			}
			this.UpdateShop();
			GridManager.instance.ReplaceUpdatedItems();
		}

		public void Button_OpenShop()
		{
			GUIManager.Instance.OpenScreenExplicitly(ScreenName.Shop);
			this.UpdateShop();
		}

		public void Button_RestorePurchasesClicked()
		{
			//MRUtilities.Instance.LogEvent("RestorePurchaseButtonClicked");
			MRInAppPurchaseManager.Instance.RestorePurchases();
		}
	}
}
