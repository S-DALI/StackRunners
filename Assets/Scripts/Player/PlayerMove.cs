using UnityEngine;

namespace Assets.ExtraAssets.Scripts
{
    public class PlayerMove : MonoBehaviour
    {
        [Header("Parametrs Player")]
        [SerializeField] private float speed;
        [SerializeField] private float dragSpeed = 5f;

        [Header("Menu elements")]
        [SerializeField] MenuController menuController;

        private Vector2 touchStartPosition;
        private Vector3 objectStartPosition;

        private bool isDragging = false;
        private float minX = -2, maxX = 2;

        private bool isRunning ;
        private bool isStartGame ;

        private Transform _transform;
        private void Start()
        {
            isRunning = true;
            isStartGame = false;
            _transform = GetComponent<Transform>();
            menuController.startGame += BeginRun;
        }

        private void Update()
        {
            if (isRunning && isStartGame)
            {
                MovePlayer(_transform.position + _transform.forward * speed * Time.deltaTime);

                if (Input.touchCount > 0)
                {
                    StartTouch();
                }

                if (isDragging)
                {
                    Dragging();
                }
            }
        }

        private void MovePlayer(Vector3 newPosition)
        {
            _transform.position = newPosition;
        }

        private void StartTouch()
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPosition = touch.position;
                objectStartPosition = _transform.position;
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
        private void Dragging()
        {
            Vector2 touchDelta = Input.GetTouch(0).position - touchStartPosition;
            float dragDistanceX = touchDelta.x / Screen.width;

            float targetX = objectStartPosition.x + dragDistanceX * dragSpeed;
            targetX = Mathf.Clamp(targetX, minX, maxX);

            _transform.position = new Vector3(targetX, _transform.position.y, _transform.position.z);
        }

        public void StopRun()
        {
            isRunning = false;
            menuController.EndGame();
        }
        public void BeginRun()
        {
            isStartGame = true;
        }
    }
}
