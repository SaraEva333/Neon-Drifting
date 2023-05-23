using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrackSwitcher : MonoBehaviour
{
    [SerializeField] public SoundVolumeController soundVolumeController;

    public void SwitchToNextTrack()
    {
        // �������� ������� ������ ������������ �����
        int currentIndex = soundVolumeController.GetMusicTracks().IndexOf(soundVolumeController.GetCurrentMusicTrack());

        // ��������� ������ ���������� �����
        int nextIndex = (currentIndex + 1) % soundVolumeController.GetMusicTracks().Count;

        // �������� ��������� ���� �� SoundVolumeController � ����������� ���
        AudioClip nextTrack = soundVolumeController.GetMusicTrack(nextIndex);
        soundVolumeController.ChangeMusicTrack(nextTrack);
    }

    public void SwitchToPreviousTrack()
    {
        // �������� ������� ������ ������������ �����
        int currentIndex = soundVolumeController.GetMusicTracks().IndexOf(soundVolumeController.GetCurrentMusicTrack());

        // ��������� ������ ����������� �����
        int previousIndex = (currentIndex - 1 + soundVolumeController.GetMusicTracks().Count) % soundVolumeController.GetMusicTracks().Count;

        // �������� ���������� ���� �� SoundVolumeController � ����������� ���
        AudioClip previousTrack = soundVolumeController.GetMusicTrack(previousIndex);
        soundVolumeController.ChangeMusicTrack(previousTrack);
    }
}