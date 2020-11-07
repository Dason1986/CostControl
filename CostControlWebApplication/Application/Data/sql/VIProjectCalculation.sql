CREATE OR REPLACE  VIEW VIProjectCalculation AS
SELECT
	projectcalculation.ID AS ID,
	projectcalculation.CreatedDate AS CreatedDate,
	projectcalculation.Created AS Created,
	projectcalculation.ModifiedDate AS ModifiedDate,
	projectcalculation.Modified AS Modified,
	projectcalculation.ProjectId AS ProjectId,
	projectcalculation.HumanCost AS HumanCost,
	projectcalculation.Salary AS Salary,
	projectmaster.Code AS Code,
	projectmaster.Name AS Name,
	projectmaster.BeginDate AS BeginDate,
	projectmaster.EndDate AS EndDate,
	projectmaster.FirstId AS FirstId,
	projectmaster.SetterId AS SetterId,
	projectmaster.SecondId AS SecondId,
	projectmaster.ThirdId AS ThirdId,
	projectmaster.EstimatedEndDate AS EstimatedEndDate,
	projectmaster.EstimatedBeginDate AS EstimatedBeginDate,
	firstid.Name AS FirstName,
	secondid.Name AS SecondName,
	thirdid.Name AS ThirdName,
	
(SELECT sum(projectprocurement.ThisProcurementAmount) FROM	projectprocurement WHERE projectprocurement.State = 2  AND  projectprocurement.ProcurementType IN  (3, 4 ) ) AS MangerCost,
(SELECT sum(projectprocurement.ThisProcurementAmount) FROM 	projectprocurement WHERE projectprocurement.State = 2  AND  projectprocurement.ProcurementType = 1 ) AS MaterialCost 
FROM
	projectcalculation 
	JOIN projectmaster ON   projectcalculation.ProjectId = projectmaster.ID   
	LEFT JOIN supplier firstid ON   projectmaster.FirstId = firstid.ID   	
	LEFT JOIN supplier secondid ON   projectmaster.SecondId = secondid.ID  	
	LEFT JOIN supplier thirdid ON   projectmaster.ThirdId = thirdid.ID   	
	LEFT JOIN supplier setterid ON   projectmaster.SetterId = setterid.ID   
	