using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Altalents.MVC.Extension
{
    public static class HtmlHelperExtension
    {
        public static HtmlString GetJsDictonnaryNotice(this IHtmlHelper helper, string dictonnaryName, List<NoticeMarqueDto> noticeMarqueDtos)
        {
            string data = "";
            foreach (NoticeMarqueDto noticeMarqueDto in noticeMarqueDtos)
            {
                data += $"{dictonnaryName}['{noticeMarqueDto.Id}'] = ";
                data += "{};";
            }
            return new HtmlString(data);
        }
    }
}
