using CostControlWebApplication.Application.Services.Dtos;
using CostControlWebApplication.Domain;

namespace CostControlWebApplication.Application.MappingResolvers
{
    class ProjectResolver
    {
        public static string StateDisplay(VIProjectInfo source, ProjectInfoListItmeDto destination)
        {
            Date(source, destination);
            Amount(source, destination);

            return string.Format("{0:n2}%", source.CompletionRatio);
        }
        public static void Amount(VIProjectInfo source, ProjectInfoListItmeDto destination)
        {
            if (source.ContractAmount > 0)
            {
                destination.ContractAmount = string.Format("{0:n2}", source.ContractAmount);
            }
            else
            {
                destination.ContractAmount = string.Empty;
            }
            if (source.CostAmount > 0)
            {
                destination.CostAmount = string.Format("{0:n2}", source.CostAmount);
            }
            else
            {
                destination.CostAmount = string.Empty;
            }
            if (source.AdditionalAmount > 0)
            {
                destination.AdditionalAmount = string.Format("{0:n2}", source.AdditionalAmount);
            }
            else
            {
                destination.AdditionalAmount = string.Empty;
            }
            if (source.BalanceAmount > 0)
            {
                destination.BalanceAmount = string.Format("{0:n2}", source.BalanceAmount);
            }
            else
            {
                destination.BalanceAmount = string.Empty;
            }
            if (source.CashInAmount > 0)
            {
                destination.CashInAmount = string.Format("{0:n2}", source.CashInAmount);
            }
            else
            {
                destination.CashInAmount = string.Empty;
            }
            if (source.CashOutAmount > 0)
            {
                destination.CashOutAmount = string.Format("{0:n2}", source.CashOutAmount);
            }
            else
            {
                destination.CashOutAmount = string.Empty;
            }
            if (source.PayableAmount > 0)
            {
                destination.PayableAmount = string.Format("{0:n2}", source.PayableAmount);
            }
            else
            {
                destination.PayableAmount = string.Empty;
            }
            if (source.ReceivableAmount > 0)
            {
                destination.ReceivableAmount = string.Format("{0:n2}", source.ReceivableAmount);
            }
            else
            {
                destination.ReceivableAmount = string.Empty;
            }
        }

        public static void Date(VIProjectInfo source, ProjectInfoListItmeDto destination)
        {
            if (source.BeginDate.HasValue)
            {
                destination.BeginDate = string.Format("{0:yyyy-MM-dd}", source.BeginDate);
            }
            else if (source.EstimatedBeginDate.HasValue)
            {
                destination.BeginDate = string.Format("{0:yyyy-MM-dd}", source.EstimatedBeginDate);
            }
            else
            {
                destination.BeginDate = "暫無";
            }

            if (source.EndDate.HasValue)
            {
                destination.EndDate = string.Format("{0:yyyy-MM-dd}", source.EndDate);
            }
            else if (source.EstimatedEndDate.HasValue)
            {
                destination.EndDate = string.Format("{0:yyyy-MM-dd}", source.EstimatedEndDate);
            }
            else
            {
                destination.EndDate = "暫無";
            }
        }
    }
}
