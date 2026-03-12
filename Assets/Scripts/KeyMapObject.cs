using UnityEngine;

public class KeyMapObject
{
    public KeyCode keyCode;
    public System.Type command;
    public object additional;

    public KeyMapObject(KeyCode keyCode, System.Type command,object additional) { 
        this.keyCode = keyCode;
        this.command = command;
        this.additional = additional;
    }



    
}
