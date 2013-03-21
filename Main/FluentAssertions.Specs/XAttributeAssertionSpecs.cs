﻿using System;
using System.Xml.Linq;

#if WINRT
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endif

namespace FluentAssertions.Specs
{
    [TestClass]
    public class XAttributeAssertionSpecs
    {
        #region Be / NotBe

        [TestMethod]
        public void When_asserting_an_xml_attribute_is_equal_to_the_same_xml_attribute_it_should_succeed()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var attribute = new XAttribute("name", "value");
            var sameXAttribute = new XAttribute("name", "value");

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () =>
                attribute.Should().Be(sameXAttribute);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void When_asserting_an_xml_attribute_is_equal_to_a_different_xml_attribute_it_should_fail_with_descriptive_message()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var attribute = new XAttribute("name", "value");
            var otherXAttribute = new XAttribute("name2", "value");

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () =>
                attribute.Should().Be(otherXAttribute, "because we want to test the failure {0}", "message");

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            string expectedMessage = string.Format("Expected XML attribute to be {0}" +
                " because we want to test the failure message," +
                    " but found {1}", otherXAttribute, attribute);

            act.ShouldThrow<AssertFailedException>().WithMessage(expectedMessage);
        }

        [TestMethod]
        public void When_asserting_an_xml_attribute_is_not_equal_to_a_different_xml_attribute_it_should_succeed()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var attribute = new XAttribute("name", "value");
            var otherXAttribute = new XAttribute("name2", "value");

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () =>
                attribute.Should().NotBe(otherXAttribute);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void When_asserting_an_xml_attribute_is_not_equal_to_the_same_xml_attribute_it_should_throw()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var attribute = new XAttribute("name", "value");
            var sameXAttribute = attribute;

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () =>
                attribute.Should().NotBe(sameXAttribute);

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>();
        }

        [TestMethod]
        public void When_asserting_an_xml_attribute_is_not_equal_to_the_same_xml_attribute_it_should_throw_with_descriptive_message()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var attribute = new XAttribute("name", "value");
            var sameXAttribute = attribute;

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () =>
                attribute.Should().NotBe(sameXAttribute, "because we want to test the failure {0}", "message");

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            string expectedMessage = string.Format(@"Did not expect XML attribute to be {0}" +
                " because we want to test the failure message.", sameXAttribute);

            act.ShouldThrow<AssertFailedException>().WithMessage(expectedMessage);
        }

        #endregion

        #region BeNull / NotBeNull

        [TestMethod]
        public void When_asserting_a_null_xml_attribute_is_null_it_should_succeed()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            XAttribute attribute = null;

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () =>
                attribute.Should().BeNull();

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void When_asserting_a_non_null_xml_attribute_is_null_it_should_fail()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var attribute = new XAttribute("name", "value");

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () =>
                attribute.Should().BeNull();

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>();
        }

        [TestMethod]
        public void When_asserting_a_non_null_xml_attribute_is_null_it_should_fail_with_descriptive_message()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var attribute = new XAttribute("name", "value");

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () =>
                attribute.Should().BeNull("because we want to test the failure {0}", "message");

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            string expectedMessage = string.Format("Expected XML attribute to be <null>" +
                " because we want to test the failure message," +
                    " but found {0}.", attribute);

            act.ShouldThrow<AssertFailedException>().WithMessage(expectedMessage);
        }

        [TestMethod]
        public void When_asserting_a_non_null_xml_attribute_is_not_null_it_should_succeed()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var attribute = new XAttribute("name", "value");

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () =>
                attribute.Should().NotBeNull();

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void When_asserting_a_null_xml_attribute_is_not_null_it_should_fail()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            XAttribute attribute = null;

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () =>
                attribute.Should().NotBeNull();

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>();
        }

        [TestMethod]
        public void When_asserting_a_null_xml_attribute_is_not_null_it_should_fail_with_descriptive_message()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            XAttribute attribute = null;

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () =>
                attribute.Should().NotBeNull("because we want to test the failure {0}", "message");

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>()
                .WithMessage("Expected XML attribute not to be <null>" +
                    " because we want to test the failure message.");
        }

        #endregion

        #region HaveValue

        [TestMethod]
        public void When_asserting_attribute_has_a_specific_value_and_it_does_it_should_succeed()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var attribute = new XAttribute("age", "36");

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () =>
                attribute.Should().HaveValue("36");

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void When_asserting_attribute_has_a_specific_value_but_it_has_a_different_value_it_should_throw()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var attribute = new XAttribute("age", "36");

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () =>
                attribute.Should().HaveValue("16");

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>();
        }

        [TestMethod]
        public void When_asserting_attribute_has_a_specific_value_but_it_has_a_different_value_it_should_throw_with_descriptive_message()
        {
            //-------------------------------------------------------------------------------------------------------------------
            // Arrange
            //-------------------------------------------------------------------------------------------------------------------
            var attribute = new XAttribute("age", "36");

            //-------------------------------------------------------------------------------------------------------------------
            // Act
            //-------------------------------------------------------------------------------------------------------------------
            Action act = () =>
                attribute.Should().HaveValue("16", "because we want to test the failure {0}", "message");

            //-------------------------------------------------------------------------------------------------------------------
            // Assert
            //-------------------------------------------------------------------------------------------------------------------
            act.ShouldThrow<AssertFailedException>()
                .WithMessage("Expected XML attribute 'age' to have value \"16\"" +
                    " because we want to test the failure message" +
                        ", but found \"36\".");
        }

        #endregion
    }
}