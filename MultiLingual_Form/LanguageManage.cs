﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

namespace MultiLingual_Form
{
    public class LanguageManage
    {
        public static List<Languages> AvailableLanguages = new List<Languages>
        {
            new Languages { LanguageFullName = "English", LanguageCultureName = "en", Direction = "ltr" },
            new Languages { LanguageFullName = "Nepali", LanguageCultureName = "ne", Direction = "ltr"  },
            new Languages { LanguageFullName = "Japanese", LanguageCultureName = "ja", Direction = "rtl"  },
        };
        public static bool IsLanguageAvailable(string lang)
        {
            return AvailableLanguages.Any(a => a.LanguageCultureName.Equals(lang));
        }
        public static string GetDefaultLanguage()
        {
            return AvailableLanguages[0].LanguageCultureName;
        }
        public void SetLanguage(string lang)
        {
            try
            {
                if (!IsLanguageAvailable(lang))
                    lang = GetDefaultLanguage();
                var cultureInfo = new CultureInfo(lang);
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                HttpCookie langCookie = new HttpCookie("culture", lang);
                langCookie.Expires = DateTime.Now.AddYears(1);
                HttpContext.Current.Response.Cookies.Add(langCookie);
            }
            catch (Exception) { }
        }
    }
    public class Languages
    {
        public string LanguageFullName { get; set; }
        public string LanguageCultureName { get; set; }
        public string Direction { get; set; }
    }
}
