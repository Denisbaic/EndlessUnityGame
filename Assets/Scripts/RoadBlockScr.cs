using UnityEngine;

public class RoadBlockScr : MonoBehaviour {

    GameManager GM;
    Vector3 moveVec;

    public GameObject CoinsObj;

    public int CoinChance;
    bool coinsSpawn;

	void Start ()
    {
        GM = FindObjectOfType<GameManager>();
        moveVec = new Vector3(-1, 0, 0);

        coinsSpawn = Random.Range(0, 101) <= CoinChance;
        CoinsObj.SetActive(coinsSpawn);
    }
	
	void Update ()
    {
        if (GM.CanPlay)
            transform.Translate(moveVec * Time.deltaTime * GM.BaseMoveSpeed);
	}

}
