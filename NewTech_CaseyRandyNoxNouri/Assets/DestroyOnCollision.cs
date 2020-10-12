using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public float impact;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.impulse.sqrMagnitude >= impact * impact)
        {
            Destroy(gameObject);
        }
    }
}
