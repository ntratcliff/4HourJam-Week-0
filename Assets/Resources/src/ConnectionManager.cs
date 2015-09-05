using UnityEngine;
using System.Collections;

public class ConnectionManager : MonoBehaviour
{
    GameManager manager;
    GameObject otherPlug;
    public float TriggerDist = 0.2f;
    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
        otherPlug = GameObject.Find("Female");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 connectionDelta = transform.position - otherPlug.transform.position;
        float dist = connectionDelta.magnitude;
        if (dist <= TriggerDist && !manager.GameOver)
        {
            transform.position = otherPlug.transform.position;
            manager.OnGameWon();
        }
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("Collision with tag: " + other.transform.tag);
    //    if (other.transform.CompareTag(this.transform.tag))
    //    {
    //        this.GetComponentInParent<Transform>().position = other.GetComponentInParent<Transform>().position;
    //        manager.OnGameWon();
    //    }
            
    //}
}
