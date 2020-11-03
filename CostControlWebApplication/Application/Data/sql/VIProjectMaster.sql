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
ProjectMaster.State,

ProjectMaster.ContractAmount,

ProjectMaster.Remark,
ProjectMaster.BeginDate,
ProjectMaster.EstimatedBeginDate,
ProjectMaster.EndDate,
ProjectMaster.EstimatedEndDate, 

ProjectMaster.ProjectTypeId,
ProjectMaster.ContractorsId,

ProjectType.Name AS ProjectType,
ContractorsId.Name AS ContractorsName,
FirstId.Name AS FirstName,
SecondId.Name AS SecondName,
SetterId.Name AS SetterName,
Manager.Name AS ManagerName

FROM
ProjectMaster

LEFT JOIN basicdata AS ProjectType ON ProjectMaster.ProjectTypeId = ProjectType.ID
LEFT JOIN supplier as FirstId ON ProjectMaster.FirstId = FirstId.ID 
LEFT JOIN supplier as SecondId ON ProjectMaster.SecondId = SecondId.ID
LEFT JOIN supplier as SetterId ON ProjectMaster.SetterId = SetterId.ID  
LEFT JOIN supplier as ContractorsId ON ProjectMaster.ContractorsId = ContractorsId.ID  
LEFT JOIN accountuser as Manager ON ProjectMaster.ManagerId = Manager.ID  
