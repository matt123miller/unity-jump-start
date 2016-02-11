/*
    Sourced from http://wiki.unity3d.com/index.php/ReverseNormals
    Created by Joachim Ante
    Line 20 altered to use sharedMesh due to potential mesh leakage.
*/


using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class FlipNormals : MonoBehaviour
{
	void Start()
	{
        
        MeshFilter filter = GetComponent(typeof (MeshFilter)) as MeshFilter;
		if (filter != null)
		{
			Mesh mesh = filter.sharedMesh;
 
			Vector3[] normals = mesh.normals;
			for (int i=0;i<normals.Length;i++)
				normals[i] = -normals[i];
			mesh.normals = normals;
 
			for (int m=0;m<mesh.subMeshCount;m++)
			{
				int[] triangles = mesh.GetTriangles(m);
				for (int i=0;i<triangles.Length;i+=3)
				{
					int temp = triangles[i + 0];
					triangles[i + 0] = triangles[i + 1];
					triangles[i + 1] = temp;
				}
				mesh.SetTriangles(triangles, m);
			}
		}		
	}
}
