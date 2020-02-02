using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garyheartbeat : MonoBehaviour
{
    float alpha = 0.0f;
    public float duration = 1.0f;


    public float RotationIntensity = 5.0f;
    public float BeatIntensityX = 5.0f;
    public float BeatintensityY = 2.0f;
    Vector3 baseScale;

    private void Start()
    {
        baseScale = transform.localScale;
    }


    // Update is called once per frame
    void Update()
    {

        alpha += Time.deltaTime / duration;
            float x = Mathf.Cos(alpha * Mathf.PI * 2.0f) * BeatIntensityX;
            float y = Mathf.Cos(alpha * Mathf.PI * 2.0f) * BeatintensityY;
            transform.localScale = baseScale + new Vector3(x, y, 0.0f);

            float r = Mathf.Sin(alpha * Mathf.PI) * RotationIntensity;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, -r);


        if (alpha >= 1.0f)
        {
            alpha -= 1.0f;
            //transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            //transform.rotation = Quaternion.identity;
        }
    }
}
