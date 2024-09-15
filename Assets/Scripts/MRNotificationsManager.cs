using MergeFactory;
//using PartaGames.Android;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MRNotificationsManager : MonoBehaviour
{
	public static MRNotificationsManager Instance;

	private string DEFAULT_NOTIFICATION_CHANNEL = "MRDefaultChannel";

	private string THEME_TEXT = "Plants";

	private string CURRENCY_TEXT = "Coins";

	private string LAND_TEXT = "Land";

	private string BOX_TEXT = "Crates";

	private static Predicate<Unit> __f__am_cache0;

	private void Awake()
	{
		MRNotificationsManager.Instance = this;
	}

	private void Start()
	{
		//LocalNotificationUnity.CreateChannel(this.DEFAULT_NOTIFICATION_CHANNEL, "Default", this.DEFAULT_NOTIFICATION_CHANNEL);
	}

	private void OnApplicationPause(bool paused)
	{
		UnityEngine.Debug.Log("Application pause called");
		if (paused)
		{
			this.SetLocalNotification(20);
			this.SetLocalNotification(21);
			this.SetLocalNotification(22);
			this.SetLocalNotification(24);
		}
	}

	public void SetLocalNotification(int notificationID)
	{
		if (!TutorialManager.instance.TUT_1_COMPLETE)
		{
			return;
		}
		if (!SettingsManager.instance.LOCALNOTIFICATION)
		{
			//this.ResetLocalNotification(notificationID);
			return;
		}
        /*
		switch (notificationID)
		{
		case 20:
			this.ResetLocalNotification(notificationID);
			LocalNotificationUnity.SendNotification(this.DEFAULT_NOTIFICATION_CHANNEL, "Merge Your " + this.THEME_TEXT, "It’s been a while. Those " + this.THEME_TEXT + " won’t merge themselves!", DateTime.Now.AddHours(12.0), "default", notificationID);
			break;
		case 21:
			this.ResetLocalNotification(notificationID);
			LocalNotificationUnity.SendNotification(this.DEFAULT_NOTIFICATION_CHANNEL, "Bank Full", string.Concat(new string[]
			{
				"Your bank is full. Come back to spend your ",
				this.CURRENCY_TEXT,
				" and discover new ",
				this.THEME_TEXT,
				"!"
			}), DateTime.Now.AddHours(3.0), "default", notificationID);
			break;
		case 22:
			if (Time.time < 10f)
			{
				return;
			}
			this.ResetLocalNotification(notificationID);
			if (GridManager.instance.FREESLOTS > 0)
			{
				LocalNotificationUnity.SendNotification(this.DEFAULT_NOTIFICATION_CHANNEL, string.Empty + this.LAND_TEXT + " Full", string.Concat(new string[]
				{
					"Your ",
					this.LAND_TEXT,
					" are full. So many ",
					this.BOX_TEXT,
					" to open!"
				}), DateTime.Now.AddMinutes(30.0), "default", notificationID);
			}
			break;
		case 23:
			this.ResetLocalNotification(notificationID);
			LocalNotificationUnity.SendNotification(this.DEFAULT_NOTIFICATION_CHANNEL, "Free Gift", "Your free gift box is ready in the store. Tap to open!", DateTime.Now.AddHours(1.0), "default", notificationID);
			break;
		case 24:
			if (DataProvider.instance.units.FindAll((Unit asd) => asd.status == UnitStatus.unlocked).Count <= 33)
			{
				this.ResetLocalNotification(notificationID);
				LocalNotificationUnity.SendNotification(this.DEFAULT_NOTIFICATION_CHANNEL, "Hey!", "Don't you wanna unlock the next plant? Tap, Merge and find out", DateTime.Now.AddHours(30.0), "default", notificationID);
			}
			break;
			       
		  }
		*/      
	}

	public void ResetLocalNotification(int notificationID)
	{
		//LocalNotificationUnity.CancelNotification(notificationID);
	}
}
