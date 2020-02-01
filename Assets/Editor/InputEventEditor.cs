using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InputEvent))]
public class InputEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InputEvent inputEvent = (InputEvent)target;
        if (inputEvent.inputType != InputType.NONE && GUI.changed)
        {
            inputEvent.AdaptButtonSprite();
        }
    }
}
