﻿//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2015 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// This script can be used to restrict camera rendering to a specific part of the screen by specifying the two corners.
/// </summary>

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/UI/Viewport Camera")]
public class UIViewport : MonoBehaviour
{
	public Camera sourceCamera;
	public Transform topLeft;
	public Transform bottomRight;
	public float fullSize = 1f;

	Camera mCam;

	void Start ()
	{
#if UNITY_4_3 || UNITY_4_5 || UNITY_4_6
		mCam = camera;
#else
		mCam = GetComponent<Camera>();
#endif
		if (sourceCamera == null) sourceCamera = Camera.main;
	}

	void LateUpdate ()
	{
		if (topLeft != null && bottomRight != null)
		{
			Vector3 tl = sourceCamera.WorldToScreenPoint(topLeft.position);
			Vector3 br = sourceCamera.WorldToScreenPoint(bottomRight.position);

			Rect rect = new Rect(tl.x / Screen.width, br.y / Screen.height,
				(br.x - tl.x) / Screen.width, (tl.y - br.y) / Screen.height);

			float size = fullSize * rect.height;

			if (rect != mCam.rect) mCam.rect = rect;
			if (mCam.orthographicSize != size) mCam.orthographicSize = size;
		}
	}
}