CREATE OR REPLACE  VIEW VIProjectMaster AS
SELECT
ProjectMaster.ID,
ProjectMaster.CreatedDate,
ProjectMaster.Created,
ProjectMaster.ModifiedDate,
ProjectMaster.Modified,
ProjectMaster.Code,
ProjectMaster.Name,
ProjectMaster.Address,
ProjectMaster.SetterId,
ProjectMaster.ManagerId,
ProjectMaster.FirstId,
ProjectMaster.SecondId, 
ProjectMaster.ThirdId, 
ProjectMaster.State, 
ProjectMaster.ContractAmount,
ProjectMaster.CompanyId,

ProjectMaster.Remark,
ProjectMaster.BeginDate,
ProjectMaster.EstimatedBeginDate,
ProjectMaster.EndDate,
ProjectMaster.EstimatedEndDate, 

ProjectMaster.ProjectMainId,
ProjectMaster.ContractorsId,

ProjectMain.Name AS ProjectMain,
ContractorsId.Name AS ContractorsName,
FirstId.Name AS FirstName,
SecondId.Name AS SecondName,
ThirdId.Name AS ThirdName,
SetterId.Name AS SetterName,
CompanyId.Name AS CompanyName,
Manager.Name AS ManagerName

FROM
ProjectMaster

LEFT JOIN basicdata AS ProjectMain ON ProjectMaster.ProjectMainId = ProjectMain.ID
LEFT JOIN supplier as FirstId ON ProjectMaster.FirstId = FirstId.ID 
LEFT JOIN supplier as SecondId ON ProjectMaster.SecondId = SecondId.ID
LEFT JOIN supplier as ThirdId ON ProjectMaster.ThirdId = ThirdId.ID
LEFT JOIN supplier as SetterId ON ProjectMaster.SetterId = SetterId.ID  
LEFT JOIN supplier as ContractorsId ON ProjectMaster.ContractorsId = ContractorsId.ID  
LEFT JOIN supplier as CompanyId ON ProjectMaster.CompanyId = CompanyId.ID  
LEFT JOIN accountuser as Manager ON ProjectMaster.ManagerId = Manager.ID  
