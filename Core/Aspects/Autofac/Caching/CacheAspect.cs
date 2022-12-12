using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60) //süre verilmezse default 60 dk cache'de
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            
             //Reflected Type = namespace + fullname (Business.Concrete + ICarService)
            

            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

            if (_cacheManager.IsAdd(key)) //Cache'de varsa
            {
                invocation.ReturnValue = _cacheManager.Get(key);//cachede varmış, datayı al
                return;
            }

            invocation.Proceed();//cache'de yokmuş, db ye git datayı topla
            _cacheManager.Add(key, invocation.ReturnValue, _duration); //cache'e ekle
        }
    }
}