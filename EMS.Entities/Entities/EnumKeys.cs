using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EMS.Entities
{
   
    public enum EnumStatus
    {
        Success,
        Failed
    }

    public enum AccountStatus
    {
        Pending = 0,
        Deny = 1,
        Grant = 2
    }

    public enum NameTitle
    {
        [Description("Mr.")]
        Mr = 1,
        [Description("Miss.")]
        Miss = 2,
        [Description("Mrs.")]
        Mrs = 3,
        [Description("Dr.")]
        Dr = 4,
        [Description("Prof.")]
        Prof = 5
    }

    public enum Gender
    {
        [Description("Male")]
        Male = 1,

        [Description("Female")]
        Female = 2,

        [Description("Other")]
        Other = 3
    }

    public enum ContentCode
    {
        [Description("Contact Us")]
        ContactUs = 1,

        [Description("Privacy Policy")]
        PrivacyPolicy = 2,

        [Description("About Us")]
        AboutUs = 3,

        [Description("Terms & Conditions")]
        TermsConditions = 4,
    }

    public enum MaritalStatus
    {
        [Description("Single")]
        Single = 1,

        [Description("Married")]
        Married = 2,

        [Description("Widowed")]
        Widowed = 3,

        [Description("Divorced")]
        Divorced = 4,

        [Description("Separated")]
        Separated = 5,
    }
}
