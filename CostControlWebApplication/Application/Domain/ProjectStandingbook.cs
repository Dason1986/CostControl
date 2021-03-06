﻿using BingoX.Domain;
using CostControlWebApplication.Application;
using System;

namespace CostControlWebApplication.Domain
{
    public class ProjectStandingbook : Entity, ISnowflakeEntity<ProjectStandingbook>
    {

  
        public long ProjectId { get; set; }
     

       
        /// <summary>
        /// 目標毛利率M（%）
        /// </summary>
        public decimal TargetGrossProfitRate { get; set; }
        /// <summary>
        /// 核算毛利率N（%）
        /// </summary>
        public decimal AccountingGrossProfitRate { get; set; }
        /// <summary>
        /// 完工百分比E（%）
        /// </summary>
        public decimal CompletionRatio { get; set; }
 

     
       
        /// <summary>
        /// 後加金額L1
        /// </summary>
        public decimal AdditionalAmount { get; set; }
        /// <summary>
        /// 結算金額R
        /// </summary>
        public decimal BalanceAmount { get; set; }

        /// <summary>
        /// 保固應收Z
        /// </summary>
        public decimal SecuringAmount { get; set; }
        /// <summary>
        /// 保固金比例
        /// </summary>
        public decimal SecuringAmountRate { get; set; }
        /// <summary>
        /// 保固金比例
        /// </summary>
        public decimal SecuringPayableAmount { get; set; }
        /// <summary>
        /// 預計項目應收V
        /// </summary>
        public decimal EstimatedProjctReceivableAmount { get; set; }
        /// <summary>
        /// 預計項目應付W
        /// </summary>
        public decimal EstimatedProjctPayableAmount { get; set; }
      
        /// <summary>
        /// 備註AH
        /// </summary>
        public string Remark { get; set; }

       

 
    }
}
