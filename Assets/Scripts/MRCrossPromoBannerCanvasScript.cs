using System;
using UnityEngine;

public class MRCrossPromoBannerCanvasScript : MonoBehaviour
{
	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		if (UnityEngine.Object.FindObjectsOfType<MRCrossPromoBannerCanvasScript>().Length > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
	}

	public void BannerClicked()
	{
		//if (MRUtilities.Instance)
		{
		//MRUtilities.Instance.ItemClicked();
		}
	}
}
