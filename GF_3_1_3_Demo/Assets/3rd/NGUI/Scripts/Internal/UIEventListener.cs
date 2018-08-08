//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2015 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Event Hook class lets you easily add remote event listener functions to an object.
/// Example usage: UIEventListener.Get(gameObject).onClick += MyClickFunction;
/// </summary>

[AddComponentMenu("NGUI/Internal/Event Listener")]
public class UIEventListener : MonoBehaviour
{
	public delegate void VoidDelegate (GameObject go);
	public delegate void BoolDelegate (GameObject go, bool state);
	public delegate void FloatDelegate (GameObject go, float delta);
	public delegate void VectorDelegate (GameObject go, Vector2 delta);
	public delegate void ObjectDelegate (GameObject go, GameObject obj);
	public delegate void KeyCodeDelegate (GameObject go, KeyCode key);

	public object parameter;

	public VoidDelegate onSubmit;
	public VoidDelegate onClick;
	public VoidDelegate onDoubleClick;
	public BoolDelegate onHover;
	public BoolDelegate onPress;
	public BoolDelegate onSelect;
	public FloatDelegate onScroll;
	public VoidDelegate onDragStart;
	public VectorDelegate onDrag;
	public VoidDelegate onDragOver;
	public VoidDelegate onDragOut;
	public VoidDelegate onDragEnd;
	public ObjectDelegate onDrop;
	public KeyCodeDelegate onKey;
	public BoolDelegate onTooltip;

	void OnSubmit ()				{ if (onSubmit != null) onSubmit(gameObject); }
	void OnClick ()					{ if (onClick != null) onClick(gameObject); }
	void OnDoubleClick ()			{ if (onDoubleClick != null) onDoubleClick(gameObject); }
	void OnHover (bool isOver)		{ if (onHover != null) onHover(gameObject, isOver); }
	void OnPress (bool isPressed)	{ if (onPress != null) onPress(gameObject, isPressed); }
	void OnSelect (bool selected)	{ if (onSelect != null) onSelect(gameObject, selected); }
	void OnScroll (float delta)		{ if (onScroll != null) onScroll(gameObject, delta); }
	void OnDragStart ()				{ if (onDragStart != null) onDragStart(gameObject); }
	void OnDrag (Vector2 delta)		{ if (onDrag != null) onDrag(gameObject, delta); }
	void OnDragOver ()				{ if (onDragOver != null) onDragOver(gameObject); }
	void OnDragOut ()				{ if (onDragOut != null) onDragOut(gameObject); }
	void OnDragEnd ()				{ if (onDragEnd != null) onDragEnd(gameObject); }
	void OnDrop (GameObject go)		{ if (onDrop != null) onDrop(gameObject, go); }
	void OnKey (KeyCode key)		{ if (onKey != null) onKey(gameObject, key); }
	void OnTooltip (bool show)		{ if (onTooltip != null) onTooltip(gameObject, show); }

	/// <summary>
	/// Get or add an event listener to the specified game object.
	/// </summary>

	static public UIEventListener Get (GameObject go)
	{
		UIEventListener listener = go.GetComponent<UIEventListener>();
		if (listener == null) listener = go.AddComponent<UIEventListener>();
		return listener;
	}
}
