namespace ENarudzbenice2.Identity
{
    public static class LocalizedIdentityErrorMessages
    {
        public static string PasswordRequiresLower { get; set; }
        public static string PasswordRequiresUniqueChars { get; set; }
        public static string PasswordRequiresUpper { get; set; }
        public static string PasswordRequiresNonAlphanumeric { get; set; }
        public static string PasswordRequiresDigit { get; set; }
        public static string PasswordMismatch { get; set; }
        public static string LoginAlreadyAssociated { get; set; }
        public static string InvalidUserName { get; set; }
        public static string InvalidToken { get; set; }
        public static string InvalidRoleName { get; set; }
        public static string DuplicateRoleName { get; set; }
        public static string InvalidEmail { get; set; }
        public static string DuplicateUserName => "Korisničko ime '{0}' je već zauzeto.";
        public static string DuplicateEmail => "Postoji korisnik sa '{0}' email adresom";
        public static string PasswordTooShort => "Lozinka mora sadržavati barem '{0}' znakova.";
        public static string UserAlreadyHasPassword { get; set; }
        public static string UserAlreadyInRole { get; set; }
        public static string UserNotInRole { get; set; }
        public static string UserLockoutNotEnabled { get; set; }
        public static string RecoveryCodeRedemptionFailed { get; set; }
        public static string ConcurrencyFailure { get; set; }
        public static string DefaultIdentityError { get; set; }
    }
}
