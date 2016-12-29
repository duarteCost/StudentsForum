﻿/* 
*  Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. 
*  See LICENSE in the source repository root for complete license information. 
*/

using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MSALConnect.Startup))]

namespace MSALConnect
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
