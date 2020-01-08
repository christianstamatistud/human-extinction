public interface IInteractable 
{
    string m_objectName { get; set; }

    bool m_isInteractable { get; set; }
    bool m_isPickable { get; set; }
    bool m_CanLink { get; set; }

    void OnAction();
}

