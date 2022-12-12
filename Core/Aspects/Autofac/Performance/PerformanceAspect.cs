using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch; //Timer. Method ne kadar sürüyor ?

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        //Methodun başında kronometre başlar
        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        //Methodun bitince kronometre biter.
        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                //Sistem sahibine/yöneticiye uyarıyı nasıl yapacağız ?
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Reset();
        }
    }
}