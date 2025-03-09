using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    private List<EventInstance> eventInstances;

    private List<StudioEventEmitter> eventEmitters;

    private EventInstance ambienceEventInstance;

    private EventInstance musicEventInstance;

    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
        instance = this;

        eventInstances = new List<EventInstance>();
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public void PlayOneShotUI(EventReference sound)
    {
        RuntimeManager.PlayOneShot(sound); 
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    void Start()
    {
        if (IsMainMenuScene())
        {
            PlayMusic(FmodEvents.instance.mainMenuMusic);
        }
        else
        {
            PlayMusic(FmodEvents.instance.music);          // 播放关卡 BGM
            PlayAmbience(FmodEvents.instance.ambience);    // 播放环境音
        }
        
    }

    public void PlayMusic(EventReference musicEventReference)
    {
        if (musicEventInstance.isValid())
        {
            musicEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            musicEventInstance.release();
        }

        musicEventInstance = CreateInstance(musicEventReference);
        musicEventInstance.start();
    }

    private void PlayAmbience(EventReference ambienceEventReference)
    {
        ambienceEventInstance = CreateInstance(ambienceEventReference);
        ambienceEventInstance.start();
    }


    public void PauseAudio()
    {
        if (musicEventInstance.isValid())
        {
            musicEventInstance.setPaused(true);
        }
        if (ambienceEventInstance.isValid())
        {
            ambienceEventInstance.setPaused(true);
        }
    }

    public void ResumeAudio()
    {
        if (musicEventInstance.isValid())
        {
            musicEventInstance.setPaused(false);
        }
        if (ambienceEventInstance.isValid())
        {
            ambienceEventInstance.setPaused(false);
        }
    }

    public void SetBGMVolume(float volume)
    {
        VCA bgmVCA = RuntimeManager.GetVCA("vca:/BGM_VCA");
        bgmVCA.setVolume(volume); // volume 的取值通常在 0 到 1 之间
    }

    public void SetSFXVolume(float volume)
    {
        VCA sfxVCA = RuntimeManager.GetVCA("vca:/SFX_VCA");
        sfxVCA.setVolume(volume); // volume 的取值通常在 0 到 1 之间
    }
    private void CleanUp()
    {
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    private bool IsMainMenuScene()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "MainMenu"; // 修改成你的主菜单场景名称
    }
}
