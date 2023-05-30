using Nuke.Common;
using Nuke.Common.Execution;
using ricaun.Nuke;
using ricaun.Nuke.Components;

class Build : NukeBuild, IPublishPack, ITestLocal
{
    public static int Main() => Execute<Build>(x => x.From<IPublishPack>().Build);
}