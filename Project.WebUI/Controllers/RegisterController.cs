using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.COMMON.Tools;
using Project.Entities.Models;
using Project.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        AppUserRepository _apRep;
        ProfileRepository _pRep;
        public RegisterController()
        {
            _apRep = new AppUserRepository();
            _pRep = new ProfileRepository();
        }

        public ActionResult RegisterNow()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterNow(AppUserVM apvm)
        {
            AppUser appUser = apvm.AppUser;
            UserProfile profile = apvm.Profile;
            appUser.Password = DantexCrypt.Crypt(appUser.Password);

            if (_apRep.Any(x=>x.UserName==appUser.UserName))
            {
                ViewBag.ZatenVar = "Kullanıcı ismi daha önce alınmıs";
                return View();
            }
            else if (_apRep.Any(x=>x.Email==appUser.Email))
            {
                ViewBag.ZatenVar = "email  önce alınmıs";
                return View();
            }

            string gonderilecekMail = "tebrikler...heesap olusuturldu.Aktif etmek için https://localhost:44393/Register/Activation/"+appUser.ActivationCode+" linkine tklayabilirsiniz";

            MailSender.Send(appUser.Email, body: gonderilecekMail, subject: "kullanıcı aktivasyon maili");

            
            _apRep.Add(appUser); //önce bu eklenmeli. cünkü appuser'ın id si ilk olusmalıdır.1-1 ilişki kurmustuk zorunlu olan alan appuser idi. opsiyonel olan alan profile idi. dolayısıyla ilk basta appuser'ın id'si olusmalıdır. 

            if (!string.IsNullOrEmpty(profile.FirstName)|| !string.IsNullOrEmpty(profile.LastName)|| !string.IsNullOrEmpty(profile.Address))
            {
                profile.ID = appUser.ID;
                _pRep.Add(profile);
            }
            return View("RegisterOk");

        }

        public ActionResult Activation(Guid id)
        {
            AppUser aktifEdilecek = _apRep.FirstOrDefault(x => x.ActivationCode == id);
            if (aktifEdilecek!=null)
            {
                aktifEdilecek.Active = true;
                _apRep.Update(aktifEdilecek);
                TempData["HesapAktifmi"] = "hesabını aktif hale getirildi";
                return RedirectToAction("Login", "Home");
            }
            TempData["HesapAktifmi"] = "aktif edilecek hesap bulunamadı";
            return RedirectToAction("Login", "Home");
        }

        public ActionResult RegisterOk()
        {
            return View();
        }
    }
}