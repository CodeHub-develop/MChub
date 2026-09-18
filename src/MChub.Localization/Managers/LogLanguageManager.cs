using Irihi.Lingua;

namespace MChub.Localization;

[LinguaManager("./Localization/zh-CN/Logs.json")]
public partial class LogLanguageManager
{
    static LogLanguageManager()
    {
        LocalizationService.Register(Instance);
    }
}
