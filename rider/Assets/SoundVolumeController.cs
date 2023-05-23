using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeController : MonoBehaviour
{
    private static SoundVolumeController instance;

    public static SoundVolumeController Instance
    {
        get { return instance; }
    }

    [SerializeField] private List<AudioClip> musicTracks;

    [Header("Components")]
    [SerializeField] private AudioSource audio; 
    [SerializeField] private Slider slider;
    [SerializeField] private Text text;

    [Header("Keys")]
    [SerializeField] private string saveVolumeKey;

    [Header("Tags")]
    [SerializeField] private string textVolumeTag;
    [SerializeField] private string sliderTag;

    [Header("Parameters")]
    [SerializeField] private float volume;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey(this.saveVolumeKey)) 
        {
            this.volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
            this.audio.volume = this.volume;

            GameObject sliderObj = GameObject.FindWithTag(this.sliderTag); 
            if (sliderObj != null) 
            {
                this.slider = sliderObj.GetComponent<Slider>();
                this.slider.value = this.volume;
            }
        }
        else
        {
            this.volume = 0.5f;
            PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
            this.audio.volume = this.volume;
        }
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public List<AudioClip> GetMusicTracks()
    {
        return musicTracks;
    }
    public AudioClip GetCurrentMusicTrack()
    {
        return audio.clip;
    }
    public AudioClip GetMusicTrack(int index)
    {
        if (index >= 0 && index < musicTracks.Count)
        {
            return musicTracks[index];
        }

        return null;
    }

    public void ChangeMusicTrack(AudioClip track)
    {
        if (track != null)
        {
            audio.Stop();
            audio.clip = track;
            audio.Play();
        }
    }
    private void LateUpdate()
    {
        GameObject sliderObj = GameObject.FindWithTag(this.sliderTag); 
        if (sliderObj != null)
        {
            this.slider = sliderObj.GetComponent<Slider>();
            this.volume = slider.value;

            if (this.audio.volume != this.volume)
            {
                PlayerPrefs.SetFloat(this.saveVolumeKey, this.volume);
                
            }

        }
        this.audio.volume = this.volume;
    }
}
