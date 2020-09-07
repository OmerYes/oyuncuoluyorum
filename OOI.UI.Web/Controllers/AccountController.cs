using OOI.Business.Manager.Repository;
using OOI.Data.Entities;
using OOI.Sms.DTO;
using OOI.Sms.Manager;
using OOI.UI.Web.Areas.Admin.Models.VM;
using OOI.UI.Web.Models;
using OOI.UI.Web.Models.Attributes;
using OOI.UI.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OOI.UI.Web.Controllers
{
    public class AccountController : BaseController
    {
        [Route("oyuncu-olmak-istiyorum/Kayıt")]
        public ActionResult Register()
        {
            return View(new WebUserRegisterVM());
        }

        [Route("oyuncu-olmak-istiyorum/Kayıt")]
        [HttpPost]
        public ActionResult Register(WebUserRegisterVM webUserRegisterVM)
        {
            if (ModelState.IsValid)
            {
                SMSDTO sms = new SMSDTO();
                Random rnd = new Random();
                string code = rnd.Next(10000, 99999).ToString();
                sms.Content = "Oyuncu Olmak İstiyorum sayfasına giriş için aktivasyon kodunuz: " + code + " Lütfen kodunuzu kimseyle paylaşmayınız";

                if (webUserRegisterVM.RegistrationType == "Firma")
                {

                    bool companyemailcontrol = unit.CompanyRepo.Any(q => q.Email.ToLower() == webUserRegisterVM.Email.ToLower());
                    if (companyemailcontrol)
                    {
                        ViewBag.IslemDurum = EnumIslemDurum.ValidationHata;
                        ModelState.AddModelError("EMail", "Mevcut emaille bir firma mevcut. Lütfen yeni bir emaille kayıt yapınız");
                        return View(webUserRegisterVM);
                    }

                    Company company = new Company();

                    company.Phone = webUserRegisterVM.Phone;
                    sms.PhoneNumber = company.Phone.Insert(0, "+90");
                    //SmsManager.SendSMS(sms);
                    webUserRegisterVM.ConfirmCode = sms.Content;
                    company.Email = webUserRegisterVM.Email;
                    company.Password = webUserRegisterVM.Password;
                    company.ConfirmCode = code;
                    company.Active = false;
                    company.RejCount = 0;
                    company.Credits = 0;
                    unit.CompanyRepo.Add(company);

                    return RedirectToAction("CompanyConfirm", "Account", new { id = company.ID });
                }
                if (webUserRegisterVM.RegistrationType == "Oyuncu")
                {
                    bool webusermailcontrol = unit.WebUserRepo.Any(q => q.Email.ToLower() == webUserRegisterVM.Email.ToLower());
                    if (webusermailcontrol)
                    {
                        ViewBag.IslemDurum = EnumIslemDurum.ValidationHata;
                        ModelState.AddModelError("EMail", "Mevcut emaille bir firma mevcut. Lütfen yeni bir emaille kayıt yapınız");
                        return View(webUserRegisterVM);
                    }

                    WebUser webUser = new WebUser();
                    webUser.Phone = webUserRegisterVM.Phone;
                    sms.PhoneNumber = webUser.Phone.Insert(0, "+90");
                    //SmsManager.SendSMS(sms);
                    webUserRegisterVM.ConfirmCode = sms.Content;
                    webUser.Email = webUserRegisterVM.Email;
                    webUser.Password = webUserRegisterVM.Password;
                    webUser.ConfirmCode = code;
                    webUser.Active = false;
                    webUser.RejCount = 0;
                    webUser.Credits = 0;
                    unit.WebUserRepo.Add(webUser);

                    return RedirectToAction("Confirm", "Account", new { id = webUser.ID });
                }
                return View(webUserRegisterVM);
            }
            else
            {
                ViewBag.IslemDurum = EnumIslemDurum.ValidationHata;
                return View(webUserRegisterVM);
            }
            
        }

        public ActionResult Confirm(int id)
        {
            ConfirmVM confirmVM = new ConfirmVM();
            confirmVM.ID = id;
            return View(confirmVM);
        }

        [HttpPost]
        public ActionResult Confirm(ConfirmVM confirmVM)
        {

            WebUser webUser = unit.WebUserRepo.FirstOrDefault(x => x.ID == confirmVM.ID);
            {
                if (webUser.RejCount != 3 && webUser != null)
                {
                    if (webUser.ConfirmCode == confirmVM.ConfirmCode)
                    {
                        webUser.Active = true;
                        unit.WebUserRepo.SaveChanges();

                        return RedirectToAction("WebUserGet", "WebUser", new { id = webUser.ID });
                    }
                    webUser.RejCount += 1;
                    unit.WebUserRepo.Update(webUser);
                    return RedirectToAction("Confirm", "Account");
                }
                return HttpNotFound();
            }
        }


        public ActionResult CompanyConfirm(int id)
        {
            ConfirmVM confirmVM = new ConfirmVM();
            confirmVM.ID = id;
            return View(confirmVM);
        }

        [HttpPost]
        public ActionResult CompanyConfirm(ConfirmVM confirmVM)
        {

            Company company = unit.CompanyRepo.FirstOrDefault(x => x.ID == confirmVM.ID);
            {
                if (company.RejCount != 3 && company != null)
                {
                    if (company.ConfirmCode == confirmVM.ConfirmCode)
                    {
                        company.Active = true;
                        unit.WebUserRepo.SaveChanges();

                        return RedirectToAction("Index", "Home");
                    }
                    company.RejCount += 1;
                    unit.CompanyRepo.Update(company);
                    return RedirectToAction("CompanyConfirm", "Account");
                }
                return HttpNotFound();
            }
        }
        [Route("oyuncu-olmak-istiyorum/Giris")]
        public ActionResult Login()
        {
            return View();
        }

        [Route("oyuncu-olmak-istiyorum/Giris")]
        [HttpPost]
        public ActionResult Login(WebUserLoginVM model)
        {
            if (ModelState.IsValid)
            {
                var webuserloginControl = unit.WebUserRepo.Any(q => q.Email.ToLower() == model.Email && q.Password == model.Password);
                var companyloginControl = unit.CompanyRepo.Any(q => q.Email.ToLower() == model.Email && q.Password == model.Password);
                if (webuserloginControl || companyloginControl)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    if (webuserloginControl)
                    {
                        return RedirectToAction("WebUserGet", "WebUser");
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.IslemDurum = EnumIslemDurum.LoginHata;
                    return View();
                }
            }
            else
            {
                ViewBag.IslemDurum = EnumIslemDurum.ValidationHata;
                return View();
            }



        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}