﻿using EZNEW.Develop.CQuery.CriteriaConvert;
using EZNEW.Framework.Fault;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZNEW.Data.CriteriaConvert
{
    /// <summary>
    /// sql server criteria convert parse
    /// </summary>
    internal static class SqlServerCriteriaConvertParse
    {
        /// <summary>
        /// parse
        /// </summary>
        /// <param name="option">parse option</param>
        /// <returns></returns>
        internal static string Parse(CriteriaConvertParseOption option)
        {
            if (string.IsNullOrWhiteSpace(option?.CriteriaConvert?.Name))
            {
                throw new EZNEWException("criteria convert config name is null or empty");
            }
            string format = null;
            switch (option.CriteriaConvert.Name)
            {
                case CriteriaConvertNames.StringLength:
                    format = string.Format("LEN({0}.[{1}])", option.ObjectName, option.FieldName);
                    break;
            }
            if (string.IsNullOrWhiteSpace(format))
            {
                throw new EZNEWException($"cann't resolve criteria convert:{option.CriteriaConvert.Name} for SQL Server");
            }
            return format;
        }
    }
}
