using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Text text;
    public Game manager;

    public GameObject introScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoTheThing()
    {
        int i = int.Parse(text.text);
        
        manager.launch(i);
        introScreen.SetActive(false);
    }
}
