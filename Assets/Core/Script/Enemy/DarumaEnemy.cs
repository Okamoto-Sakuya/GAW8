using UnityEngine;

public class DarumaEnemy : MonoBehaviour
{
    public static DarumaEnemy Instance;
    public Animator anim;

    void Awake()
    {
        Instance = this;
    }

    public void LookAtPlayer()
    {
        anim.SetTrigger("Look");
    }

    public void LookBack()
    {
        anim.SetTrigger("Back");
    }
}
