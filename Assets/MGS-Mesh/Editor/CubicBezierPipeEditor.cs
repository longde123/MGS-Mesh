/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CubicBezierPipeEditor.cs
 *  Description  :  Editor for CubicBezierPipe component.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/26/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using Developer.EditorExtension;
using Developer.MathExtension.Curve;
using UnityEditor;
using UnityEngine;

namespace Developer.MeshExtension
{
    [CustomEditor(typeof(CubicBezierPipe), true)]
    public class CubicBezierPipeEditor : GenericEditor
    {
        #region Property and Field
        protected CubicBezierPipe Script { get { return target as CubicBezierPipe; } }
        #endregion

        #region Private Method
        protected virtual void OnEnable()
        {
            Script.Awake();
        }

        protected virtual void OnSceneGUI()
        {
            if (Script.anchors.first && Script.anchors.second && Script.anchors.third && Script.anchors.fourth)
            {
                Handles.color = Color.green;

                if (!Application.isPlaying)
                {
                    EditorGUI.BeginChangeCheck();
                    DrawPositionHandle(Script.anchors.first);
                    DrawPositionHandle(Script.anchors.second);
                    DrawPositionHandle(Script.anchors.third);
                    DrawPositionHandle(Script.anchors.fourth);
                    if (EditorGUI.EndChangeCheck())
                    {
                        Script.CreateNewMesh();
                        MarkSceneDirty();
                    }

                    DrawSphereCap(Script.anchors.first.position, Script.anchors.first.rotation, nodeSize);
                    DrawSphereCap(Script.anchors.fourth.position, Script.anchors.fourth.rotation, nodeSize);

                    DrawArrow(Script.anchors.first.position, Script.anchors.second.position, nodeSize, Color.green, string.Empty);
                    DrawArrow(Script.anchors.third.position, Script.anchors.fourth.position, nodeSize, Color.green, string.Empty);
                }

                for (float i = 0; i < 1; i += 0.01f)
                {
                    var currentPos = CubicBezierCurve.GetPoint(Script.anchors.first.localPosition, Script.anchors.second.localPosition,
                    Script.anchors.third.localPosition, Script.anchors.fourth.localPosition, i);
                    var deltaPos = CubicBezierCurve.GetPoint(Script.anchors.first.localPosition, Script.anchors.second.localPosition,
                        Script.anchors.third.localPosition, Script.anchors.fourth.localPosition, i + 0.01f);
                    Handles.DrawLine(currentPos, deltaPos);
                }
            }
        }
        #endregion

        #region Public Method
        #endregion
    }
}