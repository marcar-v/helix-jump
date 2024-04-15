using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelixController : MonoBehaviour
{
    private Vector2 _lastTapPosition;
    private Vector3 _startRotation;

    [SerializeField] GameObject helixPlatformPrefab;
    public Vector3 startRotation {  get { return _startRotation; } set {  _startRotation = value; } }

    [SerializeField] Transform _topTransform;
    public Transform topTransform { get { return _topTransform; } set { _topTransform = value; } }

    [SerializeField] Transform _goalTransform;
    public Transform goalTransform { get { return _goalTransform; } set { _goalTransform = value; } }
    
    float _helixDistance;
    public float helixDistance {  get { return _helixDistance; } set { _helixDistance = value; } }

    private List<GameObject> spawnedLevels = new List<GameObject>();
    [SerializeField] List<Stage> allStages = new List<Stage>();

    private void Awake()
    {
        _startRotation = transform.localEulerAngles;
        helixDistance = topTransform.localPosition.y - (goalTransform.localPosition.y + .1f);
        LoadStage(0);
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

        if (stage == null)
        {
            Debug.Log("No más escenas");
            return;
        }

        Camera.main.backgroundColor = allStages[stageNumber].stageBackgroundColor;

        FindObjectOfType<BallController>().GetComponent<Renderer>().material.color = allStages[stageNumber].stageBallColor;

        transform.localEulerAngles = startRotation;

        foreach (GameObject go in spawnedLevels)
        {
            Destroy(go);
        }

        float levelDistance = helixDistance / stage.levels.Count;
        float spawnPositionY = topTransform.localPosition.y;

        for (int i = 0; i < stage.levels.Count; i++)
        {
            spawnPositionY -= levelDistance;

            GameObject level = Instantiate(helixPlatformPrefab, transform);

            level.transform.localPosition = new Vector3(0, spawnPositionY, 0);

            spawnedLevels.Add(level);

            int _partsToDisable = 12 - stage.levels[i].partCount;
            List<GameObject> disabledParts = new List<GameObject>();

            while (disabledParts.Count < _partsToDisable)
            {
                GameObject randomPart = level.transform.GetChild(Random.Range(0, level.transform.childCount)).gameObject;
                if (!disabledParts.Contains(randomPart))
                {
                    randomPart.SetActive(false);
                    disabledParts.Add(randomPart);
                }
            }

            List<GameObject> leftParts = new List<GameObject>();
            foreach (Transform t in level.transform)
            {
                t.GetComponent<Renderer>().material.color = allStages[stageNumber].stageLevelPartColor;
                if (t.gameObject.activeInHierarchy)
                {
                    leftParts.Add(t.gameObject);
                }
            }

            List<GameObject> deathParts = new List<GameObject>();
            while (deathParts.Count < stage.levels[i].deathPartCount)
            {
                GameObject randomDeathParts = leftParts[(Random.Range(0, leftParts.Count))].gameObject;

                if (!deathParts.Contains(randomDeathParts))
                {
                    randomDeathParts.gameObject.AddComponent<DeathPart>();
                    deathParts.Add(randomDeathParts);
                }
            }
        }
    }
}
