using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSocketConnector : MonoBehaviour
{
    public void Send(string message){
        Debug.Log("Web Socket Sending: "+ message);
    }
    public void Send(float number){
        Debug.Log("Web Socket Sending: "+ number.ToString());
    }
}
