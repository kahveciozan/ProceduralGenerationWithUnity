using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralShapes : MonoBehaviour
{
    [SerializeField]
    private float width = 10.0f ;

    [SerializeField]
    private float height = 10.0f;

    private Mesh mesh;

    private string randomShaderTypeNAme = "Standard";

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        ApplyRandomMaterial();

    }

    void Update() => GenerateQuad(width, height);


    private void GenerateQuad(float newWidth, float newHeight)
    {
        
        // Step 1 - Create & Assign Vertices
        Vector3[] vertices = new Vector3[4];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(newWidth, 0, 0);
        vertices[2] = new Vector3(0, newHeight, 0);
        vertices[3] = new Vector3(newWidth, newHeight, 0);


        // Step 2 - Create & Assign Triangles
        int[] triangles = new int[6];
        triangles[0] = 0;   // First triangle
        triangles[1] = 2;
        triangles[2] = 1;

        triangles[3] = 1;   // Second triangle
        triangles[4] = 2;
        triangles[5] = 3;


        // Step 3 - Create & Assign  Normal. Defauld 
        Vector3[] normals = new Vector3[4];
        normals[0] = -Vector3.forward;
        normals[1] = -Vector3.forward;
        normals[2] = -Vector3.forward;
        normals[3] = -Vector3.forward;


        // Step 4 - Create & Assign the UVs
        Vector2[] uvs = new Vector2[4];
        uvs[0] = new Vector2(0, 0);
        uvs[1] = new Vector2(1, 0);
        uvs[2] = new Vector2(0, 1);
        uvs[3] = new Vector2(1, 1);


        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.normals = normals;
        mesh.uv = uvs;

        mesh.Optimize();
    }

    private void ApplyRandomMaterial()
    {
        Material randomMaterial = new Material(Shader.Find(randomShaderTypeNAme));
        randomMaterial.name = $"{nameof(gameObject.name)}_material";
        randomMaterial.color = GetRandomColor();
        randomMaterial.EnableKeyword("_EMISSION");
        randomMaterial.SetColor("_EmissionColor",randomMaterial.color);
        GetComponent<Renderer>().material = randomMaterial;
    }

    Color GetRandomColor() => Random.ColorHSV(0f,1f,1f,1f,0.5f,1f);
}
