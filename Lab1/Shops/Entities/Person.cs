namespace Shops.Entities
{
    public class Person
    {
        public Person(string name, float money)
        {
            Name = name;
            Money = new Money(money);
        }

        public string Name { get; }
        public Money Money { get; }

        public void Buy(Bill bill)
        {
            Money.Withdraw(bill);
        }
    }
}
