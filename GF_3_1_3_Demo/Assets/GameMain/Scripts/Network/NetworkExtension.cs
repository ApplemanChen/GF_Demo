using System;
using System.Net;
using GameFramework.Network;
using UnityGameFramework.Runtime;

public static class NetworkExtension
{
    /// <summary>
    /// 游戏服内网
    /// </summary>
    public const string GAME_SERVER_IN_SIDE = "GAME_SERVER_IN_SIDE";
    
    /// <summary>
    /// 游戏服外网
    /// </summary>
    private const string GAME_SERVER_OUT_SIDE = "GAME_SERVER_OUT_SIDE";

    /// <summary>
    /// 聊天服
    /// </summary>
    private const string CHAT_SERVER = "CHAT_SERVER";

    /// <summary>
    /// 游戏服当前网络
    /// </summary>
    public static string gameNetworkChannel = GAME_SERVER_IN_SIDE;

    /// <summary>
    /// 获取IP
    /// </summary>
    /// <param name="networkChannelName"></param>
    /// <returns></returns>
    public static IPAddress GetIPAddress(string networkChannelName)
    {
        string ip = "";
        switch (networkChannelName)
        {
            case GAME_SERVER_IN_SIDE:
                ip = "192.168.1.112";
                break;
            case GAME_SERVER_OUT_SIDE:
                ip = "";
                break;
            case CHAT_SERVER:
                ip = "192.168.1.112";
                break;
        }

        return IPAddress.Parse(ip);
    }

    /// <summary>
    /// 获取端口
    /// </summary>
    /// <param name="networkChannelName"></param>
    /// <returns></returns>
    public static int GetPort(string networkChannelName)
    {
        int port = 3355;
        
        switch(networkChannelName)
        {
            case GAME_SERVER_IN_SIDE:
                port = 3355;
                break;
            case GAME_SERVER_OUT_SIDE:
                port = 4455;
                break;
            case CHAT_SERVER:
                port = 4466;
                break;
        }

        return port;
    }

    /// <summary>
    /// 发游戏消息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="networkComponent"></param>
    /// <param name="packet"></param>
    public static void Send<T>(this NetworkComponent networkComponent,T packet) where T:CSPacketBase
    {
        networkComponent.GetNetworkChannel(gameNetworkChannel).Send<T>(packet);
    }

    /// <summary>
    /// 发聊天消息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="networkComponent"></param>
    /// <param name="packet"></param>
    public static void SendChat<T>(this NetworkComponent networkComponent,T packet) where T:CSPacketBase
    {
        networkComponent.GetNetworkChannel(CHAT_SERVER).Send<T>(packet);
    }
}