using UnityEditor;
using UnityEngine;

public class meshBaker : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skinnedRenderer;

    [ContextMenu("Bake Mesh")]
    public void BakeMesh()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
            meshFilter = gameObject.AddComponent<MeshFilter>();

        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer == null)
            meshRenderer = gameObject.AddComponent<MeshRenderer>();

        // Create the baked mesh
        Mesh bakedMesh = new Mesh();
        bakedMesh.name = gameObject.name + "_Baked";

        skinnedRenderer.BakeMesh(bakedMesh);

        // Save the mesh as an asset
#if UNITY_EDITOR
        string path = "Assets/" + bakedMesh.name + ".asset";
        AssetDatabase.CreateAsset(bakedMesh, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
#endif

        // Assign the saved mesh
        meshFilter.sharedMesh = bakedMesh;
        meshRenderer.sharedMaterials = skinnedRenderer.sharedMaterials;

        Debug.Log("Baked mesh saved to: " + path);
    }
    }
