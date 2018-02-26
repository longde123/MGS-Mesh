/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  BezierCurve.cs
 *  Description  :  Define BezierCurve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  1/7/2017
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Developer.MathExtension.Curve
{
    /// <summary>
    /// Linear bezier curve.
    /// </summary>
    public struct LinearBezierCurve
    {
        #region Property and Field
        /// <summary>
        /// First point of curve.
        /// </summary>
        public Vector3 p0;

        /// <summary>
        /// Second point of curve.
        /// </summary>
        public Vector3 p1;
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="p0">First point of curve.</param>
        /// <param name="p1">Second point of curve.</param>
        public LinearBezierCurve(Vector3 p0, Vector3 p1)
        {
            this.p0 = p0;
            this.p1 = p1;
        }

        /// <summary>
        /// Get curve point base on t.
        /// </summary>
        /// <param name="t">t is in the range(0~1).</param>
        /// <returns>Point on curve.</returns>
        public Vector3 GetPoint(float t)
        {
            return GetPoint(p0, p1, t);
        }

        /// <summary>
        /// Get curve point base on points and t.
        /// </summary>
        /// <param name="p0">First point of curve.</param>
        /// <param name="p1">Second point of curve.</param>
        /// <param name="t">t is in the range(0~1).</param>
        /// <returns>Point on curve.</returns>
        public static Vector3 GetPoint(Vector3 p0, Vector3 p1, float t)
        {
            return (1 - t) * p0 + t * p1;
        }
        #endregion
    }

    /// <summary>
    /// Quadratic bezier curve.
    /// </summary>
    public struct QuadraticBezierCurve
    {
        #region Property and Field
        /// <summary>
        /// First point of curve.
        /// </summary>
        public Vector3 p0;

        /// <summary>
        /// Second point of curve.
        /// </summary>
        public Vector3 p1;

        /// <summary>
        /// Third point of curve.
        /// </summary>
        public Vector3 p2;
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="p0">First point of curve.</param>
        /// <param name="p1">Second point of curve.</param>
        /// <param name="p2">Third point of curve.</param>
        public QuadraticBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2)
        {
            this.p0 = p0;
            this.p1 = p1;
            this.p2 = p2;
        }

        /// <summary>
        /// Get curve point base on t.
        /// </summary>
        /// <param name="t">t is in the range(0~1).</param>
        /// <returns>Point on curve.</returns>
        public Vector3 GetPoint(float t)
        {
            return GetPoint(p0, p1, p2, t);
        }

        /// <summary>
        /// Get curve point base on points and t.
        /// </summary>
        /// <param name="p0">First point of curve.</param>
        /// <param name="p1">Second point of curve.</param>
        /// <param name="p2">Third point of curve.</param>
        /// <param name="t">t is in the range(0~1).</param>
        /// <returns>Point on curve.</returns>
        public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
        {
            return Mathf.Pow(1 - t, 2) * p0 + 2 * t * (1 - t) * p1 + Mathf.Pow(t, 2) * p2;
        }
        #endregion
    }

    /// <summary>
    /// Cubic bezier curve.
    /// </summary>
    public struct CubicBezierCurve
    {
        #region Property and Field
        /// <summary>
        /// First point of curve.
        /// </summary>
        public Vector3 p0;

        /// <summary>
        /// Second point of curve.
        /// </summary>
        public Vector3 p1;

        /// <summary>
        /// Third point of curve.
        /// </summary>
        public Vector3 p2;

        /// <summary>
        /// Fourth point of curve.
        /// </summary>
        public Vector3 p3;
        #endregion

        #region Public Method
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="p0">First point of curve.</param>
        /// <param name="p1">Second point of curve.</param>
        /// <param name="p2">Third point of curve.</param>
        /// <param name="p3">Fourth point of curve.</param>
        public CubicBezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
        {
            this.p0 = p0;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        /// <summary>
        /// Get curve point base on t.
        /// </summary>
        /// <param name="t">t is in the range(0~1).</param>
        /// <returns>Point on curve.</returns>
        public Vector3 GetPoint(float t)
        {
            return GetPoint(p0, p1, p2, p3, t);
        }

        /// <summary>
        /// Get curve point base on points and t.
        /// </summary>
        /// <param name="p0">First point of curve.</param>
        /// <param name="p1">Second point of curve.</param>
        /// <param name="p2">Third point of curve.</param>
        /// <param name="p3">Fourth point of curve.</param>
        /// <param name="t">t is in the range(0~1).</param>
        /// <returns>Point on curve.</returns>
        public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
        {
            return Mathf.Pow(1 - t, 3) * p0 + 3 * t * Mathf.Pow(1 - t, 2) * p1 +
                3 * (1 - t) * Mathf.Pow(t, 2) * p2 + Mathf.Pow(t, 3) * p3;
        }
        #endregion
    }
}