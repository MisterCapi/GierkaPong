using TMPro;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class PaddleAgent : Agent
{
    public float speed;

    public float defended;

    public float defendedMax;

    public GameObject defendedText;
    
    public GameObject defendedMaxText;

    public Rigidbody2D rb;

    [SerializeField] 
    private Transform ballTransform;

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(ballTransform.position);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveY = actions.ContinuousActions[0];
        rb.velocity = new Vector2(rb.velocity.x, moveY * speed);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Vertical");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball") && col.contacts[0].normal[1] == 0)
        {
            SetReward(1f);
            defended++;
            defendedText.GetComponent<TextMeshProUGUI>().text = defended.ToString();
        }
    }

    public void Lose()
    {
        SetReward(-1f);
        EndEpisode();
    }

    public override void OnEpisodeBegin()
    {
        if (defended > defendedMax)
        {
            defendedMax = defended;
            defendedMaxText.GetComponent<TextMeshProUGUI>().text = defendedMax.ToString();
        }

        defended = 0;
        defendedText.GetComponent<TextMeshProUGUI>().text = defended.ToString();
    }
}
