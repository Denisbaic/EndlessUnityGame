using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public GameObject ResultObj;
    public PlayerMovement PM;
    public RoadSpawner RS;

    public Text DistanceTxt,
                CoinsTxt;
    
    public Image DistanceImage, CoinImage;

    float Distance;
    public int Coins = 0;

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

        Distance = 0;
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
            Distance += BaseMoveSpeed * Time.deltaTime;
        }

        DistanceTxt.text = ((int)Distance).ToString();
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
