using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartbeat : MonoBehaviour
{
    float alpha = 0.0f;
    bool beating = false;
    bool bleeding = false;
    public float duration = 0.5f;


    public float RotationIntensity = 5.0f;
    public float BeatIntensityX = 0.1f;
    public float BeatintensityY = 0.04f;

    SpriteRenderer renderer;
    public ParticleSystem particleSystem;

    private void Start()
    {

        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!beating && !bleeding) { return; }

        alpha += Time.deltaTime / duration;
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        transform.rotation = Quaternion.identity;
        renderer.color = Color.white;

        if (beating)
        {
            float x = Mathf.Cos(alpha * Mathf.PI * 2.0f) * BeatIntensityX + (1 - BeatIntensityX);
            float y = Mathf.Cos(alpha * Mathf.PI * 2.0f) * BeatintensityY + (1 - BeatintensityY);
            transform.localScale = new Vector3(x, y, 1.0f);

            float r = Mathf.Sin(alpha * Mathf.PI) * RotationIntensity;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, -r);
        }
        
        
        if (bleeding)
        {
            float s = Mathf.Min((Mathf.Sin(alpha * Mathf.PI) * 2), 1.0f) * 0.15f + 1.0f;
            transform.localScale = new Vector3(s, s, 1.0f);

            float red = Mathf.Sin(alpha * Mathf.PI * 3) * Mathf.Sin(alpha * Mathf.PI * 3);
            renderer.color = new Color(1.0f, 1.0f - red, 1.0f - red);
        }


        if (alpha >= 1.0f)
        {
            beating = false;
            bleeding = false;
        }
    }

    public void Beat()
    {
        beating = true;
        bleeding = false;
        alpha = 0.0f;
        particleSystem.Play();
    }

    public void Bleed()
    {
        bleeding = true;
        beating = false;
        alpha = 0.0f;
    }
}
