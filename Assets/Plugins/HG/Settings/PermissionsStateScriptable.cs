using Plugins.HG.General.Utils;

using UnityEngine;

namespace HG
{
	public class PermissionsStateScriptable : ScriptableObject
	{
		public PermissionsState PermissionsState = new PermissionsState();

		public void Init(DataHolder.PermissionsData permissionsData)
		{
			PermissionsState.Init(permissionsData);
		}

		public void Save()
		{
			ScriptableHelper.Save(this);
		}
	}
}