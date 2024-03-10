namespace StateTests;
public class BankAccountStateTests
{
    [Fact]
    public void BankAccount_InitialState_IsRegularState()
    {
        var account = new BankAccount();
        Assert.IsType<RegularState>(account.BankAccountState);
    }

    [Fact]
    public void Deposit_EnoughForGoldState_ChangesStateToGold()
    {
        var account = new BankAccount();
        account.Deposit(1000);
        Assert.IsType<GoldState>(account.BankAccountState);
    }

    [Fact]
    public void Withdraw_FromGoldStateNotEnoughForRegular_KeepsGoldState()
    {
        var account = new BankAccount();
        account.Deposit(1500); // Ensure GoldState
        account.Withdraw(400); // Not enough to drop below GoldState threshold
        Assert.IsType<GoldState>(account.BankAccountState);
    }

    [Fact]
    public void Withdraw_EnoughToChangeToRegularState_ChangesState()
    {
        var account = new BankAccount();
        account.Deposit(1500); // Ensure GoldState
        account.Withdraw(600); // Drops balance to below GoldState threshold, but above Overdrawn
        Assert.IsType<GoldState>(account.BankAccountState);
    }

    [Fact]
    public void Withdraw_MoreThanBalance_ChangesStateToOverdrawn()
    {
        var account = new BankAccount();
        account.Deposit(200); // RegularState
        account.Withdraw(600); // More than balance
        Assert.IsType<OverdrawnState>(account.BankAccountState);
    }

    [Fact]
    public void Deposit_InOverdrawnStateNotEnoughToCoverDebt_KeepsOverdrawnState()
    {
        var account = new BankAccount();
        account.Deposit(100); // RegularState
        account.Withdraw(500); // Into OverdrawnState
        account.Deposit(100); // Still not enough to cover the debt
        Assert.IsType<OverdrawnState>(account.BankAccountState);
    }

    [Fact]
    public void Deposit_InOverdrawnStateEnoughToCoverDebt_ChangesStateToRegular()
    {
        var account = new BankAccount();
        account.Deposit(100); // RegularState
        account.Withdraw(300); // Into OverdrawnState
        account.Deposit(200); // Enough to cover the debt and return to RegularState
        Assert.IsType<RegularState>(account.BankAccountState);
    }
}
