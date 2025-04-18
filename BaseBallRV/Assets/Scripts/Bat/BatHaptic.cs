using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRBaseInteractable))]
public class BatHaptic : MonoBehaviour
{
    public float intensityFactor = 1.0f;
    public float duration = 0.1f;  // seconds

    private XRBaseInteractable interactable;
    private XRBaseInputInteractor controller;

    void Awake()
    {
        interactable = GetComponent<XRBaseInteractable>();
        interactable.selectEntered.AddListener(OnSelectEntered);
        interactable.selectExited.AddListener(OnSelectExited);
    }
        void OnDestroy()
    {
        interactable.selectEntered.RemoveListener(OnSelectEntered);
        interactable.selectExited.RemoveListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        var interactor = args.interactorObject;

        // Try to get XRBaseControllerInteractor
        if (interactor is UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor controllerInteractor)
        {
            this.controller = controllerInteractor;
        }
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        this.controller = null;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (this.controller != null && collision.collider.gameObject != this.controller.gameObject) {
            this.controller.SendHapticImpulse(collision.relativeVelocity.magnitude * intensityFactor, this.duration);
        }
    }
}
