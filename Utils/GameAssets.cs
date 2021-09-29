using UnityEngine;

public class GameAssets : MonoBehaviour {

    private static GameAssets instance;

    public static GameAssets Singleton {
        get {
            if (instance == null) instance = Resources.Load<GameAssets>("GameAssets");
            return instance;
        }
    }

    // is readonly appropriate here? 
    public readonly Transform pfInteractOffer, pfDialogueOffer, pfFightOffer;

}
