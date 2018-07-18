//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework;
using GameFramework.DataTable;
using GameFramework.Sound;
using UnityGameFramework.Runtime;

public static class SoundExtension
{
    private const float FadeVolumeDuration = 1f;
    private static int? s_MusicSerialId = null;

    /// <summary>
    /// 播放背景音乐
    /// </summary>
    /// <param name="soundComponent"></param>
    /// <param name="musicId"></param>
    /// <param name="userData"></param>
    /// <returns></returns>
    public static int? PlayMusic(this SoundComponent soundComponent, int musicId, object userData = null)
    {
        soundComponent.StopMusic();

        IDataTable<DRMusic> dtMusic = GameManager.DataTable.GetDataTable<DRMusic>();
        DRMusic drMusic = dtMusic.GetDataRow(musicId);
        if (drMusic == null)
        {
            Log.Warning("Can not load music '{0}' from data table.", musicId.ToString());
            return null;
        }

        PlaySoundParams playSoundParams = new PlaySoundParams
        {
            Priority = 64,
            Loop = true,
            VolumeInSoundGroup = 1f,
            FadeInSeconds = FadeVolumeDuration,
            SpatialBlend = 0f,
        };

        s_MusicSerialId = soundComponent.PlaySound(AssetUtility.GetMusicAsset(drMusic.Asset),"Music",playSoundParams.Priority,playSoundParams,userData);
        return s_MusicSerialId;
    }

    public static void StopMusic(this SoundComponent soundComponent)
    {
        if(!s_MusicSerialId.HasValue)
        {
            return;
        }

        soundComponent.StopSound(s_MusicSerialId.Value);
    }

    /// <summary>
    /// 播放普通音效
    /// </summary>
    /// <param name="soundComponent"></param>
    /// <param name="soundId"></param>
    /// <param name="entity"></param>
    public static void PlaySound(this SoundComponent soundComponent, int soundId,Entity entity)
    {
        //TODO:通过id从音效配置中找到对应的资源,播放
        string assetName = "TestSound";

        PlaySoundParams playSoundParams = new PlaySoundParams
        {
            //这些参数，可以填在音效配置中
            Priority = 0,
            Loop = true,
            VolumeInSoundGroup = 1f,
            FadeInSeconds = FadeVolumeDuration,
            SpatialBlend = 0f,
        };

        soundComponent.PlaySound(AssetUtility.GetSoundAsset(assetName),"Sound",playSoundParams.Priority,playSoundParams);
    }

    /// <summary>
    /// 播放界面音效
    /// </summary>
    /// <param name="soundComponent"></param>
    /// <param name="soundId"></param>
    public static void PlayUISound(this SoundComponent soundComponent,int soundId)
    {
        soundComponent.PlayUISound(soundId,null);
    }

    /// <summary>
    /// 播放界面音效
    /// </summary>
    /// <param name="soundComponent"></param>
    /// <param name="soundId"></param>
    /// <param name="userData"></param>
    public static void PlayUISound(this SoundComponent soundComponent,int soundId,object userData)
    {
        //TODO:通过id从音效配置中找到对应的资源,播放
        string assetName = "TestUISound";

        PlaySoundParams playSoundParams = new PlaySoundParams
        {
            //这些参数，可以填在音效配置中
            Priority = 0,
            Loop = true,
            VolumeInSoundGroup = 1f,
            FadeInSeconds = FadeVolumeDuration,
            SpatialBlend = 0f,
        };
        soundComponent.PlaySound(AssetUtility.GetUISoundAsset(assetName),"UISound",playSoundParams.Priority,playSoundParams,userData);
    }

    /// <summary>
    /// 获取声音组是否静音
    /// </summary>
    /// <param name="soundComponent"></param>
    /// <param name="soundGroupName"></param>
    /// <returns></returns>
    public static bool IsMuted(this SoundComponent soundComponent,string soundGroupName)
    {

        if(string.IsNullOrEmpty(soundGroupName))
        {
            Log.Warning("Sound group name is null or empty.");
            return true;
        }

        ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);

        if(soundGroup == null)
        {
            Log.Warning("Sound group is invalid.");
            return true;
        }

        return soundGroup.Mute;
    }

    /// <summary>
    /// 设置声音组是否静音
    /// </summary>
    /// <param name="soundComponent"></param>
    /// <param name="soundGroupName"></param>
    /// <param name="isMute"></param>
    public static void SetMute(this SoundComponent soundComponent,string soundGroupName,bool isMute)
    {
        if (string.IsNullOrEmpty(soundGroupName))
        {
            Log.Warning("Sound group name is null or empty.");
            return;
        }

        ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);

        if (soundGroup == null)
        {
            Log.Warning("Sound group is invalid.");
            return;
        }

        soundGroup.Mute = isMute;

        GameManager.Setting.SetBool(string.Format(Const.SettingKey.SoundGroupMuted,soundGroupName),isMute);
        GameManager.Setting.Save();
    }

    /// <summary>
    /// 获取声音组音量
    /// </summary>
    /// <param name="soundComponent"></param>
    /// <param name="soundGroupName"></param>
    /// <returns></returns>
    public static float GetVolume(this SoundComponent soundComponent,string soundGroupName)
    {
        if (string.IsNullOrEmpty(soundGroupName))
        {
            Log.Warning("Sound group name is null or empty.");
            return 0;
        }

        ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);

        if (soundGroup == null)
        {
            Log.Warning("Sound group is invalid.");
            return 0;
        }

        return soundGroup.Volume;
    }

    /// <summary>
    /// 设置声音组音量
    /// </summary>
    /// <param name="soundComponent"></param>
    /// <param name="soundGroupName"></param>
    /// <param name="volume"></param>
    public static void SetVolume(this SoundComponent soundComponent,string soundGroupName,float volume)
    {
        if (string.IsNullOrEmpty(soundGroupName))
        {
            Log.Warning("Sound group name is null or empty.");
            return;
        }

        ISoundGroup soundGroup = soundComponent.GetSoundGroup(soundGroupName);

        if (soundGroup == null)
        {
            Log.Warning("Sound group is invalid.");
            return;
        }

        soundGroup.Volume = volume;
        GameManager.Setting.SetFloat(string.Format(Const.SettingKey.SoundGroupVolume, soundGroupName),volume);
        GameManager.Setting.Save();
    }
}
