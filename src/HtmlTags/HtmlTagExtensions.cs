using System.Collections.Generic;

namespace HtmlTags
{
    public static class HtmlTagExtensions
    {
        public static TagList ToTagList(this IEnumerable<HtmlTag> tags) => new TagList(tags);

        public static HtmlTag EmailMode(this HtmlTag tag) => tag.Attr("type", "email");

        /// <summary>
        /// Sets the input as checked (checkbox, radio buttons)
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static T Checked<T>(this T tag) where T : HtmlTag
        {
            if (!tag.IsInputElement()) return tag;
            tag.Attr("checked", "checked");
            return tag;
        }

        public static FormTag DoPOST(this FormTag tag) => tag.Method("POST");

        public static FormTag DoGET(this FormTag tag) => tag.Method("GET");

        public static string IdFromName(string name) => name?.Replace('.', '_');

        /// <summary>
        /// Sets the id of the tag using the asp.net mvc default convention
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static T IdFromName<T>(this T tag) where T : HtmlTag
        {
            tag.Id(IdFromName(tag.Attr("name")));
            return tag;
        }

        public static LabelTag CreateLabel(this HtmlTag tag, string display) => new LabelTag(tag.Id(), display);
    }
}