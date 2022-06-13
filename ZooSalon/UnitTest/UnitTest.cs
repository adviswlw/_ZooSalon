using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ZooSalon;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void PositiveMethod()
        {
            string testEmail = "artiomShpak@mail.ru";
            bool answer = ZooSalon.Manager.IsValidEmail(testEmail);
            Assert.AreEqual(true, answer);
        }
        [TestMethod]
        public void NegativeMethod()
        {
            string testEmail = "artiomShpakmail.ru";
            bool answer = ZooSalon.Manager.IsValidEmail(testEmail);
            Assert.AreEqual(false, answer);
        }
        [TestMethod]
        public void DeleteDataMethod()
        {
            bool result = false;
            try
            {
                Client clientToDelete = AdZooSalonEntities.GetContext().Clients.Where(p => p.Id == 102).First();
                AdZooSalonEntities.GetContext().Clients.Remove(clientToDelete);
                result = true;
            }
            catch
            {
                result = false;
            }
            Assert.AreEqual(true, result);
        }
    }
}
