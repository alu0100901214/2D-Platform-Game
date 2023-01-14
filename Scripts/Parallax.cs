using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [Range(-3f, 3f)]
    public float scrollSpeedX;
    [Range(-3f, 3f)]
    public float scrollSpeedY;
    public GameObject cam;

    private float offsetX;
    private float offsetY;
    private float startPosX;
    private float startPosY;
    private Material mat;

    void Start() {
        mat = GetComponent<Renderer>().material;
        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }

    void Update() {
        float distanceX = (cam.transform.position.x * (scrollSpeedX/10f));
        float distanceY = (cam.transform.position.y * (scrollSpeedY/10f));
        mat.SetTextureOffset("_MainTex", new Vector2(startPosX + distanceX, startPosY + distanceY));
    }
}
