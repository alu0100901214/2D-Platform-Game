using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    [Range(-1f, 1f)]
    public float scrollSpeedX = 0.5f;
    [Range(-1f, 1f)]
    public float scrollSpeedY = 0.5f;

    private float offsetX;
    private float offsetY;
    private Material mat;

    void Start() {
        mat = GetComponent<Renderer>().material;
    }

    void Update() {
        offsetX += (scrollSpeedX * Time.deltaTime) / 10f;
        offsetY += (scrollSpeedY * Time.deltaTime) / 10f;

        mat.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));
    }
}