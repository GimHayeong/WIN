using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class Util
    {
        private bool m_ValidDomain = false;

        public bool IsValidEmail(string email)
        {
            m_ValidDomain = false;
            if (String.IsNullOrEmpty(email)) return false;

            try
            {
                email = Regex.Replace(email
                                    , @"(@)(.+)$"
                                    , this.DomainMapper
                                    , RegexOptions.None
                                    , TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (!m_ValidDomain) return false;

            try
            {
                return Regex.IsMatch(email
                    , @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"
                    , RegexOptions.IgnoreCase
                    , TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            IdnMapping idn = new IdnMapping();
            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
                m_ValidDomain = true;
            }
            catch (ArgumentException)
            {
                m_ValidDomain = false;
            }

            return match.Groups[1].Value + domainName;
        }
    }
}
