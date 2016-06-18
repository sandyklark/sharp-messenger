using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class Message : IMessage 
{
	private event MessageHandler MessageEvent;

	private string _type;
	public string type 
	{
		get 
		{
			return _type;
		}
	}

	public Message(string type)
	{
		_type = type;

	}

	public void AddSubscriber(MessageHandler callback)
	{
		MessageEvent += callback;
	}

	public void RemoveSubscriber(MessageHandler callback)
	{
		MessageEvent -= callback;
	}

	public void Send(object data = null)
	{
		if (MessageEvent != null)
		{
			MessageEvent (data);
		}
	}
}
