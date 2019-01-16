using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UpdateText : NetworkBehaviour {
  
	// Use this for initialization
	void Start () {
	  InputField inputField = GameObject.Find ("InputField").GetComponent <InputField> ();
          inputField.onEndEdit.AddListener (onTextAdded);	
          
          if (isServer)
          {
            NetworkServer.RegisterHandler (MessageBoardMessageType, MessageOnTextAdded);
          }
	}
	
	[SyncVar (hook = "onSyncTextChanged")]
	private string messageChange;
	
	void onSyncTextChanged (string message)
	{
	 GetComponent <TextMesh> ().text += "\n::" + message;
	}
	
	[Command]
	void CmdOnTextAdded (string message)
	{
	  messageChange = message;
	}
	
	void MessageOnTextAdded (NetworkMessage m)
	{
	  messageChange = m.ReadMessage <MessageBoardMessage> ().messageUpdate;
	}
	
	public void onTextAdded (string message)
	{
	  //CmdOnTextAdded (message);
	  MessageBoardMessage networkMessage = new MessageBoardMessage ();
	  networkMessage.messageUpdate = message;
	  NetworkClient.allClients[0].Send (MessageBoardMessageType, networkMessage);
	}
	
	private short MessageBoardMessageType = MsgType.Highest + 1;
	class MessageBoardMessage : MessageBase
	{
	  public string messageUpdate;
	}
	 
}
