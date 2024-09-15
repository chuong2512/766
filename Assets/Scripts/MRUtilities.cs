/*
using Mindravel.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MRUtilities : MonoBehaviour
{
	public enum AppOrientation
	{
		portrait,
		landscape
	}

	public delegate void RewardedVideoAction();

	private sealed class _InitializeMRUtilitiesHeavyFunctions_c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal bool p_wait;

		internal MRUtilities _this;

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

		public _InitializeMRUtilitiesHeavyFunctions_c__Iterator0()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				if (this.p_wait)
				{
					this._current = new WaitForSeconds(1f);
					if (!this._disposing)
					{
						this._PC = 1;
					}
					return true;
				}
				break;
			case 1u:
				break;
			default:
				return false;
			}
			if (this._this.USERCONSENT)
			{
               
			}
			if (this._this.transform.Find("MRBannerAdCanvas"))
			{
				this._this.mrBannerAdCanvas = this._this.transform.Find("MRBannerAdCanvas").gameObject;
			}
			this._this.bannerCanvas = this._this.transform.Find("MRCrossPromoBannerCanvas").gameObject;
			this._this.crossPromoVideoHolder = this._this.transform.Find("MRCrossPromoVideoCanvas").transform.Find("CrossPromoVideoHolder").gameObject;
			this._this.crossPromoVideoPlayer = this._this.transform.Find("MRCrossPromoVideoCanvas").transform.Find("CrossPromoVideoPlayer").GetComponent<VideoPlayer>();
			this._this.socialSharePanel = this._this.transform.Find("MRSocialShareCanvas").gameObject;
			if (this._this.socialSharePanel)
			{
				this._this.image_socialShareTexture = this._this.transform.Find("MRSocialShareCanvas/SocialSharePanel/Image_SocialShareTexture").gameObject.GetComponent<Image>();
				this._this.socialShareTexture = Resources.Load<Sprite>("MRResources/socialShareTexture");
				if (this._this.socialShareTexture != null)
				{
					this._this.image_socialShareTexture.sprite = this._this.socialShareTexture;
				}
				this._this.socialSharePanel.SetActive(false);
			}
			if (this._this.transform.Find("MRPreLoaderCanvas"))
			{
				this._this.mrPreLoaderCanvas = this._this.transform.Find("MRPreLoaderCanvas").gameObject;
				this._this.mrPreLoaderCanvas.SetActive(false);
			}
			if (this._this.gameBundle != string.Empty)
			{
				this._this.StartCoroutine(this._this.SelectAdNetwork());
				this._this.StartCoroutine(this._this.StartAdNetworkAfterDelay());
			}
			else
			{
				MR.LogError("Game Bundle Not Set");
			}
			this._this.FORCEDVIDEOADTEMPLATE = this._this.GetComponent<MRVungleImplementation>();
			this._PC = -1;
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

	private sealed class _SetSoundOnWithDelay_c__Iterator1 : IEnumerator, IDisposable, IEnumerator<object>
	{
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

		public _SetSoundOnWithDelay_c__Iterator1()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._current = new WaitForSeconds(0.01f);
				if (!this._disposing)
				{
					this._PC = 1;
				}
				return true;
			case 1u:
				AudioListener.pause = false;
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

	private sealed class _SetSoundOffWithDelay_c__Iterator2 : IEnumerator, IDisposable, IEnumerator<object>
	{
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

		public _SetSoundOffWithDelay_c__Iterator2()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._current = new WaitForSeconds(0.01f);
				if (!this._disposing)
				{
					this._PC = 1;
				}
				return true;
			case 1u:
				AudioListener.pause = true;
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

	private sealed class _HideWithDelay_c__Iterator3 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal MRUtilities _this;

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

		public _HideWithDelay_c__Iterator3()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._current = new WaitForSeconds(2f);
				if (!this._disposing)
				{
					this._PC = 1;
				}
				return true;
			case 1u:
				this._this.facebookConnectCanvas.SetActive(false);
				this._this.showingFacebookConnect = false;
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

	private sealed class _SelectAdNetwork_c__Iterator4 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal WWWForm _form___0;

		internal string _url___0;

		internal WWW _www___0;

		internal string _xmlText___0;

		internal MRUtilities _this;

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

		public _SelectAdNetwork_c__Iterator4()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._form___0 = new WWWForm();
				this._form___0.AddField("bundle", this._this.gameBundle);
				this._form___0.AddField("platform", this._this.platform);
				this._form___0.AddField("domain", this._this.domain);
				this._url___0 = this._this.baseUrl + "ADN/Seladn.php";
				MR.Log("URL = " + this._url___0);
				this._www___0 = new WWW(this._url___0, this._form___0);
				this._current = this._www___0;
				if (!this._disposing)
				{
					this._PC = 1;
				}
				return true;
			case 1u:
				this._xmlText___0 = this._www___0.text;
				MR.Log("Xml Text = " + this._xmlText___0);
				if (this._xmlText___0 != string.Empty)
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.LoadXml(this._xmlText___0);
					XmlNode xmlNode = xmlDocument.SelectSingleNode("/AdNetwork/AdmobTestDevices");
					if (xmlNode != null)
					{
						string[] array = xmlNode.InnerText.Split(new char[]
						{
							','
						});
						this._this.ADMOBTESTIDS = new List<string>();
						MR.Log("ADMOB TEST IDs ---");
						string[] array2 = array;
						for (int i = 0; i < array2.Length; i++)
						{
							string text = array2[i];
							this._this.ADMOBTESTIDS.Add(text);
							MR.Log(text);
						}
						this._this.GetComponent<MRAdmobImplementation>().TEST_DEVICE_IDS = this._this.ADMOBTESTIDS;
					}
					XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/AdNetwork/bannerPriorityPattern");
					if (xmlNode2 != null)
					{
						string[] array3 = xmlNode2.InnerText.Split(new char[]
						{
							','
						});
						string[] array4 = array3;
						for (int j = 0; j < array4.Length; j++)
						{
							string a = array4[j];
							if (a == "MRAdmob")
							{
								this._this.BANNERNETWORK = this._this.GetComponent<MRAdmobImplementation>();
							}
							else if (a == "MRAppLovin")
							{
								this._this.BANNERNETWORK = this._this.GetComponent<MRAppLovinImplementation>();
							}
							if (this._this.BANNERNETWORK)
							{
								MR.Log("BANNER PRIORITY ---");
								MR.Log(this._this.BANNERNETWORK.GetType().ToString());
							}
						}
					}
					this._this.INTERSTITIALRATE = int.Parse(xmlDocument.SelectSingleNode("/AdNetwork/interstitialRateGameOver").InnerText);
					if (this._this.interstitialImplementsPrioritized == null)
					{
						XmlNode xmlNode3 = xmlDocument.SelectSingleNode("/AdNetwork/interstitialPriorityPattern");
						if (xmlNode3 != null)
						{
							this._this.interstitialImplementsPrioritized = new List<BasicAdNetwork>();
							string[] array5 = xmlNode3.InnerText.Split(new char[]
							{
								','
							});
							string[] array6 = array5;
							for (int k = 0; k < array6.Length; k++)
							{
								string a2 = array6[k];
								if (a2 == "MRUnityAds")
								{
									this._this.interstitialImplementsPrioritized.Add(this._this.GetComponent<MRUnityAdsImplementation>());
								}
								else if (a2 == "MRVungle")
								{
									this._this.interstitialImplementsPrioritized.Add(this._this.GetComponent<MRVungleImplementation>());
								}
								else if (a2 == "MRAdmob")
								{
									this._this.interstitialImplementsPrioritized.Add(this._this.GetComponent<MRAdmobImplementation>());
								}
								else if (a2 == "MRAppLovin")
								{
									this._this.interstitialImplementsPrioritized.Add(this._this.GetComponent<MRAppLovinImplementation>());
								}
								else if (a2 == "MRChartboost")
								{
									this._this.interstitialImplementsPrioritized.Add(this._this.GetComponent<MRChartboostImplementation>());
								}
								else if (a2 == "MRAdColony")
								{
									this._this.interstitialImplementsPrioritized.Add(this._this.GetComponent<MRAdColonyImplementation>());
								}
							}
							if (MRUtilities.Instance)
							{
								MRUtilities.Instance.LogEvent(MRConstants.MRADNETWORK, MRConstants.INTERSTITIALPRIORITYFETCHED, string.Empty + array5);
							}
							MR.Log("LIVE INTERSTITIAL PRIORITIES ARE ---");
							foreach (BasicAdNetwork current in this._this.interstitialImplementsPrioritized)
							{
								MR.Log(current.GetType().ToString());
							}
						}
						else
						{
							this._this.interstitialImplementsPrioritized.Add(this._this.GetComponent<MRUnityAdsImplementation>());
							this._this.interstitialImplementsPrioritized.Add(this._this.GetComponent<MRVungleImplementation>());
							this._this.interstitialImplementsPrioritized.Add(this._this.GetComponent<MRAdColonyImplementation>());
						}
					}
					XmlNode xmlNode4 = xmlDocument.SelectSingleNode("/AdNetwork/forcedVideoAdTemplate");
					if (xmlNode4 != null)
					{
						int num2 = int.Parse(xmlNode4.InnerText);
						if (num2 == 1)
						{
							this._this.FORCEDVIDEOADTEMPLATE = this._this.GetComponent<MRVungleImplementation>();
						}
						else if (num2 == 2)
						{
							this._this.FORCEDVIDEOADTEMPLATE = this._this.GetComponent<MRUnityAdsImplementation>();
						}
					}
					if (this._this.videoAdImplementsPrioritized == null)
					{
						XmlNode xmlNode5 = xmlDocument.SelectSingleNode("/AdNetwork/videoPriorityPattern");
						if (xmlNode5 != null)
						{
							this._this.videoAdImplementsPrioritized = new List<BasicAdNetwork>();
							string[] array7 = xmlNode5.InnerText.Split(new char[]
							{
								','
							});
							string[] array8 = array7;
							for (int l = 0; l < array8.Length; l++)
							{
								string a3 = array8[l];
								if (a3 == "MRUnityAds")
								{
									this._this.videoAdImplementsPrioritized.Add(this._this.GetComponent<MRUnityAdsImplementation>());
								}
								else if (a3 == "MRVungle")
								{
									this._this.videoAdImplementsPrioritized.Add(this._this.GetComponent<MRVungleImplementation>());
								}
								else if (a3 == "MRAdmob")
								{
									this._this.videoAdImplementsPrioritized.Add(this._this.GetComponent<MRAdmobImplementation>());
								}
								else if (a3 == "MRAppLovin")
								{
									this._this.videoAdImplementsPrioritized.Add(this._this.GetComponent<MRAppLovinImplementation>());
								}
								else if (a3 == "MRChartboost")
								{
									this._this.videoAdImplementsPrioritized.Add(this._this.GetComponent<MRChartboostImplementation>());
								}
								else if (a3 == "MRAdColony")
								{
									this._this.videoAdImplementsPrioritized.Add(this._this.GetComponent<MRAdColonyImplementation>());
								}
							}
							if (MRUtilities.Instance)
							{
								MRUtilities.Instance.LogEvent(MRConstants.MRADNETWORK, MRConstants.REWARDEDVIDEOPRIORITYFETCHED, string.Empty + array7);
							}
							MR.Log("LIVE VIDEO PRIORITIES ---");
							foreach (BasicAdNetwork current2 in this._this.videoAdImplementsPrioritized)
							{
								MR.Log(current2.GetType().ToString());
							}
						}
						else
						{
							this._this.videoAdImplementsPrioritized.Add(this._this.GetComponent<MRUnityAdsImplementation>());
							this._this.videoAdImplementsPrioritized.Add(this._this.GetComponent<MRAppLovinImplementation>());
							this._this.videoAdImplementsPrioritized.Add(this._this.GetComponent<MRVungleImplementation>());
							this._this.videoAdImplementsPrioritized.Add(this._this.GetComponent<MRAdColonyImplementation>());
						}
					}
					if (xmlDocument.SelectSingleNode("/AdNetwork/showCrossPromo").InnerText == "1")
					{
						string innerText = xmlDocument.SelectSingleNode("/AdNetwork/crossPromoAdType").InnerText;
						CrossPromoGame crossPromoGame = new CrossPromoGame();
						crossPromoGame.Name = xmlDocument.SelectSingleNode("/AdNetwork/crossPromoGameName").InnerText;
						crossPromoGame.Bundle = xmlDocument.SelectSingleNode("/AdNetwork/crossPromoGameBundle").InnerText;
						crossPromoGame.appID = xmlDocument.SelectSingleNode("/AdNetwork/crossPromoGameIOSID").InnerText;
						bool flag = false;
						if (int.Parse(xmlDocument.SelectSingleNode("/AdNetwork/isConsistent").InnerText) == 1)
						{
							flag = true;
						}
						this._this.local_isConsistent = flag;
						this._this.fetchedGameCrossPromoAdType = CrossPromoAdType.BannerBottom;
						crossPromoGame.ImageURL = xmlDocument.SelectSingleNode("/AdNetwork/crossPromoBannerImageName").InnerText;
						crossPromoGame.videoName = xmlDocument.SelectSingleNode("/AdNetwork/promoVideoName").InnerText;
						if (innerText == "BannerTopLeft")
						{
							this._this.fetchedGameCrossPromoAdType = CrossPromoAdType.BannerTopLeft;
						}
						else if (innerText == "BannerTop")
						{
							this._this.fetchedGameCrossPromoAdType = CrossPromoAdType.BannerTop;
						}
						else if (innerText == "BannerTopRight")
						{
							this._this.fetchedGameCrossPromoAdType = CrossPromoAdType.BannerTopRight;
						}
						else if (innerText == "BannerLeft")
						{
							this._this.fetchedGameCrossPromoAdType = CrossPromoAdType.BannerLeft;
						}
						else if (innerText == "BannerCenter")
						{
							this._this.fetchedGameCrossPromoAdType = CrossPromoAdType.BannerCenter;
						}
						else if (innerText == "BannerRight")
						{
							this._this.fetchedGameCrossPromoAdType = CrossPromoAdType.BannerRight;
						}
						else if (innerText == "BannerBottomLeft")
						{
							this._this.fetchedGameCrossPromoAdType = CrossPromoAdType.BannerBottomLeft;
						}
						else if (innerText == "BannerBottom")
						{
							this._this.fetchedGameCrossPromoAdType = CrossPromoAdType.BannerBottom;
						}
						else if (innerText == "BannerBottomRight")
						{
							this._this.fetchedGameCrossPromoAdType = CrossPromoAdType.BannerBottomRight;
						}
						else if (innerText == "Video")
						{
							this._this.fetchedGameCrossPromoAdType = CrossPromoAdType.Video;
						}
						this._this.Games = new List<CrossPromoGame>();
						this._this.Games.Add(crossPromoGame);
						UnityEngine.Debug.Log("Fetched Is Consistent = " + flag);
						this._this.FetchImages(this._this.fetchedGameCrossPromoAdType, flag);
					}
					this._this.StartAdNetwork("ADNETWORK INITIALIZED FROM SUCCESSFUL FETCH");
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

	private sealed class _StartAdNetworkAfterDelay_c__Iterator5 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal MRUtilities _this;

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

		public _StartAdNetworkAfterDelay_c__Iterator5()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				this._current = new WaitForSeconds(6f);
				if (!this._disposing)
				{
					this._PC = 1;
				}
				return true;
			case 1u:
				if (!this._this.ADNETWORKSTARTED)
				{
					this._this.StartAdNetwork("ADNETWORK INITIALIZED FROM TIME EXPIRATION");
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

	private sealed class _InterstitialLoadFailed_c__AnonStorey8
	{
		internal BasicAdNetwork p_adNetworkImplement;

		internal bool __m__0(BasicAdNetwork asd)
		{
			return asd.GetType() == this.p_adNetworkImplement.GetType();
		}
	}

	private sealed class _VideoAdLoadFailed_c__AnonStorey9
	{
		internal BasicAdNetwork p_adNetworkImplement;

		internal bool __m__0(BasicAdNetwork asd)
		{
			return asd.GetType() == this.p_adNetworkImplement.GetType();
		}
	}

	private sealed class _FetchSingleImage_c__Iterator6 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal Param p;

		internal string _path___1;

		internal string _videoURL___2;

		internal WWW _www___2;

		internal string _savePath___2;

		internal string _imageUrl___3;

		internal WWW _www___3;

		internal MRUtilities _this;

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

		public _FetchSingleImage_c__Iterator6()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				if (this._this.fetchedGameCrossPromoAdType != CrossPromoAdType.Video)
				{
					this._imageUrl___3 = this._this.baseUrl + "ADN/PromoImages/" + this.p.game.ImageURL;
					this._www___3 = new WWW(this._imageUrl___3);
					this._current = this._www___3;
					if (!this._disposing)
					{
						this._PC = 2;
					}
					return true;
				}
				this._path___1 = Application.persistentDataPath + "/" + this.p.game.videoName;
				if (!File.Exists(this._path___1))
				{
					this._videoURL___2 = this._this.baseUrl + "ADN/PromoVideos/" + this.p.game.videoName;
					this._www___2 = new WWW(this._videoURL___2);
					this._current = this._www___2;
					if (!this._disposing)
					{
						this._PC = 1;
					}
					return true;
				}
				this._this.SetVideoOnCanvas(this.p.game, this.p.isConsistent);
				break;
			case 1u:
				this._savePath___2 = Application.persistentDataPath + "/" + this.p.game.videoName;
				File.WriteAllBytes(this._savePath___2, this._www___2.bytes);
				this._this.SetVideoOnCanvas(this.p.game, this.p.isConsistent);
				break;
			case 2u:
				this.p.game.Image = this._www___3.texture;
				this._this.crossPromoImage = this._www___3.texture;
				this._current = new WaitForSeconds(4f);
				if (!this._disposing)
				{
					this._PC = 3;
				}
				return true;
			case 3u:
				this._this.StartCoroutine(this._this.SetBannerOnCanvas(this.p.game, this.p.crossPromoAdType, this.p.isConsistent));
				break;
			default:
				return false;
			}
			this._PC = -1;
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

	private sealed class _SetBannerOnCanvas_c__Iterator7 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal bool p_isCons;

		internal CrossPromoAdType p_cpat;

		internal CrossPromoGame game;

		internal MRUtilities _this;

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

		public _SetBannerOnCanvas_c__Iterator7()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				if (!(this._this.bannerCanvas != null))
				{
					this._current = new WaitForSeconds(2f);
					if (!this._disposing)
					{
						this._PC = 1;
					}
					return true;
				}
				if (!this.p_isCons)
				{
					this._this.bannerCanvas.SetActive(false);
				}
				this._this.bannerCanvas.transform.Find(this.p_cpat.ToString()).gameObject.SetActive(true);
				this._this.bannerCanvas.transform.Find(this.p_cpat.ToString()).GetComponent<RawImage>().texture = this._this.crossPromoImage;
				break;
			case 1u:
				this._this.bannerCanvas = GameObject.Find("MRCrossPromoBannerCanvas");
				this._this.StartCoroutine(this._this.SetBannerOnCanvas(this.game, this.p_cpat, this.p_isCons));
				break;
			default:
				return false;
			}
			this._PC = -1;
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

//public IOSNativeSettings iosNativeSettings;

	public string gameBundle_Android;

	public string gameBundle_IOS;

	private string gameBundle;

	public string domain;

	private string baseUrl = "https://www.mindravel.com/GSrvrsControl/";

	private List<CrossPromoGame> Games;

	private string platform = "Android";

	public MRUtilities.AppOrientation orientation;

	public string gameIOSID;

	public string flurryIOSID;

	public string flurryAndroidID;

	public bool forceRewardedVideo = true;

	public bool ENABLE_EDITOR_TESTING;

	private Texture2D crossPromoImage;

	private bool local_isConsistent;

	private List<BasicAdNetwork> interstitialImplementsPrioritized;

	private List<BasicAdNetwork> interstitialQueue = new List<BasicAdNetwork>();

	private List<BasicAdNetwork> videoAdImplementsPrioritized;

	private List<BasicAdNetwork> videoAdQueue = new List<BasicAdNetwork>();

	private List<GameItem> promoGamesList = new List<GameItem>();

	private GameObject mrPromoGamesCanvas;

	private GameObject promoGamesGridRoot;

	private GameObject promoGameItemPrefab;

	private GameObject bannerCanvas;

	private GameObject crossPromoVideoHolder;

	private GameObject topGamesCanvas;

	private GameObject topGamesGridRoot;

	private GameObject topGameItemPrefab;

	private GameObject mrPreLoaderCanvas;

	[HideInInspector]
	public GameObject mrBannerAdCanvas;

	private int INTERSTITIALRATE = 3;

	private int INTERSTITALCOUNTER;

	private int RATERATE = 10;

	private int RATECOUNTER;

	private List<string> ADMOBTESTIDS;

	private BasicAdNetwork BANNERNETWORK;

	private BasicAdNetwork FORCEDVIDEOADTEMPLATE;

	private bool ADNETWORKSTARTED;

	[HideInInspector]
	public static MRUtilities Instance;

	private Sprite socialShareTexture;

	[HideInInspector]
	public Image image_socialShareTexture;

	[HideInInspector]
	public GameObject socialSharePanel;

	private GameObject facebookConnectCanvas;

	private bool showingFacebookConnect;

	private Text textLabelFacebookConnectFeedback;

	private GameObject customLeaderboardCanvas;

	[HideInInspector]
	public GameObject leaderboardItemPrefab;

	public GameObject consentPopUpPortrait;

	public GameObject consentPopUpLandscape;

	public GameObject mrMessagePanel;

	public List<GameObject> customVideoCrossPromoObjects;

	private VideoPlayer crossPromoVideoPlayer;

	private CrossPromoAdType fetchedGameCrossPromoAdType;

	private MRUtilities.RewardedVideoAction rewardedVideoCompleteAction;

	private MRUtilities.RewardedVideoAction rewardedVideoNotAvailableAction;

	private Dictionary<string, object> fbEventParameters = new Dictionary<string, object>();

	private static Predicate<BasicAdNetwork> __f__am_cache0;

	private static Predicate<BasicAdNetwork> __f__am_cache1;

	public bool USERCONSENT
	{
		get
		{
			return PlayerPrefs.GetInt("USERCONSENT") == 1;
		}
		set
		{
			if (value)
			{
				PlayerPrefs.SetInt("USERCONSENT", 1);
			}
			else
			{
				PlayerPrefs.SetInt("USERCONSENT", 0);
			}
		}
	}

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		if (UnityEngine.Object.FindObjectsOfType<MRUtilities>().Length > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		if (!MRUtilities.Instance)
		{
			MRUtilities.Instance = this;
		}
		this.gameBundle = this.gameBundle_Android;
       
		foreach (GameObject current in this.customVideoCrossPromoObjects)
		{
			if (current != null)
			{
				current.SetActive(false);
			}
		}
		if (this.orientation == MRUtilities.AppOrientation.portrait && this.consentPopUpPortrait == null)
		{
			UnityEngine.Debug.LogError("Consent Pop Up Portrait Reference Is Null! MRUtilities Not Initialized!");
			return;
		}
		if (this.orientation == MRUtilities.AppOrientation.landscape && this.consentPopUpLandscape == null)
		{
			UnityEngine.Debug.LogError("Consent Pop Up Landsacape Reference Is Null! MRUtilities Not Initialized!");
			return;
		}
		if (PlayerPrefs.HasKey("USERCONSENT"))
		{
			base.StartCoroutine(this.InitializeMRUtilitiesHeavyFunctions(true));
		}
		else if (this.orientation == MRUtilities.AppOrientation.landscape)
		{
			this.consentPopUpLandscape.SetActive(true);
			Time.timeScale = 0f;
		}
		else if (this.orientation == MRUtilities.AppOrientation.portrait)
		{
			this.consentPopUpPortrait.SetActive(true);
			Time.timeScale = 0f;
		}
	}

	public void ConsentReceived(bool p_consent)
	{
		this.consentPopUpPortrait.SetActive(false);
		this.consentPopUpLandscape.SetActive(false);
		this.USERCONSENT = p_consent;
		Time.timeScale = 1f;
		base.StartCoroutine(this.InitializeMRUtilitiesHeavyFunctions(false));
	}

	public void Button_PrivacyPolicyLinkClicked()
	{
		if (this.domain == "3Lane")
		{
			Application.OpenURL("http://3lanestudios.com/privacypolicy/");
		}
		else if (this.domain == "Mindravel")
		{
			Application.OpenURL("http://mindravel.com/privacy-policy/");
		}
		else if (this.domain == "BitByte")
		{
			Application.OpenURL("https://hamzaraoblog.wordpress.com/privacy-policy/");
		}
	}

	private void InitCallback()
	{
       
	}

	private void OnHideUnity(bool isGameShown)
	{
		if (!isGameShown)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	private IEnumerator InitializeMRUtilitiesHeavyFunctions(bool p_wait = true)
	{
		MRUtilities._InitializeMRUtilitiesHeavyFunctions_c__Iterator0 _InitializeMRUtilitiesHeavyFunctions_c__Iterator = new MRUtilities._InitializeMRUtilitiesHeavyFunctions_c__Iterator0();
		_InitializeMRUtilitiesHeavyFunctions_c__Iterator.p_wait = p_wait;
		_InitializeMRUtilitiesHeavyFunctions_c__Iterator._this = this;
		return _InitializeMRUtilitiesHeavyFunctions_c__Iterator;
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus)
		{
			this.SetSoundOff();
		}
		else
		{
			this.SetSoundOn();
		}
	}

	private void SetSoundOn()
	{
		base.StartCoroutine(this.SetSoundOnWithDelay());
	}

	private void SetSoundOff()
	{
		base.StartCoroutine(this.SetSoundOffWithDelay());
	}

	private IEnumerator SetSoundOnWithDelay()
	{
		return new MRUtilities._SetSoundOnWithDelay_c__Iterator1();
	}

	private IEnumerator SetSoundOffWithDelay()
	{
		return new MRUtilities._SetSoundOffWithDelay_c__Iterator2();
	}

	public void ShowPreLoader()
	{
		if (this.mrPreLoaderCanvas)
		{
			this.mrPreLoaderCanvas.SetActive(true);
		}
	}

	public void HidePreLoader()
	{
		if (this.mrPreLoaderCanvas)
		{
			this.mrPreLoaderCanvas.SetActive(false);
		}
	}

	private void ShowFacebookConnectScreen()
	{
		this.facebookConnectCanvas.SetActive(true);
		this.showingFacebookConnect = true;
	}

	private void HideFacebookConnectScreen()
	{
		base.StartCoroutine(this.HideWithDelay());
	}

	private IEnumerator HideWithDelay()
	{
		MRUtilities._HideWithDelay_c__Iterator3 _HideWithDelay_c__Iterator = new MRUtilities._HideWithDelay_c__Iterator3();
		_HideWithDelay_c__Iterator._this = this;
		return _HideWithDelay_c__Iterator;
	}

	public void ShowMessagePopUp(string p_title, string p_message)
	{
		this.mrMessagePanel.SetActive(true);
		this.mrMessagePanel.GetComponent<MRMessagePanel>().ShowMessage(p_title, p_message);
	}

	public void HideMessagePopUp()
	{
		this.mrMessagePanel.SetActive(false);
	}

	private IEnumerator SelectAdNetwork()
	{
		MRUtilities._SelectAdNetwork_c__Iterator4 _SelectAdNetwork_c__Iterator = new MRUtilities._SelectAdNetwork_c__Iterator4();
		_SelectAdNetwork_c__Iterator._this = this;
		return _SelectAdNetwork_c__Iterator;
	}

	private IEnumerator StartAdNetworkAfterDelay()
	{
		MRUtilities._StartAdNetworkAfterDelay_c__Iterator5 _StartAdNetworkAfterDelay_c__Iterator = new MRUtilities._StartAdNetworkAfterDelay_c__Iterator5();
		_StartAdNetworkAfterDelay_c__Iterator._this = this;
		return _StartAdNetworkAfterDelay_c__Iterator;
	}

	private void StartAdNetwork(string str)
	{
		if (this.ADNETWORKSTARTED)
		{
			return;
		}
		if (MRGame.Instance.showAds)
		{
			if (this.ADMOBTESTIDS == null)
			{
				this.ADMOBTESTIDS = new List<string>();
				this.ADMOBTESTIDS.Add("0FFCBE5B1FFB9C395C3DCAC09334CFAA");
				this.ADMOBTESTIDS.Add("9C1660FAB5A47BE6887B2B9CC8EE9923");
				this.ADMOBTESTIDS.Add("738B1917C482EC464814E0196A0854F4");
				this.ADMOBTESTIDS.Add("94abf359898f08175ba5def88486f73b");
				this.ADMOBTESTIDS.Add("ab09b238bcf61d3410aa081511efd5a0");
				this.ADMOBTESTIDS.Add("cdd9d8e5f9e57c3ad65b720195e201d8");
				this.ADMOBTESTIDS.Add("FC1363C2679283ACF76BD264E2AD9F8A");
				base.GetComponent<MRAdmobImplementation>().TEST_DEVICE_IDS = this.ADMOBTESTIDS;
			}
			if (this.BANNERNETWORK == null)
			{
				this.BANNERNETWORK = base.GetComponent<MRAppLovinImplementation>();
			}
			this.BANNERNETWORK.RequestBanner();
			if (this.interstitialImplementsPrioritized == null)
			{
				this.interstitialImplementsPrioritized = new List<BasicAdNetwork>();
				this.interstitialImplementsPrioritized.Add(base.GetComponent<MRUnityAdsImplementation>());
				this.interstitialImplementsPrioritized.Add(base.GetComponent<MRVungleImplementation>());
				this.interstitialImplementsPrioritized.Add(base.GetComponent<MRAdColonyImplementation>());
				if (MRUtilities.Instance)
				{
					MRUtilities.Instance.LogEvent(MRConstants.MRADNETWORK, MRConstants.DEFAULTINTERSTITIALTEMPLATEDLOADED, string.Empty);
				}
				MR.Log("Default Interstitial Template Loaded");
			}
			this.RequestTopPriorityInterstitial();
			MR.Log("Top Priority Int Requested in the start");
		}
		if (this.videoAdImplementsPrioritized == null)
		{
			this.videoAdImplementsPrioritized = new List<BasicAdNetwork>();
			this.videoAdImplementsPrioritized.Add(base.GetComponent<MRUnityAdsImplementation>());
			this.videoAdImplementsPrioritized.Add(base.GetComponent<MRAppLovinImplementation>());
			this.videoAdImplementsPrioritized.Add(base.GetComponent<MRVungleImplementation>());
			this.videoAdImplementsPrioritized.Add(base.GetComponent<MRAdColonyImplementation>());
			MR.Log("Default Video Ad Template Loaded");
		}
		this.RequestTopPriorityVideoAd();
		MR.Log("Top Priority Video Requested in the start");
		this.ADNETWORKSTARTED = true;
		MR.Log(str);
	}

	public void DestroyBannerAd()
	{
		if (this.BANNERNETWORK != null)
		{
			this.BANNERNETWORK.DestroyBanner();
		}
	}

	public void InterstitialLoadFailed(BasicAdNetwork p_adNetworkImplement)
	{
		int num = this.interstitialImplementsPrioritized.FindIndex((BasicAdNetwork asd) => asd.GetType() == p_adNetworkImplement.GetType());
		for (int i = num + 1; i < this.interstitialImplementsPrioritized.Count; i++)
		{
			if (!this.interstitialImplementsPrioritized[i].IsInterstitialRequested() && !this.interstitialImplementsPrioritized[i].IsInterstitialLoaded())
			{
				this.interstitialImplementsPrioritized[i].RequestInterstitial();
				break;
			}
		}
	}

	public void InterstitialLoadSuccess(BasicAdNetwork p_adNetworkImplement)
	{
		if (this.interstitialImplementsPrioritized[0].GetType() == p_adNetworkImplement.GetType())
		{
			this.interstitialQueue.Insert(0, p_adNetworkImplement);
		}
		else
		{
			this.interstitialQueue.Add(p_adNetworkImplement);
		}
		this.RequestTopPriorityInterstitial();
	}

	public void InterstitialOpened()
	{
		this.SetSoundOn();
		this.RequestTopPriorityInterstitial();
	}

	public void ShowInterstitialAd(bool p_rateContolled = false)
	{
		if (MRGame.Instance.showAds)
		{
			if (p_rateContolled)
			{
				this.INTERSTITALCOUNTER++;
				if (this.INTERSTITALCOUNTER % this.INTERSTITIALRATE != 0)
				{
					MR.Log("Rate Controlled But Dont Show");
					return;
				}
				MR.Log("Rate Controlled And Show");
			}
			UnityEngine.Debug.Log("SHOW INTERSTITIAL");
			if (this.interstitialQueue.Count == 0)
			{
				this.RequestTopPriorityInterstitial();
			}
			else
			{
				this.SetSoundOff();
				this.interstitialQueue[0].ShowInterstitialAd();
				this.interstitialQueue.RemoveAt(0);
				this.RequestTopPriorityInterstitial();
			}
		}
	}

	private void RequestTopPriorityInterstitial()
	{
		if (this.interstitialImplementsPrioritized != null && this.interstitialImplementsPrioritized.Count > 0 && !this.interstitialImplementsPrioritized[0].IsInterstitialRequested() && !this.interstitialImplementsPrioritized[0].IsInterstitialLoaded())
		{
			this.interstitialImplementsPrioritized[0].RequestInterstitial();
		}
	}

	private void RequestTopPriorityVideoAd()
	{
		if (this.videoAdImplementsPrioritized != null && this.videoAdImplementsPrioritized.Count > 0 && !this.videoAdImplementsPrioritized[0].IsVideoAdRequested() && !this.videoAdImplementsPrioritized[0].IsVideoAdLoaded())
		{
			this.videoAdImplementsPrioritized[0].RequestVideoAd();
		}
	}

	public void VideoAdLoadFailed(BasicAdNetwork p_adNetworkImplement)
	{
		int num = this.videoAdImplementsPrioritized.FindIndex((BasicAdNetwork asd) => asd.GetType() == p_adNetworkImplement.GetType());
		for (int i = num + 1; i < this.videoAdImplementsPrioritized.Count; i++)
		{
			if (!this.videoAdImplementsPrioritized[i].IsVideoAdRequested() && !this.videoAdImplementsPrioritized[i].IsVideoAdLoaded())
			{
				this.videoAdImplementsPrioritized[i].RequestVideoAd();
				break;
			}
		}
	}

	public void VideoAdLoadSuccess(BasicAdNetwork p_adNetworkImplement)
	{
		if (this.videoAdImplementsPrioritized[0].GetType() == p_adNetworkImplement.GetType())
		{
			this.videoAdQueue.Insert(0, p_adNetworkImplement);
		}
		else
		{
			this.videoAdQueue.Add(p_adNetworkImplement);
		}
		this.RequestTopPriorityVideoAd();
	}

	public void VideoAdCompleted(BasicAdNetwork p_adNetworkImplement)
	{
		this.SetSoundOn();
		this.RequestTopPriorityVideoAd();
		if (this.rewardedVideoCompleteAction != null)
		{
			this.rewardedVideoCompleteAction();
		}
		if (MRUtilities.Instance)
		{
			MRUtilities.Instance.LogEvent(MRConstants.REWARDEDVIDEOCOMPLETED);
		}
	}

	public void ShowVideoAd(MRUtilities.RewardedVideoAction p_rewardedVideoCompleteAction, MRUtilities.RewardedVideoAction p_rewardedVideoNotAvailableAction)
	{
		this.rewardedVideoCompleteAction = p_rewardedVideoCompleteAction;
		this.rewardedVideoNotAvailableAction = p_rewardedVideoNotAvailableAction;
		if (this.ENABLE_EDITOR_TESTING && (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor))
		{
			if (this.rewardedVideoCompleteAction != null)
			{
				this.rewardedVideoCompleteAction();
			}
			return;
		}
		if (this.videoAdQueue.Count == 0)
		{
			if (this.forceRewardedVideo)
			{
				if (this.FORCEDVIDEOADTEMPLATE.GetType() == typeof(MRVungleImplementation))
				{
					MR.Log("VideoAd Queue Empty, Forcing Vungle Now");
					if (this.videoAdImplementsPrioritized != null)
					{
						this.videoAdImplementsPrioritized.Find((BasicAdNetwork asd) => asd.GetType() == typeof(MRVungleImplementation)).ShowForcedVideoAd();
					}
				}
				else if (this.FORCEDVIDEOADTEMPLATE.GetType() == typeof(MRUnityAdsImplementation))
				{
					MR.Log("VideoAd Queue Empty, Forcing Unity Now");
					if (this.videoAdImplementsPrioritized != null)
					{
						this.videoAdImplementsPrioritized.Find((BasicAdNetwork asd) => asd.GetType() == typeof(MRUnityAdsImplementation)).ShowForcedVideoAd();
					}
				}
			}
			else
			{
				this.RequestTopPriorityVideoAd();
				if (this.rewardedVideoNotAvailableAction != null)
				{
					this.rewardedVideoNotAvailableAction();
				}
			}
		}
		else
		{
			this.SetSoundOff();
			this.videoAdQueue[0].ShowVideoAd();
			if (MRUtilities.Instance)
			{
				MRUtilities.Instance.LogEvent(MRConstants.REWARDEDVIDEOSHOWN);
			}
			this.videoAdQueue.RemoveAt(0);
			this.RequestTopPriorityVideoAd();
		}
	}

	public void LogEvent(string p_name)
	{
       
	}

	public void LogEvent(string p_name, string p_parameterName, string p_value)
	{
      
    }

    public void LogScreen(string p_screenName)
	{
       
    }

    private void FetchImages(CrossPromoAdType p_cpat, bool p_isCons)
	{
		int num = 0;
		foreach (CrossPromoGame current in this.Games)
		{
			Param p = new Param(current, num++, p_cpat, p_isCons);
			base.StartCoroutine(this.FetchSingleImage(p));
		}
	}

	private IEnumerator FetchSingleImage(Param p)
	{
		MRUtilities._FetchSingleImage_c__Iterator6 _FetchSingleImage_c__Iterator = new MRUtilities._FetchSingleImage_c__Iterator6();
		_FetchSingleImage_c__Iterator.p = p;
		_FetchSingleImage_c__Iterator._this = this;
		return _FetchSingleImage_c__Iterator;
	}

	private void SetVideoOnCanvas(CrossPromoGame p_game, bool p_isCons)
	{
		if (this.crossPromoVideoHolder != null)
		{
			string url = Application.persistentDataPath + "/" + p_game.videoName;
			this.crossPromoVideoPlayer.url = url;
			this.crossPromoVideoHolder.transform.Find("Text_Label_Name").GetComponent<Text>().text = p_game.Name;
			if (p_isCons)
			{
				this.ShowCrossPromo();
			}
			foreach (GameObject current in this.customVideoCrossPromoObjects)
			{
				if (current != null)
				{
					this.crossPromoVideoPlayer.Play();
					current.transform.GetChild(0).Find("Text_Label_Name").GetComponent<Text>().text = p_game.Name;
					current.SetActive(true);
				}
			}
		}
	}

	private IEnumerator SetBannerOnCanvas(CrossPromoGame game, CrossPromoAdType p_cpat, bool p_isCons)
	{
		MRUtilities._SetBannerOnCanvas_c__Iterator7 _SetBannerOnCanvas_c__Iterator = new MRUtilities._SetBannerOnCanvas_c__Iterator7();
		_SetBannerOnCanvas_c__Iterator.p_isCons = p_isCons;
		_SetBannerOnCanvas_c__Iterator.p_cpat = p_cpat;
		_SetBannerOnCanvas_c__Iterator.game = game;
		_SetBannerOnCanvas_c__Iterator._this = this;
		return _SetBannerOnCanvas_c__Iterator;
	}

	public void ItemClicked()
	{
		CrossPromoGame crossPromoGame = this.Games[0];
		Application.OpenURL("market://details?id=" + crossPromoGame.Bundle);
		if (MRUtilities.Instance)
		{
			MRUtilities.Instance.LogEvent(MRConstants.CROSSPROMO, MRConstants.BANNERCLICKED, crossPromoGame.appID);
		}
	}

	public void ShowCrossPromo()
	{
		if (this.fetchedGameCrossPromoAdType == CrossPromoAdType.Video)
		{
			if (this.crossPromoVideoHolder)
			{
				this.crossPromoVideoHolder.SetActive(true);
				this.crossPromoVideoPlayer.Play();
				if (MRUtilities.Instance)
				{
					MRUtilities.Instance.LogEvent(MRConstants.CROSSPROMO, MRConstants.VIDEO, MRConstants.SHOWN);
				}
			}
		}
		else if (this.bannerCanvas)
		{
			this.bannerCanvas.SetActive(true);
			if (MRUtilities.Instance)
			{
				MRUtilities.Instance.LogEvent(MRConstants.CROSSPROMO, MRConstants.BANNER, MRConstants.SHOWN);
			}
		}
	}

	public void HideCrossPromo()
	{
		if (this.fetchedGameCrossPromoAdType == CrossPromoAdType.Video)
		{
			if (this.crossPromoVideoHolder && !this.local_isConsistent)
			{
				this.crossPromoVideoHolder.SetActive(false);
				MRUtilities.Instance.LogEvent(MRConstants.CROSSPROMO, MRConstants.VIDEO, MRConstants.HIDDEN);
			}
		}
		else if (this.bannerCanvas && !this.local_isConsistent)
		{
			this.bannerCanvas.SetActive(false);
			MRUtilities.Instance.LogEvent(MRConstants.CROSSPROMO, MRConstants.BANNER, MRConstants.HIDDEN);
		}
	}

	public void RateGame(bool p_rateControlled = false)
	{
		if (p_rateControlled)
		{
			this.RATECOUNTER++;
			if (this.RATECOUNTER == this.RATERATE)
			{
				this.RATECOUNTER = 0;
				if (!MRGame.Instance.rateClicked)
				{
					this.ShowRateGameDialogue();
				}
			}
		}
		else
		{
			this.ShowRateGameDialogue();
		}
	}

	private void ShowRateGameDialogue()
	{
		string url = "market://details?id=" + this.gameBundle;
		Application.OpenURL(url);
	}

	public void ShareOnSocialPlatform(SocialSharing.SocialSharingDelegate p_socialSharingSuccessCallBack, string p_title, string p_message, SocialPlatformEnum p_socialPlatform)
	{
		p_message = p_message + " https://www.mindravel.com/DownloadGame?gameID=" + this.gameBundle;
		MR.Log(p_message);
		SocialSharing.Instance.ShareOnSocialPlatform(p_socialSharingSuccessCallBack, p_title, p_message, p_socialPlatform);
	}
}
*/