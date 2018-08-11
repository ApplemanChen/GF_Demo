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
    public class UIScrollViewWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UIScrollView);
			Utils.BeginObjectRegister(type, L, translator, 0, 13, 27, 20);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RestrictWithinBounds", _m_RestrictWithinBounds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DisableSpring", _m_DisableSpring);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateScrollbars", _m_UpdateScrollbars);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetDragAmount", _m_SetDragAmount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InvalidateBounds", _m_InvalidateBounds);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ResetPosition", _m_ResetPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdatePosition", _m_UpdatePosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnScrollBar", _m_OnScrollBar);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MoveRelative", _m_MoveRelative);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MoveAbsolute", _m_MoveAbsolute);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Press", _m_Press);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Drag", _m_Drag);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Scroll", _m_Scroll);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "panel", _g_get_panel);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isDragging", _g_get_isDragging);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "bounds", _g_get_bounds);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "canMoveHorizontally", _g_get_canMoveHorizontally);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "canMoveVertically", _g_get_canMoveVertically);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shouldMoveHorizontally", _g_get_shouldMoveHorizontally);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "shouldMoveVertically", _g_get_shouldMoveVertically);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "currentMomentum", _g_get_currentMomentum);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "movement", _g_get_movement);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "dragEffect", _g_get_dragEffect);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "restrictWithinPanel", _g_get_restrictWithinPanel);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "disableDragIfFits", _g_get_disableDragIfFits);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "smoothDragStart", _g_get_smoothDragStart);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "iOSDragEmulation", _g_get_iOSDragEmulation);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "scrollWheelFactor", _g_get_scrollWheelFactor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "momentumAmount", _g_get_momentumAmount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "dampenStrength", _g_get_dampenStrength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "horizontalScrollBar", _g_get_horizontalScrollBar);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "verticalScrollBar", _g_get_verticalScrollBar);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "showScrollBars", _g_get_showScrollBars);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "customMovement", _g_get_customMovement);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "contentPivot", _g_get_contentPivot);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onDragStarted", _g_get_onDragStarted);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onDragFinished", _g_get_onDragFinished);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onMomentumMove", _g_get_onMomentumMove);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onStoppedMoving", _g_get_onStoppedMoving);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "centerOnChild", _g_get_centerOnChild);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "currentMomentum", _s_set_currentMomentum);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "movement", _s_set_movement);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "dragEffect", _s_set_dragEffect);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "restrictWithinPanel", _s_set_restrictWithinPanel);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "disableDragIfFits", _s_set_disableDragIfFits);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "smoothDragStart", _s_set_smoothDragStart);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "iOSDragEmulation", _s_set_iOSDragEmulation);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "scrollWheelFactor", _s_set_scrollWheelFactor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "momentumAmount", _s_set_momentumAmount);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "dampenStrength", _s_set_dampenStrength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "horizontalScrollBar", _s_set_horizontalScrollBar);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "verticalScrollBar", _s_set_verticalScrollBar);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "showScrollBars", _s_set_showScrollBars);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "customMovement", _s_set_customMovement);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "contentPivot", _s_set_contentPivot);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onDragStarted", _s_set_onDragStarted);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onDragFinished", _s_set_onDragFinished);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onMomentumMove", _s_set_onMomentumMove);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onStoppedMoving", _s_set_onStoppedMoving);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "centerOnChild", _s_set_centerOnChild);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 1, 1);
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "list", _g_get_list);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "list", _s_set_list);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UIScrollView gen_ret = new UIScrollView();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UIScrollView constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RestrictWithinBounds(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _instant = LuaAPI.lua_toboolean(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.RestrictWithinBounds( _instant );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 4)) 
                {
                    bool _instant = LuaAPI.lua_toboolean(L, 2);
                    bool _horizontal = LuaAPI.lua_toboolean(L, 3);
                    bool _vertical = LuaAPI.lua_toboolean(L, 4);
                    
                        bool gen_ret = gen_to_be_invoked.RestrictWithinBounds( _instant, _horizontal, _vertical );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UIScrollView.RestrictWithinBounds!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DisableSpring(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DisableSpring(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateScrollbars(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.UpdateScrollbars(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    bool _recalculateBounds = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.UpdateScrollbars( _recalculateBounds );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UIScrollView.UpdateScrollbars!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetDragAmount(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _x = (float)LuaAPI.lua_tonumber(L, 2);
                    float _y = (float)LuaAPI.lua_tonumber(L, 3);
                    bool _updateScrollbars = LuaAPI.lua_toboolean(L, 4);
                    
                    gen_to_be_invoked.SetDragAmount( _x, _y, _updateScrollbars );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InvalidateBounds(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.InvalidateBounds(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ResetPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ResetPosition(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdatePosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdatePosition(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnScrollBar(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnScrollBar(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveRelative(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _relative;translator.Get(L, 2, out _relative);
                    
                    gen_to_be_invoked.MoveRelative( _relative );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MoveAbsolute(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _absolute;translator.Get(L, 2, out _absolute);
                    
                    gen_to_be_invoked.MoveAbsolute( _absolute );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Press(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _pressed = LuaAPI.lua_toboolean(L, 2);
                    
                    gen_to_be_invoked.Press( _pressed );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Drag(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Drag(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Scroll(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _delta = (float)LuaAPI.lua_tonumber(L, 2);
                    
                    gen_to_be_invoked.Scroll( _delta );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_panel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.panel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isDragging(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isDragging);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bounds(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineBounds(L, gen_to_be_invoked.bounds);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_canMoveHorizontally(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.canMoveHorizontally);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_canMoveVertically(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.canMoveVertically);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shouldMoveHorizontally(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.shouldMoveHorizontally);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shouldMoveVertically(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.shouldMoveVertically);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_currentMomentum(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.currentMomentum);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_list(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UIScrollView.list);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_movement(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.movement);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dragEffect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.dragEffect);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_restrictWithinPanel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.restrictWithinPanel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_disableDragIfFits(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.disableDragIfFits);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_smoothDragStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.smoothDragStart);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_iOSDragEmulation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.iOSDragEmulation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_scrollWheelFactor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.scrollWheelFactor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_momentumAmount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.momentumAmount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dampenStrength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.dampenStrength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_horizontalScrollBar(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.horizontalScrollBar);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_verticalScrollBar(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.verticalScrollBar);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showScrollBars(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.showScrollBars);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_customMovement(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.customMovement);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_contentPivot(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.contentPivot);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onDragStarted(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onDragStarted);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onDragFinished(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onDragFinished);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onMomentumMove(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onMomentumMove);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onStoppedMoving(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onStoppedMoving);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_centerOnChild(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.centerOnChild);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_currentMomentum(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.currentMomentum = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_list(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    UIScrollView.list = (BetterList<UIScrollView>)translator.GetObject(L, 1, typeof(BetterList<UIScrollView>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_movement(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                UIScrollView.Movement gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.movement = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dragEffect(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                UIScrollView.DragEffect gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.dragEffect = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_restrictWithinPanel(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.restrictWithinPanel = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_disableDragIfFits(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.disableDragIfFits = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_smoothDragStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.smoothDragStart = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_iOSDragEmulation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.iOSDragEmulation = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_scrollWheelFactor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.scrollWheelFactor = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_momentumAmount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.momentumAmount = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dampenStrength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.dampenStrength = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_horizontalScrollBar(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.horizontalScrollBar = (UIProgressBar)translator.GetObject(L, 2, typeof(UIProgressBar));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_verticalScrollBar(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.verticalScrollBar = (UIProgressBar)translator.GetObject(L, 2, typeof(UIProgressBar));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showScrollBars(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                UIScrollView.ShowCondition gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.showScrollBars = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_customMovement(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.customMovement = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_contentPivot(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                UIWidget.Pivot gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.contentPivot = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onDragStarted(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onDragStarted = translator.GetDelegate<UIScrollView.OnDragNotification>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onDragFinished(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onDragFinished = translator.GetDelegate<UIScrollView.OnDragNotification>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onMomentumMove(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onMomentumMove = translator.GetDelegate<UIScrollView.OnDragNotification>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onStoppedMoving(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onStoppedMoving = translator.GetDelegate<UIScrollView.OnDragNotification>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_centerOnChild(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIScrollView gen_to_be_invoked = (UIScrollView)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.centerOnChild = (UICenterOnChild)translator.GetObject(L, 2, typeof(UICenterOnChild));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
