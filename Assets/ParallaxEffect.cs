using UnityEngine;

public class ParallaxParent : MonoBehaviour
{
    public Transform cam; // Assign the camera in the Inspector
    private Vector3 previousCamPosition;

    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layer;
        public float parallaxFactor; // 0 = static, 1 = same as camera
    }

    public ParallaxLayer[] layers;

    void Start()
    {
        if (cam == null)
            cam = Camera.main.transform;

        previousCamPosition = cam.position;
    }

    void Update()
    {
        Vector3 delta = cam.position - previousCamPosition;

        foreach (var pLayer in layers)
        {
            Vector3 layerMovement = new Vector3(delta.x * pLayer.parallaxFactor, delta.y * pLayer.parallaxFactor, 0);
            pLayer.layer.position += layerMovement;
        }

        previousCamPosition = cam.position;
    }
}
