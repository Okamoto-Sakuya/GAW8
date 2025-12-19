using UnityEngine;

public class KillZone : MonoBehaviour
{
    Collider zoneCollider;

    void Awake()
    {
        zoneCollider = GetComponent<Collider>();

        if (zoneCollider == null)
        {
            Debug.LogError("KillZone ‚É Collider ‚ª•t‚¢‚Ä‚¢‚Ü‚¹‚ñ");
            return;
        }

        // Å‰‚Í–³Œø
        zoneCollider.enabled = false;
    }

    public void EnableZone()
    {
        zoneCollider.enabled = true;
    }

    public void DisableZone()
    {
        zoneCollider.enabled = false;
    }
}
