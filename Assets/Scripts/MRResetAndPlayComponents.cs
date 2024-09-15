using System;
using System.Collections.Generic;
using UnityEngine;

public class MRResetAndPlayComponents : MonoBehaviour
{
	public List<TweenScale> tweenScaleComponents;

	public List<TweenPosition> tweenPositionComponents;

	public List<TweenRotation> tweenRotationComponents;

	public List<TweenAlpha> tweenAlphaComponents;

	private void OnEnable()
	{
		foreach (TweenScale current in this.tweenScaleComponents)
		{
			current.ResetToBeginning();
			current.PlayForward();
		}
		foreach (TweenPosition current2 in this.tweenPositionComponents)
		{
			current2.ResetToBeginning();
			current2.PlayForward();
		}
		foreach (TweenRotation current3 in this.tweenRotationComponents)
		{
			current3.ResetToBeginning();
			current3.PlayForward();
		}
		foreach (TweenAlpha current4 in this.tweenAlphaComponents)
		{
			current4.ResetToBeginning();
			current4.PlayForward();
		}
	}
}
