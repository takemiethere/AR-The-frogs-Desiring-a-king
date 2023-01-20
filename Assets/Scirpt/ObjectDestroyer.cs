using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public GameObject particleEffect;
    public AudioClip destroySound1;
    public AudioClip destroySound2;
    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnDestroy()
    {
        Instantiate(particleEffect, transform.position, Quaternion.identity);

        audioSource.PlayOneShot(destroySound1);
        audioSource.PlayOneShot(destroySound2);

        Debug.Log("Sound on");
    }
}