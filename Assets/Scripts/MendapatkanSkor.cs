using UnityEngine;

public class MendapatkanSkor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        PengaturanSkor skorManager = FindFirstObjectByType<PengaturanSkor>();

        if (other.CompareTag("Koin"))
        {
            skorManager.TambahSkor(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Berlian"))
        {
            skorManager.TambahSkor(5);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("CoinHitam"))
        {
            skorManager.TambahSkor(10);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("HealthPotion"))
        {
            skorManager.TambahHealth(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Racun"))
        {
            skorManager.KurangiHealth(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("HeadObstacleMove"))
        {
            skorManager.KurangiHealth(1);
        }
        else if (other.CompareTag("PreasurePlate"))
        {
            skorManager.WinningPopup();
        }
    }
}