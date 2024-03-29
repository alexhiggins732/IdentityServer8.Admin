/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using IdentityServer8.Admin.UI.Helpers.Identity;
using System.Collections;
using System.Collections.Generic;

namespace IdentityServer8.Admin.UnitTests.Helpers
{
    class IdentityErrorDescriberFallbackTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            #region Parameterless methods

            yield return new object[]
            {
                nameof(IdentityErrorMessages.ConcurrencyFailure),
                nameof(IdentityErrorMessages.ConcurrencyFailure),
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.DefaultError),
                nameof(IdentityErrorMessages.DefaultError),
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.PasswordRequiresNonAlphanumeric),
                nameof(IdentityErrorMessages.PasswordRequiresNonAlphanumeric),
                };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.LoginAlreadyAssociated),
                nameof(IdentityErrorMessages.LoginAlreadyAssociated),
            };


            yield return new object[]
            {
                nameof(IdentityErrorMessages.InvalidToken),
                nameof(IdentityErrorMessages.InvalidToken),
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.PasswordMismatch),
                nameof(IdentityErrorMessages.PasswordMismatch),
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.PasswordRequiresDigit),
                nameof(IdentityErrorMessages.PasswordRequiresDigit),
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.PasswordRequiresLower),
                nameof(IdentityErrorMessages.PasswordRequiresLower),
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.RecoveryCodeRedemptionFailed),
                nameof(IdentityErrorMessages.RecoveryCodeRedemptionFailed),
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.UserAlreadyHasPassword),
                nameof(IdentityErrorMessages.UserAlreadyHasPassword),
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.UserLockoutNotEnabled),
                nameof(IdentityErrorMessages.UserLockoutNotEnabled),
            };


            #endregion

            #region Methods with parameters

            yield return new object[]
            {
                nameof(IdentityErrorMessages.InvalidEmail),
                nameof(IdentityErrorMessages.InvalidEmail),
                "TestUsername"
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.DuplicateUserName),
                nameof(IdentityErrorMessages.DuplicateUserName),
                "TestDuplicatedUsername"
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.DuplicateRoleName),
                nameof(IdentityErrorMessages.DuplicateRoleName),
                "TestRoleName"
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.InvalidRoleName),
                nameof(IdentityErrorMessages.InvalidRoleName),
                "InvalidRoleNameTest"
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.PasswordTooShort),
                nameof(IdentityErrorMessages.PasswordTooShort),
                4
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.PasswordRequiresUpper),
                nameof(IdentityErrorMessages.PasswordRequiresUpper)
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.UserAlreadyInRole),
                nameof(IdentityErrorMessages.UserAlreadyInRole),
                "TestRole"
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.UserNotInRole),
                nameof(IdentityErrorMessages.UserNotInRole),
                "TestRole"
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.InvalidUserName),
                nameof(IdentityErrorMessages.InvalidUserName),
                "TestUsername"
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.PasswordRequiresUniqueChars),
                nameof(IdentityErrorMessages.PasswordRequiresUniqueChars),
                5
            };

            yield return new object[]
            {
                nameof(IdentityErrorMessages.DuplicateEmail),
                nameof(IdentityErrorMessages.DuplicateEmail),
                "testduplicateemail@email.com"
            };

            #endregion
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
