# State User Cases

## 1. a document approval process

a document can be in one of several states (e.g., Draft, Review, Approved, Rejected). 
The document's behavior changes depending on its current state, such as whether it can be edited, approved, or rejected

```cs
// Step 1: Define the State and Concrete States
public abstract class DocumentState
{
    public abstract void HandleReview(Document context);
    public abstract void HandleApproval(Document context);
    public abstract void HandleRejection(Document context);
}


public class DraftState : DocumentState
{
    public override void HandleReview(Document context)
    {
        Console.WriteLine("Document is under review.");
        context.State = new ReviewState();
    }

    public override void HandleApproval(Document context)
    {
        Console.WriteLine("Draft document cannot be directly approved.");
    }

    public override void HandleRejection(Document context)
    {
        Console.WriteLine("Draft document cannot be rejected.");
    }
}

public class ReviewState : DocumentState
{
    public override void HandleReview(Document context)
    {
        Console.WriteLine("Document is already under review.");
    }

    public override void HandleApproval(Document context)
    {
        Console.WriteLine("Document has been approved.");
        context.State = new ApprovedState();
    }

    public override void HandleRejection(Document context)
    {
        Console.WriteLine("Document has been rejected.");
        context.State = new RejectedState();
    }
}

public class ApprovedState : DocumentState
{
    public override void HandleReview(Document context)
    {
        Console.WriteLine("Approved document cannot be reviewed again.");
    }

    public override void HandleApproval(Document context)
    {
        Console.WriteLine("Document is already approved.");
    }

    public override void HandleRejection(Document context)
    {
        Console.WriteLine("Approved document cannot be rejected.");
    }
}

public class RejectedState : DocumentState
{
    public override void HandleReview(Document context)
    {
        Console.WriteLine("Rejected document cannot be reviewed.");
    }

    public override void HandleApproval(Document context)
    {
        Console.WriteLine("Rejected document cannot be approved.");
    }

    public override void HandleRejection(Document context)
    {
        Console.WriteLine("Document is already rejected.");
    }
}

// Step 2: Create the Context Class
// The Context class maintains an instance of a ConcreteState subclass that defines the current state.

public class Document
{
    public DocumentState State { get; set; }

    public Document(DocumentState state)
    {
        this.State = state;
    }

    public void Review()
    {
        State.HandleReview(this);
    }

    public void Approve()
    {
        State.HandleApproval(this);
    }

    public void Reject()
    {
        State.HandleRejection(this);
    }
}

// Step 3: Using the State Pattern

class Program
{
    static void Main(string[] args)
    {
        Document document = new Document(new DraftState());

        document.Review();  // Output: Document is under review.
        document.Approve(); // Output: Document has been approved.
        
        // Attempt to review the approved document
        document.Review();  // Output: Approved document cannot be reviewed again.
    }
}
```

## Online Order Processing System

In an online order processing system, an order can have several states such as New, Processing, Shipped, and Delivered. 

The behavior of the order changes as it progresses through these states. For example, only new orders can be canceled, and only shipped orders can be tracked.


## Traffic Light System

A traffic light can be in one of several states such as Red, Yellow, and Green.

The behavior of the traffic light changes as it transitions from one state to another. For example, the light is red for 60 seconds, yellow for 10 seconds, and green for 60 seconds.

The State pattern can encapsulate the logic for transitioning between these colors and the actions to take when entering or exiting a state.

## 4. A vending machine

A vending machine can be in one of several states such as NoSelection, HasSelection, InsertedMoney, and Sold.

The behavior of the vending machine changes as it transitions from one state to another. For example, inserting money is only allowed when the machine is in the HasSelection state, and selecting a product is only allowed when the machine is in the NoSelection state.

The State pattern can encapsulate the logic for transitioning between these states and the actions to take when entering or exiting a state.

## 5. A game character

A game character can be in one of several states such as Idle, Walking, Running, and Jumping.

The behavior of the character changes as it transitions from one state to another. For example, the character can only jump when it is in the Running state, and it can only walk when it is in the Idle state.

The State pattern can encapsulate the logic for transitioning between these states and the actions to take when entering or exiting a state.

## 6. A user interface

A user interface can be in one of several states such as Edit, View, and Delete.

The behavior of the interface changes as it transitions from one state to another. For example, the interface can only be edited when it is in the Edit state, and it can only be deleted when it is in the View state.

The State pattern can encapsulate the logic for transitioning between these states and the actions to take when entering or exiting a state.

## 7. A door

A door can be in one of several states such as Open, Closed, and Locked.

The behavior of the door changes as it transitions from one state to another. For example, the door can only be opened when it is in the Closed state, and it can only be locked when it is in the Closed state.

The State pattern can encapsulate the logic for transitioning between these states and the actions to take when entering or exiting a state.

## 8. A light switch

A light switch can be in one of several states such as On and Off.

The behavior of the light switch changes as it transitions from one state to another. For example, the light can only be turned on when it is in the Off state, and it can only be turned off when it is in the On state.

The State pattern can encapsulate the logic for transitioning between these states and the actions to take when entering or exiting a state.

## 9. A computer

A computer can be in one of several states such as On, Off, and Standby.

The behavior of the computer changes as it transitions from one state to another. For example, the computer can only be turned on when it is in the Off state, and it can only be put into standby mode when it is in the On state.

The State pattern can encapsulate the logic for transitioning between these states and the actions to take when entering or exiting a state.

## 10. A traffic control system

A traffic control system can be in one of several states such as Manual, Automatic, and Fault.

The behavior of the traffic control system changes as it transitions from one state to another. For example, the system can only be switched to automatic mode when it is in the Manual state, and it can only be switched to manual mode when it is in the Automatic state.

The State pattern can encapsulate the logic for transitioning between these states and the actions to take when entering or exiting a state.

## 11. A mobile phone

A mobile phone can be in one of several states such as Ringing, Talking, and Silent.

The behavior of the phone changes as it transitions from one state to another. For example, the phone can only ring when it is in the Silent state, and it can only be put into silent mode when it is in the Ringing state.

The State pattern can encapsulate the logic for transitioning between these states and the actions to take when entering or exiting a state.

## 12. A thermostat

A thermostat can be in one of several states such as Heating, Cooling, and Off.

The behavior of the thermostat changes as it transitions from one state to another. For example, the thermostat can only heat when it is in the Cooling state, and it can only cool when it is in the Heating state.

The State pattern can encapsulate the logic for transitioning between these states and the actions to take when entering or exiting a state.


