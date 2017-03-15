using Autofac;
using BowlingScore.BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingScore.BusinessLogic.Configuration
{
    public class BusinessLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GameManager>().As<IGameManager>().InstancePerRequest();
            //builder.RegisterType<Frame>().As<IFrame>().InstancePerRequest();
        }
    }
}
