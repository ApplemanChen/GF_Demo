using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 游戏全局入口
/// 接管GF的GameEntry入口
/// </summary>
public class GameManager : MonoBehaviour
{
    #region 框架内置组件
    public static BaseComponent Base
    {
        private set;
        get;
    }

    public static DataTableComponent DataTable
    {
        private set;
        get;
    }

    public static ConfigComponent Config
    {
        private set;
        get;
    }

    public static EventComponent Event
    {
        private set;
        get;
    }

    public static NetworkComponent Network
    {
        private set;
        get;
    }

    public static LocalizationComponent Localization
    {
        private set;
        get;
    }

    public static SettingComponent Setting
    {
        private set;
        get;
    }

    public static SoundComponent Sound
    {
        private set;
        get;
    }

    public static UIComponent UI
    {
        private set;
        get;
    }

    public static ProcedureComponent Procedure
    {
        private set;
        get;
    }

    public static ResourceComponent Resource
    {
        private set;
        get;
    }

    #endregion

    #region 自定义组件
    #endregion


    private void InitBuiltinComponents()
    {
        Base = GameEntry.GetComponent<BaseComponent>();
        DataTable = GameEntry.GetComponent<DataTableComponent>();
        Config = GameEntry.GetComponent<ConfigComponent>();
        Event = GameEntry.GetComponent<EventComponent>();
        Network = GameEntry.GetComponent<NetworkComponent>();
        Localization = GameEntry.GetComponent<LocalizationComponent>();
        Setting = GameEntry.GetComponent<SettingComponent>();
        Sound = GameEntry.GetComponent<SoundComponent>();
        UI = GameEntry.GetComponent<UIComponent>();
        Procedure = GameEntry.GetComponent<ProcedureComponent>();
        Resource = GameEntry.GetComponent<ResourceComponent>();
    }

    private void InitCustomComponents()
    {

    }

    void Start()
    {
        InitBuiltinComponents();
        InitCustomComponents();
    }
}
