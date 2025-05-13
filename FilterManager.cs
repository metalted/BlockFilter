namespace BlockFilter;

public interface FilterManager<TFilter>
{
    void HandleLeftClick(TFilter key, LEV_Inspector instance);
    void HandleRightClick(TFilter key, LEV_Inspector instance);
}