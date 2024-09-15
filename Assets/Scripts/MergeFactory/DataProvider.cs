using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MergeFactory
{
	public class DataProvider : MonoBehaviour
	{
		public static DataProvider instance;

		public GameData gameData;

		public List<SlotData> slots = new List<SlotData>();

		public List<Unit> units = new List<Unit>();

		public List<Sprite> sprites = new List<Sprite>();

		private void Awake()
		{
			DataProvider.instance = this;
		}

		public void TestCurrency(float freecoins)
		{
			this.gameData.playerCoins += freecoins;
		}

		public void SetSprites()
		{
			for (int i = 0; i < this.sprites.Count; i++)
			{
				this.units[i].sprite = this.sprites[i];
			}
		}

		public void ResetANDRestart()
		{
			this.ResetData();
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

		public void ResetData()
		{
			for (int i = 0; i < this.slots.Count; i++)
			{
				this.slots[i].Reset();
			}
			for (int j = 0; j < this.units.Count; j++)
			{
				this.units[j].Reset();
			}
			PlayerPrefs.DeleteAll();
		}
	}
}
