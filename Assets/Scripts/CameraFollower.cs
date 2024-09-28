using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private void Awake()
    {
        //there can only be one camera following the player
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position = new Vector3(
            Mathf.Min(Mathf.Max(characterTransform.position.x, bottomLeftCorner.position.x), topRightCorner.position.x),
            Mathf.Min(Mathf.Max(characterTransform.position.y, bottomLeftCorner.position.y), topRightCorner.position.y),
            -5f
            );
    }

    public void setFocusOnCharacter(GameObject character)
    {
        characterTransform = character.transform;
    }

    public static CameraFollower instance;

    private Transform characterTransform;

    //the camera won't go outside these bounds
    //they need to be set manually for each level
    [SerializeField] private Transform bottomLeftCorner;
    [SerializeField] private Transform topRightCorner;
}
