﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject ResultObj;
    public PlayerMovement PM;
    public RoadSpawner RS;

    public Text PointsTxt,
                CoinsTxt;

    public Image DistanceImage, CoinImage;

    float Points;

    public int Coins = 0;

    public bool CanPlay = true;
    public bool IsSound = true;

    public float BaseMoveSpeed, CurrentMoveSpeed;
    public float PointsBaseValue, PointsMultiplier;// PowerUpMultiplier;

    public void StartGame()
    {
        PM.Respawn();
        ResultObj.SetActive(false);
        RS.StartGame();
        CanPlay = true;

        PM.SkinAnimator.SetTrigger("respawn");
        StartCoroutine(FixTrigger());

        CurrentMoveSpeed = BaseMoveSpeed;
        PointsMultiplier = 1;
        //PowerUpMultiplier = 1;
        Points = 0;

        Show(DistanceImage);
        Show(CoinImage);
    }

    public static void Hide(Image img)
    {
        CanvasGroup cnvGroup = img.GetComponent<CanvasGroup>();
        if (cnvGroup != null)
        {
            cnvGroup.alpha = 0f;
            cnvGroup.blocksRaycasts = false; 
        }
    }
    public static void Show(Image img)
    {
        CanvasGroup cnvGroup = img.GetComponent<CanvasGroup>();
        if (cnvGroup != null)
        {
            cnvGroup.alpha = 1f; 
            cnvGroup.blocksRaycasts = true; 
        }
    }
    IEnumerator FixTrigger()
    {
        yield return null;
        PM.SkinAnimator.ResetTrigger("respawn");
    }

    private void Update()
    {
        if (CanPlay)
        {
            Points += PointsBaseValue * PointsMultiplier * Time.deltaTime; //* PowerUpMultiplier;

            PointsMultiplier += .05f * Time.deltaTime;
            PointsMultiplier = Mathf.Clamp(PointsMultiplier, 1, 10);

            CurrentMoveSpeed += .1f * Time.deltaTime;
            CurrentMoveSpeed = Mathf.Clamp(CurrentMoveSpeed, 1, 20);
        }

        PointsTxt.text = ((int)Points).ToString();
    }

    public void ShowResult()
    {
        ResultObj.SetActive(true);
        SaveManager.Instance.SaveGame();
    }

    public void AddCoins(int number)
    {
        Coins += number;
        RefreshText();
    }

    public void RefreshText()
    {
        CoinsTxt.text = Coins.ToString();
    }
}
