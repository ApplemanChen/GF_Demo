using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;

/// <summary>
/// 玩家
/// </summary>
public class Player : GameEntity
{
    public Player()
    {

    }

    protected internal override void OnInit(object userData)
    {
        base.OnInit(userData);

        if(CachedAnimator == null)
        {
            Log.Error("CacheAnimator is null!");
            return;
        }
    }

    protected internal override void OnShow(object userData)
    {
        base.OnShow(userData);
    }

    protected internal override void OnHide(object userData)
    {
        base.OnHide(userData);

    }

    protected internal override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);

        if(Input.GetKeyUp(KeyCode.A))
        {
            CachedAnimator.Play("Walk");
        }

        if(Input.GetKeyUp(KeyCode.B))
        {
            CachedAnimator.Play("Run");
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            CachedAnimator.Play("Attack1");
        }
    }
}