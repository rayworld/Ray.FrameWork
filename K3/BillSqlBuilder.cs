using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Ray.Framework.DBUtility;

namespace Ray.Framework.K3
{
    public sealed class BillSqlBuilder
    {
        /// <summary>
        /// 生成List所用Sql
        /// </summary>
        /// <param name="iTransType"></param>
        /// <param name="columnList"></param>
        /// <param name="FilterExpress"></param>
        /// <returns></returns>
        public static string buildListSql(int iTransType, string sOptionSQL)
        {
            StringBuilder sb = new StringBuilder();
            SqlDataReader reader = (SqlDataReader)null;
            string sTransType = SqlHelper.ExecuteScalar("SELECT fName  FROM ICTransactionType WHERE fid =" + iTransType.ToString(), null).ToString();
            if (iTransType == 29) sTransType = "其他出库";
            if (iTransType == 41) sTransType = "仓库调拨";
            int TemplateId = int.Parse(SqlHelper.ExecuteScalar("SELECT FTemplateID FROM ICListTemplate WHERE FName = '" + sTransType + "'", null).ToString());
            sb.Append("SELECT ");

            StringBuilder sbColumnList = new StringBuilder();
            sbColumnList.Append(" SELECT TOP 1000  ");
            sbColumnList.Append("       case ");
            sbColumnList.Append("             when Faction <> '' then Faction + ' AS [' + FColName + '],' ");
            sbColumnList.Append("             else case ");
            sbColumnList.Append("                   when FColCaption ='$' and FColName ='FInterID' then FTableAlias + '.' + FName + ' AS [ 单据内码],' ");
            sbColumnList.Append("                   when FColCaption ='$' and FColName ='FEntryID' then FTableAlias + '.' + FName + ' AS [ 单据分录号 ],' ");
            sbColumnList.Append("                   when FColCaption ='$' and ( FColName<>'FEntryID' and FColName <>'FInterID') then FTableAlias + '.' + FName + ' AS [' + FName + '],' ");
            sbColumnList.Append("                   else FTableAlias + '.' + FName + ' AS [' + FColName + '],' ");
            sbColumnList.Append("             end ");
            sbColumnList.Append("       end as SQL ");
            sbColumnList.Append(" FROM ICChatBillTitle  ");
            sbColumnList.Append(" WHERE FTypeID IN (" + TemplateId + ") and FName<>''");

            reader = SqlHelper.ExecuteReader(sbColumnList.ToString(), null);
            while (reader.Read())
            {
                sb.Append(reader[0]);
                sb.AppendLine();
            }
            reader.Close();
            sb = sb.Remove(sb.Length - 3, 3);
            sb.AppendLine();
            sb.Append("FROM ");

            StringBuilder sbRelationList = new StringBuilder();
            sbRelationList.Append(" SELECT TOP 1000  ");
            sbRelationList.Append(" case when FInterID < 0 then FTableName + ' ' + FTableNameAlias + ' ' ");
            sbRelationList.Append(" else ''  ");
            sbRelationList.Append(" end +  ");
            sbRelationList.Append("    case when FLogic='=' then 'Inner Join'  ");
            sbRelationList.Append("           when FLogic='*=' then 'left outer Join'  ");
            sbRelationList.Append("           when FLogic= '=*' then 'right outer Join'  ");
            sbRelationList.Append("           when FLogic='*=*' then 'full outer Join'  ");
            sbRelationList.Append("    else ' '  ");
            sbRelationList.Append("    end +  ");
            sbRelationList.Append("    ' ' + FTableName11 + ' ' + FTableNameAlias11 + ' on ' + FTableNameAlias + '.' + FFieldName + '='  ");
            sbRelationList.Append("   + FTableNameAlias11 + '.' + FFieldName11 as SQL ");
            sbRelationList.Append(" FROM ICTableRelation  ");
            sbRelationList.Append(" WHERE Ftypeid in (" + TemplateId + ") and FTableNameAlias11<>'##BASE##'  ");

            reader = SqlHelper.ExecuteReader(sbRelationList.ToString(), null);
            while (reader.Read())
            {
                sb.Append(reader[0]);
                sb.AppendLine();
            }
            reader.Close();

            sb.Append("WHERE (1=1) ");
            sb.AppendLine();
            //SELECT ' ' + FTableNameAlias11+'.FStandard=1' as sql FROM ICTableRelation WHERE Ftypeid in (76 ) and FTableNameAlias11<> '##BASE##' and FTableName11='t_MeasureUnit' and FFieldName11='FUnitGroupID'
            reader = SqlHelper.ExecuteReader("SELECT ' ' + FTableNameAlias11+'.FStandard=1' as sql FROM ICTableRelation WHERE Ftypeid in (76 ) and FTableNameAlias11<> '##BASE##' and FTableName11='t_MeasureUnit' and FFieldName11='FUnitGroupID'", null);
            while (reader.Read())
            {
                sb.Append(reader[0]);
            }
            reader.Close();
            sb.AppendLine();
            //SELECT  'and ' + 'v1.FTranType= ' + cast(( SELECT FID FROM ICTransActionType WHERE FName like '销售出库' ) as char (20)) as sql
            reader = SqlHelper.ExecuteReader("SELECT  'and ' + 'v1.FTranType= ' + cast(( SELECT FID FROM ICTransActionType WHERE FName like '%" + sTransType + "%' ) as char (20)) as sql", null);
            while (reader.Read())
            {
                sb.Append(reader[0]);
            }
            reader.Close();
            sb.AppendLine();
            //Console.Write(sb.ToString());
            sb.Append(sOptionSQL);
            return sb.ToString();
        }
    }
}
