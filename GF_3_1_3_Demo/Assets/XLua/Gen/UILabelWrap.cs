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
    public class UILabelWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UILabel);
			Utils.BeginObjectRegister(type, L, translator, 0, 21, 36, 25);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSides", _m_GetSides);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MarkAsChanged", _m_MarkAsChanged);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ProcessText", _m_ProcessText);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MakePixelPerfect", _m_MakePixelPerfect);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AssumeNaturalSize", _m_AssumeNaturalSize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCharacterIndexAtPosition", _m_GetCharacterIndexAtPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetWordAtPosition", _m_GetWordAtPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetWordAtCharacterIndex", _m_GetWordAtCharacterIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetUrlAtPosition", _m_GetUrlAtPosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetUrlAtCharacterIndex", _m_GetUrlAtCharacterIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCharacterIndex", _m_GetCharacterIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PrintOverlay", _m_PrintOverlay);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnFill", _m_OnFill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ApplyOffset", _m_ApplyOffset);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ApplyShadow", _m_ApplyShadow);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalculateOffsetToFit", _m_CalculateOffsetToFit);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetCurrentProgress", _m_SetCurrentProgress);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetCurrentPercent", _m_SetCurrentPercent);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetCurrentSelection", _m_SetCurrentSelection);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Wrap", _m_Wrap);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateNGUIText", _m_UpdateNGUIText);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "isAnchoredHorizontally", _g_get_isAnchoredHorizontally);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isAnchoredVertically", _g_get_isAnchoredVertically);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "material", _g_get_material);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "bitmapFont", _g_get_bitmapFont);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "trueTypeFont", _g_get_trueTypeFont);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ambigiousFont", _g_get_ambigiousFont);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "text", _g_get_text);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "defaultFontSize", _g_get_defaultFontSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fontSize", _g_get_fontSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fontStyle", _g_get_fontStyle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "alignment", _g_get_alignment);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "applyGradient", _g_get_applyGradient);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "gradientTop", _g_get_gradientTop);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "gradientBottom", _g_get_gradientBottom);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "spacingX", _g_get_spacingX);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "spacingY", _g_get_spacingY);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "useFloatSpacing", _g_get_useFloatSpacing);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "floatSpacingX", _g_get_floatSpacingX);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "floatSpacingY", _g_get_floatSpacingY);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "effectiveSpacingY", _g_get_effectiveSpacingY);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "effectiveSpacingX", _g_get_effectiveSpacingX);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "supportEncoding", _g_get_supportEncoding);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "symbolStyle", _g_get_symbolStyle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "overflowMethod", _g_get_overflowMethod);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "multiLine", _g_get_multiLine);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "localCorners", _g_get_localCorners);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "worldCorners", _g_get_worldCorners);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "drawingDimensions", _g_get_drawingDimensions);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxLineCount", _g_get_maxLineCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "effectStyle", _g_get_effectStyle);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "effectColor", _g_get_effectColor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "effectDistance", _g_get_effectDistance);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "processedText", _g_get_processedText);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "printedSize", _g_get_printedSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "localSize", _g_get_localSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "keepCrispWhenShrunk", _g_get_keepCrispWhenShrunk);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "material", _s_set_material);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "bitmapFont", _s_set_bitmapFont);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "trueTypeFont", _s_set_trueTypeFont);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ambigiousFont", _s_set_ambigiousFont);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "text", _s_set_text);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "fontSize", _s_set_fontSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "fontStyle", _s_set_fontStyle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "alignment", _s_set_alignment);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "applyGradient", _s_set_applyGradient);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "gradientTop", _s_set_gradientTop);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "gradientBottom", _s_set_gradientBottom);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "spacingX", _s_set_spacingX);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "spacingY", _s_set_spacingY);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "useFloatSpacing", _s_set_useFloatSpacing);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "floatSpacingX", _s_set_floatSpacingX);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "floatSpacingY", _s_set_floatSpacingY);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "supportEncoding", _s_set_supportEncoding);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "symbolStyle", _s_set_symbolStyle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "overflowMethod", _s_set_overflowMethod);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "multiLine", _s_set_multiLine);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxLineCount", _s_set_maxLineCount);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "effectStyle", _s_set_effectStyle);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "effectColor", _s_set_effectColor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "effectDistance", _s_set_effectDistance);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "keepCrispWhenShrunk", _s_set_keepCrispWhenShrunk);
            
			
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
					
					UILabel gen_ret = new UILabel();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UILabel constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSides(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Transform _relativeTo = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
                    
                        UnityEngine.Vector3[] gen_ret = gen_to_be_invoked.GetSides( _relativeTo );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MarkAsChanged(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.MarkAsChanged(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ProcessText(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ProcessText(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MakePixelPerfect(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.MakePixelPerfect(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AssumeNaturalSize(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.AssumeNaturalSize(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCharacterIndexAtPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector3 _worldPos;translator.Get(L, 2, out _worldPos);
                    bool _precise = LuaAPI.lua_toboolean(L, 3);
                    
                        int gen_ret = gen_to_be_invoked.GetCharacterIndexAtPosition( _worldPos, _precise );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector2>(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    UnityEngine.Vector2 _localPos;translator.Get(L, 2, out _localPos);
                    bool _precise = LuaAPI.lua_toboolean(L, 3);
                    
                        int gen_ret = gen_to_be_invoked.GetCharacterIndexAtPosition( _localPos, _precise );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UILabel.GetCharacterIndexAtPosition!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWordAtPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _worldPos;translator.Get(L, 2, out _worldPos);
                    
                        string gen_ret = gen_to_be_invoked.GetWordAtPosition( _worldPos );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector2>(L, 2)) 
                {
                    UnityEngine.Vector2 _localPos;translator.Get(L, 2, out _localPos);
                    
                        string gen_ret = gen_to_be_invoked.GetWordAtPosition( _localPos );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UILabel.GetWordAtPosition!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetWordAtCharacterIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _characterIndex = LuaAPI.xlua_tointeger(L, 2);
                    
                        string gen_ret = gen_to_be_invoked.GetWordAtCharacterIndex( _characterIndex );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUrlAtPosition(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 2)) 
                {
                    UnityEngine.Vector3 _worldPos;translator.Get(L, 2, out _worldPos);
                    
                        string gen_ret = gen_to_be_invoked.GetUrlAtPosition( _worldPos );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector2>(L, 2)) 
                {
                    UnityEngine.Vector2 _localPos;translator.Get(L, 2, out _localPos);
                    
                        string gen_ret = gen_to_be_invoked.GetUrlAtPosition( _localPos );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UILabel.GetUrlAtPosition!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetUrlAtCharacterIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _characterIndex = LuaAPI.xlua_tointeger(L, 2);
                    
                        string gen_ret = gen_to_be_invoked.GetUrlAtCharacterIndex( _characterIndex );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCharacterIndex(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _currentIndex = LuaAPI.xlua_tointeger(L, 2);
                    UnityEngine.KeyCode _key;translator.Get(L, 3, out _key);
                    
                        int gen_ret = gen_to_be_invoked.GetCharacterIndex( _currentIndex, _key );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PrintOverlay(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _start = LuaAPI.xlua_tointeger(L, 2);
                    int _end = LuaAPI.xlua_tointeger(L, 3);
                    UIGeometry _caret = (UIGeometry)translator.GetObject(L, 4, typeof(UIGeometry));
                    UIGeometry _highlight = (UIGeometry)translator.GetObject(L, 5, typeof(UIGeometry));
                    UnityEngine.Color _caretColor;translator.Get(L, 6, out _caretColor);
                    UnityEngine.Color _highlightColor;translator.Get(L, 7, out _highlightColor);
                    
                    gen_to_be_invoked.PrintOverlay( _start, _end, _caret, _highlight, _caretColor, _highlightColor );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnFill(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    BetterList<UnityEngine.Vector3> _verts = (BetterList<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(BetterList<UnityEngine.Vector3>));
                    BetterList<UnityEngine.Vector2> _uvs = (BetterList<UnityEngine.Vector2>)translator.GetObject(L, 3, typeof(BetterList<UnityEngine.Vector2>));
                    BetterList<UnityEngine.Color32> _cols = (BetterList<UnityEngine.Color32>)translator.GetObject(L, 4, typeof(BetterList<UnityEngine.Color32>));
                    
                    gen_to_be_invoked.OnFill( _verts, _uvs, _cols );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ApplyOffset(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    BetterList<UnityEngine.Vector3> _verts = (BetterList<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(BetterList<UnityEngine.Vector3>));
                    int _start = LuaAPI.xlua_tointeger(L, 3);
                    
                        UnityEngine.Vector2 gen_ret = gen_to_be_invoked.ApplyOffset( _verts, _start );
                        translator.PushUnityEngineVector2(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ApplyShadow(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    BetterList<UnityEngine.Vector3> _verts = (BetterList<UnityEngine.Vector3>)translator.GetObject(L, 2, typeof(BetterList<UnityEngine.Vector3>));
                    BetterList<UnityEngine.Vector2> _uvs = (BetterList<UnityEngine.Vector2>)translator.GetObject(L, 3, typeof(BetterList<UnityEngine.Vector2>));
                    BetterList<UnityEngine.Color32> _cols = (BetterList<UnityEngine.Color32>)translator.GetObject(L, 4, typeof(BetterList<UnityEngine.Color32>));
                    int _start = LuaAPI.xlua_tointeger(L, 5);
                    int _end = LuaAPI.xlua_tointeger(L, 6);
                    float _x = (float)LuaAPI.lua_tonumber(L, 7);
                    float _y = (float)LuaAPI.lua_tonumber(L, 8);
                    
                    gen_to_be_invoked.ApplyShadow( _verts, _uvs, _cols, _start, _end, _x, _y );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateOffsetToFit(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 2);
                    
                        int gen_ret = gen_to_be_invoked.CalculateOffsetToFit( _text );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCurrentProgress(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.SetCurrentProgress(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCurrentPercent(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.SetCurrentPercent(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetCurrentSelection(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.SetCurrentSelection(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Wrap(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    string _text = LuaAPI.lua_tostring(L, 2);
                    string _final;
                    
                        bool gen_ret = gen_to_be_invoked.Wrap( _text, out _final );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    LuaAPI.lua_pushstring(L, _final);
                        
                    
                    
                    
                    return 2;
                }
                if(gen_param_count == 3&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    string _text = LuaAPI.lua_tostring(L, 2);
                    string _final;
                    int _height = LuaAPI.xlua_tointeger(L, 3);
                    
                        bool gen_ret = gen_to_be_invoked.Wrap( _text, out _final, _height );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    LuaAPI.lua_pushstring(L, _final);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UILabel.Wrap!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateNGUIText(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdateNGUIText(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isAnchoredHorizontally(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isAnchoredHorizontally);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isAnchoredVertically(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isAnchoredVertically);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_material(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.material);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bitmapFont(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.bitmapFont);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_trueTypeFont(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.trueTypeFont);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ambigiousFont(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ambigiousFont);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_text(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.text);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_defaultFontSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.defaultFontSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fontSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.fontSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fontStyle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.fontStyle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_alignment(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.alignment);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_applyGradient(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.applyGradient);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gradientTop(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked.gradientTop);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gradientBottom(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked.gradientBottom);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_spacingX(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.spacingX);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_spacingY(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.spacingY);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useFloatSpacing(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.useFloatSpacing);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_floatSpacingX(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.floatSpacingX);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_floatSpacingY(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.floatSpacingY);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_effectiveSpacingY(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.effectiveSpacingY);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_effectiveSpacingX(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.effectiveSpacingX);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_supportEncoding(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.supportEncoding);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_symbolStyle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.symbolStyle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_overflowMethod(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.overflowMethod);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_multiLine(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.multiLine);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_localCorners(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.localCorners);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_worldCorners(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.worldCorners);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_drawingDimensions(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector4(L, gen_to_be_invoked.drawingDimensions);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxLineCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.maxLineCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_effectStyle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.effectStyle);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_effectColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineColor(L, gen_to_be_invoked.effectColor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_effectDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.effectDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_processedText(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.processedText);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_printedSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.printedSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_localSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector2(L, gen_to_be_invoked.localSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_keepCrispWhenShrunk(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.keepCrispWhenShrunk);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_material(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.material = (UnityEngine.Material)translator.GetObject(L, 2, typeof(UnityEngine.Material));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bitmapFont(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.bitmapFont = (UIFont)translator.GetObject(L, 2, typeof(UIFont));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_trueTypeFont(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.trueTypeFont = (UnityEngine.Font)translator.GetObject(L, 2, typeof(UnityEngine.Font));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ambigiousFont(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ambigiousFont = (UnityEngine.Object)translator.GetObject(L, 2, typeof(UnityEngine.Object));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_text(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.text = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fontSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.fontSize = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fontStyle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                UnityEngine.FontStyle gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.fontStyle = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_alignment(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                NGUIText.Alignment gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.alignment = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_applyGradient(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.applyGradient = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_gradientTop(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.gradientTop = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_gradientBottom(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.gradientBottom = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_spacingX(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.spacingX = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_spacingY(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.spacingY = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useFloatSpacing(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.useFloatSpacing = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_floatSpacingX(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.floatSpacingX = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_floatSpacingY(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.floatSpacingY = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_supportEncoding(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.supportEncoding = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_symbolStyle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                NGUIText.SymbolStyle gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.symbolStyle = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_overflowMethod(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                UILabel.Overflow gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.overflowMethod = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_multiLine(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.multiLine = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxLineCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxLineCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_effectStyle(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                UILabel.Effect gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.effectStyle = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_effectColor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                UnityEngine.Color gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.effectColor = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_effectDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector2 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.effectDistance = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_keepCrispWhenShrunk(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UILabel gen_to_be_invoked = (UILabel)translator.FastGetCSObj(L, 1);
                UILabel.Crispness gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.keepCrispWhenShrunk = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
