using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0,1)]
    public float followLerp = 0.2f;

    public float minSpeed;
    public float maxSpeed;
    public float minZoom;
    public float maxZoom;


    float playerZoom;
    public float shipZoom;

    Vector3 offset;
    Transform player;
    Camera cam;
    Rigidbody2D playerRb;

    public enum CameraMode { Player, Ship }
    CameraMode cameraMode;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - player.position;
        cam = GetComponent<Camera>();
        cameraMode = CameraMode.Player;
        playerRb = player.GetComponent<Rigidbody2D>();

        playerZoom = cam.orthographicSize;
        shipZoom = cam.orthographicSize;
    }


    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, followLerp);

        float zoom;
        if(playerRb.velocity.x < minSpeed) {
            zoom = minZoom;
        }
        else {
            float adjustedSpeed = (playerRb.velocity.x - minSpeed) / (maxSpeed - minSpeed);
            Debug.Log($"adjustedSpeed: {adjustedSpeed}");
            zoom = Mathf.Lerp(minZoom, maxZoom, adjustedSpeed);
        }
        cam.orthographicSize = zoom;
    }


    public void ZoomOut(float zoom)
    {
        switch(cameraMode) {
            case CameraMode.Player:
                playerZoom += zoom;
                cam.orthographicSize = playerZoom;
                break;
            case CameraMode.Ship:
                shipZoom += zoom;
                cam.orthographicSize = shipZoom;
                break;
            default:
                Debug.LogWarning($"unknown CameraMode {cameraMode.ToString()}");
                break;
        }
    }


    public void SetCameraMode(CameraMode mode)
    {
        switch(mode) {
            case CameraMode.Player:
                cam.orthographicSize = playerZoom;
                break;
            case CameraMode.Ship:
                cam.orthographicSize = shipZoom;
                break;
            default:
                Debug.LogWarning($"unknown CameraMode {mode.ToString()} passed to SetCameraMode");
                break;
        }

        cameraMode = mode;
    }


    public void MakeCameraTight()
    {
        shipZoom = 18.0f;
        SetCameraMode(cameraMode);
    }
}
