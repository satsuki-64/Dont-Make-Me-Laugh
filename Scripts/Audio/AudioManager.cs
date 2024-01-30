using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Music[] Musics;
    public Sound[] Sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            GameObject.Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
    }
    public static AudioManager Instance()
    {
        if (instance != null)
        {
            return instance;
        }

        instance = new AudioManager();

        Debug.Log("AudioManager 为空！");
        return null;
    }
    
    private void Start()
    {
        foreach (Music music in Musics)
        {
            music.Source = gameObject.AddComponent<AudioSource>();
            music.Source.clip = music.Clip;
            music.Source.name = music.Name;
            Debug.Log(music.Source.name);
        }

        foreach (Sound sound in Sounds)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.name = sound.Name;
        }
    }


    public void MusicPlay(string name)
    {
        foreach (Music music in Musics)
        {
            if (music.Name == name)
            {
                music.Source.Play();
            }
            Debug.LogWarning("没有找到" + name + "音频！");
        }

        //AudioClip clip = Resources.Load<AudioClip>(name);
        
    }

    public void MusicPause(string name)
    {
        foreach (Music music in Musics)
        {
            if (music.Name == name)
            {
                music.Source.Pause();
            }
            Debug.LogWarning("没有找到" + name + "音频！");
        }
    }

    public void MusicStop(string name)
    {
        foreach (Music music in Musics)
        {
            if (music.Name == name)
            {
                music.Source.Stop();
            }
            Debug.LogWarning("没有找到" + name + "音频！");
        }
    }
    
    public void SoundPlay(string name)
    {
        foreach (Sound sound in Sounds)
        {
            if (sound.Name == name)
            {
                sound.Source.Play();
            }
            Debug.LogWarning("没有找到" + name + "音频！");
        }
    }

    public void SoundPause(string name)
    {
        foreach (Sound sound in Sounds)
        {
            if (sound.Name == name)
            {
                sound.Source.Pause();
            }
            Debug.LogWarning("没有找到" + name + "音频！");
        }
    }

    public void SoundStop(string name)
    {
        foreach (Sound sound in Sounds)
        {
            if (sound.Name == name)
            {
                sound.Source.Stop();
            }
            Debug.LogWarning("没有找到" + name + "音频！");
        }
    }

}