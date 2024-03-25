using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    private Vector2 _lastTapPosition;
    private Vector3 _startPosition;

    [SerializeField] Transform topTransform;
    [SerializeField] Transform bottomTransform;

    [SerializeField] GameObject helixPartPrefab;

    [SerializeField] List<Stage> allStages = new List<Stage>();
    [SerializeField] float helixDistance;

    private List<GameObject> spawnedLevels = new List<GameObject>();


    private void Awake()
    {
        _startPosition = transform.localEulerAngles;
        helixDistance = topTransform.localPosition.y - (bottomTransform.localPosition.y + .1f);
        //LoadStage(0);
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector2 _currentTapPosition = Input.mousePosition;
            if(_lastTapPosition == Vector2.zero)
            {
                _lastTapPosition = _currentTapPosition;
            }

            float _distance = _lastTapPosition.x - _currentTapPosition.x;

            _lastTapPosition = _currentTapPosition;

            transform.Rotate(Vector3.up * _distance);
        }

        if(Input.GetMouseButtonUp(0))
        {
            _lastTapPosition = Vector2.zero;
        }
    }

    public void LoadStage(int stageNumber)
    {
        Stage stage = allStages[Mathf.Clamp(stageNumber, 0, allStages.Count - 1)];
        if(stage == null)
        {
            Debug.Log("No más niveles");
            return;
        }

        Camera.main.backgroundColor = allStages[stageNumber].stageBackgroundColor;
    }
}
