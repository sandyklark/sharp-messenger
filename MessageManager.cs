using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public delegate void MessageHandler(object data);

public class MessageManager 
{

	private Dictionary<string, IMessage> _registeredMessageDictionary;

	public MessageManager(List<IMessage> messages)
	{
		//init 
		_registeredMessageDictionary = new Dictionary<string, IMessage> ();
		Register (messages);
	}

	public void Send(string messageName, object data = null)
	{
		_registeredMessageDictionary [messageName].Send (data);
	}

	public void Subscribe(string messageName, MessageHandler callback)
	{
		_registeredMessageDictionary [messageName].AddSubscriber (callback);
	}

	public void Unsubscribe(string messageName, MessageHandler callback)
	{
		_registeredMessageDictionary [messageName].RemoveSubscriber (callback);
	}

	//PROTECTED
	protected void Register(List<IMessage> messages)
	{
		foreach (IMessage message in messages)
		{
			if (MessageExists(message.type))
			{
				throw new Exception ("Message not registered.  A message with the name: " + message.type + " already exists.");
			} else
			{
				_registeredMessageDictionary.Add (message.type, message);
			}
		}
	}

	protected bool MessageExists(string messageName)
	{
		return _registeredMessageDictionary.ContainsKey(messageName);
	}
}
