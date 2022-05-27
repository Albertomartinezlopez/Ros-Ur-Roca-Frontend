#define DEBUG
// #undef DEBUG
// #define DEBUG2
#undef DEBUG2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosSharp.RosBridgeClient;
using System;

public class ConstantTrackerPublisher_twist : UnityPublisher<RosSharp.RosBridgeClient.MessageTypes.Geometry.Twist> {
 
	private string FrameId = "map";
	private RosSharp.RosBridgeClient.MessageTypes.Geometry.Twist message;
    
	public void OnEnable() {
	
		PrepareMessage();
        
			               }
    
	public void OnPublish(Vector3 linear){
		try {
			UpdateMessage(linear);
			Publish(message);
		} catch (Exception exception) {
			Debug.Log("ConstantTrackerPublisher: publish exception: "+ exception.ToString());
		}
	}
    
	private void PrepareMessage() {
		this.message = new RosSharp.RosBridgeClient.MessageTypes.Geometry.Twist();
	}
    
	private void UpdateMessage(Vector3 linear){
		this.message.linear = linear.UnityPointToRosVector3();
		//this.message.orientation = this.tracker.orientationInfo.rotation.eulerAngles.UnityEulerToRosQuaternion();
	}
}