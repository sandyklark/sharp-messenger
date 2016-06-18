using System;


public interface IMessage
{
	string type { get; }

	void AddSubscriber(MessageHandler callback);
	void RemoveSubscriber(MessageHandler callback);
	void Send(object data = null);
}
