using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip audioClip1;
    public AudioClip audioClip2;

    private KeyCode _playSong1= KeyCode.Alpha1;
    private KeyCode _playSong2 = KeyCode.Alpha2;
    private KeyCode _noSong = KeyCode.S;
    //private KeyCode _playSong3 = KeyCode.Alpha3;
    //private KeyCode _playSong4 = KeyCode.Alpha4;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(_playSong1))
        {
            audioSource.Stop();
            audioSource.clip = audioClip1;
            audioSource.Play();
        }
        if (Input.GetKey(_playSong2))
        {
            audioSource.Stop();
            audioSource.clip = audioClip2;
            audioSource.Play();
        }
        if (Input.GetKey(_noSong))
        {
            audioSource.Stop();
        }
    }
}
