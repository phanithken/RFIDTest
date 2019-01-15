
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTest
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void Withdraw_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double withdrawAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Ken Phanith", beginningBalance);

            // Act
            account.Withdraw(withdrawAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not withdrawed correctly");
        }

        [TestMethod]
        public void Deposit_WithValidAmount_UpdateBalance() {
            // Arrange
            double beginningBalance = 11.99;
            double depositAmount = 4.55;
            double expected = 16.54;
            BankAccount account = new BankAccount("Ken Phanith", beginningBalance);

            // Act
            account.Deposit(depositAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account is deposited correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "invalid amount")]
        public void Withdraw_WithInvalidAmount() {
            // Arrange
            double beginningBalance = 11.99;
            double withdrawAmount = -1.22;
            BankAccount account = new BankAccount("Ken Phanith", beginningBalance);

            // Act
            account.Withdraw(withdrawAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "invalid amount")]
        public void Deposit_WithInvalidAmount() {
            // Arrange
            double beginningBalance = 11.99;
            double withdrawAmount = 1.22;
            BankAccount account = new BankAccount("Ken Phanith", beginningBalance);

            // Act
            account.Deposit(withdrawAmount);
        }
    }
}
