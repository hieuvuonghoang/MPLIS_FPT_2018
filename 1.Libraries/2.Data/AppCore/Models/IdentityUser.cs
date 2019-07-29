// Copyright (c) Timm Krause. All rights reserved. See LICENSE file in the project root for license information.
using System;
//using Microsoft.AspNet.Identity;

namespace AppCore.Models
{
    public class IdentityUser
    {
        public IdentityUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        public IdentityUser(string userName)
            : this()
        {
            UserName = userName;
        }

        public string Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }
    }
}
