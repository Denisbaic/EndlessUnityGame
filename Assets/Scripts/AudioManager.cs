using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public GameManager GM;

    public AudioSource EffectAS;
    public AudioClip CoinSnd;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayCoinEffect()
    {
        if (GM.IsSound)
            EffectAS.PlayOneShot(CoinSnd);
    }
}