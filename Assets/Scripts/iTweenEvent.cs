using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class iTweenEvent : MonoBehaviour
{
	public enum TweenType
	{
		AudioFrom,
		AudioTo,
		AudioUpdate,
		CameraFadeFrom,
		CameraFadeTo,
		ColorFrom,
		ColorTo,
		ColorUpdate,
		FadeFrom,
		FadeTo,
		FadeUpdate,
		LookFrom,
		LookTo,
		LookUpdate,
		MoveAdd,
		MoveBy,
		MoveFrom,
		MoveTo,
		MoveUpdate,
		PunchPosition,
		PunchRotation,
		PunchScale,
		RotateAdd,
		RotateBy,
		RotateFrom,
		RotateTo,
		RotateUpdate,
		ScaleAdd,
		ScaleBy,
		ScaleFrom,
		ScaleTo,
		ScaleUpdate,
		ShakePosition,
		ShakeRotation,
		ShakeScale,
		Stab
	}

	private sealed class _GetEvent_c__AnonStorey1
	{
		internal string name;

		internal bool __m__0(iTweenEvent tween)
		{
			return tween.tweenName == this.name;
		}
	}

	private sealed class _StartEvent_c__Iterator0 : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal Hashtable _optionsHash___0;

		internal Dictionary<string, object>.Enumerator _locvar0;

		internal iTweenEvent _this;

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

		public _StartEvent_c__Iterator0()
		{
		}

		public bool MoveNext()
		{
			uint num = (uint)this._PC;
			this._PC = -1;
			switch (num)
			{
			case 0u:
				if (this._this.delay > 0f)
				{
					this._current = new WaitForSeconds(this._this.delay);
					if (!this._disposing)
					{
						this._PC = 1;
					}
					return true;
				}
				break;
			case 1u:
				break;
			case 2u:
				goto IL_8F;
			default:
				return false;
			}
			if (this._this.stopped)
			{
				this._current = null;
				if (!this._disposing)
				{
					this._PC = 2;
				}
				return true;
			}
			IL_8F:
			this._optionsHash___0 = new Hashtable();
			this._locvar0 = this._this.Values.GetEnumerator();
			try
			{
				while (this._locvar0.MoveNext())
				{
					KeyValuePair<string, object> current = this._locvar0.Current;
					if ("path" == current.Key && current.Value.GetType() == typeof(string))
					{
						this._optionsHash___0.Add(current.Key, iTweenPath.GetPath((string)current.Value));
					}
					else
					{
						this._optionsHash___0.Add(current.Key, current.Value);
					}
				}
			}
			finally
			{
				((IDisposable)this._locvar0).Dispose();
			}
			this._this.internalName = ((!string.IsNullOrEmpty(this._this.tweenName)) ? this._this.tweenName : string.Empty);
			this._this.internalName = string.Format("{0}-{1}", this._this.internalName, Guid.NewGuid().ToString());
			this._optionsHash___0.Add("name", this._this.internalName);
			switch (this._this.type)
			{
			case iTweenEvent.TweenType.AudioFrom:
				iTween.AudioFrom(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.AudioTo:
				iTween.AudioTo(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.AudioUpdate:
				iTween.AudioUpdate(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.CameraFadeFrom:
				iTween.CameraFadeFrom(this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.CameraFadeTo:
				iTween.CameraFadeTo(this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.ColorFrom:
				iTween.ColorFrom(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.ColorTo:
				iTween.ColorTo(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.ColorUpdate:
				iTween.ColorUpdate(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.FadeFrom:
				iTween.FadeFrom(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.FadeTo:
				iTween.FadeTo(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.FadeUpdate:
				iTween.FadeUpdate(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.LookFrom:
				iTween.LookFrom(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.LookTo:
				iTween.LookTo(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.LookUpdate:
				iTween.LookUpdate(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.MoveAdd:
				iTween.MoveAdd(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.MoveBy:
				iTween.MoveBy(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.MoveFrom:
				iTween.MoveFrom(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.MoveTo:
				iTween.MoveTo(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.MoveUpdate:
				iTween.MoveUpdate(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.PunchPosition:
				iTween.PunchPosition(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.PunchRotation:
				iTween.PunchRotation(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.PunchScale:
				iTween.PunchScale(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.RotateAdd:
				iTween.RotateAdd(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.RotateBy:
				iTween.RotateBy(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.RotateFrom:
				iTween.RotateFrom(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.RotateTo:
				iTween.RotateTo(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.RotateUpdate:
				iTween.RotateUpdate(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.ScaleAdd:
				iTween.ScaleAdd(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.ScaleBy:
				iTween.ScaleBy(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.ScaleFrom:
				iTween.ScaleFrom(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.ScaleTo:
				iTween.ScaleTo(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.ScaleUpdate:
				iTween.ScaleUpdate(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.ShakePosition:
				iTween.ShakePosition(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.ShakeRotation:
				iTween.ShakeRotation(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.ShakeScale:
				iTween.ShakeScale(this._this.gameObject, this._optionsHash___0);
				break;
			case iTweenEvent.TweenType.Stab:
				iTween.Stab(this._this.gameObject, this._optionsHash___0);
				break;
			default:
				throw new ArgumentException("Invalid tween type: " + this._this.type);
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

	public const string VERSION = "0.6.1";

	public string tweenName = string.Empty;

	public bool playAutomatically = true;

	public float delay;

	public iTweenEvent.TweenType type = iTweenEvent.TweenType.MoveTo;

	public bool showIconInInspector = true;

	[SerializeField]
	private string[] keys;

	[SerializeField]
	private int[] indexes;

	[SerializeField]
	private string[] metadatas;

	[SerializeField]
	private int[] ints;

	[SerializeField]
	private float[] floats;

	[SerializeField]
	private bool[] bools;

	[SerializeField]
	private string[] strings;

	[SerializeField]
	private Vector3[] vector3s;

	[SerializeField]
	private Color[] colors;

	[SerializeField]
	private Space[] spaces;

	[SerializeField]
	private iTween.EaseType[] easeTypes;

	[SerializeField]
	private iTween.LoopType[] loopTypes;

	[SerializeField]
	private GameObject[] gameObjects;

	[SerializeField]
	private Transform[] transforms;

	[SerializeField]
	private AudioClip[] audioClips;

	[SerializeField]
	private AudioSource[] audioSources;

	[SerializeField]
	private ArrayIndexes[] vector3Arrays;

	[SerializeField]
	private ArrayIndexes[] transformArrays;

	[SerializeField]
	private iTweenPath[] paths;

	private Dictionary<string, object> values;

	private bool stopped;

	private iTween instantiatedTween;

	private string internalName;

	public Dictionary<string, object> Values
	{
		get
		{
			if (this.values == null)
			{
				this.DeserializeValues();
			}
			return this.values;
		}
		set
		{
			this.values = value;
			this.SerializeValues();
		}
	}

	public static iTweenEvent GetEvent(GameObject obj, string name)
	{
		iTweenEvent[] components = obj.GetComponents<iTweenEvent>();
		if (components.Length > 0)
		{
			iTweenEvent iTweenEvent = components.FirstOrDefault((iTweenEvent tween) => tween.tweenName == name);
			if (iTweenEvent != null)
			{
				return iTweenEvent;
			}
		}
		throw new ArgumentException(string.Concat(new string[]
		{
			"No tween with the name '",
			name,
			"' could be found on the GameObject named '",
			obj.name,
			"'"
		}));
	}

	public void Start()
	{
		if (this.playAutomatically)
		{
			this.Play();
		}
	}

	public void Play()
	{
		if (!string.IsNullOrEmpty(this.internalName))
		{
			this.Stop();
		}
		this.stopped = false;
		base.StartCoroutine(this.StartEvent());
	}

	public void Stop()
	{
		iTween.StopByName(base.gameObject, this.internalName);
		this.internalName = string.Empty;
		this.stopped = true;
	}

	public void OnDrawGizmos()
	{
		if (this.showIconInInspector)
		{
			Gizmos.DrawIcon(base.transform.position, "iTweenIcon.tif");
		}
	}

	private IEnumerator StartEvent()
	{
		iTweenEvent._StartEvent_c__Iterator0 _StartEvent_c__Iterator = new iTweenEvent._StartEvent_c__Iterator0();
		_StartEvent_c__Iterator._this = this;
		return _StartEvent_c__Iterator;
	}

	private void SerializeValues()
	{
		List<string> list = new List<string>();
		List<int> list2 = new List<int>();
		List<string> list3 = new List<string>();
		List<int> list4 = new List<int>();
		List<float> list5 = new List<float>();
		List<bool> list6 = new List<bool>();
		List<string> list7 = new List<string>();
		List<Vector3> list8 = new List<Vector3>();
		List<Color> list9 = new List<Color>();
		List<Space> list10 = new List<Space>();
		List<iTween.EaseType> list11 = new List<iTween.EaseType>();
		List<iTween.LoopType> list12 = new List<iTween.LoopType>();
		List<GameObject> list13 = new List<GameObject>();
		List<Transform> list14 = new List<Transform>();
		List<AudioClip> list15 = new List<AudioClip>();
		List<AudioSource> list16 = new List<AudioSource>();
		List<ArrayIndexes> list17 = new List<ArrayIndexes>();
		List<ArrayIndexes> list18 = new List<ArrayIndexes>();
		foreach (KeyValuePair<string, object> current in this.values)
		{
			Dictionary<string, Type> dictionary = EventParamMappings.mappings[this.type];
			Type type = dictionary[current.Key];
			if (typeof(int) == type)
			{
				this.AddToList<int>(list, list2, list4, list3, current);
			}
			if (typeof(float) == type)
			{
				this.AddToList<float>(list, list2, list5, list3, current);
			}
			else if (typeof(bool) == type)
			{
				this.AddToList<bool>(list, list2, list6, list3, current);
			}
			else if (typeof(string) == type)
			{
				this.AddToList<string>(list, list2, list7, list3, current);
			}
			else if (typeof(Vector3) == type)
			{
				this.AddToList<Vector3>(list, list2, list8, list3, current);
			}
			else if (typeof(Color) == type)
			{
				this.AddToList<Color>(list, list2, list9, list3, current);
			}
			else if (typeof(Space) == type)
			{
				this.AddToList<Space>(list, list2, list10, list3, current);
			}
			else if (typeof(iTween.EaseType) == type)
			{
				this.AddToList<iTween.EaseType>(list, list2, list11, list3, current);
			}
			else if (typeof(iTween.LoopType) == type)
			{
				this.AddToList<iTween.LoopType>(list, list2, list12, list3, current);
			}
			else if (typeof(GameObject) == type)
			{
				this.AddToList<GameObject>(list, list2, list13, list3, current);
			}
			else if (typeof(Transform) == type)
			{
				this.AddToList<Transform>(list, list2, list14, list3, current);
			}
			else if (typeof(AudioClip) == type)
			{
				this.AddToList<AudioClip>(list, list2, list15, list3, current);
			}
			else if (typeof(AudioSource) == type)
			{
				this.AddToList<AudioSource>(list, list2, list16, list3, current);
			}
			else if (typeof(Vector3OrTransform) == type)
			{
				if (current.Value == null || typeof(Transform) == current.Value.GetType())
				{
					this.AddToList<Transform>(list, list2, list14, list3, current.Key, current.Value, "t");
				}
				else
				{
					this.AddToList<Vector3>(list, list2, list8, list3, current.Key, current.Value, "v");
				}
			}
			else if (typeof(Vector3OrTransformArray) == type)
			{
				if (typeof(Vector3[]) == current.Value.GetType())
				{
					Vector3[] array = (Vector3[])current.Value;
					ArrayIndexes arrayIndexes = new ArrayIndexes();
					int[] array2 = new int[array.Length];
					for (int i = 0; i < array.Length; i++)
					{
						list8.Add(array[i]);
						array2[i] = list8.Count - 1;
					}
					arrayIndexes.indexes = array2;
					this.AddToList<ArrayIndexes>(list, list2, list17, list3, current.Key, arrayIndexes, "v");
				}
				else if (typeof(Transform[]) == current.Value.GetType())
				{
					Transform[] array3 = (Transform[])current.Value;
					ArrayIndexes arrayIndexes2 = new ArrayIndexes();
					int[] array4 = new int[array3.Length];
					for (int j = 0; j < array3.Length; j++)
					{
						list14.Add(array3[j]);
						array4[j] = list14.Count - 1;
					}
					arrayIndexes2.indexes = array4;
					this.AddToList<ArrayIndexes>(list, list2, list18, list3, current.Key, arrayIndexes2, "t");
				}
				else if (typeof(string) == current.Value.GetType())
				{
					this.AddToList<string>(list, list2, list7, list3, current.Key, current.Value, "p");
				}
			}
		}
		this.keys = list.ToArray();
		this.indexes = list2.ToArray();
		this.metadatas = list3.ToArray();
		this.ints = list4.ToArray();
		this.floats = list5.ToArray();
		this.bools = list6.ToArray();
		this.strings = list7.ToArray();
		this.vector3s = list8.ToArray();
		this.colors = list9.ToArray();
		this.spaces = list10.ToArray();
		this.easeTypes = list11.ToArray();
		this.loopTypes = list12.ToArray();
		this.gameObjects = list13.ToArray();
		this.transforms = list14.ToArray();
		this.audioClips = list15.ToArray();
		this.audioSources = list16.ToArray();
		this.vector3Arrays = list17.ToArray();
		this.transformArrays = list18.ToArray();
	}

	private void AddToList<T>(List<string> keyList, List<int> indexList, IList<T> valueList, List<string> metadataList, KeyValuePair<string, object> pair)
	{
		this.AddToList<T>(keyList, indexList, valueList, metadataList, pair.Key, pair.Value);
	}

	private void AddToList<T>(List<string> keyList, List<int> indexList, IList<T> valueList, List<string> metadataList, KeyValuePair<string, object> pair, string metadata)
	{
		this.AddToList<T>(keyList, indexList, valueList, metadataList, pair.Key, pair.Value, metadata);
	}

	private void AddToList<T>(List<string> keyList, List<int> indexList, IList<T> valueList, List<string> metadataList, string key, object value)
	{
		this.AddToList<T>(keyList, indexList, valueList, metadataList, key, value, null);
	}

	private void AddToList<T>(List<string> keyList, List<int> indexList, IList<T> valueList, List<string> metadataList, string key, object value, string metadata)
	{
		keyList.Add(key);
		valueList.Add((T)((object)value));
		indexList.Add(valueList.Count - 1);
		metadataList.Add(metadata);
	}

	private void DeserializeValues()
	{
		this.values = new Dictionary<string, object>();
		if (this.keys == null)
		{
			return;
		}
		for (int i = 0; i < this.keys.Length; i++)
		{
			Dictionary<string, Type> dictionary = EventParamMappings.mappings[this.type];
			Type type = dictionary[this.keys[i]];
			if (typeof(int) == type)
			{
				this.values.Add(this.keys[i], this.ints[this.indexes[i]]);
			}
			else if (typeof(float) == type)
			{
				this.values.Add(this.keys[i], this.floats[this.indexes[i]]);
			}
			else if (typeof(bool) == type)
			{
				this.values.Add(this.keys[i], this.bools[this.indexes[i]]);
			}
			else if (typeof(string) == type)
			{
				this.values.Add(this.keys[i], this.strings[this.indexes[i]]);
			}
			else if (typeof(Vector3) == type)
			{
				this.values.Add(this.keys[i], this.vector3s[this.indexes[i]]);
			}
			else if (typeof(Color) == type)
			{
				this.values.Add(this.keys[i], this.colors[this.indexes[i]]);
			}
			else if (typeof(Space) == type)
			{
				this.values.Add(this.keys[i], this.spaces[this.indexes[i]]);
			}
			else if (typeof(iTween.EaseType) == type)
			{
				this.values.Add(this.keys[i], this.easeTypes[this.indexes[i]]);
			}
			else if (typeof(iTween.LoopType) == type)
			{
				this.values.Add(this.keys[i], this.loopTypes[this.indexes[i]]);
			}
			else if (typeof(GameObject) == type)
			{
				this.values.Add(this.keys[i], this.gameObjects[this.indexes[i]]);
			}
			else if (typeof(Transform) == type)
			{
				this.values.Add(this.keys[i], this.transforms[this.indexes[i]]);
			}
			else if (typeof(AudioClip) == type)
			{
				this.values.Add(this.keys[i], this.audioClips[this.indexes[i]]);
			}
			else if (typeof(AudioSource) == type)
			{
				this.values.Add(this.keys[i], this.audioSources[this.indexes[i]]);
			}
			else if (typeof(Vector3OrTransform) == type)
			{
				if ("v" == this.metadatas[i])
				{
					this.values.Add(this.keys[i], this.vector3s[this.indexes[i]]);
				}
				else if ("t" == this.metadatas[i])
				{
					this.values.Add(this.keys[i], this.transforms[this.indexes[i]]);
				}
			}
			else if (typeof(Vector3OrTransformArray) == type)
			{
				if ("v" == this.metadatas[i])
				{
					ArrayIndexes arrayIndexes = this.vector3Arrays[this.indexes[i]];
					Vector3[] array = new Vector3[arrayIndexes.indexes.Length];
					for (int j = 0; j < arrayIndexes.indexes.Length; j++)
					{
						array[j] = this.vector3s[arrayIndexes.indexes[j]];
					}
					this.values.Add(this.keys[i], array);
				}
				else if ("t" == this.metadatas[i])
				{
					ArrayIndexes arrayIndexes2 = this.transformArrays[this.indexes[i]];
					Transform[] array2 = new Transform[arrayIndexes2.indexes.Length];
					for (int k = 0; k < arrayIndexes2.indexes.Length; k++)
					{
						array2[k] = this.transforms[arrayIndexes2.indexes[k]];
					}
					this.values.Add(this.keys[i], array2);
				}
				else if ("p" == this.metadatas[i])
				{
					this.values.Add(this.keys[i], this.strings[this.indexes[i]]);
				}
			}
		}
	}
}
