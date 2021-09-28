using UnityEngine;

public static class ColliderCreator {

    public static SphereCollider CreateSphereColliderOnGameObject(GameObject targetGameObject, float radius, bool isTrigger) {
        SphereCollider sphereCollider = targetGameObject.AddComponent<SphereCollider>();
        
        sphereCollider.radius = radius;
        sphereCollider.isTrigger = isTrigger;

        return sphereCollider;
    }
    
}
