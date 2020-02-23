using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score;

    public GameObject boat;

    [Space]
    public GameObject coinPrefab;
    public GameObject whirlPrefab;

    [Space]
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        score = 0;

        SpawnCoin();
        SpawnWhirl(3.0f);

        Coin.OnPickUp += OnCoinPickedUp;
        Whirl.OnWhirlEnd += OnWhirlEnd;
    }

    public static Vector3 GetRandomPosition(GameObject prefab)
    {
        Vector3 position = Vector3.zero;

        position.x = Random.Range(-7.25f, 7.25f);
        position.y = prefab.transform.position.y;
        position.z = Random.Range(-3.75f, 3.5f);

        return position;
    }

    private void SpawnCoin()
    {
        GameObject go = Instantiate(coinPrefab);

        go.transform.position = GetRandomPosition(coinPrefab);
        go.SetActive(true);

        StartCoroutine(Tween.Enlarge(go, 50, 1.0f));
    }

    private void SpawnWhirl(float delay)
    {
        GameObject go = Instantiate(whirlPrefab);

        go.transform.position = GetRandomPosition(whirlPrefab);
        go.SetActive(true);

        Whirl whirl = go.GetComponent<Whirl>();

        whirl.boat = boat;
        StartCoroutine(whirl.Spawn(delay));
    }

    private void OnCoinPickedUp()
    {
        score++;
        scoreText.text = score.ToString();
        SpawnCoin();
    }

    private void OnWhirlEnd()
    {
        SpawnWhirl(3.0f);
    }
}
