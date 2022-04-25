using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera mainCamera;

    // Найбільш оптимальні налаштування границь для цієї гри
    float left = -3;
    float right = 3;
    float top = 2;
    float bottom = -2;

    float timeOffset = 5f;
    
    // Zoom
    float currentZoom; 
    float zoomIncrement = 3;
    float zoomLerpSpeed = 10;

    private void Start()
    {
        mainCamera = Camera.main;
        currentZoom = mainCamera.orthographicSize;
    }

    private void Update()
    {
        this.MoveCamera();
        this.Zoom();
    }

    private void MoveCamera()
    {
        Vector3 startPosition = transform.position; // початкове положення камери

        // ПОЗИЦІЮ МИШІ В ПІКСЕЛЯХ ПОТРІБНО КОНВЕРТУВАТИ В ПОЗИЦІЮ У Vector3 (підходить для камери) 
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 desiredPosition = Camera.main.ScreenToWorldPoint(mousePos);
        desiredPosition.z = -10;

        // ПЛАВНЕ ПЕРЕМІЩЕННЯ КАМЕРИ 
        transform.position = Vector3.Lerp(startPosition,
            new Vector3(
            Mathf.Clamp(desiredPosition.x, left, right),
            Mathf.Clamp(desiredPosition.y, bottom, top),
            desiredPosition.z),
            timeOffset * Time.deltaTime);
    }

    private void Zoom()
    {
        float scrollData = Input.GetAxis("Mouse ScrollWheel");
        currentZoom = Mathf.Clamp(currentZoom - scrollData * zoomIncrement, 2f, 5f);
        mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, currentZoom, zoomLerpSpeed * Time.deltaTime);
    }
}