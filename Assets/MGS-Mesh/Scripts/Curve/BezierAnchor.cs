/*************************************************************************
 *  Copyright © 2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  BezierAnchor.cs
 *  Description  :  Define anchor of bezier curve.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  2/26/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using System;
using UnityEngine;

namespace Developer.MathExtension.Curve
{
    /// <summary>
    /// Anchor of cubic bezier curve.
    /// </summary>
    [Serializable]
    public struct CubicBezierAnchor
    {
        public Transform first;
        public Transform second;
        public Transform third;
        public Transform fourth;
    }
}