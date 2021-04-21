using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Audio;

public class AudioStartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;
    private float mVolume = 1f;
    void Start()
    {
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        music.volume = mVolume;   
    }
    public void UpdateVolume(float volume) {
        mVolume = volume;
    }
}
