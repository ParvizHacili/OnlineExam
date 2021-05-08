using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExamUI.Helpers
{
    public static class UIMessages
    {
        public const string DeleteSureMessage = "Silmək istədiyinizdən əminsinizmi?";

        public const string PhoneErrorMessage = "Telefon nömrəsi düzgün formatda daxil edilməyib. Düzgün format: +99450XXXXXXX (Dəstəklənən prefikslər: 50, 51, 55,60, 70, 77, 99)";

        public const string ValidationCommonMessage = "Validasiya xətası";

      //  public const string OperationSuccessMessage = "Əməliyyat uğurla tamamlandı";

        public static string GetRequiredMessage(string propName)
        {
            return $"{propName} mütləq daxil edilməlidir";
        }

        public static string GetLengthMessage(string propName, int length)
        {
            return $"{propName} {length} simvoldan uzun ola bilməz";
        }

        public static string GetNumberMessage(string propName, int value)
        {
            return $"{propName} {value} dəyərindən böyük ola bilməz";
        }
    }
}
