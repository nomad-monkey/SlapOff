using UnityEngine;

public class SlapAudioSourceController : MonoBehaviour
{
    [SerializeField] private AudioSource slapAudioSource;
    
    void Start()
    {
        SlapManager.Instance.OnSlapEvent.AddListener(PlaySlapSound);
    }

    public void PlaySlapSound()
    {
        slapAudioSource.Play();
    }
}
