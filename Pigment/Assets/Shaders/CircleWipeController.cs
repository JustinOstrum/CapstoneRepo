using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleWipeController : MonoBehaviour
{
    public Shader shader;

    Material mat;

    [Range(0,1.2f)]
    public float _radius = 0f;

    public float _horizontal = 16;
    public float _vertical = 9;
    public float duration = 1f;

    private void Awake()
    {
        mat = new Material(shader);        
    }

    private void Start()
    {
        _radius = 0f;
        UpdateShader();           
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, mat);
    }

    public void FadeOut()
    {
        StartCoroutine(DoFade(1.2f, 0f));
    }

    public void FadeIn()
    {
        StartCoroutine(DoFade(0f, 1.2f));
    }

    public IEnumerator DoFade(float start, float end)
    {
        _radius = start;
        UpdateShader();

        var time = 0f;
        while(time < 1f)
        {
            _radius = Mathf.Lerp(start, end, time);
            time += Time.deltaTime / duration;
            UpdateShader();

            yield return null;
        }

        _radius = end;
        UpdateShader();
    }

    private void UpdateShader()
    {
        var radiusSpeed = Mathf.Max(_horizontal, _vertical);
        mat.SetFloat("_Horizontal", _horizontal);
        mat.SetFloat("_Vertical", _vertical);
        mat.SetFloat("_RadiusSpeed", radiusSpeed);
        mat.SetFloat("_Radius", _radius);             
    }
}
