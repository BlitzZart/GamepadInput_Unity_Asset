/// <summary>
/// The class which implements InputProcessor has to manage all visual buttons and axes
/// </summary>
public abstract class InputProcessor
{
    public InputProcessor(int playerNumber)
    {
        this.playerNumber = playerNumber;
    }
    private int playerNumber;
    public int PlayerNumber { get { return playerNumber; } }
    public VirtualButton 
        faceLeft, faceRight, faceDown, faceUp,
        dPadLeft, dPadRight, dPadDown, dPadUp,
        shoulderLeft, shoulderRight,
        start, back;
    public VirtualAxis leftX, leftY, rightX, rightY, leftTrigger, rightTrigger;
    public abstract void ProcessInput();
}
