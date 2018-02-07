﻿using System;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Core.PropertyEditors;
using Umbraco.Core.Services;

namespace Umbraco.Web.PropertyEditors
{
    /// <summary>
    /// CUstom value editor so we can serialize with the correct date format (excluding time)
    /// and includes the date validator
    /// </summary>
    internal class DateValueEditor : ValueEditor
    {
        public DateValueEditor(ValueEditorAttribute attribute)
            : base(attribute)
        {
            Validators.Add(new DateTimeValidator());
        }

        public override object ConvertDbToEditor(Property property, PropertyType propertyType, IDataTypeService dataTypeService)
        {
            var date = property.GetValue().TryConvertTo<DateTime?>();
            if (date.Success == false || date.Result == null)
            {
                return String.Empty;
            }
            //Dates will be formatted as yyyy-MM-dd
            return date.Result.Value.ToString("yyyy-MM-dd");
        }

    }
}