using System;
using System.Net;
using GameFramework.Network;
using UnityGameFramework.Runtime;

public static class NetworkExtension
{
    /// <summary>
    /// 游戏服ip
    /// 从ServerConfig中读取
    /// </summary>
    public static string GameServerIP
    {
        get;
        set;
    }

    /// <summary>
    /// 游戏服端口
    /// 从ServerConfig中读取
    /// </summary>
    public static int GameServerPort
    {
        get;
        set;
    }

    /// <summary>
    /// 发游戏消息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="networkComponent"></param>
    /// <param name="packet"></param>
    public static void Send<T>(this NetworkComponent networkComponent,T packet) where T:CSPacketBase
    {
        networkComponent.GetNetworkChannel(Const.ServerConfigKey.GameServerIP).Send<T>(packet);
    }
}