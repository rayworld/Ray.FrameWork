using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Ray.Framework.Validate
{
    public sealed class ValidateHelper
    {
        private static Regex RegNumber = new Regex("^[0-9]+$");//数字字符串
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");//数字字符串
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");//浮点数
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$"); //等价于^[+-]?\d+[.]?\d+$
        private static Regex RegEmail = new Regex("^[\\w-]+@[\\w-]+\\.(com|net|org|edu|mil|tv|biz|info)$");//w 英文字母或数字的字符串，和 [a-zA-Z0-9] 语法一样 
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");//中文
        private static Regex RegQQ = new Regex("[1-9][0-9]{4,}");//匹配腾讯QQ号
        private static Regex RegTel = new Regex("d{3}-d{8}|d{4}-d{7}");//Tel匹配国内电话号码
        private static Regex RegURL = new Regex("[a-zA-z]+://[^s]*");//URL
        private static Regex RegZipCode = new Regex("[1-9]d{5}(?!d)");//CN 邮政编码
        private static Regex RegIDCard = new Regex("d{15}|d{18}");//匹配身份证：d{15}|d{18} 
        private static Regex RegHTML = new Regex("<(S*?)[^>]*>.*?|<.*? />");//匹配HTML标记的正则表达式：<(S*?)[^>]*>.*?|<.*? /> 
        private static Regex RegPassWord = new Regex("^[a-zA-Z]w{5,17}$"); //验证用户密码:“^[a-zA-Z]w{5,17}$”正确格式为：以字母开头,长度在6-18之间
        private static Regex Reg26A_Z = new Regex("^[A-Za-z]+$");//只能输入由26个英文字母组成的字符串：“^[A-Za-z]+$” 
        private static Regex Reg26Large_A_Z = new Regex("^[A-Z]+$");//只能输入由26个大写英文字母组成的字符串：“^[A-Z]+$” 
        private static Regex Reg26Small_A_Z = new Regex("^[a-z]+$");//只能输入由26个小写英文字母组成的字符串：“^[a-z]+$” 
        private static Regex Reg0_9_A_Z = new Regex("^[A-Za-z0-9]+$");//只能输入由数字和26个英文字母组成的字符串：“^[A-Za-z0-9]+$” 
        private static Regex Reg0_9_A_Z_ = new Regex("^w+$");//只能输入由数字、26个英文字母或者下划线组成的字符串：“^w+$” 

        /// <summary>
        /// 无参数构造方法
        /// </summary>
        public ValidateHelper()
        { }

        /// <summary>
        /// 是否数字字符串
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 是否数字字符串 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsNumberSign(string inputData)
        {
            Match m = RegNumberSign.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 是否是浮点数
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsDecimal(string inputData)
        {
            Match m = RegDecimal.Match(inputData);
            return m.Success;
        }

        /// <summary>
        /// 是否是浮点数 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>

        /// <returns></returns>

        public static bool IsDecimalSign(string inputData)
        {
            Match m = RegDecimalSign.Match(inputData);
            return m.Success;
        }

        #region 中文检测

        /// <summary>
        /// 检测是否有中文字符
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }

        #endregion

        #region 邮件地址

        /// <summary>
        /// 是否是浮点数 可带正负号
        /// </summary>
        /// <param name="inputData">输入字符串</param>
        /// <returns></returns>
        public static bool IsEmail(string inputData)
        {
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }

        #endregion

        /// <summary>
        /// 验证是否合法的URL
        /// </summary>
        /// <param name="InputStr"></param>
        /// <returns></returns>
        public static bool IsURL(string InputStr)
        {
            Match m = RegURL.Match(InputStr);
            return m.Success;
        }

        /// <summary>
        /// 验证电话号码是否合法
        /// </summary>
        /// <param name="InputStr"></param>
        /// <returns></returns>
        public static bool IsTelNumber(string InputStr)
        {
            Match m = RegTel.Match(InputStr);
            return m.Success;
        }

        /// <summary>
        /// 验证邮政编码
        /// </summary>
        /// <param name="InputStr"></param>
        /// <returns></returns>
        public static bool IsZipCode(string InputStr)
        {
            Match m = RegZipCode.Match(InputStr);
            return m.Success;
        }

        /// <summary>
        /// 验证QQ号
        /// </summary>
        /// <param name="InputStr"></param>
        /// <returns></returns>
        public static bool IsQQ(string InputStr)
        {
            Match m = RegQQ.Match(InputStr);
            return m.Success;
        }

        /// <summary>
        /// 验证身份证
        /// </summary>
        /// <param name="InputStr"></param>
        /// <returns></returns>
        public static bool IsIDCard(string InputStr)
        {
            Match m = RegIDCard.Match(InputStr);
            return m.Success;
        }

        /// <summary>
        /// 验证用户密码
        /// </summary>
        /// <param name="InputStr"></param>
        /// <returns></returns>
        public static bool IsPassWord(string InputStr)
        {
            Match m = RegPassWord.Match(InputStr);
            return m.Success;
        }

        /// <summary>
        /// 验证只能输入由26个英文字母组成的字符串
        /// </summary>
        /// <param name="InputStr"></param>
        /// <returns></returns>
        public static bool Is26A_Z(string InputStr)
        {
            Match m = Reg26A_Z.Match(InputStr);
            return m.Success;
        }

        /// <summary>
        /// 只能输入由26个大写英文字母组成的字符串
        /// </summary>
        /// <param name="InputStr"></param>
        /// <returns></returns>
        public static bool Is26Large_A_Z(string InputStr)
        {
            Match m = Reg26Large_A_Z.Match(InputStr);
            return m.Success;
        }

        /// <summary>
        /// 只能输入由26个小写英文字母组成的字符串
        /// </summary>
        /// <param name="InputStr"></param>
        /// <returns></returns>
        public static bool Is26Small_A_Z(string InputStr)
        {
            Match m = Reg26Small_A_Z.Match(InputStr);
            return m.Success;
        }

        /// <summary>
        /// 只能输入由数字和26个英文字母组成的字符串
        /// </summary>
        /// <param name="InputStr"></param>
        /// <returns></returns>
        public static bool Is0_9_AZ_Str(string InputStr)
        {
            Match m = Reg0_9_A_Z.Match(InputStr);
            return m.Success;
        }

        /// <summary>
        /// 只能输入由数字和26个英文字母组成的字符串和下划线
        /// </summary>
        /// <param name="InputStr"></param>
        /// <returns></returns>
        public static bool Is0_9_A_Z_Str(string InputStr)
        {
            Match m = Reg0_9_A_Z_.Match(InputStr);
            return m.Success;
        }

        #region 日期
        /// <summary>
        /// 是否是日期格式
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static bool IsDateTime(string inputData)
        {
            bool flag = false;

            string regex = @"^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))"; //日期部分
            regex += @"(\s(((0?[0-9])|([1][0-9])|([2][0-4]))\:([0-5]?[0-9])((\s)|(\:([0-5]?[0-9])))))?$"; //时间部分

            RegexOptions options = ((RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline) | RegexOptions.IgnoreCase);
            Regex reg = new Regex(regex, options);
            if (reg.IsMatch(inputData))
            {
                flag = true;
            }
            return flag;
        }
        public static bool IsDate(string inputData)
        {
            bool flag = false;

            string regex = @"^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))"; //日期部分


            RegexOptions options = ((RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline) | RegexOptions.IgnoreCase);
            Regex reg = new Regex(regex, options);
            if (reg.IsMatch(inputData))
            {
                flag = true;
            }
            return flag;
        }

        #endregion

        #region 判断是否是IP地址格式
        /// 
        /// 判断是否是IP地址格式
        /// 
        /// 判断的字符串
        /// 
        public static bool CheckIP(string ip)
        {
            try
            {
                return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 判斷日期輸入格式是否為 yyyy/mm/dd
        /// 
        /// 檢核日期輸入格式,輸入格式為:yyyy/mm/dd
        /// 
        /// 输入的时间型字符串
        /// pass: true, no:false
        public static bool CheckDate(string strInput)
        {
            DateTime outDate;
            if (Regex.IsMatch(strInput, @"\d{4}\/\d{2}\/\d{2}"))
            {

                if (Convert.ToInt32(strInput.Substring(0, 4)) < 1753) return false;

                try
                {
                    return DateTime.TryParse(strInput, out outDate);
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
        #endregion

        #region 判断指定位置是否是空白字元
        /// 
        /// 判断指定位置是否是空白字元
        /// 
        /// 要验证的值
        /// 位置
        /// 
        public static bool CheckSpaceNull(string strVal, int intPosition)
        {
            try
            {
                if (intPosition > strVal.Trim().Length) { return false; }

                return char.IsWhiteSpace(strVal, intPosition);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 判断指定位置是否是标点符号
        /// 
        /// 判断指定位置是否是标点符号
        /// 
        /// 测试的值
        /// 位置
        /// 
        public static bool Checkpunctuation(string strVal, int intPosition)
        {
            try
            {
                if (intPosition > strVal.Trim().Length) { return false; }

                return char.IsPunctuation(strVal[intPosition]);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 判断輸入的字符串的格式
        /// 
        /// 判斷輸入的字符類型
        /// 
        /// 輸入的字串
        /// 要驗證的類型
        /// 1: 由26個英文字母組成的字串 
        /// 2: 正整數 
        /// 3: 非負整數（正整數 + 0)
        /// 4: 非正整數（負整數 + 0）
        /// 5: 負整數 
        /// 6: 整數
        /// 7: 非負浮點數（正浮點數 + 0）
        /// 8: 正浮點數
        /// 9: 非正浮點數（負浮點數 + 0)
        /// 10: 負浮點數 
        /// 11: 浮點數
        /// 12: 由26個英文字母的大寫組成的字串
        /// 13: 由26個英文字母的小寫組成的字串
        /// 14: 由數位和26個英文字母組成的字串
        /// 15: 由數位、26個英文字母或者下劃線組成的字串
        /// 16: Email
        /// 17: URL
        /// 18: 只能輸入入中文
        /// 19: 正整數並且大於0
        /// 20: 由數位、26個英文字母或者短橫線組成的字串
        /// 21: 完整的Url,包括http://192.168.1.2/test.aspx類型
        /// 
        /// true是驗証通過,false是驗証錯誤
        public static bool CheckValidateUserInput(string strVal, int intKind)
        {
            try
            {
                string RegularExpressions = null;

                switch (intKind)
                {
                    case 1:
                        //由26個英文字母組成的字串
                        RegularExpressions = "^[A-Za-z]+$";
                        break;
                    case 2:
                        //正整數 
                        RegularExpressions = "^[0-9]*[1-9][0-9]*$";
                        break;
                    case 3:
                        //非負整數（正整數 + 0)
                        RegularExpressions = "^\\d+$";
                        break;
                    case 4:
                        //非正整數（負整數 + 0）
                        RegularExpressions = "^((-\\d+)|(0+))$";
                        break;
                    case 5:
                        //負整數 
                        RegularExpressions = "^-[0-9]*[1-9][0-9]*$";
                        break;
                    case 6:
                        //整數
                        RegularExpressions = "^-?\\d+$";
                        break;
                    case 7:
                        //非負浮點數（正浮點數 + 0）
                        RegularExpressions = "^\\d+(\\.\\d+)?$";
                        break;
                    case 8:
                        //正浮點數
                        RegularExpressions = "^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
                        break;
                    case 9:
                        //非正浮點數（負浮點數 + 0）
                        RegularExpressions = "^((-\\d+(\\.\\d+)?)|(0+(\\.0+)?))$";
                        break;
                    case 10:
                        //負浮點數
                        RegularExpressions = "^(-(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*)))$";
                        break;
                    case 11:
                        //浮點數
                        RegularExpressions = "^(-?\\d+)(\\.\\d+)?$";
                        break;
                    case 12:
                        //由26個英文字母的大寫組成的字串
                        RegularExpressions = "^[A-Z]+$";
                        break;
                    case 13:
                        //由26個英文字母的小寫組成的字串
                        RegularExpressions = "^[a-z]+$";
                        break;
                    case 14:
                        //由數位和26個英文字母組成的字串
                        RegularExpressions = "^[A-Za-z0-9]+$";
                        break;
                    case 15:
                        //由數位、26個英文字母或者下劃線組成的字串 
                        RegularExpressions = "^[0-9a-zA-Z_]+$";
                        break;
                    case 16:
                        //email地址
                        RegularExpressions = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                        break;
                    case 17:
                        //url
                        RegularExpressions = "^[a-zA-z]+://(\\w+(-\\w+)*)(\\.(\\w+(-\\w+)*))*(\\?\\S*)?$";
                        break;
                    case 18:
                        //只能輸入中文
                        RegularExpressions = "^[\u4e00-\u9fa5]{0,}$";
                        break;
                    case 19:
                        //正整數且大於0
                        RegularExpressions = @"^\d{1}[0-9]\d+$";
                        break;
                    case 20:
                        //由數位、26個英文字母或者短橫線組成的字串 
                        RegularExpressions = "^[0-9a-zA-Z-]+$";
                        break;
                    case 21:
                        //完整的Url,包括http://192.168.1.2/test.aspx類型
                        RegularExpressions = "^[a-zA-z]+://[A-Za-z0-9]+\\.[A-Za-z0-9]+[\\/=\\?%\\-&_~`@[\\]\\':+!]*([^<>\"\"])*$";
                        break;
                    default:
                        break;
                }

                Match m = Regex.Match(strVal, RegularExpressions);
                if (m.Success)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 判断是否包含特殊字符(SQL注入式攻击(where 语句))
        /// 
        /// 判断是否包含特殊字符(SQL注入式攻击(where 语句))
        /// 
        /// 要验证的字符串，一般为条件判断语句
        /// 
        public static bool CheckHacker(string strVal)
        {
            try
            {
                strVal = strVal.Trim().ToLower();
                string strHack = "update|insert|delete|execute|exec|truncate|--|drop|create|select";
                string[] strArr = strHack.Split('|');
                for (int i = 0; i < strArr.Length; i++)
                {
                    string strTmp = strArr[i].Trim();
                    if (strVal.IndexOf(strTmp) > -1)
                    {
                        //记录进攻击日志
                        return true;
                    }
                }
                return false;
            }
            catch (Exception Err)
            {
                throw new Exception(Err.Message);
            }
        }
        #endregion

        #region 判断 DataSource
        /// 
        /// 判断 DataSource
        /// 
        /// 數據源
        /// 
        //public static bool CheckDataSource(IListSource lDataSource)
        //{
        //    try
        //    {
        //        if (null == lDataSource) return false;
        //        return 0 < lDataSource.GetList().Count ? true : false;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        #endregion

        #region 判斷字符串長度與指定長度的比較
        /// 
        /// 判斷字符串是否為指定長度
        /// 
        /// 判斷的字符串
        /// 判斷長度
        /// 是否檢核中文
        /// 
        public static string CheckValueLength(string strValue, int iLength)
        {
            byte[] byt = System.Text.Encoding.Default.GetBytes(strValue);
            int bytLength = byt.Length;
            string result = string.Empty;
            int AA = bytLength.CompareTo(iLength);
            switch (AA)
            {
                case 0:
                    result = "0";//等於
                    break;
                case 1:
                    result = "1";//大於
                    break;
                case -1:
                    result = "-1";//小於
                    break;
            }
            return result;
        }
        #endregion

        #region 判斷字符串是否為空
        /// 
        /// 判斷字符串是否為空
        /// 
        /// 字符串
        /// 
        public static bool CheckIsNullOrEmpty(object oValue)
        {
            return null == oValue ? true : (string.IsNullOrEmpty(oValue.ToString()) ? true : false);
        }
        #endregion

        #region 判断两个时间的大小关系
        /// 
        /// 判断两个时间的大小关系
        /// 
        /// 開始時間
        /// 結束時間
        /// 相等:0, 大於:1, 小於:-1, 異常:""
        public static string CheckDateDeff(string strBeginDate, string strEndDate)
        {
            DateTime BeginDate = new DateTime();
            DateTime EndDate = new DateTime();
            string returnValue = string.Empty;

            try
            {
                BeginDate = Convert.ToDateTime(strBeginDate);
                EndDate = Convert.ToDateTime(strEndDate);
                if (BeginDate.Ticks < EndDate.Ticks)
                    returnValue = "-1";
                if (BeginDate.Ticks == EndDate.Ticks)
                    returnValue = "0";
                if (BeginDate.Ticks > EndDate.Ticks)
                    returnValue = "1";
            }
            catch
            {
                returnValue = "";
            }
            return returnValue;
        }
        #endregion

        #region 判斷圖片格式
        public static bool CheckImage(string Image)
        {
            bool bl = true;
            if (!string.IsNullOrEmpty(Image))
            {
                Image = Image.Substring(Image.LastIndexOf('.') + 1).ToUpper();
                string ImageFormat = "JPG | GIF | BMP | PNG";
                if (!(ImageFormat.IndexOf(Image) > -1))
                {
                    bl = false;
                }
            }
            return bl;
        }
        #endregion

        #region 計算字符串的長度(包括中英文)
        /// 
        /// 計算字符串的長度(包括中英文)
        /// 
        /// 要計算的字符串
        /// 字符串的長度
        public static int StrLength(string Str_Text)
        {
            if (string.IsNullOrEmpty(Str_Text))
            {
                return 0;
            }
            else
            {
                int len = 0;

                for (int i = 0; i < Str_Text.Length; i++)
                {
                    byte[] byte_len = Encoding.Default.GetBytes(Str_Text.Substring(i, 1));
                    if (byte_len.Length > 1)
                        len += 2; //如果長度大於1,是中文,占兩個字節;+2,中文字符串的長度為原子符串長度的兩倍
                    else
                        len += 1; //如果長度等於1,是英文,占一個字節;+1
                }

                return len;
            }
        }

        #endregion

        #region 檢查字符傳的長度
        /// 
        /// 檢查字符傳的長度
        /// 
        /// 
        /// 
        /// 
        public bool ChkStrLen(string Str_Check, int length)
        {
            return (Str_Check.Trim().Length <= length) ? true : false;
        }


        /// 
        /// 欄位是否操作指定長度，中文算兩個字符
        /// 
        /// 
        /// 
        /// 
        public static bool ChkEngLen(string Str_Check, int length)
        {
            int len = 0;
            len = StrLength(Str_Check);
            return (len <= length) ? true : false;
        }
        #endregion
    }
}
