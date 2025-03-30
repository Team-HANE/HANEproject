using Godot;

public partial class LibraryInfo : Control
{
    private Label nameLabel;
    private Label addressLabel;

    public override void _Ready()
    {
        nameLabel = GetNode<Label>("Node2D/LibraryPanel/VBoxContainer/NameLabel");
        addressLabel = GetNode<Label>("Node2D/Library/VBoxContainer/AddressLabel");


    }
}
