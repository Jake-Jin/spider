using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SettingHelper
{
	public static int Level
	{
		get
		{
			return PlayerPrefs.GetInt("level", 0);
		}
		set
		{
			PlayerPrefs.SetInt("level", value);
			PlayerPrefs.Save();
		}
	}
}
