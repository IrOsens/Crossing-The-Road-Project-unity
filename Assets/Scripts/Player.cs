using UnityEngine;

public class Player : MonoBehaviour
{
    public float BesarGaya = 5f;
    public float Kecepatan = 3f;
    private Rigidbody DataRB;
    private bool DiTanah = false;
    private Vector3 inputMovement;

    void Start()
    {
        DataRB = GetComponent<Rigidbody>();
        DataRB.interpolation = RigidbodyInterpolation.Interpolate;
        DataRB.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        inputMovement = new Vector3(moveX, 0, moveZ).normalized * Kecepatan;

        if (Input.GetKeyDown(KeyCode.Space) && DiTanah)
        {
            DataRB.AddForce(Vector3.up * BesarGaya, ForceMode.Impulse);
            DiTanah = false;
        }

        if (inputMovement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(inputMovement);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        DataRB.velocity = new Vector3(inputMovement.x, DataRB.velocity.y, inputMovement.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            DiTanah = true;
        }
    }
}