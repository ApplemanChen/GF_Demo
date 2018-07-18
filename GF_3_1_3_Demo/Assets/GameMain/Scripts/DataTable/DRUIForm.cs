using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 界面
/// </summary>
[Serializable]
public class DRUIForm : IDataRow {
	
	/// <summary>
	/// 唯一标识
	/// </summary>
	public int Id { set; get; }
	
	/// <summary>
	/// 资源名
	/// </summary>
	public string AssetName { set; get; }
	
	/// <summary>
	/// 界面组名
	/// </summary>
	public string UIGroupName { set; get; }
	
	/// <summary>
	/// 是否允许多个实例
	/// </summary>
	public bool AllowMultiInstance { set; get; }
	
	/// <summary>
	/// 是否暂停被其覆盖的其他界面
	/// </summary>
	public bool PauseCoveredUIForm { set; get; }
	

	public void ParseDataRow(string dataRowText)
    {
    	
    	DRUIForm model = GameUtility.DeserializeObject<DRUIForm>(dataRowText);
		Id = model.Id;
		AssetName = model.AssetName;
		UIGroupName = model.UIGroupName;
		AllowMultiInstance = model.AllowMultiInstance;
		PauseCoveredUIForm = model.PauseCoveredUIForm;
		
	}

	//以下方法只是为了避免编译类型JIT,实际无调用
	private void AvoidJIT()
	{
		new Dictionary<int, DRUIForm>();
	}
}