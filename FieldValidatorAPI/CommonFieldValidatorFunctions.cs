using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FieldValidatorAPI
{
    public delegate bool RequiredValidDel(string fieldVal);   //用于验证字段是否为必填项
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);  //用于验证字符串的长度是否在指定范围内
    public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);  //用于验证字符串是否可以转换为有效的 DateTime，并通过输出参数提供有效的日期时间值。
    public delegate bool PatternMatchValidDel(string fieldVal, string pattern);  //用于验证字符串是否与指定的模式匹配。
    public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);  // 用于验证两个字段的值是否相等。
    public class CommonFieldValidatorFunctions  //包含通用字段验证功能的类
    {
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLengthValidDel _stringLengthValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternMatchValidDel _patternMatchValidDel = null;
        private static CompareFieldsValidDel _compareFieldsValidDel = null;
        //委托属性部分 目标方法
        public static RequiredValidDel RequiredFieldValidDel
        {
            get 
            {
                if (_requiredValidDel == null)
                    _requiredValidDel = new RequiredValidDel(RequiredFieldValid);

                return _requiredValidDel;
            }
        }

        public static StringLengthValidDel StringLengthFieldValidDel
        {
            get
            {
                if (_stringLengthValidDel == null)
                    _stringLengthValidDel = new StringLengthValidDel(StringFieldLengthValid);

                return _stringLengthValidDel;
            }
        }
        public static DateValidDel DateFieldValidDel
        {
            get
            {
                if (_dateValidDel == null)
                    _dateValidDel = new DateValidDel(DateFieldValid);

                return _dateValidDel;
            }
        }
        public static PatternMatchValidDel PatternMatchValidDel
        {
            get
            {
                if (_patternMatchValidDel == null)
                    _patternMatchValidDel = new PatternMatchValidDel(FieldPatternValid);

                return _patternMatchValidDel;
            }
        }

        public static CompareFieldsValidDel FieldsCompareValidDel
        {
            get
            {
                if (_compareFieldsValidDel == null)
                    _compareFieldsValidDel = new CompareFieldsValidDel(FieldComparisonValid);

                return _compareFieldsValidDel;
            }
        }

//从这开始是具体  逻辑验证部分
        private static bool RequiredFieldValid(string fieldVal)
        {
            if (!string.IsNullOrEmpty(fieldVal))
                return true;

            return false;

        }

        private static bool StringFieldLengthValid(string fieldVal, int min, int max)
        {
            if (fieldVal.Length >= min && fieldVal.Length <= max)
                return true;

            return false;

        }

        private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
        {
            if (DateTime.TryParse(dateTime, out validDateTime))
                return true;

            return false;
        
        }

        private static bool FieldPatternValid(string fieldVal, string regularExpressionPattern)
        {
            Regex regex = new Regex(regularExpressionPattern);

            if (regex.IsMatch(fieldVal))
                return true;

            return false;

        }

        private static bool FieldComparisonValid(string field1, string field2)
        {
            if (field1.Equals(field2))
                return true;

            return false;
        }

    }
}
