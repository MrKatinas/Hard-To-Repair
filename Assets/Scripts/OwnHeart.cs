using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnHeart : MonoBehaviour
{
    Heartbeat Heartbeat;

    // Start is called before the first frame update
    void Start()
    {
        Heartbeat = GetComponent<Heartbeat>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGiveHealth()
    {
        Heartbeat.Bleed();
    }

    public void OnKeepHealth()
    {
        Heartbeat.Beat();
    }
}
