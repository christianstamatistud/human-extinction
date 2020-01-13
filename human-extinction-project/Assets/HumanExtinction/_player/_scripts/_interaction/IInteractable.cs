public interface IInteractable 
{
    bool m_isInteractable { get; set; }
    bool m_isDraggable { get; set; }

    void OnInteraction();
    void OnDrag();
}

