using UnityEngine;

public class PlayerDefacation : MonoBehaviour
{
    public GameObject shitPrefab;

    public int minShitCounter, maxShitCounter;

    private int flapsToShit;
    private int flapCounter;
    // Start is called before the first frame update
    void Start()
    {
        CalculateNextFlapToShitCount();
        GameEvents.PlayerEvent += OnPlayerEvent;
    }

    private void OnDisable()
    {
        GameEvents.PlayerEvent -= OnPlayerEvent;
    }

    private void OnPlayerEvent(object sender, PlayerEventArgs e)
    {
        if (e.EventType == PlayerEventType.Flap)
        {
            UpdateFlap();
        }
    }

    private void UpdateFlap()
    {
        flapCounter++;
        if (flapCounter >= flapsToShit)
        {
            Defecate();
            CalculateNextFlapToShitCount();
        }
    }

    private void Defecate()
    {
        GameObject shit = Instantiate(shitPrefab, transform.position, Quaternion.identity, transform);
        shit.GetComponent<Shit>().Init(GameManager.Instance.GetScoreMultiplier() * 1.25f);
        GameEvents.FireShitPlayerEvent();
        Destroy(shit, 2f);
    }

    private void CalculateNextFlapToShitCount()
    {
        int next = Random.Range(minShitCounter, maxShitCounter);
        flapCounter = 0;
        flapsToShit = next;
    }
}