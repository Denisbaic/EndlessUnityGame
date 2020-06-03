using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameManager GM;

    public void PlayBtn()
    {
        gameObject.SetActive(false);
        GM.StartGame();
    }
    
    public void QuitBtn()
    {
        Application.Quit();
    }
}