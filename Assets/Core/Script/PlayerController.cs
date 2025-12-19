using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(h, 0, v);

        // KillZone‚ª—LŒø’†‚É“®‚¢‚½‚çGameOver
        if (GameManager.Instance != null &&
            GameManager.Instance.IsKillZoneActive() &&
            move.magnitude > 0.01f)
        {
            GameManager.Instance.GameOver();
            return;
        }

        transform.Translate(move.normalized * speed * Time.deltaTime);
    }
}
