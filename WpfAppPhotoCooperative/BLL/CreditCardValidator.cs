using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppPhotoCooperative.BLL
{
    public enum CardBrand
    {
        NotSelected
        , MasterCard
        , BankCard
        , Visa
        , AmericanExpress
        , Discover
        , DinersClub
        , JCB
    }

    public class CreditCardValidator
    {
        /// <summary>
        /// 카드번호 유효성 검증
        /// </summary>
        /// <remarks>
        /// Luhn 알고리즘 검증 : 신용카드번호, IMEI번호, 주민번호 유효성 체크
        /// 1. 홀수번째 값은 그대로 더하고, 
        ///    짝수번째 자릿값은 2배한 값(10이상이면 각 자릿값: 5 ==> 5 * 2 = 10 = 1 + 0 ==> 1)을 더한다.
        /// 2. 1의 합이 10의 배수이면 유효한 값이다.
        /// </remarks>
        /// <param name="cardBrand"></param>
        /// <param name="cardNumber"></param>
        /// <returns></returns>
        public static bool Validate(CardBrand cardBrand, string cardNumber)
        {
            byte[] number = new byte[16];

            int length = 0;

            // 유효한 숫자형 카드번호 입력여부 검증
            for(int i=0; i<cardNumber.Length; i++)
            {
                if(char.IsDigit(cardNumber, i))
                {
                    if (length == 16) return false;

                    number[length++] = byte.Parse(cardNumber[i].ToString());
                }
            }

            // 카드번호 검증
            switch (cardBrand)
            {
                case CardBrand.BankCard:
                    if (length != 16) return false;
                    if (number[0] != 5 || number[1] != 6 || number[2] > 1) return false;
                    break;

                case CardBrand.MasterCard:
                    if (length != 16) return false;
                    if (number[0] != 5 || number[1] == 0 || number[1] > 5) return false;
                    break;

                case CardBrand.Visa:
                    if (length != 16 && length != 13) return false;
                    if (number[0] != 4) return false;
                    break;

                case CardBrand.AmericanExpress:
                    if (length != 15) return false;
                    if (number[0] != 3 || (number[1] != 4 && number[1] != 7)) return false;
                    break;

                case CardBrand.Discover:
                    if (length != 16) return false;
                    if (number[0] != 6 || number[1] != 0 || number[2] != 1 || number[3] != 1) return false;
                    break;

                case CardBrand.DinersClub:
                    if (length != 14) return false;
                    if (number[0] != 3 || (number[1] != 0 && number[1] != 6 && number[1] != 8) || (number[1] == 0 && number[2] > 5)) return false;
                    break;
            }

            // Luhn 알고리즘 검증
            int sum = 0;
            for(int i=length -1; i>=0; i--)
            {
                if(i % 2 == length % 2)
                {
                    int n = number[i] * 2;
                    sum += (n / 10) + (n % 10);
                }
                else
                {
                    sum += number[i];
                }
            }

            return (sum % 10 == 0);
        }
    }
}
