using UnityEngine;
using System.Collections;

public class InvertSprite : MonoBehaviour
{
    GameManager manager;
    Color[] invertColors = new Color[2] { Color.white, Color.black };
    int colorIndex = 0;

    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.Inverted)
            colorIndex = 1;
        else
            colorIndex = 0;

        if(this.GetComponent<SpriteRenderer>().color != invertColors[colorIndex])
            this.GetComponent<SpriteRenderer>().color = invertColors[colorIndex];
    }
}
