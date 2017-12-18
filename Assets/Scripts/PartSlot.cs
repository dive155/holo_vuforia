using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartSlot : MonoBehaviour 
{
    [Header("Possible attachments:")]
    [SerializeField]
    private List<Part> suitableParts;
    [SerializeField]
    private int defaultPartID = 0;
    [SerializeField]
    private BlurHandler blurHandler;

    private Part instantiatedPart;
	
    private int cur = 0; //temporary, TODO: proper item selector

	void Start () 
    {
        if (defaultPartID < suitableParts.Count)
        {
            defaultPartID = 0;
            SpawnPart(defaultPartID);
        }
            
	}
	
    private void SpawnPart(int id)
    {
        if (instantiatedPart != null)
        {
            Destroy(instantiatedPart.gameObject);
        }

        instantiatedPart = Instantiate(suitableParts[id], this.transform.position, this.transform.rotation);
        instantiatedPart.transform.parent = this.transform;
        instantiatedPart.SetBlurAction(blurHandler.ToggleBlur);
		instantiatedPart.SetSlot(this);
		blurHandler.AddRenderers (GetPartRenderers(instantiatedPart));
		blurHandler.AddSpawnedPart(instantiatedPart);
    }
        
    public void NextObject()
    { //a temporary method to switch objects TODO: a proper item selector
        cur++;;
        cur %= suitableParts.Count;
        SpawnPart(cur);
    }

    private Renderer[] GetPartRenderers(Part part)
    {
        return part.GetComponentsInChildren<Renderer>();
    }

	public void ReportSelection(SelectableObject part)
	{
        blurHandler.RemoveRenderers(part.GetComponentsInChildren<Renderer>());
		blurHandler.LockOtherSelectables(part);
	}

    public void ReportUnselection(SelectableObject part)
    {
        blurHandler.AddRenderers(part.GetComponentsInChildren<Renderer>());
    }
		
}
