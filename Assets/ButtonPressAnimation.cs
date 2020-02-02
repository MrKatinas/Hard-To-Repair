using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressAnimation : MonoBehaviour
{
    public float duration = 0.1f;
    public float intensity = 0.1f;
    float alpha = 0.0f;
    bool animating = false;
    Vector3 BaseScale;

    // Start is called before the first frame update
    void Start()
    {
        BaseScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        alpha += Time.deltaTime / duration;

        if (animating)
        {
            float s = Mathf.Sin(alpha * Mathf.PI) * intensity;
            transform.localScale = BaseScale - new Vector3(s, s, 0);
        }

        if (alpha > 1.0f)
        {
            transform.localScale = BaseScale;
            animating = false;
        }
    }

    public void Press()
    {
        animating = true;
        alpha = 0.0f;
    }
}
