using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChainOfResponsibility;


namespace ChainOfResponsibilityTests;

    public class DocumentValidationTests
    {
        [Fact]
        public void Document_WithTitle_ShouldPassTitleValidation()
        {
            // Arrange
            var document = new Document("Title", DateTimeOffset.UtcNow, true, true);
            var handler = new DocumentTitleHandler();

            // Act & Assert
            var exception = Record.Exception(() => handler.Handle(document));
            Assert.Null(exception);
        }

        [Fact]
        public void Document_WithoutTitle_ShouldFailTitleValidation()
        {
            // Arrange
            var document = new Document(string.Empty, DateTimeOffset.UtcNow, true, true);
            var handler = new DocumentTitleHandler();

            // Act & Assert
            Assert.Throws<ValidationException>(() => handler.Handle(document));
        }

        [Fact]
        public void Document_ModifiedWithin30Days_ShouldPassLastModifiedValidation()
        {
            // Arrange
            var document = new Document("Title", DateTimeOffset.UtcNow, true, true);
            var handler = new DocumentLastModifiedHandler();

            // Act & Assert
            var exception = Record.Exception(() => handler.Handle(document));
            Assert.Null(exception);
        }

        [Fact]
        public void Document_ModifiedMoreThan30DaysAgo_ShouldFailLastModifiedValidation()
        {
            // Arrange
            var document = new Document("Title", DateTimeOffset.UtcNow.AddDays(-31), true, true);
            var handler = new DocumentLastModifiedHandler();

            // Act & Assert
            Assert.Throws<ValidationException>(() => handler.Handle(document));
        }

        [Fact]
        public void Document_ApprovedByLitigation_ShouldPassLitigationValidation()
        {
            // Arrange
            var document = new Document("Title", DateTimeOffset.UtcNow, true, true);
            var handler = new DocumentApprovedByLitigationHandler();

            // Act & Assert
            var exception = Record.Exception(() => handler.Handle(document));
            Assert.Null(exception);
        }

        [Fact]
        public void Document_NotApprovedByLitigation_ShouldFailLitigationValidation()
        {
            // Arrange
            var document = new Document("Title", DateTimeOffset.UtcNow, false, true);
            var handler = new DocumentApprovedByLitigationHandler();

            // Act & Assert
            Assert.Throws<ValidationException>(() => handler.Handle(document));
        }

        [Fact]
        public void Document_ApprovedByManagement_ShouldPassManagementValidation()
        {
            // Arrange
            var document = new Document("Title", DateTimeOffset.UtcNow, true, true);
            var handler = new DocumentApprovedByManagementHandler();

            // Act & Assert
            var exception = Record.Exception(() => handler.Handle(document));
            Assert.Null(exception);
        }

        [Fact]
        public void Document_NotApprovedByManagement_ShouldFailManagementValidation()
        {
            // Arrange
            var document = new Document("Title", DateTimeOffset.UtcNow, true, false);
            var handler = new DocumentApprovedByManagementHandler();

            // Act & Assert
            Assert.Throws<ValidationException>(() => handler.Handle(document));
        }

        // Additional tests could be created to test the chaining functionality,
        // ensuring that a document passing through all the handlers
        // meets all the criteria or fails where expected.
    }

