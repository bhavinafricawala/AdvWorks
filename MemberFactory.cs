using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Business.Applicant;
using TestProject.DataAccess;
using TestProject.DataAccess.Interface;
using TestProject.DataAccess.Log;


namespace TestProject.Factory
{
    public class MemberFactory
    {
        readonly Container container = new Container();

        public MemberFactory()
        {
            try
            {
                container.Register<IConnection, Connection>(Lifestyle.Singleton);

                container.Register<ILogger, Logger>(Lifestyle.Singleton);

                container.Register<IRepository<Member>>(() => new MemberData(container.GetInstance<Connection>(), container.GetInstance<Logger>()));
            }
            catch (Exception ex)
            {

            }
        }

        public IRepository<Member> GetMemberData()
        {
            return container.GetInstance<MemberData>();
        }
    }
}
