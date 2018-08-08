//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2015 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(UIToggle))]
public class UIToggleInspector : UIWidgetContainerEditor
{
	enum Transition
	{
		Smooth,
		Instant,
	}

	public override void OnInspectorGUI ()
	{
		serializedObject.Update();

		NGUIEditorTools.SetLabelWidth(100f);
		UIToggle toggle = target as UIToggle;

		GUILayout.Space(6f);
		GUI.changed = false;

		GUILayout.BeginHorizontal();
		SerializedProperty sp = NGUIEditorTools.DrawProperty("Group", serializedObject, "group", GUILayout.Width(120f));
		GUILayout.Label(" - zero means 'none'");
		GUILayout.EndHorizontal();

		EditorGUI.BeginDisabledGroup(sp.intValue == 0);
		NGUIEditorTools.DrawProperty("  State of 'None'", serializedObject, "optionCanBeNone");
		EditorGUI.EndDisabledGroup();

		NGUIEditorTools.DrawProperty("Starting State", serializedObject, "startsActive");
		NGUIEditorTools.SetLabelWidth(80f);

		if (NGUIEditorTools.DrawMinimalisticHeader("State Transition"))
		{
			NGUIEditorTools.BeginContents(true);
			NGUIEditorTools.DrawProperty("Sprite", serializedObject, "activeSprite");

			SerializedProperty animator = serializedObject.FindProperty("animator");
			SerializedProperty animation = serializedObject.FindProperty("activeAnimation");

			if (animator.objectReferenceValue != null)
			{
				NGUIEditorTools.DrawProperty("Animator", animator, false);
			}
			else if (animation.objectReferenceValue != null)
			{
				NGUIEditorTools.DrawProperty("Animation", animation, false);
			}
			else
			{
				NGUIEditorTools.DrawProperty("Animator", animator, false);
				NGUIEditorTools.DrawProperty("Animation", animation, false);
			}

			if (serializedObject.isEditingMultipleObjects)
			{
				NGUIEditorTools.DrawProperty("Instant", serializedObject, "instantTween");
			}
			else
			{
				GUI.changed = false;
				Transition tr = toggle.instantTween ? Transition.Instant : Transition.Smooth;
				GUILayout.BeginHorizontal();
				tr = (Transition)EditorGUILayout.EnumPopup("Transition", tr);
				NGUIEditorTools.DrawPadding();
				GUILayout.EndHorizontal();

				if (GUI.changed)
				{
					NGUIEditorTools.RegisterUndo("Toggle Change", toggle);
					toggle.instantTween = (tr == Transition.Instant);
					NGUITools.SetDirty(toggle);
				}
			}
			NGUIEditorTools.EndContents();
		}

		NGUIEditorTools.DrawEvents("On Value Change", toggle, toggle.onChange);
		serializedObject.ApplyModifiedProperties();
	}
}
