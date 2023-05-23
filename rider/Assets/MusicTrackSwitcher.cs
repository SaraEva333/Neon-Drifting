using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrackSwitcher : MonoBehaviour
{
    [SerializeField] public SoundVolumeController soundVolumeController;

    public void SwitchToNextTrack()
    {
        // Получите текущий индекс музыкального трека
        int currentIndex = soundVolumeController.GetMusicTracks().IndexOf(soundVolumeController.GetCurrentMusicTrack());

        // Вычислите индекс следующего трека
        int nextIndex = (currentIndex + 1) % soundVolumeController.GetMusicTracks().Count;

        // Получите следующий трек из SoundVolumeController и переключите его
        AudioClip nextTrack = soundVolumeController.GetMusicTrack(nextIndex);
        soundVolumeController.ChangeMusicTrack(nextTrack);
    }

    public void SwitchToPreviousTrack()
    {
        // Получите текущий индекс музыкального трека
        int currentIndex = soundVolumeController.GetMusicTracks().IndexOf(soundVolumeController.GetCurrentMusicTrack());

        // Вычислите индекс предыдущего трека
        int previousIndex = (currentIndex - 1 + soundVolumeController.GetMusicTracks().Count) % soundVolumeController.GetMusicTracks().Count;

        // Получите предыдущий трек из SoundVolumeController и переключите его
        AudioClip previousTrack = soundVolumeController.GetMusicTrack(previousIndex);
        soundVolumeController.ChangeMusicTrack(previousTrack);
    }
}