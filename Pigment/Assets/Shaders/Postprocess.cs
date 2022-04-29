using UnityEngine;

public class Postprocess : MonoBehaviour
{
    private Material material;
    public Shader shader;

    private void Start()
    {
        material = new Material(shader);
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}
