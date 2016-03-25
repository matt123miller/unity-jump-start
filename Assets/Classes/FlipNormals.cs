/*
    Original script created by Joachim Ante, found here http://wiki.unity3d.com/index.php/ReverseNormals.
    Adapted to be an editor tool instead.
    Line 21 altered to use sharedMesh instead of regular mesh variable due to potential mesh leakage.
*/

using System.Linq;
using UnityEngine;
using UnityEditor;
 
public class FlipNormals : MonoBehaviour
{
    
    [MenuItem("Tools/Flip normals of selected object")]
    private static void Flip()
    {
        MeshFilter filter = Selection.activeGameObject.GetComponent<MeshFilter>();
        
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
