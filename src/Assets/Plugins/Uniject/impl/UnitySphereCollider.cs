using System;
using Uniject;
using UnityEngine;

namespace Uniject.Impl {
    public class UnitySphereCollider : TestableComponent, ISphereCollider {
        private SphereCollider collider;
        private UnityPhysicsMaterial mat;

        public UnitySphereCollider(IGameObject obj) : base(obj)
		{
			collider = obj.GetComponent<SphereCollider>();
            if (null == collider) {
				throw new NullReferenceException("Object " + obj.Name  + " expected to have a SphereCollider but none was found");
            }
        }

        public float radius {
            get { return collider.radius; }
            set { collider.radius = value; }
        }

        public bool enabled {
            get { return collider.enabled; }
            set { collider.enabled = value; }
        }

        public Vector3 center {
            get { return collider.center; }
            set { collider.center = value; }
        }

        public IPhysicMaterial material {
            get { return mat; }
            set {
                mat = (UnityPhysicsMaterial) value;
                collider.material = mat.material;
            }
        }
    }
}

