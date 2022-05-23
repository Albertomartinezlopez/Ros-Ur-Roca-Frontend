#define DEBUG
// #undef DEBUG
// #define DEBUG2
#undef DEBUG2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RosSharp.RosBridgeClient;
using System;

public class ConstantTrackerPublisher_Pose : UnityPublisher<RosSharp.RosBridgeClient.MessageTypes.Geometry.Pose> {
 
	private string FrameId = "map";
	private RosSharp.RosBridgeClient.MessageTypes.Geometry.Pose message;
    
	public void OnEnable() {
	
		PrepareMessage();
        
			               }
    
	public void OnPublish(Vector3 position){
		try {
			UpdateMessage(position);
			Publish(message);
		} catch (Exception exception) {
			Debug.Log("ConstantTrackerPublisher: publish exception: "+ exception.ToString());
		}
	}
    
	private void PrepareMessage() {
		this.message = new RosSharp.RosBridgeClient.MessageTypes.Geometry.Pose();
	}
    
	private void UpdateMessage(Vector3 position){
		this.message.position = position.UnityPointToRosPoint();
		//this.message.orientation = this.tracker.orientationInfo.rotation.eulerAngles.UnityEulerToRosQuaternion();
	}
}