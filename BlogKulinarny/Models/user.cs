﻿using BlogKulinarny.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlogKulinarny.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Login")]
        public string? login { get; set; }

        [Display(Name = "Password")]
        public string? password { get; set; }

        [Display(Name = "Mail")]
        public string? mail { get; set; }

        [Display(Name = "ActivationStatus")]
        public bool isAccepted { get; set; }

        [Display(Name = "Role")]
        public Ranks rank { get; set; }

        // mailer
        public string? VerificationToken { get; set; }

        public DateTime? VerifiedAt { get; set; }

        public string? PasswordResetToken { get; set; }

        public DateTime? ResetTokenExpires { get; set; }

        //Relationships
    }
}
