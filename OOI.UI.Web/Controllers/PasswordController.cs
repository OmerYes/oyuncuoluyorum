using OOI.Data.Entities;
using OOI.Sms.DTO;
using OOI.Sms.Manager;
using OOI.UI.Web.Models;
using OOI.UI.Web.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OOI.UI.Web.Controllers
{

    public class PasswordController : BaseController
    {

        [Authorize]
        public ActionResult ChangePassword()
        {
            int id = GetWebUserID();
            ChangePasswordVM model = new ChangePasswordVM();
            model.ID = id;
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordVM model)
        {
            if (ModelState.IsValid)
            {
                WebUser webUser = unit.WebUserRepo.FirstOrDefault(x => x.ID == model.ID);
                if (model.Password == webUser.Password)
                {
                    webUser.Password = model.NewPassword;
                    unit.Save();
                    return View(model);
                }
                else
                {
                    ViewBag.IslemDurum = EnumIslemDurum.ValidationHata;
                    ModelState.AddModelError("eskiparola", "Eski parola yanlış");
                    return View(model);
                }

            }
            else
            {
                ViewBag.IslemDurum = EnumIslemDurum.ValidationHata;
                return View(model);
            }

        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(ForgetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                string content = "Oyuncu Olmak İstiyorum şifremi unuttum için aktivasyon kodunuz: ";
                WebUser webuser = unit.WebUserRepo.FirstOrDefault(q => q.Email == model.EMail && q.Phone == model.PhoneNumber);

                if (webuser != null)
                {
                    string returncode = SendSMS(webuser.Phone.Insert(0, "+90"), content);
                    webuser.PwdCode = returncode;
                    unit.Save();

                    return RedirectToAction("ConfirmPassword", new { id = webuser.ID });
                }

                Company company = unit.CompanyRepo.FirstOrDefault(q => q.Email == model.EMail && q.Phone == model.PhoneNumber);
                if (company != null)
                {
                    string returncode = SendSMS(company.Phone.Insert(0, "+90"), content);
                    company.PwdCode = returncode;
                    unit.Save();

                    return RedirectToAction("ConfirmPassword", new { id = company.ID });
                }
                ViewBag.IslemDurum = EnumIslemDurum.ValidationHata;
                ModelState.AddModelError("NotFoundUser", "Bu telefon ve email adresine sahip bir kullanıcı mevcut değil");
                return View();
            }
            else
            {
                ViewBag.IslemDurum = EnumIslemDurum.ValidationHata;
                return View();
            }

        }

        public ActionResult ConfirmPassword(int id)
        {
            ConfirmPasswordVM model = new ConfirmPasswordVM();

            WebUser webuser = unit.WebUserRepo.FirstOrDefault(q => q.ID == id);
            if (webuser != null)
            {
                model.ID = webuser.ID;
                return View(model);
            }
            Company company = unit.CompanyRepo.FirstOrDefault(q => q.ID == id);
            if (company != null)
            {
                model.ID = company.ID;
                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ConfirmPassword(ConfirmPasswordVM model)
        {
            string content = "Oyuncu Olmak İstiyorum yeni şifreniz: ";
            WebUser webuser = unit.WebUserRepo.FirstOrDefault(q => q.PwdCode == model.Code);
            if (webuser != null)
            {
                string code = SendSMS(webuser.Phone.Insert(0, "+90"), content);
                webuser.Password = code;
                unit.Save();
                ViewBag.IslemDurum = EnumIslemDurum.IslemBasarili;
                return View();
            }
            Company company = unit.CompanyRepo.FirstOrDefault(q => q.PwdCode == model.Code);
            if (company != null)
            {
                string code = SendSMS(company.Phone.Insert(0, "+90"),content );
                company.Password = code;
                unit.Save();
                ViewBag.IslemDurum = EnumIslemDurum.IslemBasarili;
                return View();
            }
            ViewBag.IslemDurum = EnumIslemDurum.ValidationHata;
            ModelState.AddModelError("codeerror", "Kod hatalı!");
            return View();
        }

        string SendSMS(string number,string content)
        {
            try
            {
                SMSDTO sms = new SMSDTO();
                Random rnd = new Random();
                string code = rnd.Next(10000, 99999).ToString();
                sms.PhoneNumber = number;
                sms.Content = content +   code + " Lütfen kodunuzu kimseyle paylaşmayınız";
                SmsManager.SendSMS(sms);
                return code;

            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
