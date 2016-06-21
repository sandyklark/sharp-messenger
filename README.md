# sharp-messenger

A decoupled messaging system for c# that allows the definition of custom messages and the sending of dynamic data inside of an application


## Example

1. Create an implementation of AbstractMessageConfig (remembering to generically pass your concrete class type to AbstractMessageConfig) 
and define your message type constants.

  ```csharp
  public class AppMessageConfig : AbstractMessageConfig<GameMessageConfig> 
  {
	  // messages
	  public static readonly string MESSAGE_ONE = "message_one";
	  public static readonly string MESSAGE_TWO = "message_two";
  }
  ```

2. Create an instance of MessageManager. 

  ```csharp
  MessageManager messageManager = new MessageManager();
  ```

3. Create classes that extend AbstractMessenger and pass it the instance of the message manager.

  ```csharp
  public class SomeController : AbstractMessenger
  {
	  public SomeController(MessageManager messageManager : base(messageManager)
	  {
	    //Do stuff
	  }
  }
  
  public class SomeOtherController : AbstractMessenger
  {
	  public SomeOtherController(MessageManager messageManager : base(messageManager)
	  {
	    //Do other stuff
	  }
  }
  ```
4. Subscribe to a message (must be done in a class that extends AbstractMessenger)

  ```csharp
  Subscribe(AppMessageConfig.MESSAGE_ONE, callback);
  ```  
  
5. Send a message from that class

  ```csharp
  SendMessage(AppMessageConfig.MESSAGE_ONE, optionalDataObject);
  ```
## Coming Soon
*Unity package

## License
The MIT License (MIT). Please see [License File](https://github.com/sandyklark/sharp-messenger/blob/master/LICENSE.md) for more information.
