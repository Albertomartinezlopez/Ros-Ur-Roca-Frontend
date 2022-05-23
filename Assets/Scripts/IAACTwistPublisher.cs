
using UnityEngine;
using RosSharp;
using RosSharp.RosBridgeClient;

public class IAACTwistPublisher : UnityPublisher<RosSharp.RosBridgeClient.MessageTypes.Geometry.Twist>
{
    public Transform PublishedTransformStart;
    public Transform PublishedTransformEnd;

    private RosSharp.RosBridgeClient.MessageTypes.Geometry.Twist message;

    protected override void Start()
    {
        base.Start();
        InitializeMessage();
    }

    // private void FixedUpdate()
    // {
    //     UpdateMessage();
    // }

    private void InitializeMessage()
    {
        message = new RosSharp.RosBridgeClient.MessageTypes.Geometry.Twist();
    }

    public void UpdateMessage()
    {
        Vector3 linear = PublishedTransformEnd.position - PublishedTransformStart.position;
        Vector3 angular = PublishedTransformEnd.eulerAngles - PublishedTransformStart.eulerAngles;
        GetGeometryPoint(linear.Unity2Ros(), message.linear);
        GetGeometryEulerAngles(angular.Unity2Ros(), message.angular);

        Publish(message);
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