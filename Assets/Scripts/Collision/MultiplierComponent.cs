using UnityEngine;

public class MultiplierComponent : CarComponent
{
    public float Multiplier {get => multiplier;}
    [SerializeField] private float multiplier;
    [SerializeField] private float MultiplierDelta;
    [SerializeField] private float MultiplierUpperBound;
    [SerializeField] private float MultiplierLowerBound;
    public override bool Hit()
    {
        multiplier = Mathf.Clamp(Multiplier + MultiplierDelta, MultiplierLowerBound, MultiplierUpperBound);
        return false;
    }
}
