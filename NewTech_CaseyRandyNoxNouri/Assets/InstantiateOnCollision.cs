using UnityEngine;

public class InstantiateOnCollision : MonoBehaviour
{
    public float impact;
    public GameObject prefab;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.impulse.sqrMagnitude >= impact * impact)
        {
            var contact = collision.GetContact(0);
            var instance = Instantiate(prefab, contact.point, Quaternion.Euler(contact.normal));

            var audioSource = instance.GetComponent<AudioSource>();
            Destroy(audioSource, audioSource.clip.length);

            var particleSystem = instance.GetComponent<ParticleSystem>();
            Destroy(particleSystem, particleSystem.main.duration);
        }
    }
}
