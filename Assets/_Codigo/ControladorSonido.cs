using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonido : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    //[SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource footstepsSource;

    public AudioClip background;
    public AudioClip footsteps;


    public static ControladorSonido instance;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }


    }
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();

    }
    //public void playAudio(AudioClip clip)
    //{
    //    sfxSource.PlayOneShot(clip);
    //}
    public void playFootstep()
    {


        if (!footstepsSource.isPlaying || footstepsSource.clip != footsteps)
        {
            footstepsSource.clip = footsteps;
            footstepsSource.Play();
        }
    }

    public void stopFootstep()
    {
        footstepsSource.Stop();
    }
    public AudioClip audioFootstep
    {
        get { return footstepsSource.clip; }
    }
}
