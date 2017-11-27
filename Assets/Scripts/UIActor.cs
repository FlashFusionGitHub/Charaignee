﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIActor : MonoBehaviour {

    public WinTrigger win_trigger;
    public RawImage fade_image;

    Color currentColour;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        currentColour = fade_image.color;

        if (win_trigger.EndGame() == true)
        {
            currentColour.a = Mathf.Lerp(fade_image.color.a, 255.0f, 0.003f * Time.deltaTime);

            fade_image.color = currentColour;

            StartCoroutine(EndGame());
        }
	}

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(3);
    }
}