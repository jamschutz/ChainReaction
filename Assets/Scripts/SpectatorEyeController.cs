using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class SpectatorEyeController : MonoBehaviour
{
    public enum EyePosition {
        Neutral, Up, UpLeft, Left, DownLeft, Down, DownRight, Right, UpRight
    }

    public EyePosition eyePosition;
    [Range(0,1)]
    public float eyeMoveSpeed;

    // input controller
    InputController input;

    // eyes
    Transform leftEye;
    Transform rightEye;
    Transform leftEyeTarget;
    Transform rightEyeTarget;

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

        // init targets
        leftEyeTarget = neutral_left;
        rightEyeTarget = neutral_right;

        // init input
        input = GetComponent<InputController>();
    }


    void Update()
    {
        // neutral
        if(GetXMove() == 0 && GetYMove() == 0) {
            eyePosition = EyePosition.Neutral;
        }
        // up
        else if(GetXMove() == 0 && GetYMove() == 1) {
            eyePosition = EyePosition.Up;
        }
        // up left
        else if(GetXMove() == -1 && GetYMove() == 1) {
            eyePosition = EyePosition.UpLeft;
        }
        // left
        else if(GetXMove() == -1 && GetYMove() == 0) {
            eyePosition = EyePosition.Left;
        }
        // down left
        else if(GetXMove() == -1 && GetYMove() == -1) {
            eyePosition = EyePosition.DownLeft;
        }
        // down
        else if(GetXMove() == 0 && GetYMove() == -1) {
            eyePosition = EyePosition.Down;
        }
        // down right
        else if(GetXMove() == 1 && GetYMove() == -1) {
            eyePosition = EyePosition.DownRight;
        }
        // right
        else if(GetXMove() == 1 && GetYMove() == 0) {
            eyePosition = EyePosition.Right;
        }
        // up right
        else if(GetXMove() == 1 && GetYMove() == 1) {
            eyePosition = EyePosition.UpRight;
        }

        UpdateEyePositions();
    }


    void UpdateEyePositions()
    {
        switch(eyePosition) {
            case EyePosition.Neutral:
                leftEye.position  = Vector3.Lerp(leftEye.position,  neutral_left.position,  eyeMoveSpeed);
                rightEye.position = Vector3.Lerp(rightEye.position, neutral_right.position, eyeMoveSpeed);
                break;
            case EyePosition.Up:
                leftEye.position  = Vector3.Lerp(leftEye.position,  up_left.position,  eyeMoveSpeed);
                rightEye.position = Vector3.Lerp(rightEye.position, up_right.position, eyeMoveSpeed);
                break;
            case EyePosition.UpLeft:
                leftEye.position  = Vector3.Lerp(leftEye.position,  upLeft_left.position,  eyeMoveSpeed);
                rightEye.position = Vector3.Lerp(rightEye.position, upLeft_right.position, eyeMoveSpeed);
                break;
            case EyePosition.Left:
                leftEye.position  = Vector3.Lerp(leftEye.position,  left_left.position,  eyeMoveSpeed);
                rightEye.position = Vector3.Lerp(rightEye.position, left_right.position, eyeMoveSpeed);
                break;
            case EyePosition.DownLeft:
                leftEye.position  = Vector3.Lerp(leftEye.position,  downLeft_left.position,  eyeMoveSpeed);
                rightEye.position = Vector3.Lerp(rightEye.position, downLeft_right.position, eyeMoveSpeed);
                break;
            case EyePosition.Down:
                leftEye.position  = Vector3.Lerp(leftEye.position,  down_left.position,  eyeMoveSpeed);
                rightEye.position = Vector3.Lerp(rightEye.position, down_right.position, eyeMoveSpeed);
                break;
            case EyePosition.DownRight:
                leftEye.position  = Vector3.Lerp(leftEye.position,  downRight_left.position,  eyeMoveSpeed);
                rightEye.position = Vector3.Lerp(rightEye.position, downRight_right.position, eyeMoveSpeed);
                break;
            case EyePosition.Right:
                leftEye.position  = Vector3.Lerp(leftEye.position,  right_left.position,  eyeMoveSpeed);
                rightEye.position = Vector3.Lerp(rightEye.position, right_right.position, eyeMoveSpeed);
                break;
            case EyePosition.UpRight:
                leftEye.position  = Vector3.Lerp(leftEye.position,  upRight_left.position,  eyeMoveSpeed);
                rightEye.position = Vector3.Lerp(rightEye.position, upRight_right.position, eyeMoveSpeed);
                break;
            default:
                Debug.LogError($"unknown eye position: {eyePosition.ToString()}");
                break;
        }
    }


    int GetXMove()
    {
        if(input.Current.Movement.x < -float.Epsilon) return -1;
        if(input.Current.Movement.x > float.Epsilon) return 1;

        return 0;
    }

    int GetYMove()
    {
        if(input.Current.Movement.y < -float.Epsilon) return -1;
        if(input.Current.Movement.y > float.Epsilon) return 1;

        return 0;
    }
}
