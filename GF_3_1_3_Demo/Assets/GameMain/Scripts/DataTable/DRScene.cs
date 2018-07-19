using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 场景
/// </summary>
[Serializable]
public class DRScene : IDataRow {
	
	/// <summary>
	/// 唯一标识
	/// </summary>
	public int Id { set; get; }
	
	/// <summary>
	/// 资源名
	/// </summary>
	public string AssetName { set; get; }
	
	/// <summary>
	/// 背景音乐id
	/// </summary>
	public int BgmId { set; get; }
	

	public void ParseDataRow(string dataRowText)
    {
    	
    	DRScene model = GameUtility.DeserializeObject<DRScene>(dataRowText);
		Id = model.Id;
		AssetName = model.AssetName;
		BgmId = model.BgmId;
		
	}

	//以下方法只是为了避免编译类型JIT,实际无调用
	private void AvoidJIT()
	{
		new Dictionary<int, DRScene>();
	}
}