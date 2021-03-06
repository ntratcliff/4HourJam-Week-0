﻿using UnityEngine;
using System.Collections;

public class GamepadControl : MonoBehaviour
{

    public bool Active = true;
    public float ChangeTimeMin, ChangeTimeMax, NextChangeTime;
    public float SensitivityMin = 0, SensitivityMax = 8;
    public float Sensitivity = 2.4f;
    GameManager manager;
    // Use this for initialization
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<GameManager>();
        NextChangeTime = 0f;
        StartCoroutine("setRandomSensitivity");
    }

    // Update is called once per frame
    void Update()
    {
        if (Active && !manager.GameOver)
        {

            Vector2 delta = new Vector2(
                Input.GetAxis("Horizontal") * Sensitivity,
                Input.GetAxis("Vertical") * Sensitivity);
            if (manager.Inverted)
                delta = -delta;
            Vector2 nextPos = (Vector2)delta + (Vector2)transform.position;
            Vector2 viewportSize = Camera.main.ScreenToWorldPoint(
                new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight));

            if (nextPos == (Vector2)transform.position)
            {
                nextPos += new Vector2(
                    Random.Range(-Sensitivity / 10, Sensitivity / 10),
                    Random.Range(-Sensitivity / 10, Sensitivity / 10));
            }

            nextPos.x = Mathf.Clamp(nextPos.x, -viewportSize.x + 0.3f, viewportSize.x - 0.3f);
            nextPos.y = Mathf.Clamp(nextPos.y, -viewportSize.y + 0.3f, viewportSize.y - 0.3f);

            transform.position = nextPos;
        }
    }

    IEnumerator setRandomSensitivity()
    {
        do
        {
            yield return new WaitForSeconds(NextChangeTime);
            Sensitivity = Random.Range(SensitivityMin, SensitivityMax);
            NextChangeTime = getRandomChangeTime();
        } while (true);
    }

    float getRandomChangeTime()
    {
        return Random.Range(ChangeTimeMin, ChangeTimeMax);
    }
}
