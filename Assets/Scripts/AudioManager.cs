using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    private AudioSource audioSource;
    public AudioClip[] audioClip;
    public AudioSource bgAudioSource;

    private void Awake()
    {
        instance = this;
        this.audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        DontDestroyOnLoad(instance); 
    }
    public void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            bgAudioSource.volume = GameManager.instance.volumeAdjustSlider.value;
        }    
    }

    public void PaperCrashSound()
    {   
        audioSource.PlayOneShot(audioClip[0],8);
    }
}
