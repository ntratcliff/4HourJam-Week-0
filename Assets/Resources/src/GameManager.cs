using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public bool Inverted = false;
    public bool GameOver = false;
    public float InvertTimeMin, InvertTimeMax, NextInvertTime;
    public float HeartSpawnDelay = 0.4f;
    public GameObject HeartPrefab;

    // Use this for initialization
    void Start()
    {
        NextInvertTime = GetRandomInvertTime();
        StartCoroutine("SetInvert");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && GameOver) //restart game
        {
            Application.LoadLevel(0);
        }
    }

    IEnumerator SetInvert()
    {
        do
        {
            yield return new WaitForSeconds(NextInvertTime);
            yield return new WaitForEndOfFrame();
            Inverted = !Inverted;
            NextInvertTime = GetRandomInvertTime();
        }
        while (true);
    }

    IEnumerator SpawnHearts()
    {
        do
        {
            yield return new WaitForSeconds(HeartSpawnDelay);
            GameObject heart = GameObject.Instantiate(HeartPrefab);
            heart.transform.position = GameObject.Find("Male").transform.position;
            float scale = Random.Range(0.3f, 1f);
            heart.transform.localScale = new Vector2(scale, scale);
            MoveVelocity heartController = heart.GetComponent<MoveVelocity>();
            heartController.Rotation = Random.Range(-0.2f, 0.2f);
            heartController.Velocity = new Vector2(
                Random.Range(-0.05f, 0.05f),
                Random.Range(0.01f, 0.1f));

        }
        while (true);
    }

    float GetRandomInvertTime()
    {
        return Random.Range(InvertTimeMin, InvertTimeMax);
    }

    public void OnGameWon()
    {
        GameOver = true;
        StopCoroutine("SetInvert");
        StartCoroutine("SpawnHearts");
    }
}
