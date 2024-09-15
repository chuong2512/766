using Mindravel.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class MRInAppPurchaseManager : MonoBehaviour, IStoreListener
{
	[Serializable]
	public class InAppProduct
	{
		public string name;

		public string ID;

		public string ID_IOS;

		public ProductType type;

		public UnityEvent purchaseSuccessAction;
	}

	[Serializable]
	public class PurchaseReceiptPlayStore
	{
		public string Store;

		public string TransactionID;

		public MRInAppPurchaseManager.PayloadPlayStore Payload;
	}

	[Serializable]
	public class PayloadPlayStore
	{
		public string json;

		public string signature;
	}

	[Serializable]
	public class PurchaseReceiptAppStore
	{
		public string Store;

		public string TransactionID;

		public string Payload;
	}

	private sealed class _Purchase_c__AnonStorey1
	{
		internal string productID;

		internal bool __m__0(MRInAppPurchaseManager.InAppProduct asd)
		{
			return asd.ID == this.productID;
		}
	}

	private sealed class _InitiatePurchase_c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		private sealed class _InitiatePurchase_c__AnonStorey2
		{
			internal string productID;

			internal MRInAppPurchaseManager._InitiatePurchase_c__Iterator0 __f__ref_0;

			internal bool __m__0(MRInAppPurchaseManager.InAppProduct asd)
			{
				return string.Equals(this.productID, asd.ID, StringComparison.Ordinal);
			}
		}

		internal string productID;

		internal MRInAppPurchaseManager.InAppProduct _purchasedProduct___1;

		internal MRInAppPurchaseManager _this;

		internal object _current;

		internal bool _disposing;

		internal int _PC;

		private MRInAppPurchaseManager._InitiatePurchase_c__Iterator0._InitiatePurchase_c__AnonStorey2 _locvar0;

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

		public _InitiatePurchase_c__Iterator0()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._locvar0 = new MRInAppPurchaseManager._InitiatePurchase_c__Iterator0._InitiatePurchase_c__AnonStorey2();
				this._locvar0.__f__ref_0 = this;
				this._locvar0.productID = this.productID;
				if (this._this.isTestMode)
				{
					this._current = new WaitForSeconds(2f);
					if (!this._disposing)
					{
						this._PC = 1;
					}
					return true;
				}
				this._this.BuyProductID(this._locvar0.productID);
				break;
			case 1u:
				if (GUIManager.Instance.CURRENTSCREENNAME == ScreenName.Loader)
				{
					GUIManager.Instance.Back();
				}
				///if (MRUtilities.Instance)
				{
				///MRUtilities.Instance.LogEvent(MRConstants.INAPPPURCHASING, MRConstants.PRODUCTPURCHASED, this._locvar0.productID);
				}
				this._purchasedProduct___1 = this._this.inAppProducts.Find(new Predicate<MRInAppPurchaseManager.InAppProduct>(this._locvar0.__m__0));
				if (this._purchasedProduct___1.purchaseSuccessAction != null)
				{
					this._purchasedProduct___1.purchaseSuccessAction.Invoke();
				}
				break;
			case 2u:
				this._PC = -1;
				return false;
			default:
				return false;
			}
			this._current = null;
			if (!this._disposing)
			{
				this._PC = 2;
			}
			return true;
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

	private sealed class _ProcessPurchase_c__AnonStorey3
	{
		internal PurchaseEventArgs args;

		internal bool __m__0(MRInAppPurchaseManager.InAppProduct asd)
		{
			return string.Equals(this.args.purchasedProduct.definition.id, asd.ID, StringComparison.Ordinal);
		}
	}

	public bool isTestMode;

	public List<MRInAppPurchaseManager.InAppProduct> inAppProducts = new List<MRInAppPurchaseManager.InAppProduct>();

	private static IStoreController m_StoreController;

	private static IExtensionProvider m_StoreExtensionProvider;

	public static MRInAppPurchaseManager Instance;

	private static Action<bool> __f__am_cache0;

	private void Awake()
	{
		MRInAppPurchaseManager.Instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		if (UnityEngine.Object.FindObjectsOfType<MRInAppPurchaseManager>().Length > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
	}

	private void Start()
	{
		if (MRInAppPurchaseManager.m_StoreController == null)
		{
			this.InitializePurchasing();
		}
	}

	public void InitializePurchasing()
	{
		if (this.IsInitialized())
		{
			return;
		}
		ConfigurationBuilder configurationBuilder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance(), new IPurchasingModule[0]);
		foreach (MRInAppPurchaseManager.InAppProduct current in this.inAppProducts)
		{
			configurationBuilder.AddProduct(current.ID, current.type);
		}
		UnityPurchasing.Initialize(this, configurationBuilder);
	}

	private bool IsInitialized()
	{
		return MRInAppPurchaseManager.m_StoreController != null && MRInAppPurchaseManager.m_StoreExtensionProvider != null;
	}

	public void Purchase(string productID)
	{
        /*
		if (this.IsAppInstalled("com.android.vending.billing.InAppBillingService.COIN") || this.IsAppInstalled("com.android.vending.billing.InAppBillingService.LACK") || this.IsAppInstalled("com.android.vending.billing.InAppBillingService.LOCK") || this.IsAppInstalled("com.android.vending.billing.InAppBillingService.LUCK") || this.IsAppInstalled("com.android.vending.billing.InAppBillingService.CRACK") || this.IsAppInstalled("com.dimonvideo.luckypatcher"))
		{
			GUIManager.Instance.OpenScreenExplicitly(ScreenName.MessagePanel);
			GUIManager.Instance.CURRENTPANEL.GetComponent<MRMessagePanel>().ShowMessage("Error!", "Please remove Lucky Patcher app to make In App Purchases");
			//MRUtilities.Instance.LogEvent("Lucky Patcher Detected");
			return;
		}
		if (this.IsAppInstalled("apps.zhasik007.hack"))
		{
			GUIManager.Instance.OpenScreenExplicitly(ScreenName.MessagePanel);
			GUIManager.Instance.CURRENTPANEL.GetComponent<MRMessagePanel>().ShowMessage("Error!", "Please remove Cree Hack app to make In App Purchases");
			//MRUtilities.Instance.LogEvent("Cree Hack Detected");
			return;
		}
		if (this.IsAppInstalled("com.leo.playcard"))
		{
			GUIManager.Instance.OpenScreenExplicitly(ScreenName.MessagePanel);
			GUIManager.Instance.CURRENTPANEL.GetComponent<MRMessagePanel>().ShowMessage("Error!", "Please remove Leo PlayCard app to make In App Purchases");
			//MRUtilities.Instance.LogEvent("Leo PlayCard Detected");
			return;
		}
		if (this.IsAppInstalled("com.appsara.app"))
		{
			GUIManager.Instance.OpenScreenExplicitly(ScreenName.MessagePanel);
			GUIManager.Instance.CURRENTPANEL.GetComponent<MRMessagePanel>().ShowMessage("Error!", "Please remove AppSara app to make In App Purchases");
			//MRUtilities.Instance.LogEvent("AppSara Detected");
			return;
		}
		if (this.IsAppInstalled("cc.madkite.freedom"))
		{
			GUIManager.Instance.OpenScreenExplicitly(ScreenName.MessagePanel);
			GUIManager.Instance.CURRENTPANEL.GetComponent<MRMessagePanel>().ShowMessage("Error!", "Please remove Freedom app to make In App Purchases");
			//MRUtilities.Instance.LogEvent("Freedom Detected");
			return;
		}
		*/
		if (this.isTestMode)
		{
			GUIManager.Instance.OpenScreenExplicitly(ScreenName.Loader);
			base.StartCoroutine(this.InitiatePurchase(productID));
		}
		else
		{
			MRInAppPurchaseManager.InAppProduct inAppProduct = this.inAppProducts.Find((MRInAppPurchaseManager.InAppProduct asd) => asd.ID == productID);
			if (inAppProduct != null)
			{
				GUIManager.Instance.OpenScreenExplicitly(ScreenName.Loader);
				base.StartCoroutine(this.InitiatePurchase(productID));
			}
			else
			{
				MR.LogError("Product ID " + productID + " not found in the available products list. Please add this product from InAppPurchaseManager Object!");
			}
		}
	}

	private IEnumerator InitiatePurchase(string productID)
	{
		MRInAppPurchaseManager._InitiatePurchase_c__Iterator0 _InitiatePurchase_c__Iterator = new MRInAppPurchaseManager._InitiatePurchase_c__Iterator0();
		_InitiatePurchase_c__Iterator.productID = productID;
		_InitiatePurchase_c__Iterator._this = this;
		return _InitiatePurchase_c__Iterator;
	}

	private void BuyProductID(string productId)
	{
		if (this.IsInitialized())
		{
			Product product = MRInAppPurchaseManager.m_StoreController.products.WithID(productId);
			if (product != null && product.availableToPurchase)
			{
				//if (MRUtilities.Instance)
				{
				//MRUtilities.Instance.LogEvent(MRConstants.INAPPPURCHASING, MRConstants.PURCHASINGPRODUCT, product.definition.id);
				}
				MRInAppPurchaseManager.m_StoreController.InitiatePurchase(product);
			}
			else if (GUIManager.Instance.CURRENTSCREENNAME == ScreenName.Loader)
			{
				GUIManager.Instance.Back();
			}
		}
		else
		{
			if (GUIManager.Instance.CURRENTSCREENNAME == ScreenName.Loader)
			{
				GUIManager.Instance.Back();
			}
			//if (MRUtilities.Instance)
			{
				///MRUtilities.Instance.LogEvent(MRConstants.INAPPPURCHASING, MRConstants.INITIALIZATIONFAILED, productId);
			}
		}
	}

	public void RestorePurchases()
	{
		if (!this.IsInitialized())
		{
			return;
		}
		if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.OSXPlayer)
		{
			IAppleExtensions extension = MRInAppPurchaseManager.m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
			extension.RestoreTransactions(delegate(bool result)
			{
				UnityEngine.Debug.Log("MRLOG RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
			});
		}
	}

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		MRInAppPurchaseManager.m_StoreController = controller;
		MRInAppPurchaseManager.m_StoreExtensionProvider = extensions;
	}

	public void OnInitializeFailed(InitializationFailureReason error)
	{
	}

	public void OnInitializeFailed(InitializationFailureReason error, string message)
	{
		
	}

	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
	{
		MRInAppPurchaseManager.InAppProduct inAppProduct = this.inAppProducts.Find((MRInAppPurchaseManager.InAppProduct asd) => string.Equals(args.purchasedProduct.definition.id, asd.ID, StringComparison.Ordinal));
		if (inAppProduct != null)
		{
			if (GUIManager.Instance.CURRENTSCREENNAME == ScreenName.Loader)
			{
				GUIManager.Instance.Back();
			}
			//if (MRUtilities.Instance)
			{
			//MRUtilities.Instance.LogEvent(MRConstants.INAPPPURCHASING, MRConstants.PRODUCTPURCHASED, args.purchasedProduct.definition.id);
			}
			if (inAppProduct.purchaseSuccessAction != null)
			{
				inAppProduct.purchaseSuccessAction.Invoke();
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("amount", args.purchasedProduct.metadata.localizedPriceString);
			dictionary.Add("currency", args.purchasedProduct.metadata.isoCurrencyCode);
			MRInAppPurchaseManager.PurchaseReceiptPlayStore purchaseReceiptPlayStore = JsonUtility.FromJson<MRInAppPurchaseManager.PurchaseReceiptPlayStore>(args.purchasedProduct.receipt);
			dictionary.Add("receipt_data", purchaseReceiptPlayStore.Payload.json);
			dictionary.Add("receipt_data_signature", purchaseReceiptPlayStore.Payload.signature);
			//AppLovin.TrackEvent("iap", dictionary);
		}
		else
		{
			//if (MRUtilities.Instance)
			{
			//MRUtilities.Instance.LogEvent(MRConstants.INAPPPURCHASING, MRConstants.UNRECOGNIZABLEPRODUCT, args.purchasedProduct.definition.id);
			}
			if (GUIManager.Instance.CURRENTSCREENNAME == ScreenName.Loader)
			{
				GUIManager.Instance.Back();
			}
		}
		return PurchaseProcessingResult.Complete;
	}

	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
	//if (MRUtilities.Instance)
		{
			//MRUtilities.Instance.LogEvent(MRConstants.INAPPPURCHASING, MRConstants.PURCHASEFAILED, product.definition.id);
		}
		if (GUIManager.Instance.CURRENTSCREENNAME == ScreenName.Loader)
		{
			GUIManager.Instance.Back();
		}
	}

	private bool IsAppInstalled(string bundleID)
	{
        /*
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
		AndroidJavaObject androidJavaObject = @static.Call<AndroidJavaObject>("getPackageManager", new object[0]);
		AndroidJavaObject result = null;
		try
		{
			result = androidJavaObject.Call<AndroidJavaObject>("getLaunchIntentForPackage", new object[]
			{
				bundleID
			});
		}
		catch (Exception var_4_46)
		{
		}
		return result != null;
		*/
        return false;      
	}
}
