
using UnityEngine;
using RosSharp;
using RosSharp.RosBridgeClient;
using UnityEngine.UI;

public class IAACTwistPublisher : UnityPublisher<RosSharp.RosBridgeClient.MessageTypes.Geometry.TwistStamped>
{
    public Transform baseTransform;
    public Transform PublishedTransform;

    public Text text;

    private RosSharp.RosBridgeClient.MessageTypes.Geometry.TwistStamped message;
	private string FrameId = "wrist_3_link";

    public float scalar = 5;

    protected override void Start()
    {
        base.Start();
        InitializeMessage();
    }

    // private void FixedUpdate()
    // {
    //     UpdateMessage();
    // }

    private void InitializeMessage(){
		this.message = new RosSharp.RosBridgeClient.MessageTypes.Geometry.TwistStamped{
			header = new RosSharp.RosBridgeClient.MessageTypes.Std.Header() {
				frame_id = this.FrameId
			},
			twist =  new RosSharp.RosBridgeClient.MessageTypes.Geometry.Twist()
		};
    }

    public void UpdateMessage(){
		this.message.header.Update();
        Vector3 linear = baseTransform.InverseTransformPoint (PublishedTransform.position);
        linear *= scalar;
        Vector3 angular = PublishedTransform.eulerAngles - baseTransform.eulerAngles;
        GetGeometryPoint(linear.Unity2Ros(), message.twist.linear);
       GetGeometryEulerAngles(angular.Unity2Ros(), message.twist.angular);
        Debug.Log("Twist: lenar: " + linear + ", angular: " + angular);
        text.text = "Sending a Twist: lenar: " + linear.ToString("F4") + ", angular: " + angular.ToString("F4");

       Publish(message);
       print(message);
	}

    private static void GetGeometryPoint(Vector3 position, RosSharp.RosBridgeClient.MessageTypes.Geometry.Vector3 geometryPoint)
    {
        geometryPoint.x = position.x;
        geometryPoint.y = position.y;
        geometryPoint.z = position.z;
    }

    private static void GetGeometryEulerAngles(Vector3 eulerAngles, RosSharp.RosBridgeClient.MessageTypes.Geometry.Vector3 geometryAngular)
    {
        geometryAngular.x = eulerAngles.x;
        geometryAngular.y = eulerAngles.y;
        geometryAngular.z = eulerAngles.z;
    }

}