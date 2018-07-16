using ListItemUI.ListItemPage.DomainLogic;
using NUnit.Framework;

namespace ListItemUITest
{
    [TestFixture]
    public class ItemTest
    {
        private IItem sut;

        [SetUp]
        public void setUp()
        {
            sut = new Item("",0,0,"",0);

        }

        [Test]
        public void isProgramSelected()
        {
            sut.select();
            bool exp = true;
            bool act = sut.isSelected();
            Assert.That(act, Is.EqualTo(exp));
        }

        [Test]
        public void isProgramSelectedByTwoClick()
        {
            sut.select();
            sut.select();
            bool exp = false;
            bool act = sut.isSelected();
            Assert.That(act, Is.EqualTo(exp));
        }
        public void isProgramNotSelectedByDefault()
        {
            bool exp = false;
            bool act = sut.isSelected();
            Assert.That(act, Is.EqualTo(exp));
        }

        [Test]
        public void shouldSelected()
        {
            //TODO: Testare la select
        }

        [TearDown]
        public void tearDown()
        {
            sut = null;
        }

    }

}
