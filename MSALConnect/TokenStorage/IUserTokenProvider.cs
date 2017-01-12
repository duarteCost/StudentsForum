﻿/* 
*  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. 
*  See LICENSE in the source repository root for complete license information. 
*/

using System.Threading.Tasks;

namespace MSALConnect.TokenStorage
{
    public interface IUserTokenProvider
    {
        Task<string> GetUserAccessTokenAsync();
    }
}