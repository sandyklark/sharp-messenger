using UnityEngine;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractMessageConfig <T> 
{

	public static List<IMessage> GetMessages()
	{
		Type t = typeof(T);
		FieldInfo[] fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);

		List<IMessage> messages = new List<IMessage> ();

		foreach(FieldInfo field in fields)
		{
			messages.Add ( new Message (field.GetValue (null).ToString()) );
		}

		return messages;
	}
}
