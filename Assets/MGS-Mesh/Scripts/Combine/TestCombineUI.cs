/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  TestCombineUI.cs
 *  Description  :  Draw UI in scene to test combine Meshes.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  3/19/2018
 *  Description  :  Initial development version.
 *************************************************************************/

using UnityEngine;

namespace Mogoson.MeshExtension
{
    public class TestCombineUI : MonoBehaviour
    {
        #region Field and Property
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