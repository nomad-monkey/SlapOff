using UnityEngine;

public class SlapAudioSourceController : MonoBehaviour
{
    [SerializeField] private AudioSource slapAudioSource;
    
    void Start()
    {
        SlapManager.Instance.OnSlapEvent.AddListener(PlaySlapSound);
    }

    private void PlaySlapSound()
    {
        slapAudioSource.Play();
    }
}
