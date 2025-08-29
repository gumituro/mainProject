// using UnityEngine;
//
// [RequireComponent(typeof(Renderer))]
// public class WavyWaterScroll : MonoBehaviour
// {
//     public float scrollSpeed = 0.2f;
//     public float waveSpeed = 1.5f;
//     public float waveStrength = 0.05f;
//     private Material mat;
//
//     void Start()
//     {
//         mat = GetComponent<Renderer>().material;
//     }
//
//     void Update()
//     {
//         float offsetX = Time.time * scrollSpeed;
//         float offsetY = Mathf.Sin(Time.time * waveSpeed) * waveStrength;
//         mat.mainTextureOffset = new Vector2(offsetX, offsetY);
//     }
// }

/*
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class WaterScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        mat.mainTextureOffset = new Vector2(offset, 0);
    }
}
*/
