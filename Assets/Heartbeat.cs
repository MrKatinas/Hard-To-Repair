using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heartbeat : MonoBehaviour
{
    float alpha = 0.0f;
    bool beating = false;
    public float duration = 0.5f;

    public float RotationIntensity = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!beating) { return; }

        alpha += Time.deltaTime / duration;

        float x = Mathf.Cos(alpha * Mathf.PI * 2.0f) * 0.10f + 0.90f;
        float y = Mathf.Cos(alpha * Mathf.PI * 2.0f) * 0.04f + 0.96f;
        transform.localScale = new Vector3(x, y, 1.0f);

        float r = Mathf.Sin(alpha * Mathf.PI) * RotationIntensity;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, -r);
        

        if (alpha >= 1.0f)
        {
            beating = false;
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            transform.rotation = Quaternion.identity;
        }
    }

    public void Beat()
    {
        beating = true;
        alpha = 0.0f;
    }
}
