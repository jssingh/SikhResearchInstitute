﻿using Tarantino.Core.Commons.Model;

namespace SikhResearchInstitute.Core.Domain.Model
{
    public class User : PersistentObject
    {
        public const string ADMIN_USERNAME = "admin";

        public virtual string Username { get; set; }
        public virtual string Name { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string PasswordSalt { get; set; }

        public virtual bool IsAdmin()
        {
            return Username == ADMIN_USERNAME;
        }
    }
}
