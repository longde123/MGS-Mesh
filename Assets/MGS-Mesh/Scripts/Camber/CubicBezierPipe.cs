/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  CubicBezierPipe.cs
 *  Description  :  Create pipe mesh base on cubic bezier curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/26/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using Developer.MathExtension.Curve;
using UnityEngine;

namespace Developer.MeshExtension
{
    [AddComponentMenu("Developer/MeshExtension/CubicBezierPipe")]
    [RequireComponent(typeof(SkinnedMeshRenderer))]
    public class CubicBezierPipe : MonoBehaviour
    {
        #region Property and Field
        /// <summary>
        /// Segment of around cubic bezier curve.
        /// </summary>
        public int aroundSegment = 8;

        /// <summary>
        /// Segment of extend base on cubic bezier curve.
        /// </summary>
        public int extendSegment = 16;

        /// <summary>
        /// Radius of pipe mesh.
        /// </summary>
        public float radius = 0.1f;

        /// <summary>
        /// Anchors of cubic bezier curve.
        /// </summary>
        public CubicBezierAnchor anchors;

        /// <summary>
        /// Radian of circle.
        /// </summary>
        protected const float CircleRadian = Mathf.PI * 2;

        /// <summary>
        /// Skinned mesh renderer of pipe.
        /// </summary>
        protected SkinnedMeshRenderer smRenderer;

        /// <summary>
        /// Mesh collider of pipe.
        /// </summary>
        protected MeshCollider mCollider;

        protected Mesh mesh;
        #endregion

        #region Private Method
        public virtual void Awake()
        {
            smRenderer = GetComponent<SkinnedMeshRenderer>();
            mCollider = GetComponent<MeshCollider>();
            mesh = new Mesh { name = "Pipe" };
            CreateNewMesh();


        }

        protected virtual void Update()
        {
            CreateNewMesh();
        }

        /// <summary>
        /// Create the vertices of pipe mesh.
        /// </summary>
        /// <returns>Vertices of pipe mesh.</returns>
        protected virtual Vector3[] CreateVertices()
        {
            var vertices = new List<Vector3>();
            var space = 1.0f / extendSegment;
            for (int i = 0; i <= extendSegment; i++)
            {
                var currentPos = CubicBezierCurve.GetPoint(anchors.first.localPosition, anchors.second.localPosition,
                    anchors.third.localPosition, anchors.fourth.localPosition, i * space);
                var deltaPos = CubicBezierCurve.GetPoint(anchors.first.localPosition, anchors.second.localPosition,
                    anchors.third.localPosition, anchors.fourth.localPosition, i * space - 0.001f);

                var tangent = (currentPos - deltaPos).normalized;
                var rotation = Quaternion.LookRotation(tangent);

                var vs = CreateSegmentVertices(currentPos, rotation);
                vertices.AddRange(vs);
            }
            return vertices.ToArray();
        }

        /// <summary>
        /// Create vertices of current segment base on cubic bezier curve.
        /// </summary>
        /// <param name="center">Center point of segment.</param>
        /// <param name="rotation">Rotation of segment vertices.</param>
        /// <returns>Segment vertices.</returns>
        protected virtual List<Vector3> CreateSegmentVertices(Vector3 center, Quaternion rotation)
        {
            var vertices = new List<Vector3>();
            for (int i = 0; i < aroundSegment; i++)
            {
                var angle = CircleRadian / aroundSegment * i;
                var point = center + rotation * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
                vertices.Add(transform.TransformPoint(point));
            }
            return vertices;
        }

        /// <summary>
        /// Calculate triangles of pipe mesh.
        /// </summary>
        /// <returns>Triangles array.</returns>
        protected virtual int[] CalculateTriangles()
        {
            var triangles = new List<int>();
            for (int i = 0; i < extendSegment; i++)
            {
                for (int j = 0; j < aroundSegment - 1; j++)
                {
                    triangles.Add(aroundSegment * i + j);
                    triangles.Add(aroundSegment * i + j + 1);
                    triangles.Add(aroundSegment * (i + 1) + j + 1);

                    triangles.Add(aroundSegment * i + j);
                    triangles.Add(aroundSegment * (i + 1) + j + 1);
                    triangles.Add(aroundSegment * (i + 1) + j);
                }

                triangles.Add(aroundSegment * i);
                triangles.Add(aroundSegment * (i + 1));
                triangles.Add(aroundSegment * (i + 2) - 1);

                triangles.Add(aroundSegment * i);
                triangles.Add(aroundSegment * (i + 2) - 1);
                triangles.Add(aroundSegment * (i + 1) - 1);
            }
            return triangles.ToArray();
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Create new mesh for pipe.
        /// </summary>
        public virtual void CreateNewMesh()
        {
            mesh.vertices = CreateVertices();
            mesh.triangles = CalculateTriangles();

            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            smRenderer.sharedMesh = mesh;
            smRenderer.localBounds = mesh.bounds;
            if (mCollider)
                mCollider.sharedMesh = mesh;
        }
        #endregion
    }
}