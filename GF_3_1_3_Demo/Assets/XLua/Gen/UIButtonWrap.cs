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
    public class UIButtonWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UIButton);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 12, 12);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetState", _m_SetState);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "isEnabled", _g_get_isEnabled);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "normalSprite", _g_get_normalSprite);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "normalSprite2D", _g_get_normalSprite2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "dragHighlight", _g_get_dragHighlight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "hoverSprite", _g_get_hoverSprite);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pressedSprite", _g_get_pressedSprite);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "disabledSprite", _g_get_disabledSprite);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "hoverSprite2D", _g_get_hoverSprite2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pressedSprite2D", _g_get_pressedSprite2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "disabledSprite2D", _g_get_disabledSprite2D);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pixelSnap", _g_get_pixelSnap);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onClick", _g_get_onClick);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "isEnabled", _s_set_isEnabled);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "normalSprite", _s_set_normalSprite);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "normalSprite2D", _s_set_normalSprite2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "dragHighlight", _s_set_dragHighlight);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "hoverSprite", _s_set_hoverSprite);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pressedSprite", _s_set_pressedSprite);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "disabledSprite", _s_set_disabledSprite);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "hoverSprite2D", _s_set_hoverSprite2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pressedSprite2D", _s_set_pressedSprite2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "disabledSprite2D", _s_set_disabledSprite2D);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pixelSnap", _s_set_pixelSnap);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onClick", _s_set_onClick);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 1, 1);
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "current", _g_get_current);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "current", _s_set_current);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UIButton gen_ret = new UIButton();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UIButton constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetState(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UIButtonColor.State _state;translator.Get(L, 2, out _state);
                    bool _immediate = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.SetState( _state, _immediate );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isEnabled(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isEnabled);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_normalSprite(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.normalSprite);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_normalSprite2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.normalSprite2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_current(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UIButton.current);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dragHighlight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.dragHighlight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hoverSprite(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.hoverSprite);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pressedSprite(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.pressedSprite);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_disabledSprite(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.disabledSprite);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hoverSprite2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.hoverSprite2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pressedSprite2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.pressedSprite2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_disabledSprite2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.disabledSprite2D);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pixelSnap(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.pixelSnap);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onClick(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onClick);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isEnabled(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.isEnabled = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_normalSprite(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.normalSprite = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_normalSprite2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.normalSprite2D = (UnityEngine.Sprite)translator.GetObject(L, 2, typeof(UnityEngine.Sprite));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_current(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    UIButton.current = (UIButton)translator.GetObject(L, 1, typeof(UIButton));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dragHighlight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.dragHighlight = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_hoverSprite(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.hoverSprite = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pressedSprite(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pressedSprite = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_disabledSprite(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.disabledSprite = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_hoverSprite2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.hoverSprite2D = (UnityEngine.Sprite)translator.GetObject(L, 2, typeof(UnityEngine.Sprite));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pressedSprite2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pressedSprite2D = (UnityEngine.Sprite)translator.GetObject(L, 2, typeof(UnityEngine.Sprite));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_disabledSprite2D(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.disabledSprite2D = (UnityEngine.Sprite)translator.GetObject(L, 2, typeof(UnityEngine.Sprite));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pixelSnap(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pixelSnap = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onClick(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIButton gen_to_be_invoked = (UIButton)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onClick = (System.Collections.Generic.List<EventDelegate>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<EventDelegate>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
