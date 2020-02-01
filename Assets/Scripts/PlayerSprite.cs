using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    SpriteRenderer SpriteRenderer;

    public Sprite Happy;
    public Sprite Unhappy;
    public Sprite Idle;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetSprite(Sprite s)
    {
        SpriteRenderer.sprite = s;
    }

    public void OnGiveHealth()
    {
        //SpriteRenderer.sprite = Unhappy;
    }

    public void OnKeepHealth()
    {
        //SpriteRenderer.sprite = Happy;
    }

    public void HoverKeepEnter()
    {
        SetSprite(Happy);
    }

    public void HoverKeepExit()
    {
        SetSprite(Idle);
    }

    public void HoverGiveEnter()
    {
        SetSprite(Unhappy);
    }

    public void HoverGiveExit()
    {
        SetSprite(Idle);
    }
}
