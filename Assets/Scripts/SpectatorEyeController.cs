using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorEyeController : MonoBehaviour
{
    public enum EyePosition {
        Neutral, Up, UpLeft, Left, DownLeft, Down, DownRight, Right, UpRight
    }

    public EyePosition eyePosition;

    // eyes
    Transform leftEye;
    Transform rightEye;

    // left eye positions
    Transform neutral_left;
    Transform up_left;
    Transform upLeft_left;
    Transform left_left;
    Transform downLeft_left;
    Transform down_left;
    Transform downRight_left;
    Transform right_left;
    Transform upRight_left;

    // right eye positions
    Transform neutral_right;
    Transform up_right;
    Transform upLeft_right;
    Transform left_right;
    Transform downLeft_right;
    Transform down_right;
    Transform downRight_right;
    Transform right_right;
    Transform upRight_right;


    void Start()
    {
        // init eyes
        leftEye = transform.Find("Pupil_left").transform;
        rightEye = transform.Find("Pupil_right").transform;

        // init left
        neutral_left = transform.Find("neutral_left").transform;
        up_left = transform.Find("up_left").transform;
        upLeft_left = transform.Find("upleft_left").transform;
        left_left = transform.Find("left_left").transform;
        downLeft_left = transform.Find("downleft_left").transform;
        down_left = transform.Find("down_left").transform;
        downRight_left = transform.Find("downright_left").transform;
        right_left = transform.Find("right_left").transform;
        upRight_left = transform.Find("upright_left").transform;

        // init right
        neutral_right = transform.Find("neutral_right").transform;
        up_right = transform.Find("up_right").transform;
        upLeft_right = transform.Find("upleft_right").transform;
        left_right = transform.Find("left_right").transform;
        downLeft_right = transform.Find("downleft_right").transform;
        down_right = transform.Find("down_right").transform;
        downRight_right = transform.Find("downright_right").transform;
        right_right = transform.Find("right_right").transform;
        upRight_right = transform.Find("upright_right").transform;
    }


    void Update()
    {
        UpdateEyePositions();
    }


    void UpdateEyePositions()
    {
        switch(eyePosition) {
            case EyePosition.Neutral:
                leftEye.position  = neutral_left.position;
                rightEye.position = neutral_right.position;
                break;
            case EyePosition.Up:
                leftEye.position  = up_left.position;
                rightEye.position = up_right.position;
                break;
            case EyePosition.UpLeft:
                leftEye.position  = upLeft_left.position;
                rightEye.position = upLeft_right.position;
                break;
            case EyePosition.Left:
                leftEye.position  = left_left.position;
                rightEye.position = left_right.position;
                break;
            case EyePosition.DownLeft:
                leftEye.position  = downLeft_left.position;
                rightEye.position = downLeft_right.position;
                break;
            case EyePosition.Down:
                leftEye.position  = down_left.position;
                rightEye.position = down_right.position;
                break;
            case EyePosition.DownRight:
                leftEye.position  = downRight_left.position;
                rightEye.position = downRight_right.position;
                break;
            case EyePosition.Right:
                leftEye.position  = right_left.position;
                rightEye.position = right_right.position;
                break;
            case EyePosition.UpRight:
                leftEye.position  = upRight_left.position;
                rightEye.position = upRight_right.position;
                break;
            default:
                Debug.LogError($"unknown eye position: {eyePosition.ToString()}");
                break;
        }
    }
}
