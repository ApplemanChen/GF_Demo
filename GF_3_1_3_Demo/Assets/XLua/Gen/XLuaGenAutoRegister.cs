#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;
using System.Collections.Generic;
using System.Reflection;


namespace XLua.CSObjectWrap
{
    public class XLua_Gen_Initer_Register__
	{
	    static XLua_Gen_Initer_Register__()
        {
		    XLua.LuaEnv.AddIniter((luaenv, translator) => {
			    
				translator.DelayWrapLoader(typeof(GameManager), GameManagerWrap.__Register);
				
				translator.DelayWrapLoader(typeof(LuaCallStatic), LuaCallStaticWrap.__Register);
				
				translator.DelayWrapLoader(typeof(DialogParams), DialogParamsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(LuaSendEventArgs), LuaSendEventArgsWrap.__Register);
				
				translator.DelayWrapLoader(typeof(LuaEventId), LuaEventIdWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UILabel), UILabelWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UIInput), UIInputWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UIButton), UIButtonWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UIScrollView), UIScrollViewWrap.__Register);
				
				translator.DelayWrapLoader(typeof(LuaComponent), LuaComponentWrap.__Register);
				
				translator.DelayWrapLoader(typeof(UIExtension), UIExtensionWrap.__Register);
				
				
				
			});
		}
		
		
	}
	
}
namespace XLua
{
	public partial class ObjectTranslator
	{
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ s_gen_reg_dumb_obj = new XLua.CSObjectWrap.XLua_Gen_Initer_Register__();
		static XLua.CSObjectWrap.XLua_Gen_Initer_Register__ gen_reg_dumb_obj {get{return s_gen_reg_dumb_obj;}}
	}
	
	internal partial class InternalGlobals
    {
	    
	    static InternalGlobals()
		{
		    extensionMethodMap = new Dictionary<Type, IEnumerable<MethodInfo>>()
			{
			    
			};
			
			genTryArrayGetPtr = StaticLuaCallbacks.__tryArrayGet;
            genTryArraySetPtr = StaticLuaCallbacks.__tryArraySet;
		}
	}
}
