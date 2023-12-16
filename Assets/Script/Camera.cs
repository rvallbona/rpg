using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float height = 10.0f, distance = 8.0f, smoth = 5.0f;

    void LateUpdate()
    {
        IsPlayer();
        CamMovement();
    }
    private void IsPlayer()
    {
        if (player == null)
        {
            Debug.Log("No Player to Follow");
            return;
        }
    }
    private void CamMovement()
    {
        Vector3 pos = player.position - Vector3.forward * distance;
        pos.y = height;

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * smoth);

        transform.LookAt(player);
    }
}
