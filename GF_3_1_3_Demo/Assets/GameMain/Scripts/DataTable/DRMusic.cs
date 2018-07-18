using System;
using System.Collections.Generic;
using GameFramework.DataTable;
using Newtonsoft.Json;
using UnityEngine;
using UnityGameFramework.Runtime;

/// <summary>
/// 背景音乐
/// </summary>
[Serializable]
public class DRMusic : IDataRow {
	
	/// <summary>
	/// 唯一标识
	/// </summary>
	public int Id { set; get; }
	
	/// <summary>
	/// 名称
	/// </summary>
	public string Name { set; get; }
	
	/// <summary>
	/// 描述
	/// </summary>
	public string Des { set; get; }
	
	/// <summary>
	/// 资源名
	/// </summary>
	public string Asset { set; get; }
	

	public void ParseDataRow(string dataRowText)
    {
    	
    	DRMusic model = GameUtility.DeserializeObject<DRMusic>(dataRowText);
		Id = model.Id;
		Name = model.Name;
		Des = model.Des;
		Asset = model.Asset;
		
	}

	//以下方法只是为了避免编译类型JIT,实际无调用
	private void AvoidJIT()
	{
		new Dictionary<int, DRMusic>();
	}
}