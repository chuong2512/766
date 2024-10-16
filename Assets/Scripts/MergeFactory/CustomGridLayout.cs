using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MergeFactory
{
	public class CustomGridLayout : LayoutGroup
	{
		public static CustomGridLayout instance;

		[SerializeField]
		protected Corner m_StartCorner;

		[SerializeField]
		protected Axis m_StartAxis;

		[SerializeField]
		protected Vector2 m_CellSize = new Vector2(100f, 100f);

		[SerializeField]
		protected Vector2 m_Spacing = Vector2.zero;

		[SerializeField]
		protected Constraint m_Constraint;

		[SerializeField]
		protected int m_ConstraintCount = 2;

		public List<LayoutClass> layoutClass = new List<LayoutClass>();

		public LayoutClass currentLayoutClass;

		private Vector2 _elementSize = Vector2.zero;

		private Vector2 _boxSize = Vector2.zero;

		public Corner startCorner
		{
			get
			{
				return this.m_StartCorner;
			}
			set
			{
				base.SetProperty<Corner>(ref this.m_StartCorner, value);
			}
		}

		public Axis startAxis
		{
			get
			{
				return this.m_StartAxis;
			}
			set
			{
				base.SetProperty<Axis>(ref this.m_StartAxis, value);
			}
		}

		public Vector2 cellSize
		{
			get
			{
				return this.m_CellSize;
			}
			set
			{
				base.SetProperty<Vector2>(ref this.m_CellSize, value);
			}
		}

		public Vector2 spacing
		{
			get
			{
				return this.m_Spacing;
			}
			set
			{
				base.SetProperty<Vector2>(ref this.m_Spacing, value);
			}
		}

		public Constraint constraint
		{
			get
			{
				return this.m_Constraint;
			}
			set
			{
				base.SetProperty<Constraint>(ref this.m_Constraint, value);
			}
		}

		public int constraintCount
		{
			get
			{
				return this.m_ConstraintCount;
			}
			set
			{
				base.SetProperty<int>(ref this.m_ConstraintCount, Mathf.Max(1, value));
			}
		}

		public Vector2 CURRENT_BOXSIZE
		{
			get
			{
				return this.GetBoxSize();
			}
		}

		public Vector2 CURRENT_ELEMENTSIZE
		{
			get
			{
				return this.GetElementSize();
			}
		}

		protected CustomGridLayout()
		{
		}

		protected override void Awake()
		{
			base.Awake();
			CustomGridLayout.instance = this;
		}

		private Vector2 GetBoxSize()
		{
			for (int i = 0; i < this.layoutClass.Count; i++)
			{
				if (DataProvider.instance.gameData.maxGridSlots <= this.layoutClass[i].validChildCount)
				{
					return this.layoutClass[i].cellSize;
				}
			}
			return Vector2.zero;
		}

		private Vector2 GetElementSize()
		{
			for (int i = 0; i < this.layoutClass.Count; i++)
			{
				if (DataProvider.instance.gameData.maxGridSlots <= this.layoutClass[i].validChildCount)
				{
					return this.layoutClass[i].itemSize;
				}
			}
			return Vector2.zero;
		}

		private void CheckLayoutClass()
		{
			for (int i = 0; i < this.layoutClass.Count; i++)
			{
				if (base.rectChildren.Count <= this.layoutClass[i].validChildCount)
				{
					this.currentLayoutClass = this.layoutClass[i];
					break;
				}
			}
			if (this.currentLayoutClass != null)
			{
				this.constraintCount = this.currentLayoutClass.constraintCount;
				this.constraint = this.currentLayoutClass.constraint;
				this.cellSize = this.currentLayoutClass.cellSize;
				this.startAxis = this.currentLayoutClass.axis;
			}
		}

		public override void CalculateLayoutInputHorizontal()
		{
			this.CheckLayoutClass();
			base.CalculateLayoutInputHorizontal();
			int num2;
			int num;
			if (this.m_Constraint == Constraint.FixedColumnCount)
			{
				num = (num2 = this.m_ConstraintCount);
			}
			else if (this.m_Constraint == Constraint.FixedRowCount)
			{
				num = (num2 = Mathf.CeilToInt((float)base.rectChildren.Count / (float)this.m_ConstraintCount - 0.001f));
			}
			else
			{
				num2 = 1;
				num = Mathf.CeilToInt(Mathf.Sqrt((float)base.rectChildren.Count));
			}
			base.SetLayoutInputForAxis((float)base.padding.horizontal + (this.cellSize.x + this.spacing.x) * (float)num2 - this.spacing.x, (float)base.padding.horizontal + (this.cellSize.x + this.spacing.x) * (float)num - this.spacing.x, -1f, 0);
		}

		public override void CalculateLayoutInputVertical()
		{
			this.CheckLayoutClass();
			int num;
			if (this.m_Constraint == Constraint.FixedColumnCount)
			{
				num = Mathf.CeilToInt((float)base.rectChildren.Count / (float)this.m_ConstraintCount - 0.001f);
			}
			else if (this.m_Constraint == Constraint.FixedRowCount)
			{
				num = this.m_ConstraintCount;
			}
			else
			{
				float x = base.rectTransform.rect.size.x;
				int num2 = Mathf.Max(1, Mathf.FloorToInt((x - (float)base.padding.horizontal + this.spacing.x + 0.001f) / (this.cellSize.x + this.spacing.x)));
				num = Mathf.CeilToInt((float)base.rectChildren.Count / (float)num2);
			}
			float num3 = (float)base.padding.vertical + (this.cellSize.y + this.spacing.y) * (float)num - this.spacing.y;
			base.SetLayoutInputForAxis(num3, num3, -1f, 1);
		}

		public override void SetLayoutHorizontal()
		{
			this.CheckLayoutClass();
			this.SetCellsAlongAxis(0);
		}

		public override void SetLayoutVertical()
		{
			this.CheckLayoutClass();
			this.SetCellsAlongAxis(1);
		}

		private void SetCellsAlongAxis(int axis)
		{
			if (axis == 0)
			{
				for (int i = 0; i < base.rectChildren.Count; i++)
				{
					RectTransform rectTransform = base.rectChildren[i];
					this.m_Tracker.Add(this, rectTransform, DrivenTransformProperties.AnchoredPositionX | DrivenTransformProperties.AnchoredPositionY | DrivenTransformProperties.AnchorMinX | DrivenTransformProperties.AnchorMinY | DrivenTransformProperties.AnchorMaxX | DrivenTransformProperties.AnchorMaxY | DrivenTransformProperties.SizeDeltaX | DrivenTransformProperties.SizeDeltaY);
					rectTransform.anchorMin = Vector2.up;
					rectTransform.anchorMax = Vector2.up;
					rectTransform.sizeDelta = this.cellSize;
				}
				return;
			}
			float x = base.rectTransform.rect.size.x;
			float y = base.rectTransform.rect.size.y;
			int num;
			int num2;
			if (this.m_Constraint == Constraint.FixedColumnCount)
			{
				num = this.m_ConstraintCount;
				num2 = Mathf.CeilToInt((float)base.rectChildren.Count / (float)num - 0.001f);
			}
			else if (this.m_Constraint == Constraint.FixedRowCount)
			{
				num2 = this.m_ConstraintCount;
				num = Mathf.CeilToInt((float)base.rectChildren.Count / (float)num2 - 0.001f);
			}
			else
			{
				if (this.cellSize.x + this.spacing.x <= 0f)
				{
					num = 2147483647;
				}
				else
				{
					num = Mathf.Max(1, Mathf.FloorToInt((x - (float)base.padding.horizontal + this.spacing.x + 0.001f) / (this.cellSize.x + this.spacing.x)));
				}
				if (this.cellSize.y + this.spacing.y <= 0f)
				{
					num2 = 2147483647;
				}
				else
				{
					num2 = Mathf.Max(1, Mathf.FloorToInt((y - (float)base.padding.vertical + this.spacing.y + 0.001f) / (this.cellSize.y + this.spacing.y)));
				}
			}
			int num3 = (int)((int)this.startCorner % (int)Corner.LowerLeft);
			int num4 = (int)((int)this.startCorner / (int)Corner.LowerLeft);
			int num5;
			int num6;
			int num7;
			if (this.startAxis == Axis.Horizontal)
			{
				num5 = num;
				num6 = Mathf.Clamp(num, 1, base.rectChildren.Count);
				num7 = Mathf.Clamp(num2, 1, Mathf.CeilToInt((float)base.rectChildren.Count / (float)num5));
			}
			else
			{
				num5 = num2;
				num7 = Mathf.Clamp(num2, 1, base.rectChildren.Count);
				num6 = Mathf.Clamp(num, 1, Mathf.CeilToInt((float)base.rectChildren.Count / (float)num5));
			}
			Vector2 vector = new Vector2((float)num6 * this.cellSize.x + (float)(num6 - 1) * this.spacing.x, (float)num7 * this.cellSize.y + (float)(num7 - 1) * this.spacing.y);
			Vector2 vector2 = new Vector2(base.GetStartOffset(0, vector.x), base.GetStartOffset(1, vector.y));
			for (int j = 0; j < base.rectChildren.Count; j++)
			{
				int num8;
				int num9;
				if (this.startAxis == Axis.Horizontal)
				{
					num8 = j % num5;
					num9 = j / num5;
				}
				else
				{
					num8 = j / num5;
					num9 = j % num5;
				}
				if (num3 == 1)
				{
					num8 = num6 - 1 - num8;
				}
				if (num4 == 1)
				{
					num9 = num7 - 1 - num9;
				}
				base.SetChildAlongAxis(base.rectChildren[j], 0, vector2.x + (this.cellSize[0] + this.spacing[0]) * (float)num8, this.cellSize[0]);
				base.SetChildAlongAxis(base.rectChildren[j], 1, vector2.y + (this.cellSize[1] + this.spacing[1]) * (float)num9, this.cellSize[1]);
			}
		}
	}
}
