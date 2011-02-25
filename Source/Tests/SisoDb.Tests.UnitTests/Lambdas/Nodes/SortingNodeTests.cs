using NUnit.Framework;
using SisoDb.Lambdas.Nodes;

namespace SisoDb.Tests.UnitTests.Lambdas.Nodes
{
    [TestFixture]
    public class SortingNodeTests
    {
        [Test]
        public void CTor_WhenMemberPathIsId_MemberNameIsNotTranslated()
        {
            var node = new SortingNode("Id");

            Assert.AreEqual("Id", node.MemberPath);
        }

        [Test]
        public void CTor_WhenMemberPathStartsWithId_MemberNameIsNotTranslated()
        {
            var node = new SortingNode("IdTmp");

            Assert.AreEqual("IdTmp", node.MemberPath);
        }

        [Test]
        public void CTor_WhenMemberPathEndsWithId_MemberNameIsNotTranslated()
        {
            var node = new SortingNode("TmpId");

            Assert.AreEqual("TmpId", node.MemberPath);
        }

        [Test]
        public void CTor_WhenNestedMemberPathIsId_MemberNameIsNotTranslated()
        {
            var node = new SortingNode("Nested.Id");

            Assert.AreEqual("Nested.Id", node.MemberPath);
        }

        [Test]
        public void CTor_WhenNestedMemberPathStartsWithId_MemberNameIsNotTranslated()
        {
            var node = new SortingNode("Nested.IdTmp");

            Assert.AreEqual("Nested.IdTmp", node.MemberPath);
        }

        [Test]
        public void CTor_WhenNestedMemberPathEndsWithId_MemberNameIsNotTranslated()
        {
            var node = new SortingNode("Nested.TmpId");

            Assert.AreEqual("Nested.TmpId", node.MemberPath);
        }
    }
}