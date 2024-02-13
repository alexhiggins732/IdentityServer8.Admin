/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

namespace IdentityServer8.Admin.UnitTests.Helpers
{
    public class IdentityErrorDescriberTests
    {
        [Theory]
        [ClassData(typeof(IdentityErrorDescriberTestData))]
        public void TranslationTests(string key, string methodName, string translated, params object[] args)
        {

            // Arrange
            var localizer = new Mock<IStringLocalizer<IdentityErrorMessages>>();

            string formatString = translated;
            if (args.Any())
            {
                formatString = $"{formatString} {{0}}";
            }

            // GetString extension method uses indexer underneath
            localizer.Setup(x => x[key, args])
                .Returns(new LocalizedString(key, string.Format(formatString, args)));

            var describer = new IdentityErrorMessages(localizer.Object);

            // Act
            var methodInfo = typeof(IdentityErrorMessages).GetMethod(methodName); // get method name dynamically
            var error = methodInfo.Invoke(describer, args) as IdentityError; // invoke method on our instance

            // Assert
            Assert.IsType<IdentityError>(error);

            Assert.Equal(key, error.Code);

            // ASP.NET Core Identity uses arguments passed to methods to format error strings
            // So it's safe to assume that Description string contains argument as string representation
            // WARNING: Possible flaky test if ASP.NET Core Identity team makes some breaking changes
            foreach (var argument in args)
            {
                Assert.Contains(argument.ToString(), error.Description);
            }
        }

        [Theory]
        [ClassData(typeof(IdentityErrorDescriberFallbackTestData))]
        public void AspNetIdentity_Base_Translation_Fallback_Test(string key, string methodName, params object[] args)
        {

            // Arrange
            var localizer = new Mock<IStringLocalizer<IdentityErrorMessages>>();

            // GetString extension method uses indexer underneath
            localizer.Setup(x => x[key, args])
                .Returns(new LocalizedString(key, string.Empty, resourceNotFound: true));

            var describer = new IdentityErrorMessages(localizer.Object);

            // Act
            var methodInfo = typeof(IdentityErrorMessages).GetMethod(methodName); // get method name dynamically
            var error = methodInfo.Invoke(describer, args) as IdentityError; // invoke method on our instance

            // Assert
            Assert.IsType<IdentityError>(error);

            Assert.Equal(key, error.Code);

            // ASP.NET Core Identity uses arguments passed to methods to format error strings
            // So it's safe to assume that Description string contains argument as string representation
            // WARNING: Possible flaky test if ASP.NET Core Identity team makes some breaking changes
            foreach (var argument in args)
            {
                Assert.Contains(argument.ToString(), error.Description);
            }
        }
    }
}
