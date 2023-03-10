using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource levelMusic, gameOverMusic, vitoryMusic;
    public AudioSource[] sfx;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGameOver()
    {
        levelMusic.Stop();
        gameOverMusic.Play();
    }

    public void PlayVictoryMusic()
    {
        levelMusic.Stop();
        vitoryMusic.Play();
    }

    public void playSFX(int sxfToPlay)
    {
        sfx[sxfToPlay].Stop();
        sfx[sxfToPlay].Play();
    }
}
