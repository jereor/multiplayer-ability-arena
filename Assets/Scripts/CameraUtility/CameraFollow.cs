using System;
using UnityEngine;

namespace CameraUtility
{
    public class CameraFollow : MonoBehaviour
    {
        [NonSerialized]
        public Transform Target;
        
        [SerializeField]
        private Vector3 offset;

        private void LateUpdate()
        {
            if (Target == null) 
                return;
            
            transform.position = Target.position + offset;
        }
    }
}
