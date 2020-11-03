CREATE OR REPLACE  VIEW VIProjectStandingbook AS
SELECT
ProjectStandingbook.ID,
ProjectStandingbook.CreatedDate,
ProjectStandingbook.Created,
ProjectStandingbook.ModifiedDate,
ProjectStandingbook.Modified,
projectmaster.Code AS Code,
projectmaster.Name AS Name ,
projectmaster.Address,
ProjectStandingbook.projectId,
projectmaster.SetterId,
projectmaster.ManagerId,
projectmaster.ContractorsId,
ProjectStandingbook.ProjectMainId,
ProjectStandingbook.ContractTypeId,
ProjectStandingbook.SettlementMethodId,
projectmaster.FirstId,
projectmaster.SecondId,
ProjectStandingbook.TargetGrossProfitRate,
ProjectStandingbook.AccountingGrossProfitRate,
ProjectStandingbook.CompletionRatio,
ProjectStandingbook.ContractAmount,
ProjectStandingbook.CostAmount,
ProjectStandingbook.AdditionalAmount,
ProjectStandingbook.BalanceAmount,
ProjectStandingbook.SecuringAmount,
ProjectStandingbook.SecuringAmountRate,
ProjectStandingbook.SecuringPayableAmount,
ProjectStandingbook.EstimatedProjctReceivableAmount,
ProjectStandingbook.EstimatedProjctPayableAmount,
ProjectStandingbook.UndertakingId,
ProjectStandingbook.ProjectTypeId,
projectmaster.Remark,
projectmaster.BeginDate,
projectmaster.EstimatedBeginDate,
projectmaster.EndDate,
projectmaster.EstimatedEndDate,
ProjectStandingbook.State,
projectMain.Name AS ProjectMain,
undertaking.Name AS undertaking,
ProjectType.Name AS ProjectType,
ContractType.Name AS ContractType,
SettlementMethod.Name AS SettlementMethod,
Contractors.Name AS ContractorsName,
FirstId.Name AS FirstName,
SecondId.Name AS SecondName,
SetterId.Name AS SetterName,
Manager.Name AS ManagerName, 
	0 AS PayableAmount,
	0 AS ReceivableAmount,
	0 AS CashOutAmount,
	0 AS CashInProjectAmount,
	0 AS CashInSecuringAmount,
	0 AS CashInAmount 
FROM
projectmaster
left JOIN  ProjectStandingbook ON  projectStandingbook.ProjectId = projectmaster.ID  
LEFT JOIN basicdata AS projectMain ON ProjectStandingbook.ProjectMainId = projectMain.ID
LEFT JOIN basicdata AS undertaking ON ProjectStandingbook.UndertakingId = undertaking.ID
LEFT JOIN basicdata AS ProjectType ON ProjectStandingbook.ProjectTypeId = ProjectType.ID
LEFT JOIN basicdata AS ContractType ON ProjectStandingbook.ContractTypeId = ContractType.ID
LEFT JOIN basicdata AS SettlementMethod ON ProjectStandingbook.SettlementMethodId = SettlementMethod.ID
LEFT JOIN supplier AS Contractors ON projectmaster.ContractorsId = Contractors.ID 
LEFT JOIN supplier as FirstId ON projectmaster.FirstId = FirstId.ID 
LEFT JOIN supplier as SecondId ON projectmaster.SecondId = SecondId.ID
LEFT JOIN supplier as SetterId ON projectmaster.SetterId = SetterId.ID  
LEFT JOIN accountuser as Manager ON projectmaster.ManagerId = Manager.ID  


 
;