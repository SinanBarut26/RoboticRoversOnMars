using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Entities.Enums
{
    public enum ExceptionEnum
    {
        //Robot Errors
        [Display(Name = "Pusulamda olmayan bir yöne bakmamı istiyorsun")]
        WrongDirection = 1000,

        [Display(Name = "Rotamda çözümleyemediğim bazı karakterler var")]
        WrongRoute = 1000,

        //Plateau Errors
        [Display(Name = "Plato koordinatlarında bir yanlışlık bulunuyor")]
        PlateauHasNotAcceptableCoordinate = 2000,

        [Display(Name = "Göndermiş olduğun rota plato dışına çıkmaya zorluyor. Daha ileri gidemem")]
        OutOfPlateau = 2001,


        //Test File Errors
        [Display(Name = "Sonucumu karşılaştıracağım output dosyası yok")]
        OutputFileNotFound = 5000,

        [Display(Name = "Girdi ve çıktı değeleri uyumuyor bir yerde fazlalık var")]
        InputAndOutputNotEqual = 5001,


        //General Errors
        [Display(Name = "Üzgünüm. Hatayla karşılaştım. Kendimi kapatıyorum.")]
        ThrowException = 99999,
    }
}
