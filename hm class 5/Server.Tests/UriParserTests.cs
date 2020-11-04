using Microsoft.VisualStudio.TestTools.UnitTesting;

using ServerCore.Requests;

using System.Collections.Generic;
using System.Text;

namespace Server.Tests
{
    [TestClass]
    public class UriParserTests
    {
        [TestMethod]
        public void Request_With_Uri_Should_Return_Correct_Uri()
        {
            // 1. Arrange
            var uri = @"/paths/4/paths/2/path?key=value&key2=value2&key3=value3";

            // 2. Act
            var uriParts = UriParser.Parse(uri);

            // 3. Assert
            string actualUri = uriParts.Uri;
            Assert.AreEqual(uri, actualUri);
        }

        [TestMethod]
        public void Request_Without_Query_Should_Return_Correct_Uri()
        {
            // 1. Arrange
            var uri = "/paths/4/paths/2/path";

            // 2. Act
            var uriParts = UriParser.Parse(uri);

            // 3. Assert
            string actualUri = uriParts.Uri;
            Assert.AreEqual(uri, actualUri);
        }

        [TestMethod]
        [DataRow("path/.#$$.../path")]
        [DataRow("path/path?key=")]
        [DataRow("Some custom invalid uri.")]
        [DataRow("path%20%20/path")]
        [DataRow("path?key=value&key")]
        public void Request_With_Invalid_Uri_Should_Throw_Argument_Exception(string invalidUri)
        {
            // 2. Act
            System.Action parseUri = () => UriParser.Parse(invalidUri);

            // 3. Assert            
            Assert.ThrowsException<System.ArgumentException>(parseUri, "uri");
        }

        [TestMethod]
        public void Request_With_Empty_Uri_Should_Return_Empty_Path_And_Empty_Query()
        {
            // 1. Arrange
            var uri = "/";

            // 2. Act
            var actual = UriParser.Parse(uri);

            // 3. Assert
            string actualUri = actual.Uri;
            Assert.AreEqual(uri, actualUri);
            Assert.AreEqual(0, actual.Paths.Length);
            Assert.AreEqual(0, actual.Query.Count);
        }
    }
}
