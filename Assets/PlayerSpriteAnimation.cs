using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteAnimation : MonoBehaviour
{
    float alpha = 0.0f;
    bool jumping;
    bool angry;
    Vector3 BasePosition;

    public float duration = 0.5f;
    public float JumpHeight = 1.0f;
    public float RotationIntensity = 30.0f;

    SpriteRenderer renderer;

    
    // Start is called before the first frame update
    void Start()
    {
        BasePosition = transform.position;
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!jumping && !angry) { return; }

        alpha += Time.deltaTime / duration;
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        transform.rotation = Quaternion.identity;
        transform.position = BasePosition;
        renderer.color = Color.white;

        if (jumping)
        {
            float y = (1 - (Mathf.Cos(alpha * Mathf.PI * 6.0f) * 0.5f + 0.5f)) * JumpHeight;
            Vector3 Diff = new Vector3(0.0f, y, 0.0f);
            transform.position = BasePosition + Diff;

            float r = Mathf.Sin(alpha * Mathf.PI * 3.0f) * Mathf.Sin(alpha * Mathf.PI * 3.0f) * Mathf.Sin(alpha * Mathf.PI * 3.0f) * RotationIntensity;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, r);
        }

        if (angry)
        {
            float r = Mathf.Sin(alpha * Mathf.PI * 4.0f) * 20;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, r);

            float s = Mathf.Min((Mathf.Sin(alpha * Mathf.PI) * 2), 1.0f) * 0.15f + 1.0f;
            transform.localScale = new Vector3(s, s, 1.0f);

            float red = Mathf.Min((Mathf.Sin(alpha * Mathf.PI) * 2), 1.0f);
            renderer.color = new Color(1.0f, 1.0f - red, 1.0f - red);
        }



        if (alpha >= 1.0f)
        {
            jumping = false;
            angry = false;
        }
    }

    public void Jump()
    {
        jumping = true;
        angry = false;
        alpha = 0.0f;
    }

    public void Angry()
    {
        angry = true;
        jumping = false;
        alpha = 0.0f;
    }
}
