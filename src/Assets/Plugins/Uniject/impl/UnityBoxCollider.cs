using System;
using UnityEngine;

namespace Uniject.Impl {
    public class UnityBoxCollider : UnityComponent, IBoxCollider {
        private BoxCollider box;
        private UnityPhysicsMaterial mat;

        public UnityBoxCollider(IGameObject obj) : base(obj) {
            box = obj.GetComponent<BoxCollider>();
            if (null == box) {
				throw new NullReferenceException("Object " + obj.Name  + " expected to have a BoxCollider but none was found");
            }
        }

        public Vector3 center {
            get { return box.center; }
            set { box.center = value; }
        }

        public Vector3 size {
            get { return box.size; }
            set { box.size = value; }
        }

        public bool enabled {
            get { return box.enabled; }
            set { box.enabled = value; }
        }

        public IPhysicMaterial material {
            get { return mat; }
            set {
                mat = (UnityPhysicsMaterial) value;
                box.material = mat.material;
            }
        }
    }
}

