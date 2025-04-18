using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.UI;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ButtonHaptic : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [SerializeField] private float vibrationIntensity = 0.5f;
    [SerializeField] private float duration = 0.1f;  // seconds

    private XRUIInputModule InputModule => EventSystem.current.currentInputModule as XRUIInputModule;

    public void OnPointerDown(PointerEventData eventData)
    {
        sendVibration(eventData);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sendVibration(eventData);
    }

    private void sendVibration(PointerEventData eventData)
    {
        var interactor = InputModule.GetInteractor(eventData.pointerId);
        // Trigger haptic feedback on hover
        if (interactor is UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor controllerInteractor)
        {
            controllerInteractor.SendHapticImpulse(vibrationIntensity, duration);

        }
    }
}
