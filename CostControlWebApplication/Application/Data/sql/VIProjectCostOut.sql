CREATE OR REPLACE  VIEW `VIProjectCostOut` AS
SELECT
 
projectmaster.`Code`,
projectmaster.`Name`,
projectcostout.ID,
projectcostout.CreatedDate,
projectcostout.Created,
projectcostout.ModifiedDate,
projectcostout.Modified,
projectcostout.ProjectId,
projectcostout.CostTypeId,
projectcostout.OrderNo,
projectcostout.CostoutDate,
projectcostout.DepartmentId,
projectcostout.PartyId,
projectcostout.Title,
projectcostout.CurrencyId,
projectcostout.ReceiveAmount,
projectcostout.ExpendAmount,
projectcostout.InvoiceNo,
projectcostout.SettlementMethodId,
projectcostout.CheckNumber,
projectcostout.InvoiceDate,
projectcostout.TransferDate,
projectcostout.ExpectedPaymentDate,
projectcostout.FollowUser,
projectcostout.Dispatcher,
projectcostout.ExchangeDate,
projectcostout.Confirmation,
projectcostout.Handover,
projectcostout.Remark,
Department.`Name` Department,
CostType.`Name` CostType,
Currency.`Name` Currency,
SettlementMethod.`Name` SettlementMethod,
Party.`Name` Party
FROM
projectcostout
INNER JOIN projectmaster ON projectcostout.ProjectId = projectmaster.ID

LEFT JOIN basicdata AS Department ON projectcostout.DepartmentId = Department.ID 
LEFT JOIN basicdata AS CostType ON projectcostout.CostTypeId = CostType.ID 
LEFT JOIN basicdata AS Currency ON projectcostout.Currencyid = Currency.ID 
LEFT JOIN basicdata AS SettlementMethod ON projectcostout.SettlementMethodId = SettlementMethod.ID 
LEFT JOIN supplier AS Party ON projectcostout.PartyId = Party.ID 
