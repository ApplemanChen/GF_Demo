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
    public class UIInputWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UIInput);
			Utils.BeginObjectRegister(type, L, translator, 0, 7, 23, 21);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Validate", _m_Validate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ProcessEvent", _m_ProcessEvent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Submit", _m_Submit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateLabel", _m_UpdateLabel);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveFocus", _m_RemoveFocus);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SaveValue", _m_SaveValue);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadValue", _m_LoadValue);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "defaultText", _g_get_defaultText);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "inputShouldBeHidden", _g_get_inputShouldBeHidden);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "value", _g_get_value);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isSelected", _g_get_isSelected);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cursorPosition", _g_get_cursorPosition);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "selectionStart", _g_get_selectionStart);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "selectionEnd", _g_get_selectionEnd);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "caret", _g_get_caret);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "label", _g_get_label);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "inputType", _g_get_inputType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onReturnKey", _g_get_onReturnKey);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "keyboardType", _g_get_keyboardType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "hideInput", _g_get_hideInput);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "selectAllTextOnFocus", _g_get_selectAllTextOnFocus);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "validation", _g_get_validation);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "characterLimit", _g_get_characterLimit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "savedAs", _g_get_savedAs);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "activeTextColor", _g_get_activeTextColor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "caretColor", _g_get_caretColor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "selectionColor", _g_get_selectionColor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onSubmit", _g_get_onSubmit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onChange", _g_get_onChange);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "onValidate", _g_get_onValidate);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "defaultText", _s_set_defaultText);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "value", _s_set_value);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "isSelected", _s_set_isSelected);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "cursorPosition", _s_set_cursorPosition);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "selectionStart", _s_set_selectionStart);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "selectionEnd", _s_set_selectionEnd);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "label", _s_set_label);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "inputType", _s_set_inputType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onReturnKey", _s_set_onReturnKey);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "keyboardType", _s_set_keyboardType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "hideInput", _s_set_hideInput);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "selectAllTextOnFocus", _s_set_selectAllTextOnFocus);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "validation", _s_set_validation);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "characterLimit", _s_set_characterLimit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "savedAs", _s_set_savedAs);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "activeTextColor", _s_set_activeTextColor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "caretColor", _s_set_caretColor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "selectionColor", _s_set_selectionColor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onSubmit", _s_set_onSubmit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onChange", _s_set_onChange);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "onValidate", _s_set_onValidate);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 2, 2);
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "current", _g_get_current);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "selection", _g_get_selection);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "current", _s_set_current);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "selection", _s_set_selection);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					UIInput gen_ret = new UIInput();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UIInput constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Validate(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _val = LuaAPI.lua_tostring(L, 2);
                    
                        string gen_ret = gen_to_be_invoked.Validate( _val );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ProcessEvent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Event _ev = (UnityEngine.Event)translator.GetObject(L, 2, typeof(UnityEngine.Event));
                    
                        bool gen_ret = gen_to_be_invoked.ProcessEvent( _ev );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Submit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Submit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateLabel(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdateLabel(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveFocus(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.RemoveFocus(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SaveValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.SaveValue(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.LoadValue(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_defaultText(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.defaultText);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_inputShouldBeHidden(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.inputShouldBeHidden);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_value(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.value);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isSelected(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isSelected);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cursorPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.cursorPosition);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_selectionStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.selectionStart);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_selectionEnd(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.selectionEnd);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_caret(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.caret);
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
			    translator.Push(L, UIInput.current);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_selection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UIInput.selection);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_label(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.label);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_inputType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.inputType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onReturnKey(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onReturnKey);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_keyboardType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.keyboardType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hideInput(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.hideInput);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_selectAllTextOnFocus(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.selectAllTextOnFocus);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_validation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.validation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_characterLimit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.characterLimit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_savedAs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.savedAs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_activeTextColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked.activeTextColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_caretColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked.caretColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_selectionColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked.selectionColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onSubmit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onSubmit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onChange(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onChange);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_onValidate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.onValidate);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_defaultText(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.defaultText = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_value(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.value = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_isSelected(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.isSelected = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cursorPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.cursorPosition = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_selectionStart(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.selectionStart = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_selectionEnd(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.selectionEnd = LuaAPI.xlua_tointeger(L, 2);
            
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
			    UIInput.current = (UIInput)translator.GetObject(L, 1, typeof(UIInput));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_selection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    UIInput.selection = (UIInput)translator.GetObject(L, 1, typeof(UIInput));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_label(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.label = (UILabel)translator.GetObject(L, 2, typeof(UILabel));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_inputType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                UIInput.InputType gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.inputType = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onReturnKey(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                UIInput.OnReturnKey gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.onReturnKey = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_keyboardType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                UIInput.KeyboardType gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.keyboardType = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_hideInput(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.hideInput = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_selectAllTextOnFocus(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.selectAllTextOnFocus = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_validation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                UIInput.Validation gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.validation = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_characterLimit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.characterLimit = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_savedAs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.savedAs = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_activeTextColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.activeTextColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_caretColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.caretColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_selectionColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.selectionColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onSubmit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onSubmit = (System.Collections.Generic.List<EventDelegate>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<EventDelegate>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onChange(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onChange = (System.Collections.Generic.List<EventDelegate>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<EventDelegate>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_onValidate(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UIInput gen_to_be_invoked = (UIInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.onValidate = translator.GetDelegate<UIInput.OnValidate>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
