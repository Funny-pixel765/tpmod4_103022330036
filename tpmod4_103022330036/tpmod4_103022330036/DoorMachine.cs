using System;

// Define the states for the door
public enum DoorState
{
    TERKUNCI,
    TERBUKA
}

// Define the triggers that cause state transitions
public enum DoorTrigger
{
    BUKA_PINTU,
    KUNCI_PINTU
}

// Class to represent a transition between states
class DoorTransition
{
    public DoorState prevState;
    public DoorState nextState;
    public DoorTrigger trigger;

    public DoorTransition(DoorState prevState, DoorState nextState, DoorTrigger trigger)
    {
        this.prevState = prevState;
        this.nextState = nextState;
        this.trigger = trigger;
    }
}

class DoorMachine
{
    private DoorState currentState;
    private DoorTransition[] transitions;

    public DoorMachine()
    {
        // Set initial state to TERKUNCI as per the assignment
        currentState = DoorState.TERKUNCI;

        // Define all possible transitions
        transitions = new DoorTransition[]
        {
            new DoorTransition(DoorState.TERKUNCI, DoorState.TERBUKA, DoorTrigger.BUKA_PINTU),
            new DoorTransition(DoorState.TERBUKA, DoorState.TERKUNCI, DoorTrigger.KUNCI_PINTU)
        };
    }

    public void ProcessTrigger(DoorTrigger trigger)
    {
        // Find a matching transition
        foreach (var transition in transitions)
        {
            if (transition.prevState == currentState && transition.trigger == trigger)
            {
                // Found a matching transition, update the state
                currentState = transition.nextState;
                DisplayStateMessage();
                return;
            }
        }
    }

    public void DisplayStateMessage()
    {
        // Display appropriate message based on current state
        switch (currentState)
        {
            case DoorState.TERKUNCI:
                Console.WriteLine("Pintu terkunci");
                break;
            case DoorState.TERBUKA:
                Console.WriteLine("Pintu terbuka");
                break;
        }
    }

    public DoorState GetCurrentState()
    {
        return currentState;
    }
}

// Example Program class to demonstrate the DoorMachine
