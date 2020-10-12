using BingoX;
using BingoX.Domain;
using BingoX.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CostControlWebApplication
{
    public class SerialNumberProvider : ISerialNumberProvider
    {
        public SerialNumberProvider(IServiceProvider serviceProvider)
        {
            repository = serviceProvider.CreateScope().ServiceProvider.GetService<IRepository<SerialNumber>>();
            dic = repository.QueryAll().ToDictionary(n => n.Code, x =>
            {
                SerialNumberBuilder builder = new SerialNumberBuilder(x);

                return builder;
            });

        }
        readonly Dictionary<string, SerialNumberBuilder> dic;
        private readonly IRepository<SerialNumber> repository;
        object lockobj = new object();

        public string Dequeue(string code)
        {
            lock (lockobj)
            {
                if (dic.ContainsKey(code))
                {
                    var builder = dic[code];
                    var number = builder.Dequeue();
                    repository.Update(builder.SerialNumber);
                    repository.UnitOfWork.Commit();
                    return number;
                }
                throw new LogicException("编号代码不存在");
            }

        }
    }
    public class SerialNumber : IStringEntity<SerialNumber>, IDomainEntry
    {
        [SqlSugar.SugarColumn(IsPrimaryKey = true, IsIdentity = false)]
        public string Code { get; set; }

        public string Name { get; set; }
        public int CurrentNumber { get; set; }
        public string SerialNumberFormat { get; set; }
        public int Buildrecord { get; private set; }
        string IEntity<SerialNumber, string>.ID { get => Code; set => Code = value; }
    }
    public interface ISerialNumberProvider
    {
        string Dequeue(string code);
    }
    public class SerialNumberCode
    {
        public const string ProjectCode = "ProjectNo";
        public const string TargetCost = "TargetCost";
    }
    /// <summary>
    ///
    /// </summary>
    public class SerialNumberBuilder : ISerialNumberBuilder
    {
        /// <summary>
        /// /
        /// </summary>
        public int CurrentNumber { get; private set; }

        /// <summary>
        /// /
        /// </summary>
        public string SerialNumberFormat { get; private set; }

        /// <summary>
        ///
        /// </summary>
        public int Buildrecord { get; private set; }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="format"></param>
        /// <param name="currentNumber"></param>
        /// <param name="buildrecord"></param>
        public void SetOption(string format, int currentNumber, int buildrecord)
        {
            if (format == null) throw new ArgumentNullException("format");
            SerialNumberFormat = format;
            CurrentNumber = currentNumber;
            Buildrecord = buildrecord;
        }

        /// <summary>
        ///
        /// </summary>
        protected internal static readonly Regex VariableRegex = new Regex(@"({(?<Key>[^=]*?):(?<Param>[^=]*?)})|({(?<Key>[^=]*?)})");

        private static readonly object Lockobj = new object();

        private readonly Queue<string> _numberQueue = new Queue<string>();

        public SerialNumberBuilder(SerialNumber x)
        {
            SerialNumber = x;
            SetOption(x.SerialNumberFormat, x.CurrentNumber, x.Buildrecord);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>

        protected internal static IEnumerable<GroupCollection> GetEnumerateVariables(string s)
        {
            var matchCollection = VariableRegex.Matches(s);

            for (int i = 0; i < matchCollection.Count; i++)
            {
                yield return matchCollection[i].Groups;
            }
        }

        /// <summary>
        ///
        /// </summary>
        public void CreateSerialNumber()
        {
            lock (Lockobj)
            {
                if (SerialNumberFormat == null) throw new ArgumentException("SerialNumberFormat");
                var matches = GetEnumerateVariables(SerialNumberFormat);

                var groupCollections = matches as GroupCollection[] ?? matches.ToArray();
                for (int i = 1; i <= Buildrecord; i++)
                {
                    String numberstr = SerialNumberFormat;
                    foreach (var variable in groupCollections)
                    {
                        var param = variable["Param"].Value;

                        switch (variable["Key"].Value)
                        {
                            case "Date":
                                if (string.IsNullOrEmpty(param))
                                {
                                    param = "ddMMyyyy";
                                }

                                numberstr = numberstr.Replace(variable[0].Value, DateTime.Now.ToString(param));

                                break;

                            case "Number":

                                if (string.IsNullOrEmpty(param))
                                {
                                    param = "d8";
                                }

                                numberstr = numberstr.Replace(variable[0].Value, (CurrentNumber + i).ToString(param));

                                break;
                        }
                    }
                    _numberQueue.Enqueue(numberstr);
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        public int Count
        {
            get { return _numberQueue.Count; }
        }

        public SerialNumber SerialNumber { get; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public string Dequeue()
        {
            lock (Lockobj)
            {
                if (Count == 0)
                {
                    this.CreateSerialNumber();
                }

                var sn = _numberQueue.Dequeue();
                CurrentNumber++;
                this.SerialNumber.CurrentNumber = CurrentNumber;
                return sn;
            }
        }
    }
}
