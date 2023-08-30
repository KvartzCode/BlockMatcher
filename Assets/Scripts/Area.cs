using UnityEngine;


public class Area : MonoBehaviour
{
    public int ID = -1; //TODO: Make use of this when implementing handling for differently shaped blocks.
    public bool isFilled = false;
    Block block;


    private void OnTriggerEnter(Collider other)
    {
        var block = other.GetComponent<Block>();

        if (!block.isSnapped)
            return;

        isFilled = true;
        this.block = block;
        AreaManager.Instance.UpdateScore();
    }

    private void OnTriggerExit(Collider other)
    {
        if (block && other.GetComponent<Block>() == block)
        {
            isFilled = false;
            AreaManager.Instance.UpdateScore();
            block = null;
        }
    }
}
