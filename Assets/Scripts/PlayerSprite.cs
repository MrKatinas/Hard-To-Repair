using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
    SpriteRenderer SpriteRenderer;
    PlayerSpriteAnimation animator;

    public Sprite Happy;
    public Sprite Unhappy;
    public Sprite Idle;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<PlayerSpriteAnimation>();
    }
    
    void SetSprite(Sprite s)
    {
        SpriteRenderer.sprite = s;
    }

    public void OnGiveHealth()
    {
        //SpriteRenderer.sprite = Unhappy;
        animator.Angry();
    }

    public void OnKeepHealth()
    {
        //SpriteRenderer.sprite = Happy;
        animator.Jump();
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
