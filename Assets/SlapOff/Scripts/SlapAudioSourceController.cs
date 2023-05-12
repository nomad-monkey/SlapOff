using UnityEngine;

public class SlapAudioSourceController : MonoBehaviour
{
    [SerializeField] private AudioSource slapMinAudioSource;
    [SerializeField] private AudioSource slapMidAudioSource;
    [SerializeField] private AudioSource slapMaxAudioSource;
    [SerializeField] private float slapMinEndValue;
    [SerializeField] private float slapMidEndValue;
    
    void Start()
    {
        SlapManager.Instance.OnSlapEvent.AddListener(PlaySlapSound);
    }

    private void PlaySlapSound()
    {
        var slapScore = SlapManager.Instance.Score;
        PlayOneOfTheSlapSounds(slapScore);
    }

    public void PlayOneOfTheSlapSounds(float slapScore)
    {
        if (slapScore <= slapMinEndValue)
        {
            PlaySlapMinSound();
        }
        else if (slapScore <= slapMidEndValue)
        {
            PlaySlapMidSound();
        }
        else
        {
            PlaySlapMaxSound();
        }
    }

    private void PlaySlapMinSound()
    {
        slapMinAudioSource.Play();
    }

    private void PlaySlapMidSound()
    {
        slapMidAudioSource.Play();
    }

    private void PlaySlapMaxSound()
    {
        slapMaxAudioSource.Play();
    }
}
