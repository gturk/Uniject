using System;
using UnityEngine;

namespace Uniject {
    public interface IPhysicMaterial {
        float dynamicFriction { get; set; }
        float staticFriction { get; set; }
        float bounciness { get; set; }
        Vector3 frictionDirection2 { get; set; }
        float dynamicFriction2 { get; set; }
        float staticFriction2 { get; set; }
        UnityEngine.PhysicMaterialCombine frictionCombine { get; set; }
        UnityEngine.PhysicMaterialCombine bounceCombine { get; set; }
    }
}

