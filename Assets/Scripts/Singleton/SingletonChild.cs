using UnityEngine;

public class SingletonChild: Singleton3<SingletonChild> // So the child can replace T because it inherits from Singleton3. But it can only inherit because it can replace T. What the hell.
{
    
}
