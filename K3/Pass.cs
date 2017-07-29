using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Ray.Framework.K3
{
    /// <summary>
    /// 用于生成Kingdee K3系统用户密码
    /// </summary>
    public sealed class Pass
    {
        //数字
        string[] p0 = new string[] { " P ", "#  ", ",  " };
        string[] p1 = new string[] { " Q ", "#$ ", ",0 " };
        string[] p2 = new string[] { " R ", "#( ", ",@ " };
        string[] p3 = new string[] { " S ", "#, ", ",P " };
        string[] p4 = new string[] { " T ", "#0 ", "-  " };
        string[] p5 = new string[] { " U ", "#4 ", "-0 " };
        string[] p6 = new string[] { " V ", "#8 ", "-@ " };
        string[] p7 = new string[] { " W ", "#< ", "-P " };
        string[] p8 = new string[] { " X ", "#@ ", ".  " };
        string[] p9 = new string[] { " Y ", "#D ", ".0 " };
        //小写字母
        string[] pa = new string[] { "!A ", "&$ ", "80" };
        string[] pb = new string[] { "!B ", "&( ", "8@" };
        string[] pc = new string[] { "!C ", "&, ", "8P" };
        string[] pd = new string[] { "!D ", "&0 ", "9 " };
        string[] pe = new string[] { "!E ", "&4 ", "90" };
        string[] pf = new string[] { "!F ", "&8 ", "9@" };
        string[] pg = new string[] { "!G ", "&< ", "9P" };
        string[] ph = new string[] { "!H ", "&@ ", ": " };
        string[] pi = new string[] { "!I ", "&D ", ":0" };
        string[] pj = new string[] { "!J ", "&H ", ":@" };
        string[] pk = new string[] { "!K ", "&L ", ":P" };
        string[] pl = new string[] { "!L ", "&P ", "; " };
        string[] pm = new string[] { "!M ", "&T ", ";0" };
        string[] pn = new string[] { "!N ", "&X ", ";@" };
        string[] po = new string[] { "!O ", "&/ ", ";P" };
        string[] pp = new string[] { "!P ", "'  ", "< " };
        string[] pq = new string[] { "!Q ", "'$ ", "<0" };
        string[] pr = new string[] { "!R ", "'( ", "<@" };
        string[] ps = new string[] { "!S ", "', ", "<P" };
        string[] pt = new string[] { "!T ", "'0 ", "= " };
        string[] pu = new string[] { "!U ", "'4 ", "=0" };
        string[] pv = new string[] { "!V ", "'8 ", "=@" };
        string[] pw = new string[] { "!W ", "'< ", "=P" };
        string[] px = new string[] { "!X ", "'@ ", "> " };
        string[] py = new string[] { "!Y ", "'D ", ">0" };
        string[] pz = new string[] { "!Z ", "'H ", ">@" };
        //大写字母
        string[] pA = new string[] { "!! ", "$$ ", "00" };
        string[] pB = new string[] { "!\" ", "$( ", "0@" };
        string[] pC = new string[] { "!# ", "$, ", "0P" };
        string[] pD = new string[] { "!$ ", "$0 ", "1 " };
        string[] pE = new string[] { "!% ", "$4 ", "10" };
        string[] pF = new string[] { "!& ", "$8 ", "1@" };
        string[] pG = new string[] { "!' ", "$< ", "1P" };
        string[] pH = new string[] { "!( ", "$@ ", "2 " };
        string[] pI = new string[] { "!) ", "$D ", "20" };
        string[] pJ = new string[] { "!* ", "$H ", "2@" };
        string[] pK = new string[] { "!+ ", "$L ", "2P" };
        string[] pL = new string[] { "!, ", "$P ", "3 " };
        string[] pM = new string[] { "!- ", "$T ", "30" };
        string[] pN = new string[] { "!. ", "$X ", "3@" };
        string[] pO = new string[] { "!/ ", "$/ ", "3P" };
        string[] pP = new string[] { "!0 ", "%  ", "4 " };
        string[] pQ = new string[] { "!1 ", "%$ ", "40" };
        string[] pR = new string[] { "!2 ", "%( ", "4@" };
        string[] pS = new string[] { "!3 ", "%, ", "4P" };
        string[] pT = new string[] { "!4 ", "%0 ", "5 " };
        string[] pU = new string[] { "!5 ", "%4 ", "50" };
        string[] pV = new string[] { "!6 ", "%8 ", "5@" };
        string[] pW = new string[] { "!7 ", "%< ", "5P" };
        string[] pX = new string[] { "!8 ", "%@ ", "6 " };
        string[] pY = new string[] { "!9 ", "%D ", "60" };
        string[] pZ = new string[] { "!: ", "%H ", "6@" };
        //符号
        //!
        string[] p11 = new string[] { " A ", "\"$ ", "(0" };
        //@
        string[] p12 = new string[] { " ! ", "$  ", "0 " };
        //#
        string[] p13 = new string[] { " C ", "\", ", "(P" };
        //$
        string[] p14 = new string[] { " D ", "\"0 ", ") " };
        //%
        string[] p15 = new string[] { " E ", "\"4 ", ")0" };
        //^
        string[] p16 = new string[] { "!> ", "%X ", "7@" };
        //&
        string[] p17 = new string[] { " F ", "\"8 ", ")@" };
        //*
        string[] p18 = new string[] { " J ", "\"H ", "*@" };
        //(
        string[] p19 = new string[] { " H ", "\"@ ", "* " };
        //)
        string[] p20 = new string[] { " I ", "\"D ", "*0" };

        //_
        string[] p21 = new string[] { "!? ", "%/ ", "7P" };
        //+
        string[] p22 = new string[] { " K ", "\"L ", "*P" };
        //=
        string[] p23 = new string[] { " ] ", "#T ", "/0" };
        //-
        string[] p24 = new string[] { " M ", "\"T ", "+0" };
        //[
        string[] p25 = new string[] { "!; ", "%L ", "6P" };
        //]
        string[] p26 = new string[] { "!= ", "%T ", "70" };
        //{
        string[] p27 = new string[] { "![ ", "'L ", ">P" };
        //}
        string[] p28 = new string[] { "!] ", "'T ", "?0" };
        //;
        string[] p29 = new string[] { " [ ", "#L ", ".P" };
        //:
        string[] p30 = new string[] { " Z ", "#H ", ".@" };

        //"
        string[] p31 = new string[] { " B ", "\"( ", "(@" };
        //'
        string[] p32 = new string[] { " G ", "\"< ", ")P" };
        //,
        string[] p33 = new string[] { " L ", "\"P ", "+ " };
        //.
        string[] p34 = new string[] { " N ", "\"X ", "+@" };
        //?
        string[] p35 = new string[] { " _ ", "#/ ", "/P" };
        /// 
        string[] p36 = new string[] { "!< ", "%P ", "7 " };
        //|
        string[] p37 = new string[] { "!/ ", "'P ", "? " };
        //\
        string[] p38 = new string[] { " 0 ", "\"/", "+P" };
        //\
        string[] p39 = new string[] { "!@ ", "&  ", "8 " };
        //~
        string[] p40 = new string[] { "!^ ", "'X ", "?@" };

        //<
        string[] p41 = new string[] { " / ", "#P ", "/ " };
        //>
        string[] p42 = new string[] { " ^ ", "#X ", "/@" };

        /// <summary>
        /// 查询密码表，对应生成Kingdee密码
        /// 版本号是用来区别V11以下的K3，前面有一组字符前缀
        /// </summary>
        /// <param name="pass">密码明文</param>
        /// <param name="KingdeeVersion">版本号</param>
        /// <returns></returns>
        public string EncryptPassword(string pass, int KingdeeVersion)
        {
            string retVal = "";

            for (int i = 0; i < pass.Length; i++)
            {
                //该位是数字
                if (Regex.IsMatch(pass[i].ToString(), @"^[0-9]*$"))
                {
                    if (pass[i].ToString() == "0")
                    {
                        retVal += i % 6 == 3 ? p0[0].Substring(1) : p0[i % 3];
                    }
                    else if (pass[i].ToString() == "1")
                    {
                        retVal += i % 6 == 3 ? p1[0].Substring(1) : p1[i % 3];
                    }
                    else if (pass[i].ToString() == "2")
                    {
                        retVal += i % 6 == 3 ? p2[0].Substring(1) : p2[i % 3];
                    }
                    else if (pass[i].ToString() == "3")
                    {
                        retVal += i % 6 == 3 ? p3[0].Substring(1) : p3[i % 3];
                    }
                    else if (pass[i].ToString() == "4")
                    {
                        retVal += i % 6 == 3 ? p4[0].Substring(1) : p4[i % 3];
                    }
                    else if (pass[i].ToString() == "5")
                    {
                        retVal += i % 6 == 3 ? p5[0].Substring(1) : p5[i % 3];
                    }
                    else if (pass[i].ToString() == "6")
                    {
                        retVal += i % 6 == 3 ? p6[0].Substring(1) : p6[i % 3];
                    }
                    else if (pass[i].ToString() == "7")
                    {
                        retVal += i % 6 == 3 ? p7[0].Substring(1) : p7[i % 3];
                    }
                    else if (pass[i].ToString() == "8")
                    {
                        retVal += i % 6 == 3 ? p8[0].Substring(1) : p8[i % 3];
                    }
                    else if (pass[i].ToString() == "9")
                    {
                        retVal += i % 6 == 3 ? p9[0].Substring(1) : p9[i % 3];
                    }
                    else
                    {
                        retVal += "";
                    }
                }
                else if (Regex.IsMatch(pass[i].ToString(), @"^[a-z]+$"))//是小写字母
                {
                    if (pass[i].ToString() == "a")
                    {
                        retVal += pa[i % 3];
                    }
                    else if (pass[i].ToString() == "b")
                    {
                        retVal += pb[i % 3];
                    }
                    else if (pass[i].ToString() == "c")
                    {
                        retVal += pc[i % 3];
                    }
                    else if (pass[i].ToString() == "d")
                    {
                        retVal += pd[i % 3];
                    }
                    else if (pass[i].ToString() == "e")
                    {
                        retVal += pe[i % 3];
                    }
                    else if (pass[i].ToString() == "f")
                    {
                        retVal += pf[i % 3];
                    }
                    else if (pass[i].ToString() == "g")
                    {
                        retVal += pg[i % 3];
                    }
                    else if (pass[i].ToString() == "h")
                    {
                        retVal += ph[i % 3];
                    }
                    else if (pass[i].ToString() == "i")
                    {
                        retVal += pi[i % 3];
                    }
                    else if (pass[i].ToString() == "j")
                    {
                        retVal += pj[i % 3];
                    }
                    else if (pass[i].ToString() == "k")
                    {
                        retVal += pk[i % 3];
                    }
                    else if (pass[i].ToString() == "l")
                    {
                        retVal += pl[i % 3];
                    }
                    else if (pass[i].ToString() == "m")
                    {
                        retVal += pm[i % 3];
                    }
                    else if (pass[i].ToString() == "n")
                    {
                        retVal += pn[i % 3];
                    }
                    else if (pass[i].ToString() == "o")
                    {
                        retVal += po[i % 3];
                    }
                    else if (pass[i].ToString() == "p")
                    {
                        retVal += pp[i % 3];
                    }
                    else if (pass[i].ToString() == "q")
                    {
                        retVal += pq[i % 3];
                    }
                    else if (pass[i].ToString() == "r")
                    {
                        retVal += pr[i % 3];
                    }
                    else if (pass[i].ToString() == "s")
                    {
                        retVal += ps[i % 3];
                    }
                    else if (pass[i].ToString() == "t")
                    {
                        retVal += pt[i % 3];
                    }
                    else if (pass[i].ToString() == "u")
                    {
                        retVal += pu[i % 3];
                    }
                    else if (pass[i].ToString() == "v")
                    {
                        retVal += pv[i % 3];
                    }
                    else if (pass[i].ToString() == "w")
                    {
                        retVal += pw[i % 3];
                    }
                    else if (pass[i].ToString() == "x")
                    {
                        retVal += px[i % 3];
                    }
                    else if (pass[i].ToString() == "y")
                    {
                        retVal += py[i % 3];
                    }
                    else if (pass[i].ToString() == "z")
                    {
                        retVal += pz[i % 3];
                    }
                }
                else if (Regex.IsMatch(pass[i].ToString(), @"^[A-Z]+$"))//是大写字母
                {
                    if (pass[i].ToString() == "A")
                    {
                        retVal += pA[i % 3];
                    }
                    else if (pass[i].ToString() == "B")
                    {
                        retVal += pB[i % 3];
                    }
                    else if (pass[i].ToString() == "C")
                    {
                        retVal += pC[i % 3];
                    }
                    else if (pass[i].ToString() == "D")
                    {
                        retVal += pD[i % 3];
                    }
                    else if (pass[i].ToString() == "E")
                    {
                        retVal += pE[i % 3];
                    }
                    else if (pass[i].ToString() == "F")
                    {
                        retVal += pF[i % 3];
                    }
                    else if (pass[i].ToString() == "G")
                    {
                        retVal += pG[i % 3];
                    }
                    else if (pass[i].ToString() == "H")
                    {
                        retVal += pH[i % 3];
                    }
                    else if (pass[i].ToString() == "I")
                    {
                        retVal += pI[i % 3];
                    }
                    else if (pass[i].ToString() == "J")
                    {
                        retVal += pJ[i % 3];
                    }
                    else if (pass[i].ToString() == "K")
                    {
                        retVal += pK[i % 3];
                    }
                    else if (pass[i].ToString() == "L")
                    {
                        retVal += pL[i % 3];
                    }
                    else if (pass[i].ToString() == "M")
                    {
                        retVal += pM[i % 3];
                    }
                    else if (pass[i].ToString() == "N")
                    {
                        retVal += pN[i % 3];
                    }
                    else if (pass[i].ToString() == "O")
                    {
                        retVal += pO[i % 3];
                    }
                    else if (pass[i].ToString() == "P")
                    {
                        retVal += pP[i % 3];
                    }
                    else if (pass[i].ToString() == "Q")
                    {
                        retVal += pQ[i % 3];
                    }
                    else if (pass[i].ToString() == "R")
                    {
                        retVal += pR[i % 3];
                    }
                    else if (pass[i].ToString() == "S")
                    {
                        retVal += pS[i % 3];
                    }
                    else if (pass[i].ToString() == "T")
                    {
                        retVal += pT[i % 3];
                    }
                    else if (pass[i].ToString() == "U")
                    {
                        retVal += pU[i % 3];
                    }
                    else if (pass[i].ToString() == "V")
                    {
                        retVal += pV[i % 3];
                    }
                    else if (pass[i].ToString() == "W")
                    {
                        retVal += pW[i % 3];
                    }
                    else if (pass[i].ToString() == "X")
                    {
                        retVal += pX[i % 3];
                    }
                    else if (pass[i].ToString() == "Y")
                    {
                        retVal += pY[i % 3];
                    }
                    else if (pass[i].ToString() == "Z")
                    {
                        retVal += pZ[i % 3];
                    }
                }
                else//是符号
                {
                    if (pass[i].ToString() == "!")
                    {
                        retVal += p11[i % 3];
                    }
                    else if (pass[i].ToString() == "@")
                    {
                        retVal += p12[i % 3];
                    }
                    else if (pass[i].ToString() == "#")
                    {
                        retVal += p13[i % 3];
                    }
                    else if (pass[i].ToString() == "$")
                    {
                        retVal += p14[i % 3];
                    }
                    else if (pass[i].ToString() == "%")
                    {
                        retVal += p15[i % 3];
                    }
                    else if (pass[i].ToString() == "^")
                    {
                        retVal += p16[i % 3];
                    }
                    else if (pass[i].ToString() == "&")
                    {
                        retVal += p17[i % 3];
                    }
                    else if (pass[i].ToString() == "*")
                    {
                        retVal += p18[i % 3];
                    }
                    else if (pass[i].ToString() == "(")
                    {
                        retVal += p19[i % 3];
                    }
                    else if (pass[i].ToString() == ")")
                    {
                        retVal += p20[i % 3];
                    }
                    else if (pass[i].ToString() == "_")
                    {
                        retVal += p21[i % 3];
                    }
                    else if (pass[i].ToString() == "+")
                    {
                        retVal += p22[i % 3];
                    }
                    else if (pass[i].ToString() == "=")
                    {
                        retVal += p23[i % 3];
                    }
                    else if (pass[i].ToString() == "-")
                    {
                        retVal += p24[i % 3];
                    }
                    else if (pass[i].ToString() == "[")
                    {
                        retVal += p25[i % 3];
                    }
                    else if (pass[i].ToString() == "]")
                    {
                        retVal += p26[i % 3];
                    }
                    else if (pass[i].ToString() == "{")
                    {
                        retVal += p27[i % 3];
                    }
                    else if (pass[i].ToString() == "}")
                    {
                        retVal += p28[i % 3];
                    }
                    else if (pass[i].ToString() == ";")
                    {
                        retVal += p29[i % 3];
                    }
                    else if (pass[i].ToString() == ":")
                    {
                        retVal += p30[i % 3];
                    }
                    else if (pass[i].ToString() == "\"")
                    {
                        retVal += p31[i % 3];
                    }
                    else if (pass[i].ToString() == "'")
                    {
                        retVal += p32[i % 3];
                    }
                    else if (pass[i].ToString() == ",")
                    {
                        retVal += p33[i % 3];
                    }
                    else if (pass[i].ToString() == ".")
                    {
                        retVal += p34[i % 3];
                    }
                    else if (pass[i].ToString() == "?")
                    {
                        retVal += p35[i % 3];
                    }
                    else if (pass[i].ToString() == "/")
                    {
                        retVal += p36[i % 3];
                    }
                    else if (pass[i].ToString() == "|")
                    {
                        retVal += p37[i % 3];
                    }
                    else if (pass[i].ToString() == "\\")
                    {
                        retVal += p38[i % 3];
                    }
                    else if (pass[i].ToString() == "`")
                    {
                        retVal += p39[i % 3];
                    }
                    else if (pass[i].ToString() == "~")
                    {
                        retVal += p40[i % 3];
                    }
                    else if (pass[i].ToString() == "<")
                    {
                        retVal += p41[i % 3];
                    }
                    else if (pass[i].ToString() == ">")
                    {
                        retVal += p42[i % 3];
                    }
                    else
                    {
                        retVal += "";
                    }
                }

                //retVal += pass[i].ToString();
            }

            retVal = KingdeeVersion >= 11 ? ")  F \", ,P T #8 *P!D &D 80!N &@ <0 C \'< : !M &4 )0" + retVal : retVal;

            return retVal;
        }
    }
}
