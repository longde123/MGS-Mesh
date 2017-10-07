/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *  FileName: TestCombineUI.cs
 *  Author: Mogoson   Version: 0.1.0   Date: 5/24/2017
 *  Version Description:
 *    Internal develop version,mainly to achieve its function.
 *  File Description:
 *    Ignore.
 *  Class List:
 *    <ID>           <name>             <description>
 *     1.         TestCombineUI            Ignore.
 *  Function List:
 *    <class ID>     <name>             <description>
 *     1.
 *  History:
 *    <ID>    <author>      <time>      <version>      <description>
 *     1.     Mogoson     5/24/2017       0.1.0        Create this file.
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