CREATE OR REPLACE  VIEW `viprojectinfo` AS
SELECT
projectinfo.ID,
projectinfo.CreatedDate,
projectinfo.Created,
projectinfo.ModifiedDate,
projectinfo.Modified,
projectinfo.`Code`,
projectinfo.`Name`,
projectinfo.Address,
projectinfo.SupremeManagerId,
projectinfo.SetterId,
projectinfo.ManagerId,
projectinfo.ContractorsId,
projectinfo.ProjectMainId,
projectinfo.ContractTypeId,
projectinfo.SettlementMethodId,
projectinfo.FirstId,
projectinfo.SecondId,
projectinfo.TargetGrossProfitRate,
projectinfo.AccountingGrossProfitRate,
projectinfo.CompletionRatio,
projectinfo.ContractAmount,
projectinfo.MustApprovelFile,
projectinfo.CostAmount,
projectinfo.AdditionalAmount,
projectinfo.BalanceAmount,
projectinfo.SecuringAmount,
projectinfo.SecuringAmountRate,
projectinfo.SecuringPayableAmount,
projectinfo.EstimatedProjctReceivableAmount,
projectinfo.EstimatedProjctPayableAmount,
projectinfo.UndertakingId,
projectinfo.ProjectTypeId,
projectinfo.Remark,
projectinfo.BeginDate,
projectinfo.EstimatedBeginDate,
projectinfo.EndDate,
projectinfo.EstimatedEndDate,
projectinfo.State,
projectMain.`Name` AS ProjectMain,
undertaking.`Name` AS undertaking,
ProjectType.`Name` AS ProjectType,
ContractType.`Name` AS ContractType,
SettlementMethod.`Name` AS SettlementMethod,
Contractors.`Name` AS ContractorsName,
FirstId.`Name` AS FirstName,
SecondId.`Name` AS SecondName,
SetterId.`Name` AS SetterName,
Manager.`Name` AS ManagerName,
supremeManager.`Name` AS SupremeManagerName,
0 as PayableAmount,
0 as ReceivableAmount,
0 as CashOutAmount,
0 as CashInAmount
FROM
projectinfo
LEFT JOIN basicdata AS projectMain ON projectinfo.ProjectMainId = projectMain.ID
LEFT JOIN basicdata AS undertaking ON projectinfo.UndertakingId = undertaking.ID
LEFT JOIN basicdata AS ProjectType ON projectinfo.ProjectTypeId = ProjectType.ID
LEFT JOIN basicdata AS ContractType ON projectinfo.ContractTypeId = ContractType.ID
LEFT JOIN basicdata AS SettlementMethod ON projectinfo.SettlementMethodId = SettlementMethod.ID
LEFT JOIN supplier AS Contractors ON projectinfo.ContractorsId = Contractors.ID 
LEFT JOIN supplier as FirstId ON projectinfo.FirstId = FirstId.ID 
LEFT JOIN supplier as SecondId ON projectinfo.SecondId = SecondId.ID
LEFT JOIN supplier as SetterId ON projectinfo.SetterId = SetterId.ID  
LEFT JOIN accountuser as Manager ON projectinfo.ManagerId = Manager.ID  
LEFT JOIN accountuser as supremeManager ON projectinfo.supremeManagerId = supremeManager.ID  

 
;