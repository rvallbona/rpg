using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float smoothTime = 0.1f;
    private float velocidadRotacion;

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoverPersonaje();
    }

    void MoverPersonaje()
    {
        float movimientoAdelante = Input.GetAxis("Vertical");
        float movimientoLateral = Input.GetAxis("Horizontal");

        Vector3 direccionMovimiento = new Vector3(movimientoLateral, 0, movimientoAdelante).normalized;

        if (direccionMovimiento.magnitude >= 0.1f)
        {
            float objetivoAngulo = Mathf.Atan2(direccionMovimiento.x, direccionMovimiento.z) * Mathf.Rad2Deg;
            float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, objetivoAngulo, ref velocidadRotacion, smoothTime);

            transform.rotation = Quaternion.Euler(0, angulo, 0);

            Vector3 movimiento = direccionMovimiento * velocidadMovimiento;
            characterController.Move(movimiento * Time.deltaTime);
        }
    }
}