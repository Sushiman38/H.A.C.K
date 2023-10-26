using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public class TurnSway : MonoBehaviour
    {
        public float MoveAmount = .3f;
        public float MoveSpeed = 5f;

        private Vector3 _origin;

        private void Start()
        {
            _origin = transform.localPosition;
        }

        void FixedUpdate()
        {
            var moveOnX = Input.GetAxis("Mouse X") * MoveAmount;
            var moveOnY = Input.GetAxis("Mouse Y") * MoveAmount;

            var newPos = new Vector3(moveOnX, _origin.y + moveOnY, _origin.z);

            transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, MoveSpeed * Time.deltaTime);
        }
    }
}