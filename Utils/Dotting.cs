using System.Collections.Generic;
using UnityEngine;

// is this a clear name?
public static class Dotting {

    // Is it good?
    public static bool IsClosestPositionTo(List<Vector3> candidatePositionList, Vector3 verifiablePosition, Vector3 targetPosition) {
        float closestDistance = float.MaxValue;
        foreach(Vector3 candidate in candidatePositionList) {
            float distance = Vector3.Distance(targetPosition, candidate);
            if (distance < closestDistance) closestDistance = distance;
        }

        if (closestDistance > Vector3.Distance(targetPosition, verifiablePosition))
            return true;

        return false;
    }
    
}
