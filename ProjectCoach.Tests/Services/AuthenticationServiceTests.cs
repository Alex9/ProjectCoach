using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Raven.Client;
using Xemio.ProjectCoach.Core.Exceptions;
using NUnit;
using Xemio.ProjectCoach.Core.Services;
using Xemio.ProjectCoach.Entities.Users;
using Xemio.ProjectCoach.Infrastructure.Services;
using Xemio.ProjectCoach.Tests.Services.Base;

namespace Xemio.ProjectCoach.Tests.Services
{
    public class AuthenticationServiceTests
    {
        [TestFixture]
        public class TheAuthenticateMethod : RavenTest
        {
            [Test]
            public void ThrowsExceptionWhenUsernameIsNull()
            {
                //Arrange
                IDocumentSession session = this.DocumentStore.OpenSession();
                IAuthenticationService unitUnderTest = new AuthenticationService(session, null);

                //Act
                TestDelegate @delegate = () => unitUnderTest.Authenticate(null, "password");

                //Assert
                Assert.Throws<ArgumentNullException>(@delegate);
            }

            [Test]
            public void ThrowsExceptionWhenUsernameIsEmpty()
            {
                //Arrange
                IDocumentSession session = this.DocumentStore.OpenSession();
                IAuthenticationService unitUnderTest = new AuthenticationService(session, null);

                //Act
                TestDelegate @delegate = () => unitUnderTest.Authenticate("", "password");

                //Assert
                Assert.Throws<ArgumentException>(@delegate);
            }

            [Test]
            public void ThrowsExceptionWhenPasswordIsNull()
            {
                //Arrange
                IDocumentSession session = this.DocumentStore.OpenSession();
                IAuthenticationService unitUnderTest = new AuthenticationService(session, null);

                //Act
                TestDelegate @delegate = () => unitUnderTest.Authenticate("username", null);

                //Assert
                Assert.Throws<ArgumentNullException>(@delegate);
            }

            [Test]
            public void ThrowsExceptionWhenPasswordIsEmpty()
            {
                //Arrange
                IDocumentSession session = this.DocumentStore.OpenSession();
                IAuthenticationService unitUnderTest = new AuthenticationService(session, null);

                //Act
                TestDelegate @delegate = () => unitUnderTest.Authenticate("username", "");

                //Assert
                Assert.Throws<ArgumentException>(@delegate);
            }

            [Test]
            public void ThrowsExceptionWhenUsernameDoesNotExist()
            {
                //Arrange
                IDocumentSession session = this.DocumentStore.OpenSession();
                IAuthenticationService unitUnderTest = new AuthenticationService(session, null);

                //Act
                TestDelegate @delegate = () => unitUnderTest.Authenticate("leRandomUsername", "lePassword");

                //Assert
                Assert.Throws<UserNotFoundException>(@delegate);
            }

            [Test]
            public void ReturnsFalseWhenPasswordIsWrong()
            {
                
            }

            [Test]
            public void ReturnsTrueWhenPasswordIsCorrect()
            {
                
            }
        }
    }
}
