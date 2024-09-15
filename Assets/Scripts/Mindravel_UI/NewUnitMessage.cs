using MergeFactory;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Mindravel.UI
{
	public class NewUnitMessage : MonoBehaviour
	{
		public Image unit_Image;

		public Text unitName_Text;

		public void ShowMessage(Unit unit)
		{
			this.unit_Image.sprite = UnitManager.instance.itemUnlockedSprites[unit.id];
			this.unit_Image.SetNativeSize();
			this.unitName_Text.text = unit.name;
		}
	}
}
