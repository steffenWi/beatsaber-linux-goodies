using System;
using Xunit;
using Beataroni.Services;

namespace Beataroni.Tests
{
    public class BeatModsV1Tests
    {
        [Fact]
        public void TestFetchBSVersions()
        {
            var versions = BeatModsV1.FetchBSVersions();
            Assert.NotNull(versions);
            Assert.Equal(11, versions.Count);
        }

        [Fact]
        public void TestFetchMods()
        {
            var filters = BeatModsV1.DefaultFilters;
            filters.Add("gameVersion","1.12.2");

            var mods = BeatModsV1.FetchMods(filters);
            Assert.NotNull(mods);
            Assert.Equal(56, mods.Count);
        }

        // [Fact]
        // public void TestInstallMod()
        // {
        //     throw new NotImplementedException();
        // }
    }
}
