using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager
{
    private GameManager gameManager;

    public AudioSourceManager(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    //控制音量大小
    public void ChangeVolume(float volume)
    {
        gameManager.audioSource.volume = volume / 100.0f;
    }

    //切换声音 1.主界面 2.发牌 3.游戏界面
    public void ChangeBGM(int index)
    {
        gameManager.audioSource.clip = gameManager.audioClip[index];
        gameManager.audioSource.Play();
    }

    //停止播放
    public void StopPlay()
    {
        gameManager.audioSource.Pause();
    }
}