using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRBaseInteractable))]
public class BatHaptic : MonoBehaviour
{
    [SerializeField] private float intensityFactor = 1.0f;
    [SerializeField] private float collisionImpulseAtMaxIntensity = 3.0f;
    [SerializeField] private float duration = 0.1f;  // seconds

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
            float impact = math.min(collision.impulse.magnitude * intensityFactor / collisionImpulseAtMaxIntensity, 1.0f);
            this.controller.SendHapticImpulse(impact, duration);
            AudioManager.Instance.PlaySFX("BatHit");
        }
    }
}
