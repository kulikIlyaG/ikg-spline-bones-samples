using UnityEngine;

namespace Plugins.spline_bones.Demo.OffRoadCar.Scripts
{
    internal sealed class WheelComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _body;

        public void AddTorque(float value)
        {
            _body.AddTorque(-value, ForceMode2D.Force);
        }

        public void Break(float power)
        {
            _body.angularVelocity *= Mathf.Clamp01(1f - power * Time.fixedDeltaTime);
        }
    }
}