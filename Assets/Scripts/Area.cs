using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    public int ID = -1;
    public bool isFilled = false;
    Block block;


    private void OnTriggerEnter(Collider other)
    {
        var block = other.GetComponent<Block>();

        if (!block.isSnapped)
            return;

        isFilled = true;
        this.block = block;
        AreaManager.Instance.AreaFilled();
    }

    private void OnTriggerExit(Collider other)
    {
        if (block && other.GetComponent<Block>() == block)
        {
            isFilled = false;
            AreaManager.Instance.AreaEmptied();
            block = null;
        }
    }
}
