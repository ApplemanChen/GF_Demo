#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class LuaCallStaticWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(LuaCallStatic);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 8, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "LuaCloseForm", _m_LuaCloseForm_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LuaOpenForm", _m_LuaOpenForm_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddButtonClick", _m_AddButtonClick_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RemoveButtonClick", _m_RemoveButtonClick_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "AddEvent", _m_AddEvent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "RemoveEvent", _m_RemoveEvent_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FireEvent", _m_FireEvent_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					LuaCallStatic gen_ret = new LuaCallStatic();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to LuaCallStatic constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LuaCloseForm_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _uiFormId = LuaAPI.lua_tostring(L, 1);
                    
                    LuaCallStatic.LuaCloseForm( _uiFormId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LuaOpenForm_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)&& translator.Assignable<object>(L, 2)) 
                {
                    string _uiFormId = LuaAPI.lua_tostring(L, 1);
                    object _userData = translator.GetObject(L, 2, typeof(object));
                    
                    LuaCallStatic.LuaOpenForm( _uiFormId, _userData );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1&& (LuaAPI.lua_isnil(L, 1) || LuaAPI.lua_type(L, 1) == LuaTypes.LUA_TSTRING)) 
                {
                    string _uiFormId = LuaAPI.lua_tostring(L, 1);
                    
                    LuaCallStatic.LuaOpenForm( _uiFormId );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaCallStatic.LuaOpenForm!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddButtonClick_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& translator.Assignable<UIEventListener.VoidDelegate>(L, 2)) 
                {
                    UnityEngine.GameObject _go = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    UIEventListener.VoidDelegate _onBtnClick = translator.GetDelegate<UIEventListener.VoidDelegate>(L, 2);
                    
                    LuaCallStatic.AddButtonClick( _go, _onBtnClick );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& translator.Assignable<UnityEngine.Events.UnityAction>(L, 2)) 
                {
                    UnityEngine.GameObject _go = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    UnityEngine.Events.UnityAction _onBtnClick = translator.GetDelegate<UnityEngine.Events.UnityAction>(L, 2);
                    
                    LuaCallStatic.AddButtonClick( _go, _onBtnClick );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaCallStatic.AddButtonClick!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveButtonClick_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& translator.Assignable<UIEventListener.VoidDelegate>(L, 2)) 
                {
                    UnityEngine.GameObject _go = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    UIEventListener.VoidDelegate _onBtnClick = translator.GetDelegate<UIEventListener.VoidDelegate>(L, 2);
                    
                    LuaCallStatic.RemoveButtonClick( _go, _onBtnClick );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.GameObject>(L, 1)&& translator.Assignable<UnityEngine.Events.UnityAction>(L, 2)) 
                {
                    UnityEngine.GameObject _go = (UnityEngine.GameObject)translator.GetObject(L, 1, typeof(UnityEngine.GameObject));
                    UnityEngine.Events.UnityAction _onBtnClick = translator.GetDelegate<UnityEngine.Events.UnityAction>(L, 2);
                    
                    LuaCallStatic.RemoveButtonClick( _go, _onBtnClick );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to LuaCallStatic.RemoveButtonClick!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddEvent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _eventId = LuaAPI.xlua_tointeger(L, 1);
                    System.EventHandler<GameFramework.Event.GameEventArgs> _onEventHandler = translator.GetDelegate<System.EventHandler<GameFramework.Event.GameEventArgs>>(L, 2);
                    
                    LuaCallStatic.AddEvent( _eventId, _onEventHandler );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveEvent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _eventId = LuaAPI.xlua_tointeger(L, 1);
                    System.EventHandler<GameFramework.Event.GameEventArgs> _onEventHandler = translator.GetDelegate<System.EventHandler<GameFramework.Event.GameEventArgs>>(L, 2);
                    
                    LuaCallStatic.RemoveEvent( _eventId, _onEventHandler );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FireEvent_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _eventId = LuaAPI.xlua_tointeger(L, 1);
                    string _sender = LuaAPI.lua_tostring(L, 2);
                    object[] _param = (object[])translator.GetObject(L, 3, typeof(object[]));
                    
                    LuaCallStatic.FireEvent( _eventId, _sender, _param );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
