using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 实体
/// </summary>
[Serializable]
public class DREntity : IDataRow {
	
	/// <summary>
	/// 唯一标识(实体类型)
	/// </summary>
	public int Id { set; get; }
	
	/// <summary>
	/// 资源名
	/// </summary>
	public string AssetName { set; get; }
	
	/// <summary>
	/// 实体组
	/// </summary>
	public string EntityGroup { set; get; }
	

	public void ParseDataRow(string dataRowText)
    {
    	
    	DREntity model = GameUtility.DeserializeObject<DREntity>(dataRowText);
		Id = model.Id;
		AssetName = model.AssetName;
		EntityGroup = model.EntityGroup;
		
	}

	//以下方法只是为了避免编译类型JIT,实际无调用
	private void AvoidJIT()
	{
		new Dictionary<int, DREntity>();
	}
}