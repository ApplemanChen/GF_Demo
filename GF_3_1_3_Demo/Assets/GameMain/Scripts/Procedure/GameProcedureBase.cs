using GameFramework;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

/// <summary>
/// 应用层-流程基类
/// </summary>
public abstract class GameProcedureBase : ProcedureBase
{
    protected ProcedureOwner ProcedureOwner
    {
        private set;
        get;
    }

    protected override void OnInit(GameFramework.Fsm.IFsm<IProcedureManager> procedureOwner)
    {
        base.OnInit(procedureOwner);

        ProcedureOwner = procedureOwner;
    }

    protected override void OnEnter(GameFramework.Fsm.IFsm<IProcedureManager> procedureOwner)
    {
        Log.Info("GameProcedureBase ===> Enter {0}",this.GetType().Name);

        base.OnEnter(procedureOwner);
    }

    protected override void OnUpdate(GameFramework.Fsm.IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
    }

    protected override void OnLeave(GameFramework.Fsm.IFsm<IProcedureManager> procedureOwner, bool isShutdown)
    {
        base.OnLeave(procedureOwner, isShutdown);
    }

}
