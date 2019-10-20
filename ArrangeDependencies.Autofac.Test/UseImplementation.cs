﻿using ArrangeDependencies.Autofac.Extensions;
using ArrangeDependencies.Autofac.Test.Basis.Interfaces;
using ArrangeDependencies.Autofac.Test.Basis.Services;
using NUnit.Framework;

namespace ArrangeDependencies.Autofac.Test
{
    [TestFixture]
    public class UseImplementation
    {
        [Test]
        public void ShouldResolveUseImplementation()
        {
            var arrange = ArrangeDependencies.Config<IUserService, UserService>(dependencies =>
            {
                dependencies.UseImplementation<IUserService, UserService>();
            });

            var userService = arrange.Resolve<IUserService>();

            Assert.IsInstanceOf<UserService>(userService);
        }
    }
}
