using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [System.Serializable]
    public class Audio {
        public string name;
        public AudioClip clip;
    } 

    public List<Audio> AudioClips = new List<Audio>();

    private void Awake() {
    if (!instance)
        instance = this;
    else
        Destroy(this);
    }

    public void Play(string name, bool loop, AudioSource source) {
        source.Stop();
        source.clip = AudioClips.Find(x => x.name == name).clip;
        source.loop = loop;
        source.Play();
    }

    public void Play(string name, bool loop) {
        Play(name, loop, GetComponent<AudioSource>());
    }

    public void DisableListener() {
        GetComponent<AudioListener>().enabled = false;
    }

    public void EnableListener() {
        GetComponent<AudioListener>().enabled = true;
    }
}
