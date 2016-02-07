using System.Collections;
using UnityEngine;

// Implement this interface in input processors for hardware which supports vibration.
namespace InputProcessing {
    public interface IVibration {
        // MonoBehavior is needed to use Coroutines.
        void SetMonoBehaviour(MonoBehaviour virtualController);
        // Invoke StopVibration() at the end of Vibrate() - best practice.
        void Vibrate(float duration, float leftStrength, float rightStrenght);
        IEnumerator StopVibration(float duration);
    }
}
