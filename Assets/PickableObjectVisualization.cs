using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectVisualization : MonoBehaviour
{
    [SerializeField] private Transform _trashBagPivot;
    [SerializeField] private Transform _coffeePivot;
    [SerializeField] private Transform _photocameraPivot;

    [SerializeField] private Transform _coffeePutPivot;
    [SerializeField] private Transform _cameraPutPivot;

    GameObject _trashBag;
    GameObject _coffee;
    GameObject _camera;

    private void OnEnable()
    {
        TakeTrashBagScenario.OnGetTrash += SetTrashBag;
        TakeCoffeeScenario.OnGetCoffee += SetCoffeeCup;
        PickCameraScenario.OnGetCamera += SetCamera;
    }

    private void OnDisable()
    {
        TakeTrashBagScenario.OnGetTrash -= SetTrashBag;
        TakeCoffeeScenario.OnGetCoffee -= SetCoffeeCup;
        PickCameraScenario.OnGetCamera -= SetCamera;
    }

    private void SetTrashBag(GameObject trashBag)
    {
        trashBag.transform.parent = _trashBagPivot;
        trashBag.transform.localPosition = new Vector3(0f, 0f, 0f);
        _trashBag = trashBag;
    }

    private void SetCoffeeCup(GameObject coffeeCup)
    {
        coffeeCup.transform.parent = _coffeePivot;
        coffeeCup.transform.localPosition = new Vector3(0f, 0f, 0f);
        coffeeCup.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        _coffee = coffeeCup;
    }

    private void SetCamera(GameObject camera)
    {
        camera.transform.parent = _coffeePivot;
        camera.transform.localPosition = new Vector3(0f, 0f, 0f);
        camera.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        _camera = camera;
       // PutCoffee();
    }

    //private void PutCoffee()
    //{
    //    _coffee.transform.parent = _coffeePutPivot;
    //    _coffee.transform.localPosition = new Vector3(0f, 0f, 0f);
    //    _coffee.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    //}

    //private void PutCamera()
    //{
    //    _camera.transform.parent = _cameraPutPivot;
    //    _camera.transform.localPosition = new Vector3(0f, 0f, 0f);
    //    _camera.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    //}
}
