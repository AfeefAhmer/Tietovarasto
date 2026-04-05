using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    // Äänilähteet sisältävä oliotaulukko
    public Sound[] sounds;

    // Vain yksi esiintymä (Sinkelton)
    public static AudioManager instance;

	// Use this for initialization before Start-metohod
	void Awake () {

        // Onko AudioManageri olemassa?
        if (instance == null)
            // AudioManager ei ole olemassa, joten luodaan se
            instance = this;
        else
        {
            // AudioManager on jom olemassa, joten tuhotaan se
            Destroy(gameObject);

            // Varmistetaan että muuta koodia ei enää suoriteta
            return;
        }

        // Älä tuhoa GameObjektia ladattaessa
        DontDestroyOnLoad(gameObject);
        
        // Näyttää oliotaulukon kaikki äänilähteet
        foreach (Sound s in sounds)
        {
            // Yhetys äänilähteeseen
            s.source = gameObject.AddComponent<AudioSource>();
            
            // Ääni joka halutaan soittaa
            s.source.clip = s.clip;
            
            // Päivittää tehdyt säädöt Audio-komponenttiin
            s.source.volume = s.volume; // voimakkuus
            s.source.pitch = s.pitch;   // 
            s.source.loop = s.loop;     // soitetaanko loopissa
        }
	}

    public void Start()
    {
        // Soitetaan Teema niminen ääni
        //Play("WinFanfare");
    }

    /// <summary>
    /// Soittaa halutun äänen.
    /// </summary>
    /// <param name="name"></param>
    public void Play(string name)
    {   
        // Etsitään haluttu ääni
        Sound s = Array.Find(sounds, sound => sound.name == name);
        // Onko ääntä olemassa?
        if (s == null)
            // Ei ole, joten hypätään metodista pois
            return;
        // Soitetaan ääni
        s.source.Play();
    }
}
