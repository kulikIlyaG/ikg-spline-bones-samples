using System;
using UnityEngine;

namespace Plugins.spline_bones.Demo.OffRoadCar.Scripts
{
    internal sealed class CarComponent : MonoBehaviour
    {
        [SerializeField] private WheelComponent[] _wheels;
        [SerializeField] private WheelComponent[] _torqueWheels;

        [SerializeField] private float _power = 10f;
        [SerializeField] private float _brakePower = 10f;

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.D))
            {
                ApplyForwardTorque();
            }
            else if (Input.GetKey(KeyCode.A))
            {
                ApplyBackwardTorque();
            }else if (Input.GetKey(KeyCode.Space))
            {
                ApplyBrake();
            }
        }

        private void ApplyBrake()
        {
            foreach (WheelComponent wheel in _wheels)
            {
                wheel.Break(_brakePower);
            }
        }

        private void ApplyBackwardTorque()
        {
            ApplyTorque(-_power);
        }

        private void ApplyForwardTorque()
        {
            ApplyTorque(_power);
        }

        private void ApplyTorque(float power)
        {
            foreach (WheelComponent wheel in _torqueWheels)
            {
                wheel.AddTorque(power);
            }
        }
    }
}