using UnityEngine;
using UnityEngine.EventSystems;

namespace BlockFilter;

public class CustomClickHandler<TFilter, TManager> : MonoBehaviour, IPointerClickHandler where TManager : FilterManager<TFilter>
{
    private TFilter key;
    private TManager manager;
    private LEV_Inspector instance;

    public void Initialize(TFilter key, TManager manager, LEV_Inspector instance)
    {
        this.key = key;
        this.manager = manager;
        this.instance = instance;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            manager.HandleLeftClick(key, instance);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            manager.HandleRightClick(key, instance);
        }
    }
}