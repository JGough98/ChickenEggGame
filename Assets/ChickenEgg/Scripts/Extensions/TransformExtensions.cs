using System;
using UnityEngine;


namespace CG.Scripts
{
    public enum TransformLengthDirection
    {
        X,
        Y,
        Z
    }


    public enum TransformDirection
    {
        FORWARD,
        BACKWARD,
        UP,
        DOWN,
        LEFT,
        RIGHT
    }


    public static class TransformExtensions
    {
        public static (float length, Func<Vector3> directionFunction) GetLengthAndDirecton(
            this Transform transform,
            TransformDirection transformDirection)
        {
            var directionFunction = transform.GetDirectionFunction(transformDirection);
            float length;

            switch (transformDirection)
            {
                case TransformDirection.UP:
                case TransformDirection.DOWN:
                    length = transform.GetLength(TransformLengthDirection.Y);
                    break;
                case TransformDirection.LEFT:
                case TransformDirection.RIGHT:
                    length = transform.GetLength(TransformLengthDirection.X);
                    break;
                default:
                case TransformDirection.FORWARD:
                case TransformDirection.BACKWARD:
                    length = transform.GetLength(TransformLengthDirection.Z);
                    break;
            }

            return (length, directionFunction);
        }


        public static float GetLength(
            this Transform transform,
            TransformLengthDirection direction)
        {
            switch (direction)
            {
                case TransformLengthDirection.X:
                    return transform.localScale.x;
                case TransformLengthDirection.Y:
                    return transform.localScale.y;
                default:
                    return transform.localScale.z;
            }
        }

        public static Func<Vector3> GetDirectionFunction(
            this Transform transform,
            TransformDirection direction)
        {
            switch (direction)
            {
                case TransformDirection.UP:
                    return () => transform.TransformDirection(Vector3.up);
                case TransformDirection.DOWN:
                    return () => transform.TransformDirection(Vector3.down);
                case TransformDirection.LEFT:
                    return () => transform.TransformDirection(Vector3.left);
                default:
                    return () => transform.TransformDirection(Vector3.right);
            }
        }
    }
}
