/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson tech. Co., Ltd.
 *  FileName: TestCombineUI.cs
 *  Author: Mogoson   Version: 1.0   Date: 5/24/2017
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
 *     1.     Mogoson     5/24/2017       1.0        Build this file.
 *************************************************************************/

namespace Developer.Mesh
{
    using UnityEngine;

    [AddComponentMenu("Developer/Mesh/TestCombineUI")]
    public class TestCombineUI : MonoBehaviour
    {
        #region Property and Field
        public GameObject meshesRoot;
        public GameObject meshSave;
        #endregion

        #region Private Method
        void OnGUI()
        {
            if (GUILayout.Button("Combine"))
            {
                DMesh.MultiCombine(meshesRoot, meshSave);
            }
        }
        #endregion
    }
}