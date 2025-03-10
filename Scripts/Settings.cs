using Godot;

namespace escapetampere
{
public partial class Settings : Control
{
	    public void Open()
    {
        Visible = true; // Show the panel
    }

    public void Close()
    {
        Visible = false; // Hide the panel
    }
}
}
