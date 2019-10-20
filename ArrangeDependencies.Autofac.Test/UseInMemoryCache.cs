﻿using ArrangeDependencies.Autofac.EntityFrameworkCore;
using ArrangeDependencies.Autofac.MemoryCache;
using ArrangeDependencies.Autofac.Test.Basis;
using ArrangeDependencies.Autofac.Test.Basis.Entites;
using ArrangeDependencies.Autofac.Test.Basis.Interfaces;
using ArrangeDependencies.Autofac.Test.Basis.Repository;
using NUnit.Framework;

namespace ArrangeDependencies.Autofac.Test
{
    public class UseMemoryCache
    {
        [Test]
        public void ShouldResolveClassWithInMemoryCacheDependency()
        {
            var arrange = ArrangeDependencies.Config<IUserRepository, UserRepository>(dependencies =>
            {
                dependencies.UseDbContext<TestDbContext>();
            });

            var userRepository = arrange.Resolve<IUserRepository>();

            Assert.IsInstanceOf<UserRepository>(userRepository);
        }

        [Test]
        public void ShouldReturnValueInCache()
        {
            var user = new User();
            user.SetName("Test");

            var arrange = ArrangeDependencies.Config<IUserRepository, UserRepository>(dependencies =>
            {
                dependencies.UseDbContext<TestDbContext>();
                dependencies.UseMemoryCache("Test", user);
            });

            var userRepository = arrange.Resolve<IUserRepository>();
            var result = userRepository.GetByName("Test");

            Assert.AreEqual(user.Name, result?.Name);

        }

    }
}
