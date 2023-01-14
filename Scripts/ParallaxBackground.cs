using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{


    //public PlayerController notify;
    public float scrollSpeedX = 0f;
    public float scrollSpeedY = 0f;

    private float actualSpeed;

    private float offsetX;
    private float offsetY;
    private bool parallaxBgActive;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;

        //notify.OnMove += activateBG;
        //notify.OnStop += desactivateBG;
    }

    void Update() {
        if(parallaxBgActive == true){
            offsetX += (actualSpeed * Time.deltaTime) / 10f;
            offsetY += (actualSpeed * Time.deltaTime) / 10f;
            mat.SetTextureOffset("_MainTex", new Vector2(offsetX, 0));
        }
        
    }

    private void activateBG(bool right, bool up){
        if(right){
            actualSpeed = scrollSpeedX;
        }else{
            actualSpeed = scrollSpeedX * (-1);
        }

        if(up){
            actualSpeed = scrollSpeedY;
        }else{
            actualSpeed = scrollSpeedY * (-1);
        }
        parallaxBgActive = true;
    }

    private void desactivateBG(bool right){
        parallaxBgActive = false;
    }

}