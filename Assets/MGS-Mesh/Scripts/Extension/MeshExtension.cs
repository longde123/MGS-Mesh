/*************************************************************************
 *  Copyright (C), 2017-2018, Mogoson Tech. Co., Ltd.
 *------------------------------------------------------------------------
 *  File         :  MeshExtension.cs
 *  Description  :  Extension of UnityEngine.Mesh.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  5/24/2017
 *  Description  :  Initial development version.
 *************************************************************************/

using System.Collections.Generic;
using UnityEngine;

namespace Developer.MeshExtension
{
    public static class MeshCombiner
    {
        #region Public Method
        /// <summary>
        /// Combine the children meshes of meshesRoot to meshSave.
        /// </summary>
        /// <param name="meshesRoot">Root of multi meshes.</param>
        /// <param name="meshSave">Save combine mesh.</param>
        public static void MultiCombine(GameObject meshesRoot, GameObject meshSave)
        {
            //Combine meshes that in meshesRoot's children to a new mesh.
            var meshFilters = meshesRoot.GetComponentsInChildren<MeshFilter>();
            var combines = new CombineInstance[meshFilters.Length];
            var materialList = new List<Material>();
            for (int i = 0; i < meshFilters.Length; i++)
            {
                combines[i].mesh = meshFilters[i].sharedMesh;
                combines[i].transform = Matrix4x4.TRS(meshFilters[i].transform.position - meshesRoot.transform.position,
                    meshFilters[i].transform.rotation, meshFilters[i].transform.lossyScale);
                var materials = meshFilters[i].GetComponent<MeshRenderer>().sharedMaterials;
                foreach (var material in materials)
                {
                    materialList.Add(material);
                }
            }
            var newMesh = new Mesh();
            newMesh.CombineMeshes(combines, false);

#if !UNITY_5_5_OR_NEWER
            //Mesh.Optimize was removed in version 5.5.2p4.
            newMesh.Optimize();
#endif
            //Add the new mesh to the meshSave.
            meshSave.AddComponent<MeshFilter>().sharedMesh = newMesh;
            meshSave.AddComponent<MeshCollider>().sharedMesh = newMesh;
            meshSave.AddComponent<MeshRenderer>().sharedMaterials = materialList.ToArray();
        }
        #endregion
    }
}