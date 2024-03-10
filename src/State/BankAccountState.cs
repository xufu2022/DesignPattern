namespace State;

public abstract class BankAccountState
{
    public BankAccount BankAccount { get; protected set; } = null!;
    public decimal Balance { get; protected set; }

    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);

}

public class BankAccount
{
    public BankAccountState BankAccountState { get; set; }
    public decimal Balance => BankAccountState.Balance;

    public BankAccount()
    {
        BankAccountState = new RegularState(200, this);
    }

    /// <summary>
    /// Request a deposit
    /// </summary> 
    public void Deposit(decimal amount)
    {
        // let the current state handle the deposit
        BankAccountState.Deposit(amount);
    }

    /// <summary>
    /// Request a withdrawal
    /// </summary> 
    public void Withdraw(decimal amount)
    {
        // let the current state handle the withdrawel
        BankAccountState.Withdraw(amount);
    }
}