using System;

public interface ICollectable
{
    bool isCollect {
        get;
        set;
    }
}

public interface IDraggable
{
    bool isDrag
    {
        get;
        set;
    }
}

public interface IClickable
{

    bool isClick
    {
        get;
        set;
    }
    event EventHandler onClicked;
}