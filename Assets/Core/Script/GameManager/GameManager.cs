using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Audio")]
    public AudioSource darumaVoice;
    public AudioClip darumaClip;

    [Header("Kill Zone Collider")]
    public Collider killZoneCollider;   // InspectorÇ≈éwíË

    [Header("Game Limit")]
    public float limitTime = 180f;

    float gameTimer;
    bool isGameOver = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // KillZoneÇÕç≈èâOFF
        if (killZoneCollider != null)
            killZoneCollider.enabled = false;

        StartCoroutine(DarumaLoop());
    }

    void Update()
    {
        if (isGameOver) return;

        gameTimer += Time.deltaTime;
        if (gameTimer >= limitTime)
        {
            GameOver();
        }
    }

    IEnumerator DarumaLoop()
    {
        while (!isGameOver)
        {
            // á@ 1?5ïbÉâÉìÉ_ÉÄë“ã@
            yield return new WaitForSeconds(Random.Range(1f, 5f));

            // áA âπê∫çƒê∂Åiç≈å„Ç‹Ç≈ÅEèdÇ»ÇÁÇ»Ç¢Åj
            darumaVoice.PlayOneShot(darumaClip);
            yield return new WaitForSeconds(darumaClip.length);

            // áB KillZone ONÅi2ïbÅj
            killZoneCollider.enabled = true;
            yield return new WaitForSeconds(2f);

            // áC KillZone OFF
            killZoneCollider.enabled = false;
        }
    }

    public bool IsKillZoneActive()
    {
        return killZoneCollider != null && killZoneCollider.enabled;
    }

    // =========================
    // Game Over
    // =========================
    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        StopAllCoroutines();

        Time.timeScale = 0f;
        HorrorUI.Instance.Show();
        Invoke(nameof(LoadGameOver), 3f);
    }

    void LoadGameOver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameOver");
    }

    // =========================
    // Game Clear
    // =========================
    public void GameClear()
    {
        if (isGameOver) return;

        isGameOver = true;
        StopAllCoroutines();

        Time.timeScale = 0f;
        Invoke(nameof(LoadResult), 1f);
    }

    void LoadResult()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Result");
    }
}
