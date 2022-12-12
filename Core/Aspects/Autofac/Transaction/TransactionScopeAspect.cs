using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation) //invocation = method
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed(); //methodu çalıştır
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose(); //işlemi iptal et, değişiklikleri geri al
                    throw; //hata mesajını fırlat
                }
            }
        }
    }
}