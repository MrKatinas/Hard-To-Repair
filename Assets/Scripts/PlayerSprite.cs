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

    bool HoveringTake = false;
    bool HoveringGive = false;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<PlayerSpriteAnimation>();
    }

    private void Update()
    {
        if (HoveringGive)
        {
            SetSprite(Unhappy);
        }
        else if (HoveringTake)
        {
            SetSprite(Happy);
        }
        else
        {
            SetSprite(Idle);
        }
    }

    void SetSprite(Sprite s)
    {
        if (animator.IsAnimating()) { return; }
        SpriteRenderer.sprite = s;
    }

    public void OnGiveHealth()
    {
        SpriteRenderer.sprite = Unhappy;
        animator.Angry();
    }

    public void OnKeepHealth()
    {
        SpriteRenderer.sprite = Happy;
        animator.Jump();
    }

    public void HoverKeepEnter()
    {
        HoveringTake = true;
    }

    public void HoverKeepExit()
    {
        HoveringTake = false;
    }

    public void HoverGiveEnter()
    {
        HoveringGive = true;
    }

    public void HoverGiveExit()
    {
        HoveringGive = false;
    }
}
