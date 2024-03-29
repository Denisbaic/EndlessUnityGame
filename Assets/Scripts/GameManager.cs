﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject ResultObj;
    public PlayerMovement PM;
    public RoadSpawner RS;

    public Text SpeedTxt,
                CoinsTxt;
    
    public Image SpeedImage, CoinImage;

    public int Coins;

    public bool CanPlay = true;
    public bool IsSound = true;

    public float BaseMoveSpeed;

    public void StartGame()
    {
        PM.Respawn();
        ResultObj.SetActive(false);
        RS.StartGame();
        CanPlay = true;

        PM.SkinAnimator.SetTrigger("respawn");
        StartCoroutine(FixTrigger());

        Show(SpeedImage);
        Show(CoinImage);
        SpeedTxt.text = ((int)BaseMoveSpeed).ToString();
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
