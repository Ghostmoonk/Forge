using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PatternItem))]
public class ItemPatternEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PatternItem patternItem = (PatternItem)target;

        if (patternItem.model != null && GUI.changed)
        {
            patternItem.UpdateModel();
        }
    }
}
