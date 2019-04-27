using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Entities.Enums
{
    public enum ExceptionEnum
    {
        [Display(Name = "Pusulamda olmayan bir yöne bakmamı istiyorsun. Lütfen kontrol et")]
        WrongDirection = 1000,

        [Display(Name = "Rotamda çözümleyemediğim bazı karakterler var. Lütfen kontrol et")]
        WrongRoute = 1000,

        [Display(Name = "Üzgünüm ama görev alanımın dışına çıkamam. Rotam beni buna zorluyor. Lütfen kontrol et")]
        OutOfPlateau = 2000,


    }
}
