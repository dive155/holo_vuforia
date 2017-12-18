using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurHandler : MonoBehaviour
{
    [SerializeField]
    private List<Renderer> handledRenderers;

	private List<Part> spawnedParts;

    [SerializeField]
    private float blurModifier = 0.3f;

    private bool isBlured;

	private void Start()
	{
		spawnedParts = new List<Part>();
	}

    public void ToggleBlur(bool blur)
    {
        if (blur == isBlured)
        {
            return;
        } 
        foreach (Renderer renderer in handledRenderers)
        {
            foreach (Material mat in renderer.materials)
            {
				if (blur)
                {
					mat.color = mat.color * blurModifier;
				}
				else
				{
					mat.color = mat.color / blurModifier;
					UnlockAllSelectables();
				}
            }
        }

        isBlured = blur;
    }

    public void AddRenderers(params Renderer[] rend)
    {
        foreach (Renderer r in rend)
        {
            handledRenderers.Add(r);
        }
    }

    public void RemoveRenderers(params Renderer[] rend)
    {
        foreach (Renderer r in rend)
        {
            while (handledRenderers.Contains(r))
            {
                handledRenderers.Remove(r);
            }
        }
    }

	public void AddSpawnedPart(Part part)
	{
		spawnedParts.Add(part);
	}

	public void RemoveSpawnedPart(Part part)
	{
        spawnedParts.Remove(part);
	}

	public void LockOtherSelectables(SelectableObject part)
	{
		foreach (SelectableObject currentPart in spawnedParts)
		{
			if (currentPart != part)
			{
				currentPart.SetState(SelectableStates.Locked);
			}
		}
	}

	public void UnlockAllSelectables ()
	{
		foreach (SelectableObject currentPart in spawnedParts)
		{
			currentPart.ForceSetState(SelectableStates.Idle);
		}
	}
}
