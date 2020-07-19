using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;

[CustomEditor(typeof(CameraBounds))]
public class CameraBoundsEditor : Editor
{
    CameraBounds _bounds;
    readonly BoxBoundsHandle m_BoundsHandle = new BoxBoundsHandle();

    public void OnSceneGUI()
    {
        _bounds = (CameraBounds)target;
        Matrix4x4 handleMatrix = _bounds.transform.localToWorldMatrix;
        handleMatrix.SetRow(0, Vector4.Scale(handleMatrix.GetRow(0), new Vector4(1f, 0f, 1f, 1f)));
        handleMatrix.SetRow(1, Vector4.Scale(handleMatrix.GetRow(1), new Vector4(1f, 0f, 1f, 1f)));
        handleMatrix.SetRow(2, new Vector4(0f, 1f, 0f, _bounds.transform.position.y));

        using (new Handles.DrawingScope(handleMatrix))
        {
            m_BoundsHandle.center = _bounds.offset;
            m_BoundsHandle.size = _bounds.scaleBound;
            m_BoundsHandle.SetColor(Color.white);
            EditorGUI.BeginChangeCheck();
            m_BoundsHandle.DrawHandle();
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(_bounds, $"Modify {ObjectNames.NicifyVariableName(_bounds.GetType().Name)}");

                // test for size change after using property setter in case input data was sanitized
                Vector2 oldSize = _bounds.scaleBound;
                _bounds.scaleBound = m_BoundsHandle.size;

                // because projection of offset is a lossy operation, only do it if the size has actually changed
                // this check prevents drifting while dragging handle when size is zero (case 863949)
                if (_bounds.scaleBound != oldSize)
                    _bounds.offset = m_BoundsHandle.center;
            }
        }

        GUIUtility.ExitGUI();
    }
}