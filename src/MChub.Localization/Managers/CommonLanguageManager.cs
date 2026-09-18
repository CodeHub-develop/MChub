using Irihi.Lingua;

namespace MChub.Localization;

[LinguaManager("./Localization/zh-CN/Common.json")]
public partial class CommonLanguageManager
{
    static CommonLanguageManager()
    {
        LocalizationService.Register(Instance);
    }
}
