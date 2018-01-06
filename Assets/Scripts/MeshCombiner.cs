using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour {

	public void CombineMeshes()
    {
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();
        Mesh finalMesh = new Mesh();
        Quaternion oldRot = transform.rotation;
        Vector3 oldPos = transform.position;

        transform.rotation = Quaternion.identity;

        Debug.Log(name + "is combining "+filters.Length+" meshses");

        CombineInstance[] combiners = new CombineInstance[filters.Length];

        for(int a=0; a<filters.Length; a++)
        {
            if (filters[a].transform == transform)
                continue;

            combiners[a].subMeshIndex = 0;
            combiners[a].mesh = filters[a].sharedMesh;
            combiners[a].transform = filters[a].transform.localToWorldMatrix;
        }

        finalMesh.CombineMeshes(combiners);

        GetComponent<MeshFilter>().sharedMesh = finalMesh;

        transform.rotation = oldRot;
        transform.position = oldPos;
    }
}
