CREATE OR REPLACE  VIEW `VIProjectTargetCost` AS
SELECT
projecttargetcost.ID,
projecttargetcost.State,
projecttargetcost.CreatedDate,
projecttargetcost.Created,
projecttargetcost.ModifiedDate,
projecttargetcost.Modified,
projecttargetcost.ProjectId,
projecttargetcost.ProjectTypeId,
projecttargetcost.LastHomeId,
projecttargetcost.ApprovalFileId,
projecttargetcost.BuildSize,
projecttargetcost.BuildUnitCost, 
projecttargetcost.ContractInAmount,
projecttargetcost.ContractOutAmount,
projectmaster.`Code`,
projectmaster.`Name`,
projectmaster.Address,
projectmaster.ManagerId,
projectmaster.ContractAmount,
projectmaster.ContractorsId,
projectmaster.SetterId,
projectmaster.FirstId,
projectmaster.SecondId,
projectmaster.BeginDate,
projectmaster.EndDate,
projectmaster.EstimatedBeginDate,
projectmaster.EstimatedEndDate,
ProjectType.Name AS ProjectType,
ContractorsId.Name AS ContractorsName,
FirstId.Name AS FirstName,
SecondId.Name AS SecondName,
SetterId.Name AS SetterName,
Manager.Name AS ManagerName
FROM
 projectmaster
left JOIN projecttargetcost ON projecttargetcost.ProjectId = projectmaster.ID
LEFT JOIN basicdata AS ProjectType ON ProjectMaster.ProjectTypeId = ProjectType.ID
LEFT JOIN supplier as FirstId ON ProjectMaster.FirstId = FirstId.ID 
LEFT JOIN supplier as SecondId ON ProjectMaster.SecondId = SecondId.ID
LEFT JOIN supplier as SetterId ON ProjectMaster.SetterId = SetterId.ID  
LEFT JOIN supplier as ContractorsId ON ProjectMaster.ContractorsId = ContractorsId.ID  
LEFT JOIN accountuser as Manager ON ProjectMaster.ManagerId = Manager.ID  
