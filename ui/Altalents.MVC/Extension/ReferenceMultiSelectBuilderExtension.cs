using System.Collections;

using Altalents.Entities.Enum;

using Kendo.Mvc.UI.Fluent;

namespace Altalents.MVC.Extension
{
    public static class ReferenceMultiSelectBuilderExtension
    {
        public static MultiSelectBuilder CreateDefautMultiSelectReference(this MultiSelectBuilder multiSelectBuilder, IEnumerable value, string name, EnumTypeReference type, string onDataBoundAction, string? onChangeAction = null, bool withAutoBind = true)
        {
            MultiSelectBuilder multiSelectBuilder1 = BaseMultiSelect(multiSelectBuilder, value, name, withAutoBind, "ReferenceId", "LibelleFr")
                                                        .DataSource(source =>
                                                        {
                                                            source.Read(read =>
                                                            {
                                                                read.Action("GetReferencesType", ReferenceController.ControllerName, new { type = type });
                                                            })
                                                            .ServerFiltering(true);
                                                        })
                                                        .Events(e => e.DataBound(onDataBoundAction));

            if (!string.IsNullOrWhiteSpace(onChangeAction))
            {
                multiSelectBuilder1 = multiSelectBuilder1.Events(e => e.Change(onChangeAction));
            }
            return multiSelectBuilder1;
        }

        public static MultiSelectBuilder CreateDefautMultiSelectSousReference(this MultiSelectBuilder multiSelectBuilder, IEnumerable value, string name, List<SousReferenceLightDto> dataSource, string onDataBoundAction, string? onChangeAction = null, bool withAutoBind = true)
        {
            MultiSelectBuilder multiSelectBuilder1 = BaseMultiSelect(multiSelectBuilder, value, name, withAutoBind, "SousReferenceId", "LibelleFr",FilterType.Contains)
                                                        .BindTo(dataSource)
                                                        .Events(e => e.DataBound(onDataBoundAction));

            if (!string.IsNullOrWhiteSpace(onChangeAction))
            {
                multiSelectBuilder1 = multiSelectBuilder1.Events(e => e.Change(onChangeAction));
            }
            return multiSelectBuilder1;
        }

        private static MultiSelectBuilder BaseMultiSelect(MultiSelectBuilder multiSelectBuilder, IEnumerable value, string name, bool withAutoBind, string valueField, string textField, FilterType? filterType = null)
        {
            MultiSelectBuilder multiSelectBuilder1 = multiSelectBuilder
                                .Name(name)
                                .DataValueField(valueField)
                                .DataTextField(textField)
                                .AutoBind(withAutoBind)
                                .Value(value);

            if(filterType.HasValue)
            {
                return multiSelectBuilder1
                        .Filter(filterType.Value);
            }
            else
            {
                return multiSelectBuilder1;
            }
        }
    }
}
