using UnityEngine;
using System.Collections;

public abstract class AbstractMessenger
{
	protected MessageManager _messageManager;

	public AbstractMessenger(MessageManager messageManager)
	{
		_messageManager = messageManager;
	}

	protected void Subscribe(string messageName, MessageHandler callback)
	{
		_messageManager.Subscribe(messageName, callback);
	}

	protected void Unsubscribe(string messageName, MessageHandler callback)
	{
		_messageManager.Unsubscribe(messageName, callback);
	}

	protected void SendMessage (string messageName, object data = null)
	{
		_messageManager.Send (messageName, data);
	}
}
