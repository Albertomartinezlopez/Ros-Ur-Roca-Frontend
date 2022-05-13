using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public WebSocketConnector webSocketConnector;
    public string messageToSend;
    public List<string> tagsToDetect;

    public float min = -.1f;
    public float max = .1f;
    private void OnTriggerEnter(Collider other){
        if (tagsToDetect.Contains(other.tag)){
            Debug.Log("Collider entered: " + other.name);
            webSocketConnector.Send(messageToSend);
        }
    }
    void OnTriggerStay(Collider other)
    {
        
        if (tagsToDetect.Contains(other.tag)){
            Debug.Log("Collider stay: " + other.name);
            float x = other.transform.position.x - transform.position.x;
            webSocketConnector.Send(Mathf.Clamp(x, min, max));
        }
    }
}
