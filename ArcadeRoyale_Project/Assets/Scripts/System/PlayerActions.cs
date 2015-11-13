using System;
using InControl;
using UnityEngine;


public class PlayerActions : PlayerActionSet {
	
	public PlayerAction Left;
	public PlayerAction Right;
	public PlayerAction Up;
	public PlayerAction Down;

    public PlayerAction Enter;
    public PlayerAction Escape;

    public PlayerActions() {		

		Left = CreatePlayerAction( "Left" );
		Right = CreatePlayerAction( "Right" );
		Up = CreatePlayerAction( "Up" );
		Down = CreatePlayerAction( "Down" );

        Enter = CreatePlayerAction("Enter");
        Escape = CreatePlayerAction("Escape");	
	}


    public static PlayerActions CreateWithDefaultBindings()
	{
        var playerActions = new PlayerActions();		

        // Controllers
		playerActions.Left.AddDefaultBinding( InputControlType.LeftStickLeft );
		playerActions.Right.AddDefaultBinding( InputControlType.LeftStickRight );
		playerActions.Up.AddDefaultBinding( InputControlType.LeftStickUp );
		playerActions.Down.AddDefaultBinding( InputControlType.LeftStickDown );

		playerActions.Left.AddDefaultBinding( InputControlType.DPadLeft );
		playerActions.Right.AddDefaultBinding( InputControlType.DPadRight );
		playerActions.Up.AddDefaultBinding( InputControlType.DPadUp );
		playerActions.Down.AddDefaultBinding( InputControlType.DPadDown );


        // Cabinet Controls
        playerActions.Up.AddDefaultBinding(Key.UpArrow);
        playerActions.Down.AddDefaultBinding(Key.DownArrow);
        playerActions.Left.AddDefaultBinding(Key.LeftArrow);
        playerActions.Right.AddDefaultBinding(Key.RightArrow);

        playerActions.Enter.AddDefaultBinding(Key.Z);
        playerActions.Enter.AddDefaultBinding(Key.X);


        playerActions.Up.AddDefaultBinding(Key.R);
        playerActions.Down.AddDefaultBinding(Key.F);
        playerActions.Left.AddDefaultBinding(Key.D);
        playerActions.Right.AddDefaultBinding(Key.G);

        playerActions.Enter.AddDefaultBinding(Key.A);
        playerActions.Enter.AddDefaultBinding(Key.S);


        playerActions.Up.AddDefaultBinding(Key.O);
        playerActions.Down.AddDefaultBinding(Key.L);
        playerActions.Left.AddDefaultBinding(Key.K);
        playerActions.Right.AddDefaultBinding(Key.Semicolon);

        playerActions.Enter.AddDefaultBinding(Key.H);
        playerActions.Enter.AddDefaultBinding(Key.J);


        playerActions.Up.AddDefaultBinding(Key.Home);
        playerActions.Down.AddDefaultBinding(Key.End);
        playerActions.Left.AddDefaultBinding(Key.Delete);
        playerActions.Right.AddDefaultBinding(Key.PageDown);

        playerActions.Enter.AddDefaultBinding(Key.B);
        playerActions.Enter.AddDefaultBinding(Key.N);


        playerActions.Enter.AddDefaultBinding(Key.PadEnter);

        playerActions.Escape.AddDefaultBinding(Key.Key9);
        playerActions.Escape.AddDefaultBinding(Key.Escape);

		playerActions.ListenOptions.IncludeUnknownControllers = true;
		playerActions.ListenOptions.MaxAllowedBindings = 3;
//			playerActions.ListenOptions.MaxAllowedBindingsPerType = 1;
//			playerActions.ListenOptions.UnsetDuplicateBindingsOnSet = true;

		playerActions.ListenOptions.OnBindingFound = ( action, binding ) =>
		{
			if (binding == new KeyBindingSource( Key.Escape ))
			{
				action.StopListeningForBinding();
				return false;
			}
			return true;
		};

		playerActions.ListenOptions.OnBindingAdded += ( action, binding ) =>
		{
			Debug.Log( "Binding added... " + binding.DeviceName + ": " + binding.Name );
		};

		playerActions.ListenOptions.OnBindingRejected += ( action, binding, reason ) =>
		{
			Debug.Log( "Binding rejected... " + reason );
		};

		return playerActions;
	}
}
