using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using ABDHFramework.Services;
using ABDHFramework.Models;
using ABDHFramework.Utility.Crypto;
using ABDHFramework.Common;
using ABDHFramework.Utility;
using ABDHFramework.Lib;

namespace ABDHFramework.Controllers
{

    [HandleError]
    public class AccountController : BaseController
    {
        // This constructor is used by the MVC framework to instantiate the controller using
        // the default forms authentication and membership providers.

        public AccountController()
            : this(null, null)
        {
        }

        // This constructor is not used by the MVC framework but is instead provided for ease
        // of unit testing this type. See the comments at the end of this file for more
        // information.
        public AccountController(IFormsAuthentication formsAuth, IMembershipService service)
        {
            FormsAuth = formsAuth ?? new FormsAuthenticationService();
            MembershipService = service ?? new AccountMembershipService();
        }

        public IFormsAuthentication FormsAuth
        {
            get;
            private set;
        }

        public IMembershipService MembershipService
        {
            get;
            private set;
        }

        ABDHFrameworkAccountController _accountController = new ABDHFrameworkAccountController();
        public ActionResult LogOn()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings",
            Justification = "Needs to take same parameter type as Controller.Redirect()")]
        public ActionResult LogOn(string userName, string password, bool rememberMe, string returnUrl)
        {

            if (!ValidateLogOn(userName, password))
            {
                return View();
            }

            FormsAuth.SignIn(userName, rememberMe);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOff()
        {

            FormsAuth.SignOut();
            _accountController.Logoff();
            return RedirectToAction("IndexForNews", "ABDHFramework");
        }

        private List<SelectListItem> LoadDataForDropDownList()
        {
            List<SelectListItem> lsEN = new List<SelectListItem>();
            List<SelectListItem> lsVN = new List<SelectListItem>();
            
            lsVN.Add((new SelectListItem { Text = "Ban giám đốc", Value = Department.Managers.ToString(), Selected = true }));
            lsVN.Add((new SelectListItem { Text = "Phòng kỹ thuật", Value = Department.Techonology.ToString(), Selected = false }));
            lsVN.Add((new SelectListItem { Text = "Phòng marketing", Value = Department.Marketing.ToString(), Selected = false }));
            lsVN.Add((new SelectListItem { Text = "Phòng kinh doanh", Value = Department.Sales.ToString(), Selected = false }));
            lsVN.Add((new SelectListItem { Text = "Phòng kế toán", Value = Department.Accounts.ToString(), Selected = false }));

            lsEN.Add((new SelectListItem { Text = "Managers Department", Value = Department.Managers.ToString(), Selected = true }));
            lsEN.Add((new SelectListItem { Text = "Technology Department", Value = Department.Techonology.ToString(), Selected = false }));
            lsEN.Add((new SelectListItem { Text = "Marketing Department", Value = Department.Marketing.ToString(), Selected = false }));
            lsEN.Add((new SelectListItem { Text = "Sales Department", Value = Department.Sales.ToString(), Selected = false }));
            lsEN.Add((new SelectListItem { Text = "Accounts Department", Value = Department.Accounts.ToString(), Selected = false }));

            if (Request.Cookies["Culture"] != null && Request.Cookies["Culture"].Value == "en-US")
                return lsEN;
            else
                return lsVN;

        }
        public ActionResult Register()
        {
            if (User.Identity.Name != "")
            {
                List<SelectListItem> lsEN = new List<SelectListItem>();
                List<SelectListItem> lsVN = new List<SelectListItem>();

                lsVN.Add((new SelectListItem { Text = "Ban giám đốc", Value = Department.Managers.ToString(), Selected = true }));
                lsVN.Add((new SelectListItem { Text = "Phòng kỹ thuật", Value = Department.Techonology.ToString(), Selected = false }));
                lsVN.Add((new SelectListItem { Text = "Phòng marketing", Value = Department.Marketing.ToString(), Selected = false }));
                lsVN.Add((new SelectListItem { Text = "Phòng kinh doanh", Value = Department.Sales.ToString(), Selected = false }));
                lsVN.Add((new SelectListItem { Text = "Phòng kế toán", Value = Department.Accounts.ToString(), Selected = false }));

                lsEN.Add((new SelectListItem { Text = "Managers Department", Value = Department.Managers.ToString(), Selected = true }));
                lsEN.Add((new SelectListItem { Text = "Technology Department", Value = Department.Techonology.ToString(), Selected = false }));
                lsEN.Add((new SelectListItem { Text = "Marketing Department", Value = Department.Marketing.ToString(), Selected = false }));
                lsEN.Add((new SelectListItem { Text = "Sales Department", Value = Department.Sales.ToString(), Selected = false }));
                lsEN.Add((new SelectListItem { Text = "Accounts Department", Value = Department.Accounts.ToString(), Selected = false }));
                ViewData["Department"] = LoadDataForDropDownList();
                ViewData["PasswordLength"] = MembershipService.MinPasswordLength;

                return View();
            }
            return RedirectToAction("Logon", "Account");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Register(string userName, string email, string password, string confirmPassword,byte department)
        {
            ViewData["Department"] = LoadDataForDropDownList();   
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;

            if (ValidateRegistration(userName, email, password, confirmPassword))
            {
                if (_accountController.CreateUser(userName, password, email,department))
                {
                    FormsAuth.SignIn(userName, false /* createPersistentCookie */);
                    return RedirectToAction("IndexForNews", "ABDHFramework");
                }
                else
                {
                    ModelState.AddModelError("_FORM", "Register unsuccessful");
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            if (User.Identity.Name != "")
            {
                ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
                return View();        
            }
            return RedirectToAction("Logon", "Account");
        }

        [Authorize]
        [AcceptVerbs(HttpVerbs.Post)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Exceptions result in password not being changed.")]
        public ActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {

            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;

            if (!ValidateChangePassword(currentPassword, newPassword, confirmPassword))
            {
                return View();
            }

            try
            {
                if (_accountController.ChangePassword(User.Identity.Name, currentPassword, newPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("_FORM", "The current password is incorrect or the new password is invalid.");
                    return View();
                }
            }
            catch
            {
                ModelState.AddModelError("_FORM", "The current password is incorrect or the new password is invalid.");
                return View();
            }
        }

        public ActionResult ChangePasswordSuccess()
        {

            return View();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity is WindowsIdentity)
            {
                throw new InvalidOperationException("Windows authentication is not supported.");
            }
        }

        #region Validation Methods

        private bool ValidateChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            if (String.IsNullOrEmpty(currentPassword))
            {
                ModelState.AddModelError("currentPassword", Resources.Global.ValidatePassword);
            }
            if (newPassword == null || newPassword.Length < MembershipService.MinPasswordLength)
            {
                ModelState.AddModelError("newPassword",Resources.Global.WarningPasswordLength);
            }

            if (!String.Equals(newPassword, confirmPassword, StringComparison.Ordinal))
            {
                ModelState.AddModelError("confirmPassword", Resources.Global.ValidatePasswordConfirmPassword);
            }

            return ModelState.IsValid;
        }

        private bool ValidateLogOn(string userName, string password)
        {
            if (String.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("username", Resources.Global.ValidateUserName);
            }
            if (String.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("password",Resources.Global.ValidatePassword);
            }

            if (!_accountController.ValidateUser(userName, password))
            {
                ModelState.AddModelError("_FORM", Resources.Global.WarningLogonUnssucessful);
            }

            return ModelState.IsValid;
        }

        private bool ValidateRegistration(string userName, string email, string password, string confirmPassword)
        {
            if (String.IsNullOrEmpty(userName))
            {
                ModelState.AddModelError("username", Resources.Global.ValidateUserName);
            }
            if (String.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("email",Resources.Global.ValidateEmail);
            }
            if (password == null || password.Length < MembershipService.MinPasswordLength)
            {
                ModelState.AddModelError("password",Resources.Global.WarningPasswordLength);
            }
            if (!String.Equals(password, confirmPassword, StringComparison.Ordinal))
            {
                ModelState.AddModelError("_FORM", Resources.Global.ValidatePasswordConfirmPassword);
            }
            if (_accountController.DuplicateUsername(userName))
            {
                ModelState.AddModelError("username", Resources.Global.ValidateDuplicateUserName);
            }
            if (_accountController.DuplicateEmail(email))
            {
                ModelState.AddModelError("email", Resources.Global.ValidateDuplicateEmail);
            }
            return ModelState.IsValid;
        }
        #endregion


        public ActionResult SetCulture(string id)
        {

            HttpCookie userCookie = Request.Cookies["Culture"];

            userCookie.Value = id;
            userCookie.Expires = DateTime.Now.AddYears(100);
            Response.SetCookie(userCookie);

            return Redirect(Request.UrlReferrer.ToString());
        }
    }

    // The FormsAuthentication type is sealed and contains static members, so it is difficult to
    // unit test code that calls its members. The interface and helper class below demonstrate
    // how to create an abstract wrapper around such a type in order to make the AccountController
    // code unit testable.

    public interface IFormsAuthentication
    {
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationService : IFormsAuthentication
    {
        public void SignIn(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }

    public class ABDHFrameworkAccountController
    {
        const int MIN_PASSWORD_LENGTH = 6;
        const string INPUT_TEXT = "HiepNguyen";

        ABDHFrameworkService _ABDHFrameworkService = ABDHFrameworkService.Instance;
        public static ABDHFrameworkAccountController _accountController = new ABDHFrameworkAccountController();

        public ABDHFrameworkAccountController()
        { 
        }

        public bool DuplicateUsername(string username)
        {
            return _ABDHFrameworkService.DuplicateUsername(username);
        }

        public bool DuplicateEmail(string email)
        {
            return _ABDHFrameworkService.DuplicateEmail(email);
        }
        
        public bool ValidateUser(string userName, string password)
        {
            return _ABDHFrameworkService.Logon(userName, KeyGeneration.EncryptString(INPUT_TEXT, password));
        }
        public void Logoff()
        {
            _ABDHFrameworkService.Logoff();
        }
        public bool CreateUser(string userName, string password, string email,byte department)
        {
            tblUser user = new tblUser();
            user.ID = Guid.NewGuid();
            user.UserName = userName;
            user.Email = email;
            user.Department = department;
            //user.Email = email;
            user.Password = KeyGeneration.EncryptString(INPUT_TEXT, password);          
            return _ABDHFrameworkService.InsertUser(user);
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            string oldPassEncrypt = KeyGeneration.EncryptString(INPUT_TEXT,oldPassword);
            string newPassEncrypt = KeyGeneration.EncryptString(INPUT_TEXT, newPassword);
            return _ABDHFrameworkService.ChangePassword(userName, oldPassEncrypt, newPassEncrypt);
        }

    }
    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }

    public class AccountMembershipService : IMembershipService
    {
        private MembershipProvider _provider;
        ABDHFrameworkService _ABDHFrameworkService = ABDHFrameworkService.Instance;
        public AccountMembershipService()
            : this(null)
        {
        }

        public AccountMembershipService(MembershipProvider provider)
        {
            _provider = provider ?? Membership.Provider;
        }

        public int MinPasswordLength
        {
            get
            {
                return _provider.MinRequiredPasswordLength;
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            if (_ABDHFrameworkService.GetUser(userName, password) == null)
                return false;
            else
                return true;
        }

        public MembershipCreateStatus CreateUser(string userName, string password, string email)
        {
            MembershipCreateStatus status;
            _provider.CreateUser(userName, password, email, null, null, true, null, out status);
            return status;
        }

        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            MembershipUser currentUser = _provider.GetUser(userName, true /* userIsOnline */);
            return currentUser.ChangePassword(oldPassword, newPassword);
        }
    }
}
