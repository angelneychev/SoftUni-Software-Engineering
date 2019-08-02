using System;
using NUnit.Framework;
using Skeleton;

namespace Skleton.Tests
{
    [TestFixture] // - това казва на съответния клас, че ще има тестове
    public class BankAccountTest
    {
        //Този метод ще бъде изпълнява преди всеки тест
        private BankAccount bankAccount;
        [SetUp]
        public void CreateBankAccount()
        {
            bankAccount = new BankAccount(100m);
        }
        [TearDown]
        public void DestroyBankAccount()
        {
            bankAccount = null; // унищожават се обектите след всеки тест
        }

        [Test]
        public void TestNewBankAccount()
        {
            var bankAccount = new BankAccount(100m);

            // провери че обекта (bankAccount.Balance) е равен на 100
            // добре и накрая да си добавим говорящо съобщение, да се ориентираме по-лесно при проблем

            Assert.That(bankAccount.Balance, Is.EqualTo(100m),"Creating new Bank Account");
        }
        [Test]
        public void TestNewBankAccountWithNegativBalance()
        {
            // Това е вариант с Ламда и ще хвърли ексшепшън
        //    Assert.That(()=> new BankAccount(-100m),Throws.ArgumentException);

            // тук теста ще мине, само ако върне коректното съобщение.
            Assert.That(()=> new BankAccount(-100m),Throws.ArgumentException.With.Message.EqualTo("Balance can not be negative"));

        }
        [Test]
        public void TestDeposit()
        {
            bankAccount.Deposit(100m);

            Assert.That(bankAccount.Balance, Is.EqualTo(200m));
        }
        [Test]
        public void TestDepositWithNegativSum()
        {
            Assert.That(() => bankAccount.Deposit(-50m),Throws.ArgumentException);
        }
        [Test]
        public void TestWithdraw()
        {
            decimal balans = bankAccount.Withdraw(34m);

            //Варинат 1 - bool expression / true - false
            //Assert.That(balans == bankAccount.Balance);
            //Вариант 2
            Assert.That(bankAccount.Balance, Is.EqualTo(balans));
        }
        [Test]
        public void TestWhithdrawMoreThanBalace()
        {
            Assert.That(() => bankAccount.Withdraw(500m),
                Throws.ArgumentException.With.Message.EqualTo("Balance can not be negative"));
        }
    }
}
