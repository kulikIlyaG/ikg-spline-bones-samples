using UnityEngine;

namespace IKGTools.Samples.SplineBones
{
    [RequireComponent(typeof(Rigidbody2D))]
    internal sealed class SlimeMovementComponent : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _body = null;

        [SerializeField] private float _power = 100f;
        [SerializeField] private float _jumpPower = 100f;

        private float _jumpDelay = 5f;

        private float _previousJumpTime;

        public void Update()
        {
            if (Input.GetKey(KeyCode.D))
                Move(Vector2.right);
            else if (Input.GetKey(KeyCode.A))
                Move(Vector2.left);
            
            if (Input.GetKeyDown(KeyCode.W))
                Jump();
        }

        private void Jump()
        {
            if(Time.time - _previousJumpTime < _jumpDelay)
                return;
            
            _body.AddForce(Vector2.up * _jumpPower, ForceMode2D.Force);
            _previousJumpTime = Time.time;
        }

        private void Move(Vector2 direction)
        {
            _body.AddForce(direction * (_power * Time.deltaTime));
        }

        private void OnValidate()
        {
            if (_body == null)
                _body = GetComponent<Rigidbody2D>();
        } 
    }
}