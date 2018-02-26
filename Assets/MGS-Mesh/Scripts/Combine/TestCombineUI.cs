/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TestCombineUI.cs
 *  Description  :  Draw UI in scene to test combine Meshes.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  5/24/2017
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Developer.MeshExtension
{
    [AddComponentMenu("Developer/MeshExtension/TestCombineUI")]
    public class TestCombineUI : MonoBehaviour
    {
        #region Property and Field
        public GameObject meshesRoot;
        public GameObject meshSave;
        #endregion

        #region Private Method
        private void OnGUI()
        {
            if (GUILayout.Button("Combine"))
                MeshCombiner.MultiCombine(meshesRoot, meshSave);
        }
        #endregion
    }
}