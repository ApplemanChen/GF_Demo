using UnityEngine;
using GameFramework;
using UnityGameFramework.Runtime;

/// <summary>
/// 玩家
/// </summary>
public class Player : GameEntity
{
    private const string IsWalking = "IsWalking";
    private const string IsAttacking = "IsAttacking";
    private const string IsRunning = "IsRunning";

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

        if(Input.GetKeyDown(KeyCode.A))
        {
            CachedAnimator.SetBool(IsWalking,true);
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            CachedAnimator.SetBool(IsRunning,true);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CachedAnimator.SetBool(IsAttacking,true);
        }
    }
}