using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace prmToolkit.NotificationPattern.Tests
{
    [TestClass]
    public class NotificationPatternTests
    {
        private readonly Customer _customer = new Customer();

        [TestMethod]
        public void IsRequired()
        {
            new ValidationContract<Customer>(_customer).IsRequired(x => x.Name);
            Assert.AreEqual(false, _customer.IsValid());
        }

        [TestMethod]
        public void HasMinLength()
        {
            _customer.Name = "A";
            new ValidationContract<Customer>(_customer).HasMinLenght(x => x.Name, 10);
            Assert.AreEqual(false, _customer.IsValid());
        }

        [TestMethod]
        public void HasMaxLength()
        {
            _customer.Name = "André Baltieri";
            new ValidationContract<Customer>(_customer).HasMaxLenght(x => x.Name, 1);
            Assert.AreEqual(false, _customer.IsValid());
        }

        [TestMethod]
        public void IsRequiredWithSize()
        {
            Customer customerNameEmpty = new Customer();
            Customer customerNameMinInvalid = new Customer();
            customerNameMinInvalid.Name = "a";
            Customer customerNameMaxInvalid = new Customer();
            customerNameMaxInvalid.Name = "Nome com mais de 10 caracteres";

            new ValidationContract<Customer>(customerNameEmpty).IsRequiredWithSize(x => x.Name, 3, 10);
            new ValidationContract<Customer>(customerNameMinInvalid).IsRequiredWithSize(x => x.Name, 3, 10);
            new ValidationContract<Customer>(customerNameMaxInvalid).IsRequiredWithSize(x => x.Name, 3, 10);

            Assert.AreEqual(1, customerNameEmpty.Notifications.Count);
            Assert.AreEqual(1, customerNameMinInvalid.Notifications.Count);
            Assert.AreEqual(1, customerNameMaxInvalid.Notifications.Count);
        }


        [TestMethod]
        public void IsFixedLenght()
        {
            _customer.Name = "André Baltieri";
            new ValidationContract<Customer>(_customer).IsFixedLenght(x => x.Name, 5);
            Assert.AreEqual(false, _customer.IsValid());
        }

        [TestMethod]
        public void IsEmail()
        {
            _customer.Name = "This is not an e-mail";
            new ValidationContract<Customer>(_customer).IsEmail(x => x.Name);
            Assert.AreEqual(false, _customer.IsValid());
        }

        [TestMethod]
        public void IsUrl()
        {
            _customer.Name = "This is not an URL";
            new ValidationContract<Customer>(_customer).IsUrl(x => x.Name);
            Assert.AreEqual(false, _customer.IsValid());
        }
    }

    public class Customer : Notifiable
    {
        public string Name { get; set; }
    }
}