CREATE OR REPLACE  VIEW VIProjectMaster AS
SELECT
projectmaster.ID AS ID,
projectmaster.CreatedDate AS CreatedDate,
projectmaster.Created AS Created,
projectmaster.ModifiedDate AS ModifiedDate,
projectmaster.Modified AS Modified,
projectmaster.Code AS Code,
projectmaster.Name AS Name,
projectmaster.CreateFileId AS CreateFileId,
projectmaster.Address AS Address,
projectmaster.SetterId AS SetterId,
projectmaster.ManagerId AS ManagerId,
projectmaster.FirstId AS FirstId,
projectmaster.SecondId AS SecondId,
projectmaster.ThirdId AS ThirdId,
projectmaster.State AS State,
projectmaster.ContractAmount AS ContractAmount,
projectmaster.CompanyId AS CompanyId,
projectmaster.Remark AS Remark,
projectmaster.BeginDate AS BeginDate,
projectmaster.EstimatedBeginDate AS EstimatedBeginDate,
projectmaster.EndDate AS EndDate,
projectmaster.EstimatedEndDate AS EstimatedEndDate,
projectmaster.ProjectMainId AS ProjectMainId,
projectmaster.ContractorsId AS ContractorsId,
projectmain.Name AS ProjectMain,
contractorsid.Name AS ContractorsName,
projectmaster.ContractTypeId AS ContractTypeId,
projectmaster.SettlementMethodId AS SettlementMethodId,
projectmaster.ProjectTypeId AS ProjectTypeId,
projectmaster.UndertakingId AS UndertakingId,
firstid.Name AS FirstName,
secondid.Name AS SecondName,
thirdid.Name AS ThirdName,
setterid.Name AS SetterName,
companyid.Name AS CompanyName,
manager.Name AS ManagerName,
contracttypeid.Name AS ContractType,
projecttypeid.Name AS ProjectType,
settlementmethodid.Name AS SettlementMethod,
undertakingid.Name AS Undertaking,
projectaboutfile.FileName AS createFileName
FROM
projectmaster
LEFT JOIN basicdata AS projectmain ON projectmaster.ProjectMainId = projectmain.ID
LEFT JOIN supplier AS firstid ON projectmaster.FirstId = firstid.ID
LEFT JOIN supplier AS secondid ON projectmaster.SecondId = secondid.ID
LEFT JOIN supplier AS thirdid ON projectmaster.ThirdId = thirdid.ID
LEFT JOIN supplier AS setterid ON projectmaster.SetterId = setterid.ID
LEFT JOIN supplier AS contractorsid ON projectmaster.ContractorsId = contractorsid.ID
LEFT JOIN supplier AS companyid ON projectmaster.CompanyId = companyid.ID
LEFT JOIN accountuser AS manager ON projectmaster.ManagerId = manager.ID
LEFT JOIN basicdata AS contracttypeid ON projectmaster.ContractTypeId = contracttypeid.ID
LEFT JOIN basicdata AS projecttypeid ON projectmaster.ProjectTypeId = projecttypeid.ID
LEFT JOIN basicdata AS settlementmethodid ON projectmaster.SettlementMethodId = settlementmethodid.ID
LEFT JOIN basicdata AS undertakingid ON projectmaster.UndertakingId = undertakingid.ID  
LEFT JOIN projectaboutfile  ON projectmaster.CreateFileId = projectaboutfile.ID  

