public interface IInteractable 
{
    string m_objectName { get; set; }

    bool m_isInteractable { get; set; }

    bool m_isPickable { get; set; }

    bool showUi { get; set; }

    void OnAction();
}

