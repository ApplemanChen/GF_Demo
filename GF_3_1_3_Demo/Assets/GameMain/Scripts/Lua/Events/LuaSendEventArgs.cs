//------------------------------------------------------------
// Copyright © 2017-2020 Chen Hua. All rights reserved.
// Author: 一条猪儿虫
// Email: 1184923569@qq.com
//------------------------------------------------------------

using GameFramework.Event;

/// <summary>
/// Lua发送的过来的事件（Lua通用）
/// </summary>
public class LuaSendEventArgs:GameEventArgs
{
    public override int Id
    {
        get { return EventId; }
    }

    public int EventId
    {
        private set;
        get;
    }

    public string Sender
    {
        private set;
        get;
    }

    public object[] Param
    {
        private set;
        get;
    }

    public override void Clear()
    {
        EventId = default(int);
    }

    /// <summary>
    /// 填充事件参数
    /// </summary>
    /// <param name="eventId">事件id</param>
    /// <param name="param">参数数组</param>
    public LuaSendEventArgs Fill(int eventId,string sender,object[] param)
    {
        this.Sender = sender;
        this.EventId = eventId;
        this.Param = param;

        return this;
    }
}
