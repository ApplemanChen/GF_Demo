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
    public class DialogParamsWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(DialogParams);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 11, 11);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Mode", _g_get_Mode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Title", _g_get_Title);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Message", _g_get_Message);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "PauseGame", _g_get_PauseGame);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ConfirmText", _g_get_ConfirmText);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "OnClickConfirm", _g_get_OnClickConfirm);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CancelText", _g_get_CancelText);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "OnClickCancel", _g_get_OnClickCancel);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "OtherText", _g_get_OtherText);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "OnClickOther", _g_get_OnClickOther);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "UserData", _g_get_UserData);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Mode", _s_set_Mode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Title", _s_set_Title);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "Message", _s_set_Message);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "PauseGame", _s_set_PauseGame);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ConfirmText", _s_set_ConfirmText);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "OnClickConfirm", _s_set_OnClickConfirm);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "CancelText", _s_set_CancelText);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "OnClickCancel", _s_set_OnClickCancel);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "OtherText", _s_set_OtherText);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "OnClickOther", _s_set_OnClickOther);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "UserData", _s_set_UserData);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					DialogParams gen_ret = new DialogParams();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to DialogParams constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Mode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Mode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Title(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Title);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Message(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.Message);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PauseGame(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.PauseGame);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ConfirmText(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.ConfirmText);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnClickConfirm(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.OnClickConfirm);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CancelText(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.CancelText);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnClickCancel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.OnClickCancel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OtherText(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.OtherText);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnClickOther(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.OnClickOther);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UserData(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.UserData);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Mode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Mode = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Title(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Title = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Message(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Message = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PauseGame(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.PauseGame = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ConfirmText(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ConfirmText = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnClickConfirm(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.OnClickConfirm = translator.GetDelegate<GameFramework.GameFrameworkAction<object>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CancelText(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.CancelText = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnClickCancel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.OnClickCancel = translator.GetDelegate<GameFramework.GameFrameworkAction<object>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OtherText(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.OtherText = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnClickOther(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.OnClickOther = translator.GetDelegate<GameFramework.GameFrameworkAction<object>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UserData(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                DialogParams gen_to_be_invoked = (DialogParams)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.UserData = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
