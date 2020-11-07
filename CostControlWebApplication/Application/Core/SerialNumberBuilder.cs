using BingoX;
using BingoX.Domain;
using BingoX.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CostControlWebApplication.Domain;

namespace CostControlWebApplication
{
    public class SerialNumberProvider : ISerialNumberProvider
    {
        private readonly string format;
        private readonly IRepository<Supplier> repository;

        public SerialNumberProvider(string format, IRepository<Supplier> repository)
        {
            this.format = format;
            this.repository = repository;
        }


        public string Dequeue(string code)
        {
            var supplier = repository.Get(n => n.Code == code);
            if (supplier == null) throw new LogicException("编号代码不存在");

            return Dequeue(supplier);
        }
        public string Dequeue(Supplier supplier)
        {

            if (supplier == null) throw new LogicException("编号代码不存在");
            var bulider = new SerialNumberBuilder(supplier.Code, format, supplier.CurrentNumber);
            try
            {
                var number = bulider.Dequeue();
                return number;
            }
            finally
            {
                supplier.CurrentNumber = bulider.CurrentNumber;
                repository.Update(supplier);
                repository.UnitOfWork.Commit();
            }

        }
    }

    public interface ISerialNumberProvider
    {
        string Dequeue(string code);
        string Dequeue(Supplier supplier);
    }

    /// <summary>
    ///
    /// </summary>
    public class SerialNumberBuilder : ISerialNumberBuilder
    {
        public SerialNumberBuilder(string code, string format, int currentNumber)
        {
            Code = code;
            SerialNumberFormat = format;
            CurrentNumber = currentNumber;
        }
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
        protected internal static readonly Regex VariableRegex = new Regex(@"({(?<Key>[^=]*?)})");

        private static readonly object Lockobj = new object();



        public string Code { get; set; }

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
        /// <returns></returns>
        public string Dequeue()
        {
            lock (Lockobj)
            {
                if (SerialNumberFormat == null) throw new ArgumentException("SerialNumberFormat");
                var matches = GetEnumerateVariables(SerialNumberFormat);

                var groupCollections = matches as GroupCollection[] ?? matches.ToArray();

                String numberstr = SerialNumberFormat;
                foreach (var variable in groupCollections)
                {
                    var array = variable["Key"].Value.Split(':', 2, StringSplitOptions.None);
                    var key = array[0];
                    string param = array.Length>1? array[1]:string.Empty;
                   
                    switch (key.ToLower())
                    {
                        case "code":


                            numberstr = numberstr.Replace(variable[0].Value, Code);

                            break;
                        case "date":
                            if (string.IsNullOrEmpty(param))
                            {
                                param = "ddMMyyyy";
                            }

                            numberstr = numberstr.Replace(variable[0].Value, DateTime.Now.ToString(param));

                            break;

                        case "number":

                            if (string.IsNullOrEmpty(param))
                            {
                                param = "d8";
                            }

                            numberstr = numberstr.Replace(variable[0].Value, (CurrentNumber + 1).ToString(param));

                            break;
                    }
                }
                CurrentNumber++;
                return numberstr;
            }
        }
    }
}
