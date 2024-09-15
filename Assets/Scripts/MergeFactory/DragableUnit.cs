using Mindravel.UI;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MergeFactory
{
	public class DragableUnit : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IEventSystemHandler
	{
		public static bool itemBeingDrag;

		public static GameObject itemBeingDraged;

		public static float itemDragedPerSecondReward;

		public CoinPopUp coinPopUp;

		private CanvasGroup canvasGroup;

		private Slot startSlot;

		private Slot targetSlot;

		public Unit unit;

		public TweenScale unitUpdatedTween;

		private bool draging;

		private Vector3 mousePos;

		private bool pressedInPlace;

		private float pressedInPlaceTime;

		private int touchIDToConsider;

		private Vector3 coinPopupScale;

		private float currentTime;

		public Image image
		{
			get
			{
				return base.transform.GetChild(1).GetComponent<Image>();
			}
		}

		public Slot currentSlot
		{
			get
			{
				return base.GetComponentInParent<Slot>();
			}
		}

		public void AdjustSize()
		{
			this.coinPopUp.GetComponent<RectTransform>().localScale = this.coinPopupScale * (CustomGridLayout.instance.CURRENT_BOXSIZE.x / 200f);
			base.GetComponent<RectTransform>().sizeDelta = CustomGridLayout.instance.CURRENT_BOXSIZE;
			this.image.GetComponent<RectTransform>().sizeDelta = CustomGridLayout.instance.CURRENT_ELEMENTSIZE;
		}

		public void OnMouseDown()
		{
			this.pressedInPlace = true;
			this.targetSlot = GridManager.instance.GetDestination(base.transform.position);
			this.startSlot = base.GetComponentInParent<Slot>();
			GridManager.instance.HighlightTargets(this.unit.id, this.startSlot);
		}

		public void OnMouseUp()
		{
			this.HideInformation();
			GridManager.instance.ResetGrid();
		}

		private void HideInformation()
		{
			this.pressedInPlace = false;
			this.pressedInPlaceTime = 0f;
			GUIManager.Instance.HideItemInformation();
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			this.HideInformation();
			if (DragableUnit.itemBeingDraged != null)
			{
				return;
			}
			DragableUnit.itemBeingDraged = base.gameObject;
			DragableUnit.itemDragedPerSecondReward = this.unit.perSecondReward;
			DragableUnit.itemBeingDrag = true;
			this.draging = true;
			this.startSlot = base.GetComponentInParent<Slot>();
			this.canvasGroup.blocksRaycasts = false;
			GridManager.instance.slotNotFree = this.startSlot;
			base.transform.SetParent(base.transform.root);
		}

		public void OnDrag(PointerEventData eventData)
		{
			this.HideInformation();
			if (!this.draging)
			{
				return;
			}
			this.mousePos = eventData.position;
			this.mousePos.z = 100f;
			base.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(this.mousePos.x, this.mousePos.y - 80f, this.mousePos.z));
			this.targetSlot = GridManager.instance.GetDestination(Camera.main.ScreenToWorldPoint(this.mousePos));
			GridManager.instance.HighlightTargets(this.unit.id, this.startSlot);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			this.HideInformation();
			if (!this.draging)
			{
				return;
			}
			DragableUnit.itemBeingDrag = false;
			DragableUnit.itemBeingDraged = null;
			DragableUnit.itemDragedPerSecondReward = 0f;
			SlotType type = this.targetSlot.type;
			if (type != SlotType.Empty)
			{
				if (type != SlotType.Box)
				{
					if (type == SlotType.Unit)
					{
						if (this.targetSlot.item == base.gameObject)
						{
							return;
						}
						if (this.targetSlot.item.GetComponent<DragableUnit>().unit.id == this.unit.id && this.unit.id < UnitManager.instance.units.Count - 1)
						{
							AchievementsManager.instance.IncrementAchievementEvent(AchievementType.MERGE);
							SFXManager.instance.PlaySound(Sound.Merge);
							UnityEngine.Object.Destroy(this.targetSlot.item);
							base.transform.SetParent(this.targetSlot.transform);
							base.transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
							int inc = this.unit.id + 1;
							if (!TutorialManager.instance.TUT_1_COMPLETE)
							{
								TutorialManager.instance.CompleteTask_TUT1();
							}
							this.unit = UnitManager.instance.units[this.unit.id + 1];
							ParticleManager.instance.LevelIncShowParticle(base.transform.position, inc);
							if (this.unit.status == UnitStatus.locked)
							{
								SFXManager.instance.PlaySound(Sound.NewItem);
								AchievementsManager.instance.IncrementAchievementEvent(AchievementType.UNLOCK);
								
								DataProvider.instance.gameData.highestUnitUnlocked = this.unit.id;
								this.unit.status = UnitStatus.unlocked;
								GUIManager.Instance.OpenScreenExplicitly(ScreenName.NewUnit);
								GUIManager.Instance.CURRENTPANEL.GetComponent<NewUnitMessage>().ShowMessage(this.unit);
								if (this.unit.id > DataProvider.instance.gameData.currentBoxLevel + 4)
								{
									StoreChangeIcon.Instance.ShowStoreChangeIcon(true);
								}
							}
							else if (!TutorialManager.instance.TUT_1_COMPLETE)
							{
								TutorialManager.instance.CloseNewUnitDLG();
							}
							this.currentSlot.slotData.unit = this.unit;
							this.currentSlot.slotData.type = SlotType.Unit;
							base.transform.Find("MergeShine").gameObject.SetActive(true);
							base.transform.Find("MergeShine").GetComponent<TweenRotation>().ResetToBeginning();
							base.transform.Find("MergeShine").GetComponent<TweenScale>().ResetToBeginning();
							base.transform.Find("MergeShine").GetComponent<TweenRotation>().PlayForward();
							base.transform.Find("MergeShine").GetComponent<TweenScale>().PlayForward();
							this.UpdateUnit();
						}
						else
						{
							this.targetSlot.item.transform.SetParent(this.startSlot.transform);
							this.startSlot.item.transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
							base.transform.SetParent(this.targetSlot.transform);
							base.transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
						}
					}
				}
				else
				{
					this.targetSlot.item.transform.SetParent(this.startSlot.transform);
					this.startSlot.item.transform.GetComponent<RectTransform>().anchoredPosition = BoxManager.instance.offset;
					base.transform.SetParent(this.targetSlot.transform);
					base.transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
				}
			}
			else
			{
				base.transform.SetParent(this.targetSlot.transform);
				base.transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
			}
			this.currentSlot.SaveData();
			this.draging = false;
			this.currentTime = 0f;
			this.canvasGroup.blocksRaycasts = true;
			GridManager.instance.slotNotFree = null;
			BoxManager.instance.FreeSlotCheck();
			GridManager.instance.ResetGrid();
			this.targetSlot.SaveData();
			this.startSlot.SaveData();
		}

		public void UpdateUnit()
		{
			if (this.unit)
			{
				this.coinPopUp.SetCoins(this.unit);
				this.image.sprite = this.unit.sprite;
				this.unitUpdatedTween.ResetToBeginning();
				this.unitUpdatedTween.PlayForward();
			}
		}

		private void RewardPlayer()
		{
			if (this.unit == null)
			{
				return;
			}
			DataProvider.instance.gameData.playerCoins += this.unit.rewardCoins;
			if (this.coinPopUp.coinText.text == string.Empty)
			{
				this.coinPopUp.SetCoins(this.unit);
			}
			if (!this.draging)
			{
				base.GetComponent<TweenScale>().enabled = true;
				this.coinPopUp.SetObjectActive(true);
			}
		}

		public void StartReward()
		{
			if (this.unit != null)
			{
				if (Time.timeSinceLevelLoad > 5f)
				{
					base.InvokeRepeating("RewardPlayer", this.unit.rewardTime, this.unit.rewardTime);
				}
				else
				{
					base.InvokeRepeating("RewardPlayer", UnityEngine.Random.Range(0.5f, 2.3f), this.unit.rewardTime);
				}
			}
		}

		private void Start()
		{
			this.UpdateUnit();
			this.coinPopupScale = this.coinPopUp.GetComponent<RectTransform>().localScale;
			this.coinPopUp.GetComponent<RectTransform>().localScale = this.coinPopupScale * (CustomGridLayout.instance.CURRENT_BOXSIZE.x / 200f);
			this.coinPopUp.SetObjectActive(false);
			this.canvasGroup = base.GetComponent<CanvasGroup>();
			base.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

		private void Update()
		{
			if (this.pressedInPlace)
			{
				this.pressedInPlaceTime += Time.deltaTime;
				if (this.pressedInPlaceTime > 0.35f)
				{
					GUIManager.Instance.ShowItemInformation(this.unit, base.gameObject.transform.position.y);
					this.pressedInPlace = false;
					this.pressedInPlaceTime = 0f;
				}
			}
			if (!this.draging)
			{
				this.currentTime += Time.deltaTime;
				if (this.currentTime > this.unit.rewardTime)
				{
					this.currentTime = 0f;
				}
			}
		}
	}
}
